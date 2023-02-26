using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.Security.Policy;
using Newtonsoft.Json.Linq;
using System.Web;
using System.ComponentModel;

namespace mLAMB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //!First Focus
            boxRequest.Focus();
            //!Test code here
            labelReqtype.Visibility = Visibility.Hidden;
            
        }
        public delegate void shellcall(string cmd);
        public shellcall shell_cmd = null;
        public shellcall shell_listen = null;
        public delegate string shellfeed(string cmd);
        public shellfeed shell_feed = null;
        public string requestcache = "";
        ThreadStart procthreadstart;
        Thread procthread;
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
           // buttonExe.IsEnabled = false;
            procthreadstart = new ThreadStart(RequestProc);
            procthread = new Thread(procthreadstart);
            shell_cmd = this.ShellCMD;
            shell_listen = this.ShellListener;
            shell_feed = this.ShellFeed;
            requestcache = boxRequest.Text;
            procthread.Start();
          //  buttonExe.IsEnabled = true;
        }
        Processor.Command cmd = new Processor.Command();
        public void RequestProc()
        {
            this.Dispatcher.Invoke(new Action(() => { buttonExe.IsEnabled = false; buttonExe.Content = "Processing..."; }),System.Windows.Threading.DispatcherPriority.Normal);
            string a = requestcache;
            if (Enum.IsDefined(typeof(Processor.Command.commander), a)) a = "cmd:" + a;
            int code = cmd.start(shell_cmd, shell_listen, shell_feed, a) ;
            switch (code)
            {
                case 1000000000: this.Dispatcher.Invoke(new Action(() => System.Windows.Application.Current.Shutdown()), System.Windows.Threading.DispatcherPriority.Normal); break;
            }
            this.Dispatcher.Invoke(new Action(() => { buttonExe.IsEnabled = true; buttonExe.Content = "Execute"; }), System.Windows.Threading.DispatcherPriority.Normal);
        }
        public int write(string message)
        {
            this.boxShell.AppendText(message);
            return 0;
        }
        public int writeln(string name, string value)
        {
            return write($"{name}: {value}")+write("\n");
        }
        public int writeln(string[] pair)
        {
            if (2 != pair.Length) return 42694269;
            return writeln(pair[0], pair[1]);
        }
        public int writeln(string message)
        {
            return write(message)+write("\n");
        }
        public string shelltext()
        {
            TextRange textRange = new TextRange(
                // TextPointer to the start of content in the RichTextBox.
                boxShell.Document.ContentStart,
                // TextPointer to the end of content in the RichTextBox.
                boxShell.Document.ContentEnd
            );

            // The Text property on a TextRange object returns a string
            // representing the plain text content of the TextRange.
            return textRange.Text;
        }
        public int prepare()
        {
            if (string.IsNullOrWhiteSpace(shelltext())) return 255;
            boxShell.AppendText("\n");
            return 0;
        }
        public static int shellcache;
        [DebuggerStepThrough]
        public void ShellCMD(string cmd)
        {
            
            switch (cmd)
            {
                case "prepare": this.Dispatcher.Invoke(new Action(() => this.prepare()), System.Windows.Threading.DispatcherPriority.Normal); break;
                case "scrolltoend": this.Dispatcher.Invoke(new Action(() => this.boxShell.ScrollToEnd()), System.Windows.Threading.DispatcherPriority.Normal); break;
            }

            switch (cmd[0])
            {
                case ' ': this.Dispatcher.Invoke(new Action(() => this.write(cmd.Substring(1))), System.Windows.Threading.DispatcherPriority.Normal); break;
                //u2035
                case '`': this.Dispatcher.Invoke(new Action(()=>this.writeln(cmd.Substring(1))), System.Windows.Threading.DispatcherPriority.Normal); break;
                case '@':
                    this.Dispatcher.Invoke(new Action(() => this.writeln(ValueSeparate(cmd.Substring(1), ","))), System.Windows.Threading.DispatcherPriority.Normal);
                     break;
                case '?': dovarCMD(cmd.Substring(1));break;
            }
            string[] ValueSeparate(string str,string splitcode)
            {
                return new string[]{str.Remove(str.IndexOf(splitcode)),str.Substring(str.IndexOf(splitcode)+splitcode.Length) };
            }
            void dovarCMD(string cmdstr)
            {
                switch (cmdstr.Remove(cmdstr.IndexOf('\n')))
                {
                    case "clipboard.settext": { this.Dispatcher.Invoke(new Action(() => SystemAlt.Windows_Forms_Clipboard_SetText(cmdstr.Substring(cmdstr.IndexOf('\n')+1))), System.Windows.Threading.DispatcherPriority.Normal); break; } break;
                }
            }
        }
        /// <summary>
        /// Get Information from form
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public string ShellFeed(string cmd)
        {
            string cache = "";
            switch (cmd)
            {
                case "listen": { ShellListener(""); this.Dispatcher.Invoke(new Action(() => cache = FeedResult), System.Windows.Threading.DispatcherPriority.Normal); }  break;
                case "y/n":
                    {
                        listenerstart = true;
                        listener_keyget = true;
                        this.Dispatcher.Invoke(new Action(() => { boxShell.Focus(); boxShell.ScrollToEnd();boxShell.CaretPosition = boxShell.CaretPosition.DocumentEnd; }), System.Windows.Threading.DispatcherPriority.Normal);
                        procthread.Suspend();
                        listenerstart = false;
                        listener_keyget = false;
                        if (!string.IsNullOrEmpty(ShellLine))
                        {

                            for (int i=ShellKeyLine.Count-1; i >=0; i--)
                            {
                                if (ShellKeyLine[i] == Key.N) return "n";
                                if (ShellKeyLine[i] == Key.Y) return "y";
                            }
                        }
                    }
                    break;
                case "?location":
                    {
                        JObject jcache = new JObject();
                        this.Dispatcher.Invoke(new Action(() => {
                            
                            jcache.Add("left", this.Left);
                            jcache.Add("top", this.Top);
                            jcache.Add("width", this.Width);
                            jcache.Add("height", this.Height);
                        })
                            , System.Windows.Threading.DispatcherPriority.Normal);
                        return jcache.ToString(Newtonsoft.Json.Formatting.None);
                    }break;
                case "":this.Dispatcher.Invoke(new Action(() => cache = FeedResult), System.Windows.Threading.DispatcherPriority.Normal); break;
            }
            
            return cache;
            
        }
        public string FeedResult = "";
        public bool listenerstart = false;
        public bool listener_keyget = false;
        public async void ShellListener(string cmd)
        {
            listenerstart = true;
            FeedResult = await ShellGetLine();
            listenerstart = false;
        }
        public string ShellLine = "";
        public List<Key> ShellKeyLine = new List<Key>();
        public async Task<string> ShellGetLine()
        {
            bool satisfied = false;
            while (!satisfied)
            {
                procthread.Suspend();
                satisfied = null != ShellLine;
            }
            string cache = ShellLine;
            ShellLine = "";
            return cache;
        }
        public enum enumGroup
        {
            groupMain = 0,
            groupQuick = 1
        }
        public enum enumFocusState
        {
            nonfocus = 0,
            focus = 1,
            warning = 10,
            error = 100
        }
        
        public class focusdat
        {
            public enumGroup name;
            public int _stat;
            public System.EventHandler<Core.mLAMBEventArg.integerArg> FocusChanged;
            public virtual void OnFocusChanged()
            {
                var Arg = new Core.mLAMBEventArg.integerArg();
                Arg.x = _stat;
                if (null != FocusChanged) FocusChanged(name, Arg);
            }
            public int stat
            {
                get
                {
                    return _stat;
                }
                set
                {
                    if (value != _stat)
                    {
                        _stat = value;
                        OnFocusChanged();
                    }
                }
            }
            public void focuschangedDefault(object sender, Core.mLAMBEventArg.integerArg e)
            {

            }
        }
        /*public class notifyGroupFocus : INotifyPropertyChanged
        {
            public enumGroup _name;
            public int _stat;
            public object x;
            private object _lock;
            public int stat
            {
                get
                {
                    return _stat;
                }
                set
                {
                    lock (_lock)
                    {
                        if (value != _stat)
                        {
                            _stat = value;
                            onFocusChanged();
                        }
                    }
                }
            }
            public void onFocusChanged()
            {
                Core.mLAMBEventArg.integerArg Arg = new Core.mLAMBEventArg.integerArg();
                Arg.x = _stat;
                PropertyChangedEventArgs Args = new PropertyChangedEventArgs("stat");
               
                if (null!= focuschanged) focuschanged(this,Args);
                
            }
            public event PropertyChangedEventHandler focuschanged;
        }
        */
        public void onButQuickclick(object sender, RoutedEventArgs e)
        {
            boxRequest.Text = ((Label)((Button)sender).Content).Content.ToString();
            buttonExe.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
        }

        //
        // Form Event
        //

        private void boxShell_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            boxShell.ScrollToEnd();
        }

        private void boxShell_KeyUp(object sender, KeyEventArgs e)
        {
            if (listenerstart)
            {
                switch (e.Key)
                {
                    case Key.Enter: procthread.Resume(); break;
                    default: { ShellLine += e.Key.GetTypeCode().ToString();
                            if (listener_keyget)
                            ShellKeyLine.Add(e.Key);
                        } break;
                }
               
            }
        }

        private void boxRequest_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                buttonExe.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
        }

        private void boxRequest_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
        Timer time;
        public void VersionOpen(object sender)
        {
            
            Application.Current.Dispatcher.Invoke(new Action(()=> { SystemWindow win = new SystemWindow(); win.ShowInTaskbar = true; win.ShowDialog(); }),System.Windows.Threading.DispatcherPriority.Normal);
           // MessageBox.Show("test");
        }

        private void Title_DragEnter(object sender, MouseEventArgs e)
        {
            
            time = new Timer(new TimerCallback(VersionOpen), this, 1800, 0);
           
            Title.Cursor = Cursors.Wait;
        }

        private void Title_DragLeave(object sender, MouseEventArgs e)
        {
            if (null!=time)
            time.Dispose();
        }

        private void boxRequest_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            
        }

        private void boxRequest_TextInput(object sender, TextCompositionEventArgs e)
        {
            
        }

        private void boxRequest_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Enum.IsDefined(typeof(Processor.Command.commander), boxRequest.Text))
            {
                playCMDlabel();
                return;
            }
            //For dynamic cmd
            if (boxRequest.Text.StartsWith("cmd:"))
            {
                playCMDlabel();
                return;
            }
            if (Processor.Support.Check.isLink(boxRequest.Text))
            {

                if (!Processor.Command.SupportedHost.Contains<string>((new Uri(boxRequest.Text)).Host))
                    playUNLINKlabel();
                else playLINKlabel();
                return;
            }
            hidelabel();
            void playCMDlabel()
            {
                labelReqtype.Visibility = Visibility.Visible;
                labelReqtype.Content = "CMD";
                LinearGradientBrush cache = new LinearGradientBrush(Color.FromRgb(0xff, 0, 0), Color.FromRgb(0x9C, 00, 00), 90.00);
                labelReqtype.Foreground = cache;
            }
            void playLINKlabel()
            {
                labelReqtype.Visibility = Visibility.Visible;
                labelReqtype.Content = "LINK";
                LinearGradientBrush cache = new LinearGradientBrush(Color.FromRgb(0, 0xFF, 0x15), Color.FromRgb(00, 0x9C, 0x2F), 90.00);
                labelReqtype.Foreground = cache;
            }
            void playUNLINKlabel()
            {
                labelReqtype.Visibility = Visibility.Visible;
                labelReqtype.Content = "unsupported link";
                LinearGradientBrush cache = new LinearGradientBrush(Color.FromRgb(0xff, 0xFF, 00), Color.FromRgb(0xff, 0xaa, 00), 90.00);
                labelReqtype.Foreground = cache;
            }
            void hidelabel()
            {
                labelReqtype.Visibility = Visibility.Hidden;
            }
        }
        
        private void gridgroupMain_GotFocus(object sender, RoutedEventArgs e)
        {

        }
    }
}
