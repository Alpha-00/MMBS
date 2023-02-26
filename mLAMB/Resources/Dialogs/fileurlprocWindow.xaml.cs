using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace mLAMB.Resources.Dialogs
{
    /// <summary>
    /// Interaction logic for fileurlprocWindow.xaml
    /// </summary>
    public partial class fileurlprocWindow : Window
    {
        public fileurlprocWindow()
        {
            InitializeComponent();
            
        }
        public Uri downloadLink;
        public Uri mirrordownLink;
        public delegate string shellfeed(string cmd);
        public delegate void updateprog(double value);
        public shellfeed feed;
        public updateprog udown;
        public updateprog umirr;
        public updateprog ureup;
        public fileurlprocWindow(string downlink,string mirrorlink)
        {
            downloadLink = new Uri(downlink);
            if (string.IsNullOrWhiteSpace(mirrorlink))
            mirrordownLink = new Uri(mirrorlink);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            feed = shellfeed_proc;
            udown = udown_proc;
            umirr = umirr_proc;
            ureup = ureup_proc;
            ThreadStart threadStart = new ThreadStart(bridge);
            Thread thread = new Thread(threadStart);
            thread.Start(feed);
        }
        public void bridge()
        {
            Processor.WindowCommands.fileurlprocWindowCommand command = new Processor.WindowCommands.fileurlprocWindowCommand(downloadLink, mirrordownLink);
            int code = command.start(udown, umirr, ureup, feed);
        }
        public int write(string message)
        {
            this.boxShell.AppendText(message);
            return 0;
        }
        public int writeln(string name, string value)
        {
            return write($"{name}: {value}") + write("\n");
        }
        public int writeln(string[] pair)
        {
            if (2 != pair.Length) return 42694269;
            return writeln(pair[0], pair[1]);
        }
        public int writeln(string message)
        {
            return write(message) + write("\n");
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
        public string shellfeed_proc(string cmd)
        {
            switch (cmd[0])
            {
                case ' ': this.Dispatcher.Invoke(new Action(() => this.write(cmd.Substring(1))), System.Windows.Threading.DispatcherPriority.Normal); break;
                //u2035
                case '`': this.Dispatcher.Invoke(new Action(() => this.writeln(cmd.Substring(1))), System.Windows.Threading.DispatcherPriority.Normal); break;
                
                case '?': dovarCMD(cmd.Substring(1)); break;
            }
            return "";
            void dovarCMD(string cmdstr)
            {
                switch (cmdstr.Remove(cmdstr.IndexOf('\n')))
                {
                    case "clipboard.settext": { this.Dispatcher.Invoke(new Action(() => SystemAlt.Windows_Forms_Clipboard_SetText(cmdstr.Substring(cmdstr.IndexOf('\n') + 1))), System.Windows.Threading.DispatcherPriority.Normal); break; } break;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value">In percent %</param>
        public void udown_proc(double value)
        {
            this.Dispatcher.Invoke(new Action(() => this.progDown.Value = value), System.Windows.Threading.DispatcherPriority.Normal);
        }
        public void umirr_proc(double value)
        {
            this.Dispatcher.Invoke(new Action(() => this.progMirrorDown.Value = value), System.Windows.Threading.DispatcherPriority.Normal);
        }
        public void ureup_proc(double value)
        {
            this.Dispatcher.Invoke(new Action(() => this.progReUp.Value = value), System.Windows.Threading.DispatcherPriority.Normal);
        }
    }
}
