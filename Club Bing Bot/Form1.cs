/*Lines which will need to be updated with 
 * new colors as CB changes how games look
 * 235
 * 379
 * 387
 * 610
 * 660
 */
using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.Net;
using System.Text.RegularExpressions;
using System.IO;
using System.Security.Permissions;
using System.Diagnostics;

namespace Xenix
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr GetWindow(IntPtr hWnd, uint uCmd);
        //enum GetWindow_Cmd : uint
        //{ GW_CHILD = 5 }

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("User32.dll", EntryPoint = "PrintWindow", SetLastError = true)]
        private static extern bool PrintWindow(IntPtr hwnd, IntPtr hDC, uint nFlags);


        bool loggedin = false;
        string DocText = "_";
        string Anagram = null;
        int Account = 0;
        string[] AccountUsername = new string[200];
        string[] AccountPassword = new string[200];
        string[] AccountGame = new string[200];
        bool[] UseAccount = new bool[200];
        internal bool StopPlaying = false;
        internal bool PausePlaying = false;
        string email = null;
        bool gamerunn = false;
        long startTicks = DateTime.Now.Ticks;
        int totaltries = 0;

        internal int newgameMin, newgameMax, startgameMin, startgameMax, nextletterMin, nextletterMax, nextwordMin, nextwordMax, EnterType = 0;
        internal string DecapUser, DecapPass = null;
        internal bool UseDecap = false;

        public delegate void Solve2();
        public delegate void Solve();
        public delegate void Login();

        public Form1()
        {
            InitializeComponent();
        }

        #region Singleton
        static Form1 _Instance = null;
        static readonly object PadLock = new object();

        public static Form1 Instance
        {
            get
            {
                lock (PadLock)
                {
                    if (_Instance == null)
                    {
                        _Instance = new Form1();
                    }
                    return _Instance;
                }
            }
        }
        #endregion

        /// <summary>
        /// Grab the anagram letters
        /// </summary>
        public void GetLetters()
        {
            if (Form1.Instance.StopPlaying)
            {
                Form1.Instance.toolStripStatusLabel5.Text = "Status: Stopped";
                return;
            }
            while (Form1.Instance.PausePlaying)
            {
                Form1.Instance.toolStripStatusLabel5.Text = "Status: Paused";
                Thread.Sleep(1000);
            }

            string letters = null;
            string str = null;
            int startIndex = 0;
            int length = 0;

            Input.TypeLetter(GetHandle(), (int)Keys.Return);
            Form1.Instance.webBrowser1.Document.Window.ScrollTo(0, 0);

            while (!Form1.Instance.webBrowser1.Document.GetElementsByTagName("IFRAME")[0].GetAttribute("src").Contains("q="))
            {
                if (Form1.Instance.StopPlaying)
                {
                    Form1.Instance.toolStripStatusLabel5.Text = "Status: Stopped";
                    return;
                }
                while (Form1.Instance.PausePlaying)
                {
                    Form1.Instance.toolStripStatusLabel5.Text = "Status: Paused";
                    Thread.Sleep(1000);
                }
                Application.DoEvents();
            }
            str = Form1.Instance.webBrowser1.Document.GetElementsByTagName("IFRAME")[0].GetAttribute("src").ToString();
            startIndex = str.IndexOf("q=") + 2;
            length = str.IndexOf("&", startIndex) - startIndex;
            letters = str.Substring(startIndex, length);

            str = null;
            startIndex = 0;
            length = 0;
            if (letters.Length == 7)
            {
                Form1.Instance.toolStripStatusLabel5.Text = "Status: Letters: " + letters.ToUpper();
                Form1.Instance.Anagram = letters;
                letters = null;
                new Thread(new ThreadStart(Form1.Instance.SolvePuzzle)).Start();
            }
            else
            {
                Form1.Instance.toolStripStatusLabel5.Text = "Status: Error getting game letters, restarting game";
                Form1.Instance.loggedin = true;
                Form1.Instance.webBrowser1.Navigate("http://www.clubbing.com/Pages/Home/HomePage.aspx");
            }
        }

        private void loginLive2()
        {
            if (Form1.Instance.StopPlaying)
            {
                Form1.Instance.toolStripStatusLabel5.Text = "Status: Stopped";
                return;
            }
            while (Form1.Instance.PausePlaying)
            {
                Form1.Instance.toolStripStatusLabel5.Text = "Status: Paused";
                Thread.Sleep(1000);
            }

            try
            { Form1.Instance.webBrowser1.Document.GetElementById("i1668").InvokeMember("click"); }
            catch { }

            try
            {
                Form1.Instance.webBrowser1.Document.GetElementById("i0201").InvokeMember("click");
                Thread.Sleep(new Random().Next(100, 400));
                Form1.Instance.webBrowser1.Document.GetElementById("i0116").SetAttribute("value", Form1.Instance.AccountUsername[Form1.Instance.Account]);
                Thread.Sleep(new Random().Next(100, 400));
                Form1.Instance.webBrowser1.Document.GetElementById("i0118").SetAttribute("value", Form1.Instance.AccountPassword[Form1.Instance.Account]);
                Thread.Sleep(new Random().Next(100, 400));
                Form1.Instance.webBrowser1.Document.GetElementById("idSIButton9").InvokeMember("click");
                Form1.Instance.loggedin = true;
            }
            catch { }
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            Form1.Instance.DocText = Form1.Instance.webBrowser1.DocumentText;
            if (Form1.Instance.webBrowser1.Url.ToString().Contains("GamePlay.aspx?game=") & DocText.Contains("Congratulations, you have exceeded the"))
            {
                Form1.Instance.DocText = "_";
                Form1.Instance.toolStripStatusLabel5.Text = email + " hit the ticket limit(1000). Rotating account";
                Form1.Instance.UseAccount[Form1.Instance.Account] = false;
                Form1.Instance.Account++;
                Form1.Instance.StopPlaying = true;
                Form1.Instance.webBrowser1.Navigate("http://login.live.com/logout.srf?ct=1282897228&rver=6.1.6195.0&lc=1033&id=265515&ru=http:%2F%2Fwww.clubbing.com%2FPages%2FHome%2FHomePage.aspx%3Ffbid%3D6d1m1vSiVYu%26wom%3Dfalse");
                new Thread(new ThreadStart(StartNewAccount)).Start();
                return;
            }
            Thread.Sleep(500);
            new Thread(new ThreadStart(HandleWeb)).Start();
        }

        private void HandleWeb()
        {
            if (Form1.Instance.webBrowser1.Url.ToString().Contains("live.com/login.srf?"))
            {
                Login log = new Login(loginLive2);
                Form1.Instance.webBrowser1.Invoke(log);
            }

            if (Form1.Instance.webBrowser1.Url.ToString().Contains("Home/HomePage.aspx"))
            {
                if (Form1.Instance.loggedin == true & Form1.Instance.DocText.Contains("Sign Out"))
                {
                    Thread.Sleep(500);
                    Form1.Instance.loggedin = true;
                    Form1.Instance.toolStripStatusLabel5.Text = "Status: Logged In";
                    Thread.Sleep(new Random().Next(Form1.Instance.newgameMin, Form1.Instance.newgameMax));
                    gamerunn = true;
                    switch (Form1.Instance.AccountGame[Form1.Instance.Account])
                    {
                        case "Chicktionary":
                            Form1.Instance.webBrowser1.Navigate("http://www.clubbing.com/Pages/Games/GamePlay.aspx?game=Chicktionary&mode=play");
                            break;
                        case "Spelling Bee":
                            Form1.Instance.webBrowser1.Navigate("http://www.clubbing.com/Pages/Games/GamePlay.aspx?game=Spelling_Bee&mode=play");
                            break;
                        case "Word Slugger":
                            Form1.Instance.webBrowser1.Navigate("http://www.clubbing.com/Pages/Games/GamePlay.aspx?game=Word_Slugger&mode=play");
                            break;
                    }
                }
            }

            if (Form1.Instance.webBrowser1.Url.ToString().Contains("GamePlay.aspx?game=") & gamerunn == true)
            {
                Thread.Sleep(500);
                gamerunn = false;
                string url = Form1.Instance.webBrowser1.Url.ToString().Split('=')[1].Split('&')[0];
                if (loggedin)
                {
                    Form1.Instance.loggedin = false;
                    Thread CheckLoad = new Thread(CheckGameLoad);
                    switch (url)
                    {//Colors will need to me updated as CB games switch to new "looks" (winter, 4th of july, etc)
                        case "Chicktionary":
                            CheckLoad.Start(-7901065);//- 13500416);
                            break;
                        case "Spelling_Bee":
                            CheckLoad.Start(-14141297);
                            break;
                        case "Word_Slugger":
                            CheckLoad.Start(-15658735);
                            break;
                    }
                }
                url = null;
            }
            Form1.Instance.DocText = "_";
        }

        private Bitmap GetBrowserImage()
        {
            IntPtr webHandle = GetHandle();
            Graphics graphics;
            Bitmap image0 = new Bitmap(1010, 335);
            Bitmap image = new Bitmap(1010, 335);
            using (graphics = Graphics.FromImage(image))
            {
                IntPtr hdc = graphics.GetHdc();
                PrintWindow(webHandle, hdc, 0);
                graphics.ReleaseHdc(hdc);
            }
            using (graphics = Graphics.FromImage(image0))
            {
                graphics.DrawImage(image, new Rectangle(0, 0, 1010, 335), 188, 0, 1010, 335, GraphicsUnit.Pixel);
            }
            image.Dispose();
            graphics.Dispose();
            return image0;
        }

        private void CheckGameLoad(object color)
        {
            bool captchaTrue = false;
        Label_1:
            Form1.Instance.toolStripStatusLabel5.Text = "Status: Loading Game";
            checkStatus();

            if (!captchaTrue & (Form1.Instance.AccountGame[Form1.Instance.Account] != "Chicktionary"))
            {
                if (IsCaptchaThar())
                {
                    captchaTrue = true;
                    Solve2 deg2 = new Solve2(Form1.Instance.DownloadCaptchas);
                    Form1.Instance.webBrowser1.Invoke(deg2);
                    return;
                }
            }

            //int col2 = GetBrowserImage().GetPixel(207, 61).ToArgb();
            //if (col2 == (int)color) { col2 = 1; } //get new color, debugging
            if (GetBrowserImage().GetPixel(207, 61).ToArgb() == (int)color)
            {
                Form1.Instance.toolStripStatusLabel5.Text = "Status: Game Loaded";
                new Thread(new ThreadStart(Form1.Instance.StartGame)).Start();
                return;
            }
            else
            {
                Thread.Sleep(4000);
                goto Label_1;
            }
        }

        private void StartGame()
        {
            checkStatus();
            Form1.Instance.webBrowser2.Navigate("http://www.clubbing.com/StatusBar.ashx?command=getStatusBarContent");
            Form1.Instance.toolStripStatusLabel5.Text = "Status: Starting Game";
            if (IsCaptchaThar())
            { newcaptchas(); return; }
            IntPtr webHandle = GetHandle();
            if (Form1.Instance.AccountGame[Form1.Instance.Account] == "Chicktionary")
            {
                Input.ClickXY(webHandle, 300, 225); //Start Game button
            }

            checkStatus();
            Thread.Sleep(7000);
            checkStatus();
            if (Form1.Instance.AccountGame[Form1.Instance.Account] == "Chicktionary")
            {
                if (IsCaptchaThar())
                {
                    Solve2 deg2 = new Solve2(Form1.Instance.DownloadCaptchas);
                    Form1.Instance.webBrowser1.Invoke(deg2);
                    return;
                }
            }

            switch (Form1.Instance.AccountGame[Form1.Instance.Account])
            {
                case "Chicktionary":
                    //Click all the chickens/hens
                    Input.ClickXY(webHandle, 340, 202);
                    Input.ClickXY(webHandle, 394, 202);
                    Input.ClickXY(webHandle, 449, 202);
                    Input.ClickXY(webHandle, 502, 202);
                    Input.ClickXY(webHandle, 556, 202);
                    Input.ClickXY(webHandle, 611, 202);
                    Input.ClickXY(webHandle, 665, 202);
                    break;

                case "Spelling Bee":
                    Input.ClickXY(webHandle, 367, 166);
                    Input.ClickXY(webHandle, 413, 193);
                    Input.ClickXY(webHandle, 457, 166);
                    Input.ClickXY(webHandle, 505, 195);
                    Input.ClickXY(webHandle, 551, 167);
                    Input.ClickXY(webHandle, 596, 195);
                    Input.ClickXY(webHandle, 642, 167);
                    break;

                case "Word Slugger":
                    Input.ClickXY(webHandle, 344, 250);
                    Input.ClickXY(webHandle, 400, 250);
                    Input.ClickXY(webHandle, 451, 250);
                    Input.ClickXY(webHandle, 504, 251);
                    Input.ClickXY(webHandle, 556, 251);
                    Input.ClickXY(webHandle, 609, 252);
                    Input.ClickXY(webHandle, 663, 250);
                    break;
            }

            checkStatus();
            Input.TypeLetter(webHandle, (int)Keys.Return);
            Solve2 deg = new Solve2(Form1.Instance.GetLetters);
            Form1.Instance.webBrowser1.Invoke(deg);
        }


        private bool IsCaptchaThar()
        {
            Form1.Instance.toolStripStatusLabel5.Text = "Status: Checking for Asirra";
            checkStatus();
            if (GetBrowserImage().GetPixel(280, 82).ToArgb() == -4210753)
            { return true; }
            else
            { return false; }
        }


        private void DownloadCaptchas()
        {
            int tries = 0;

        Label_1:
            /*if (!Form1.Instance.webBrowser1.Url.ToString().Contains("GamePlay.aspx?game="))
            {
                Form1.Instance.toolStripStatusLabel5.Text = "Status: Reloading game to get new captchas";
                Form1.Instance.loggedin = true;
                Form1.Instance.webBrowser1.Navigate("http://www.clubbing.com/Pages/Home/HomePage.aspx");
                return;
            }*/
            while (!(Form1.Instance.webBrowser1.ReadyState == WebBrowserReadyState.Complete))
            {
                Thread.Sleep(1000);
            }
            try
            {
                for (int i = 0; i < 15; i++)
                { File.Delete(i + "_Asirra.bmp"); }
            }
            catch { }
            Thread.Sleep(500);
            /*if (totaltries >= 4)
            {
                totaltries = 0;
                Form1.Instance.toolStripStatusLabel5.Text = "Status: Can't get captchas after 5 reloads. Logging account back in...";
                Thread.Sleep(1500);
                stopToolStripMenuItem.PerformClick();
                Thread.Sleep(2000);
                startToolStripMenuItem2.PerformClick();
                return;
            }*/
            if (tries >= 4)
            {
                totaltries++;
                Form1.Instance.toolStripStatusLabel5.Text = "Status: Reloading game to get new captchas";
                Form1.Instance.loggedin = true;
                Form1.Instance.webBrowser1.Navigate("http://www.clubbing.com/Pages/Home/HomePage.aspx");
                return;
            }
            checkStatus();
            try
            {
                Form1.Instance.toolStripStatusLabel5.Text = "Status: Downloading CatCha's";
                mshtml.IHTMLDocument2 doc = (mshtml.IHTMLDocument2)
                    Form1.Instance.webBrowser1.Document.GetElementById("asirra-challenge").Document.DomDocument;
                mshtml.IHTMLSelectionObject sobj = doc.selection;
                mshtml.HTMLBody body = doc.body as mshtml.HTMLBody;
                sobj.empty();
                mshtml.IHTMLControlRange range = body.createControlRange() as mshtml.IHTMLControlRange;
                mshtml.IHTMLControlElement img;
                string name = null;
                Uri u;
                for (int im = 0; im < Form1.Instance.webBrowser1.Document.GetElementById("asirra-challenge").Document.Images.Count - 1; im++)
                {
                    img = (mshtml.IHTMLControlElement)Form1.Instance.webBrowser1.Document.GetElementById("asirra-challenge").Document.Images[im].DomElement;

                    u = new Uri(Form1.Instance.webBrowser1.Document.GetElementById("asirra-challenge").Document.Images[im].GetAttribute("src"));

                    name = u.Segments[u.Segments.Length - 1].ToString();

                    range.add(img);
                    range.select();

                    range.execCommand("Copy", false, null);
                    Bitmap bimg = new Bitmap(Clipboard.GetImage());
                    bimg.Save(im.ToString() + "_Asirra.bmp");
                    bimg.Dispose();
                    Clipboard.Clear();
                }
                doc = null;
                sobj = null;
                body = null;
                range = null;
                img = null;
                name = null;
                u = null;

                Form1.Instance.toolStripStatusLabel5.Text = "Status: All CatCha images downloaded";
                /*if (Form1.Instance.UseDecap)
                {
                    Decaptcher decap = new Decaptcher(Form1.Instance.DecapUser, Form1.Instance.DecapPass);
                    if (decap.CreateCaptcha())
                    {
                        decap.sendCaptcha(Image.FromFile("catcha.png"));

                    }
                    else { return; }

                }
                else
                {*/
                    CaptchaForm CatForm = new CaptchaForm();
                    CatForm.Show();
                //}
                return;
            }
            catch { totaltries++; Thread.Sleep(15000); goto Label_1; } //MessageBox.Show(ex.ToString() + "\n\n\n" + ex.Message); 
        }

        internal void newcaptchas()
        {
            checkStatus();
            Thread.Sleep(10000);
            if (IsCaptchaThar())
            {
                Solve deg2 = new Solve(Form1.Instance.DownloadCaptchas);
                Form1.Instance.webBrowser1.Invoke(deg2);
            }
            else
            {
                Form1.Instance.webBrowser1.Document.Window.ScrollTo(0, 0);
                new Thread(new ThreadStart(Form1.Instance.StartGame)).Start();
            }
        }

        private void SolvePuzzle()
        {
            Form1.Instance.toolStripStatusLabel5.Text = "Status: Downloading answers";
            string response = new WebClient().
                DownloadString("http://www.anagramssolved.com/anagram-solutions.html?letters=" + Form1.Instance.Anagram);
            string[] words = Regex.Split(response, "<li>[0-9]{1,} ([^<]*)</li>");
            response = null;
            words[0] = String.Empty;

            IntPtr webHandle = GetHandle();
            for (int ix = 0; ix < 7; ix++)
            {
                Input.TypeLetter(webHandle, (int)Keys.Back);
            }

            switch (Form1.Instance.EnterType)
            {
                case 0:
                    words = RandomOrder(words);
                    break;

                case 2:
                    Array.Reverse(words);
                    break;
            }

            //This looks so bad...
            int maxlength = new Random().Next(15, 18);

            int iii1 = 0;
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length == 3)
                {
                    if (iii1 >= maxlength)
                    {
                        words[i] = String.Empty;
                    }
                    iii1++;
                }
            }

            int iii2 = 0;
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length == 4)
                {
                    if (iii2 >= maxlength)
                    {
                        words[i] = String.Empty;
                    }
                    iii2++;
                }
            }

            int iii3 = 0;
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length == 5)
                {
                    if (iii3 >= maxlength)
                    {
                        words[i] = String.Empty;
                    }
                    iii3++;
                }
            }

            iii1 = 0;
            iii2 = 0;
            iii3 = 0;
            maxlength = 0;

            for (int i = 0; i < words.Length; i++)
            {
                checkStatus();
                if (words[i].Length >= 3 & words[i].Length <= 7)
                {
                    Form1.Instance.toolStripStatusLabel5.Text = "Status: Entering word: " + words[i];

                    char[] word = words[i].ToCharArray();
                    for (int ii = 0; ii < word.Length; ii++)
                    {
                        Input.TypeLetter(webHandle, (int)word[ii]);
                    }
                    word = null;


                    Input.TypeLetter(webHandle, (int)Keys.Return);
                    Thread.Sleep(new Random().Next(300, 900));
                    for (int ix = 0; ix < words[i].Length; ix++)
                    {
                        Input.TypeLetter(webHandle, (int)Keys.Back);
                    }
                    Thread.Sleep(new Random().Next(Form1.Instance.nextwordMin, Form1.Instance.nextwordMax));
                }
            }
            words = null;
            Thread.Sleep(new Random().Next(500, 1200));

            int FinishColor = 0;
            switch (Form1.Instance.AccountGame[Form1.Instance.Account])
            {//Colors will need to me updated as CB games switch to new "looks" (winter, 4th of july, etc)
                case "Chicktionary":
                    FinishColor = -16746573;// -9460709;
                    break;

                case "Spelling Bee":
                    FinishColor = -5678064;
                    break;

                case "Word Slugger":
                    FinishColor = -11769692;
                    break;
            }

            if (GetBrowserImage().GetPixel(370, 190).ToArgb() != FinishColor)
            {
                Form1.Instance.toolStripStatusLabel5.Text = "Status: Game didn't finish completely, using Give Up option.";
                Thread.Sleep(new Random().Next(200, 700));
                new Thread(new ThreadStart(Form1.Instance.GiveUp)).Start();
                Thread.CurrentThread.Join();
                return;
            }
            Form1.Instance.toolStripStatusLabel5.Text = "Status: Finished Game";
            Form1.Instance.loggedin = true;
            Form1.Instance.webBrowser1.Navigate("http://www.clubbing.com/Pages/Home/HomePage.aspx");
            Thread.CurrentThread.Join();
        }

        private void checkStatus()
        {
            if (Form1.Instance.StopPlaying)
            {
                Form1.Instance.toolStripStatusLabel5.Text = "Status: Stopped";
                Thread.CurrentThread.Join();
                return;
            }
            while (Form1.Instance.PausePlaying)
            {
                Form1.Instance.toolStripStatusLabel5.Text = "Status: Paused";
                Thread.Sleep(1000);
            }
        }

        private void GiveUp()
        {
            IntPtr webHandle = GetHandle();
            int FinishColor = 0;
            ushort Xvar = 0;
            ushort Yvar = 0;
            switch (Form1.Instance.AccountGame[Form1.Instance.Account])
            {//Colors will need to me updated as CB games switch to new "looks" (winter, 4th of july, etc)
                case "Chicktionary":
                    Xvar = 246;
                    Yvar = 197;
                    FinishColor = -5844000;// -9460709;
                    Input.ClickXY(webHandle, Xvar, Yvar);
                    break;

                case "Spelling Bee":
                    Xvar = 272;
                    Yvar = 222;
                    FinishColor = -6270450;// -5678064;
                    Input.ClickXY(webHandle, Xvar, Yvar);
                    break;

                case "Word Slugger":
                    Xvar = 254;
                    Yvar = 270;
                    FinishColor = -11769692;
                    Input.ClickXY(webHandle, Xvar, Yvar);
                    break;
            }
            Thread.Sleep(new Random().Next(1000, 3000));
            Input.ClickXY(webHandle, 537, 234);
            Thread.Sleep(new Random().Next(2000, 4000));

        Label_1:
            Input.ClickXY(webHandle, Xvar, Yvar);
            Thread.Sleep(new Random().Next(500, 1500));

            if (GetBrowserImage().GetPixel(470, 170).ToArgb() == FinishColor)
            {
                Form1.Instance.toolStripStatusLabel5.Text = "Status: Finished Game";
                Form1.Instance.loggedin = true;
                Form1.Instance.webBrowser1.Navigate("http://www.clubbing.com/Pages/Home/HomePage.aspx");
            }
            else
            { goto Label_1; }
        }

        public string[] RandomOrder(string[] arrList)
        {
            Random r = new Random();
            for (int cnt = 0; cnt < arrList.Length; cnt++)
            {
                object tmp = arrList[cnt];
                int idx = r.Next(arrList.Length - cnt) + cnt;
                arrList[cnt] = arrList[idx];
                arrList[idx] = (string)tmp;
            }
            r = null;
            return arrList;
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;

            if (Form1.Instance.PausePlaying) { Form1.Instance.PausePlaying = false; return; }
            if (!Form1.Instance.LoadAccounts() & !Form1.Instance.LoadSettings()) { return; }

            Form1.Instance.toolStripStatusLabel5.Text = "Status: Logging In";
            Form1.Instance.StopPlaying = false;
            Form1.Instance.startToolStripMenuItem2.Enabled = false;
            startToolStripMenuItem2.Enabled = false;
            for (int i = 0; i < Form1.Instance.UseAccount.Length; i++)
            {
                if (Form1.Instance.UseAccount[i] == true)
                {
                    Form1.Instance.Account = i;
                    Form1.Instance.startToolStripMenuItem2.Enabled = false;
                    Form1.Instance.webBrowser1.Navigate("http://login.live.com/login.srf?wa=wsignin1.0&rpsnv=11&ct=1282657439&rver=6.1.6195.0&wp=MBI&wreply=http:%2F%2Fwww.clubbing.com%2FPages%2FHome%2FHomePage.aspx%3Ffbid%3Dbmb9G1XdAOW%26wa%3Dwsignin1.0%26lc%3D1033%26wom%3Dfalse&lc=1033&id=265515");
                    break;
                }
            }
        }

        private void StartNewAccount()
        {
            if (Form1.Instance.StopPlaying) Thread.Sleep(10000);
            Form1.Instance.StopPlaying = false;
            for (int i = 0; i < Form1.Instance.UseAccount.Length; i++)
            {
                if (Form1.Instance.UseAccount[i] == true)
                {
                    Form1.Instance.Account = i;
                    Form1.Instance.webBrowser1.Navigate("http://login.live.com/login.srf?wa=wsignin1.0&rpsnv=11&ct=1282657439&rver=6.1.6195.0&wp=MBI&wreply=http:%2F%2Fwww.clubbing.com%2FPages%2FHome%2FHomePage.aspx%3Ffbid%3Dbmb9G1XdAOW%26wa%3Dwsignin1.0%26lc%3D1033%26wom%3Dfalse&lc=1033&id=265515");
                    break;
                }
            }
            Thread.CurrentThread.Join();
        }


        private bool LoadAccounts()
        {
            StreamReader inputstream = new StreamReader("XenixAccounts.txt");
            try
            {
                string[] newstr = new string[3];
                int i = 0;
                while (inputstream.Peek() != -1)
                {
                    newstr = inputstream.ReadLine().Split('|');
                    if (Convert.ToBoolean(newstr[0]) == true) { Form1.Instance.UseAccount[i] = true; }
                    else { Form1.Instance.UseAccount[i] = false; }
                    Form1.Instance.AccountUsername[i] = newstr[1];
                    Form1.Instance.AccountPassword[i] = newstr[2];
                    Form1.Instance.AccountGame[i] = newstr[3];
                    switch (newstr[3])
                    {//I forget why this is here
                        case "Chicktionary":
                            break;
                        case "Spelling Bee":
                            break;
                        case "Word Slugger":
                            break;
                        default:
                            MessageBox.Show("Invalid game in settings file for email: " + newstr[1] +
                                "\nMust be Chicktionary, Spelling Bee, or Word Slugger");
                            return false;
                    }
                    i++;
                }
                inputstream.Close();
                newstr = null;
                return true;
            }
            catch (Exception ex)
            {
                Form1.Instance.toolStripStatusLabel5.Text = "Status: Error loading accounts. Error: " + ex.ToString();
                inputstream.Close(); return false;
            }
        }

        internal bool LoadSettings()
        {
            StreamReader inputstream = new StreamReader("XenixSettings.txt");
            try
            {
                string[] newstr = new string[9];
                while (inputstream.Peek() != -1)
                {
                    newstr = inputstream.ReadLine().Split('|');

                    Form1.Instance.newgameMin = Int32.Parse(newstr[0]);
                    Form1.Instance.newgameMax = Int32.Parse(newstr[1]);
                    Form1.Instance.startgameMin = Int32.Parse(newstr[2]);
                    Form1.Instance.startgameMax = Int32.Parse(newstr[3]);
                    Form1.Instance.nextletterMin = Int32.Parse(newstr[4]);
                    Form1.Instance.nextletterMax = Int32.Parse(newstr[5]);
                    Form1.Instance.nextwordMin = Int32.Parse(newstr[6]);
                    Form1.Instance.nextwordMax = Int32.Parse(newstr[7]);
                    Form1.Instance.EnterType = Int32.Parse(newstr[8]);
                    Form1.Instance.DecapUser = newstr[9];
                    Form1.Instance.DecapPass = newstr[10];
                    Form1.Instance.UseDecap = Convert.ToBoolean(newstr[11]);
                }
                inputstream.Close();
                newstr = null;
                return true;
            }
            catch (Exception ex)
            {
                Form1.Instance.toolStripStatusLabel5.Text = "Status: Error loading settings. Error: " + ex.ToString();
                inputstream.Close(); return false;
            }
        }

        private IntPtr GetHandle()
        {
            StringBuilder builder = new StringBuilder(100);
            IntPtr webHandle = Form1.Instance.webBrowser1.Handle;
            builder = new StringBuilder(100);

            while (builder.ToString() != "Internet Explorer_Server")
            {
                webHandle = GetWindow(webHandle, 5);
                GetClassName(webHandle, builder, builder.Capacity);
            }
            builder = null;
            return webHandle;
        }

        private void webBrowser2_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            int gameplays = Int32.Parse(Regex.Split(Form1.Instance.webBrowser2.DocumentText, "PuzzlePlaysSinceLastCAPTCHA\":")[1].Split(',')[0]);
            int tickets = Int32.Parse(Regex.Split(Form1.Instance.webBrowser2.DocumentText, "todaysTicketCt\":\"")[1].Split('"')[0]);
            string TotalTicks = Regex.Split(Form1.Instance.webBrowser2.DocumentText, "totalTicketCt\":\"")[1].Split('"')[0];
            email = Regex.Split(Form1.Instance.webBrowser2.DocumentText, "EmailAddress\":\"")[1].Split('"')[0];

            toolStripStatusLabel1.Text = "Captcha In: " + (4 - gameplays) + " games.";
            toolStripStatusLabel2.Text = "Tickets today: " + tickets.ToString();
            toolStripStatusLabel3.Text = "Email: " + email;
            toolStripStatusLabel4.Text = "Total tickets: " + TotalTicks;


            if (tickets >= 1000)
            {
                Form1.Instance.toolStripStatusLabel5.Text = email + " hit the ticket limit(1000). Rotating account";
                Form1.Instance.UseAccount[Form1.Instance.Account] = false;
                Form1.Instance.Account++;
                Form1.Instance.StopPlaying = true;
                Form1.Instance.webBrowser1.Navigate("http://login.live.com/logout.srf?ct=1282897228&rver=6.1.6195.0&lc=1033&id=265515&ru=http:%2F%2Fwww.clubbing.com%2FPages%2FHome%2FHomePage.aspx%3Ffbid%3D6d1m1vSiVYu%26wom%3Dfalse");
                new Thread(new ThreadStart(StartNewAccount)).Start();
            }

            try
            {
                StreamReader reader = new StreamReader("XenixAccounts.txt");
                string newstr = null;
                string newstr2 = null;
                while (reader.Peek() != -1)
                {
                    newstr = reader.ReadLine();
                    for (int i = 0; i < newstr.Length - 1; i++)
                    {
                        if (newstr.Contains(Form1.Instance.AccountUsername[Form1.Instance.Account]) &
                            newstr.Contains(Form1.Instance.AccountPassword[Form1.Instance.Account]))
                        {
                            newstr = newstr.Replace('|' + newstr.Split('|')[4], '|' + TotalTicks.ToString());
                        }
                    }
                    newstr2 += newstr + '\n';
                }
                reader.Close();

                StreamWriter writer = new StreamWriter("XenixAccounts.txt");
                writer.Write(newstr2);
                writer.Close();

                newstr = null;
                newstr2 = null;
                TotalTicks = null;
                gameplays = 0;
                tickets = 0;
            }
            catch { } //(Exception exx) { MessageBox.Show("Error saving accounts.\nError:\n" + exx.Message); }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ((Control)Form1.Instance.webBrowser1).Enabled = false;
            Form1.Instance.notifyIcon1.Visible = true;
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1.Instance.StopPlaying = true;
            Form1.Instance.startToolStripMenuItem2.Enabled = true;
            startToolStripMenuItem2.Enabled = true;
            Form1.Instance.webBrowser1.Navigate("http://login.live.com/logout.srf?ct=1282897228&rver=6.1.6195.0&lc=1033&id=265515&ru=http:%2F%2Fwww.clubbing.com%2FPages%2FHome%2FHomePage.aspx%3Ffbid%3D6d1m1vSiVYu%26wom%3Dfalse");
            Form1.Instance.toolStripStatusLabel5.Text = "Status: Stopped";
            if (pauseToolStripMenuItem.Text == "Unpause")
            {
                pauseToolStripMenuItem.Text = "Pause";
                Form1.Instance.PausePlaying = false;
            }
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Application.ExecutablePath);
            Environment.Exit(0);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            notifyIcon1.Dispose();
            Environment.Exit(0);
        }

        //private const int WM_SYSCOMMAND = 0x0112;
        //private const int SC_MINIMIZE = 0xF020;
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x0112:
                    int command = m.WParam.ToInt32() & 0xfff0;
                    if (command == 0xF020)
                    {
                        Form1.Instance.Opacity = 0;
                        Form1.Instance.ShowInTaskbar = false;
                        return;
                    }
                    break;
            }
            base.WndProc(ref m);
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Form1.Instance.Opacity = 100;
            Form1.Instance.ShowInTaskbar = true;
            Form1.Instance.WindowState = FormWindowState.Normal;
            Form1.Instance.BringToFront();
        }

        private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pauseToolStripMenuItem.Text == "Pause")
            {
                pauseToolStripMenuItem.Text = "Unpause";
                Form1.Instance.PausePlaying = true;
                Form1.Instance.toolStripStatusLabel5.Text = "Status: Paused";
            }
            else if (pauseToolStripMenuItem.Text == "Unpause")
            {
                pauseToolStripMenuItem.Text = "Pause";
                Form1.Instance.PausePlaying = false;
                Form1.Instance.toolStripStatusLabel5.Text = "Status: Unpaused";
            }
        }

        private void HandleFileToolStrip(object sender, EventArgs e)
        {
            switch (((ToolStripMenuItem)sender).Name)
            {
                case "accountsToolStripMenuItem2":
                    foreach (Form frm in Application.OpenForms)
                    {
                        if (frm is AccountForm)
                        {
                            frm.BringToFront();
                            return;
                        }
                    }
                    AccountForm accfrm = new AccountForm();
                    accfrm.Show();
                    break;

                case "settingsToolStripMenuItem2":
                    foreach (Form frm in Application.OpenForms)
                    {
                        if (frm is SettingsForm)
                        {
                            frm.BringToFront();
                            return;
                        }
                    }
                    SettingsForm settingsfrm = new SettingsForm();
                    settingsfrm.Show();
                    break;

                case "enableInputToolStripMenuItem":
                    ((Control)Form1.Instance.webBrowser1).Enabled = true;
                    break;

                case "disableInputToolStripMenuItem":
                    ((Control)Form1.Instance.webBrowser1).Enabled = false;
                    break;

                case "exitToolStripMenuItem2":
                    Environment.Exit(0);
                    break;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            long ticks = DateTime.Now.Ticks;
            if ((ticks - startTicks) > 0x989680L)
            {
                startTicks = ticks;
                Process currentProcess = Process.GetCurrentProcess();
                Input.SetProcessWorkingSetSize(currentProcess.Handle, -1, -1);
                currentProcess.Dispose();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            while (IsKeyPushedDown(Keys.LControlKey))
            {
                Thread.Sleep(500);
            }
        }

        public static bool IsKeyPushedDown(Keys vKey)
        {
            return 0 != (Input.GetAsyncKeyState((int)vKey) & 0x8000);
        }
    }
}