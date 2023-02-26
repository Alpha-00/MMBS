using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.IO;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Google.Apis.Auth.OAuth2;
using System.Threading;
using RTF;
//using User_DebugSystem;
namespace MMBS
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            Properties.Settings.Default.exit = false;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            string cache = resources.GetString("UpdateLog.Text");
            Properties.Settings.Default.appver = cache.Split("\n")[1].Split(":")[0].Trim();
            Properties.Settings.Default.appmessage = cache.Split("\n")[1].Split(":")[1].Trim();
            
            if (Properties.Settings.Default.AFFautoOpen) { 
                this.Hide();  
                AFForm AFFcontrol = new AFForm("new");
                AFFcontrol.ShowDialog();
                try
                {
                    this.Show();
                }
                catch (Exception e)
                { }
            }
            
            InitializeComponent();
            ThemeSystem.LoadOldStyle(this);
            this.Size = new Size(375, 476);
        }
        
        public void LoadChangeLogs()
        {
            RTFBuilderbase cache = new RTFBuilder();
            //string cache = "";
            string[] LogLine = UpdateLog.Text.Split('\n') ;
            /*cache += "{\\rtf1\\ansi\\deff0{\\colortbl;\red0\\green0\blue0;\red255\\green0\blue0; }";
            
            cache += "}";
            UpdateLog.Rtf = cache;
            string Logs(string version, string content)
            {
                return "";
            }*/
            UpdateLog.Clear();
            cache.AppendRTFDocument(this.UpdateLog.Rtf);
            cache.FontSize(22);
            foreach (string s in LogLine)
            {
                if (s == LogLine.First())
                {
                    cache.Alignment(StringAlignment.Center).FontStyle(FontStyle.Bold | FontStyle.Underline).ForeColor(Properties.Settings.Default.OldStyle ? Color.Orange:Color.Yellow).Append(s).AppendLine();
                }
                else if (s.Contains(":"))
                {
                    cache.FontSize(20);
                    cache.Alignment(StringAlignment.Near);
                    cache.FontStyle(FontStyle.Underline).ForeColor(Color.Lime).Append(s.Remove(s.IndexOf(" : ")));
                    cache.ForeColor(Color.Lime).Append(" : ");
                    cache.Alignment(StringAlignment.Far);
                    cache.ForeColor(Properties.Settings.Default.OldStyle?Color.Black:Color.White).Append(s.Substring(s.IndexOf(" : ") + " : ".Length));
                    cache.AppendLine();
                }
            }

           UpdateLog.Rtf = "";
            UpdateLog.Rtf = cache.ToString();
            
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolBoxaccess_Click(object sender, EventArgs e)
        {
            this.Hide();
            ToolsForm formTools = new ToolsForm();
            formTools.ShowDialog();
            this.Show();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void ETest1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            MessageBox.Show(e.ClickedItem.Name);
        }

        private void cmdEXE1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tôi mới nhấn cmdEXE1");
            string rescache = Interaction.InputBox("Nhập đường dẫn cần rút gọn", "Check Rút gọn link", "http://offlinemods.com");
            var request = (HttpWebRequest)WebRequest.Create("https://123link.co/api?api=796632dc0627534f171fd34fe0ab7c80072696ad&url="+rescache+"&format=text");
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            if (responseString != "") {
                MessageBox.Show("Success:" + responseString.ToString());
            }
            else
            {
                MessageBox.Show("False");
            };
        }

        private void ShoLinkBut_Click(object sender, EventArgs e)
        {
            string cache;
            if (System.IO.File.Exists("C:\\BloggerSupporter\\123linkToken.txt"))
            {
                cache = System.IO.File.ReadAllText("C:\\BloggerSupporter\\123linkToken.txt");
                
            }
            else
            {
                cache = Interaction.InputBox("Nhập API token 123link của bạn", "API token");
            }
            if (cache != "")
            {
                cache = cache.Trim();
                string rescache = Interaction.InputBox("Nhập đường dẫn cần rút gọn\nAPI của bạn là "+(cache==Class1.GetToken("123")?"API của chủ app":cache), "Check Rút gọn link", (Clipboard.GetText().Contains("http") ? Clipboard.GetText() : "http://offlinemods.com"));
                var request = (HttpWebRequest)WebRequest.Create("https://123link.co/api?api="+cache+"&url=" + rescache + "&format=text");
                var response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                if (responseString != "")
                {
                    MessageBox.Show("Thành công : " + responseString.ToString()+"\nLink đã nằm trong Clipboard của bạn");
                    SystemAlt.Windows_Forms_Clipboard_SetText(responseString.ToString());
                }
                else
                {
                    MessageBox.Show("Không thể lấy link");
                };
            }
        }

        private void cmdEXE2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] Scopes = { DriveService.Scope.DriveReadonly };
            string ApplicationName = "MMBS";
            UserCredential credential;

            using (var stream =
                new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                // The file token.json stores the user's access and refresh tokens, and is created
                // automatically when the authorization flow completes for the first time.
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }
            var service1 = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });
            
            var pretest = service1.Files.Get("0B_EWJlt3Q4AganpmQzVrSXk3dDg");
            pretest.Fields = "size";
            MessageBox.Show((pretest.Execute().Size.ToString()!=""?"Check ok":"False"));

           /* var service = new DriveService(new BaseClientService.Initializer
            {
                ApplicationName = "MMBS",
               ApiKey = Class1.GetToken("gg")
            });
            var result = service.Files.Get("0B_EWJlt3Q4AganpmQzVrSXk3dDg");
            MessageBox.Show(result.Execute().Name);
            MessageBox.Show(result.Execute().Shared.ToString());
            var simplecache = result.Execute().Permissions;
            if (simplecache != null && simplecache.Count>0)
            {
                foreach (var s in simplecache)
                {
                    MessageBox.Show(s.ToString());
                }
            }
            else
            {
                MessageBox.Show("What's happend");
            }
            MessageBox.Show(result.Execute().Size.HasValue.ToString());
            */
        }

        private void SearchKGBut_Click(object sender, EventArgs e)
        {
            SystemAlt.Windows_Forms_Clipboard_SetText(Module.SearchKeywordModule.GetResStr("mod", Interaction.InputBox("Nhập tên app vào","Search Keyword Generator").ToString()));
            MessageBox.Show(Clipboard.GetText());
        }

        private void formFMF_MouseClick(object sender, MouseEventArgs e)
        {
            
            

        }

        private void formFMF_Click(object sender, EventArgs e)
        {
            Hide();
            FMForm FMFcontrol = new FMForm();
            FMFcontrol.ShowDialog();
            
            Show();
        }

        private void formAFF_Click(object sender, EventArgs e)
        {
            
            Hide();
            AFForm AFFcontrol = new AFForm("new");
            AFFcontrol.ShowDialog();
            try
            {
                if (!IsDisposed)
                Show();
            }
            finally
            {

            }
        }

        private void cmdEXE3ToolStripMenuItem_Click(object sender, EventArgs e)
        {//Remove Special character
            MessageBox.Show(OldProcessor.ProcSupporter.HtmlSpecialProcess(Interaction.InputBox("Html Decode", "Html Decoder")));

        }

        private void cmdEXE4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(OldProcessor.ProcSupporter.StrToHex(Interaction.InputBox("String To Hex", "StrToHex Conventer")));
        }

        private void cmdEXE5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Uri uri = new Uri(Interaction.InputBox("Uri check host", "Uri host checker"));
            MessageBox.Show(uri.Host);
        }

        private void cmdEXE6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Uri uri = new Uri(Interaction.InputBox("Uri check info", "Uri host information checker"));
            
            MessageBox.Show(uri.PathAndQuery+'\n'+uri.PathAndQuery+'\n'+uri.Query+'\n'+uri.Fragment+'\n'+uri.Segments.Length.ToString()+'\n'+uri.LocalPath+'\n');
            
        }

        private void cmdEXE7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /* string link1 = Interaction.InputBox("Image 1", "Image Check Duplicated");
             string link2 = Interaction.InputBox("Image 2", "Image Check Duplicated");
             MessageBox.Show("Duplicated level: "+oldProcessor.ProcSupporter.imageDuplicateAIdistance(link1, link2, true).ToString());*/
            MessageBox.Show("Sorry. Image Duplicated Checker is not available");
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            
            
            LoadChangeLogs();
        }

        private void AFFms_autoOpen_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.AFFautoOpen = AFFms_autoOpen.Checked;
            Properties.Settings.Default.Save();
        }

        private void UpdateLog_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.BetaTest)
            {
                this.Hide();
                SMForm form = new SMForm();
                form.ShowDialog();
                this.Show();
            }
        }

        private void standardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.OldStyle = standardToolStripMenuItem.Checked;
            Properties.Settings.Default.Save();
        }

        private void betaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.BetaTest = betaToolStripMenuItem.Checked;
        }
    }
}
