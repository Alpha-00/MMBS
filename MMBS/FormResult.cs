using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Blogger.v3;
using Google.Apis.Blogger.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Google.Apis.Auth.OAuth2;
using System.Threading;
using Newtonsoft.Json.Linq;
namespace MMBS
{
    public partial class FormResult : Form
    {
        public List<String> ProcessLog;
        CustomizePostResult res;
        public string CoreDirectory;
        bool back_call = false;//Call when need to back
        public FormResult()
        {
            InitializeComponent();
            LoadLocation();
            if (Properties.Settings.Default.OldStyle) ThemeSystem.LoadOldStyle(this);
        }
        public FormResult(PostDataBundle thenow)
        {
            InitializeComponent();
            LoadLocation();
            //For Simple Process
            res = new CustomizePostResult();
            res.SimpleProcess(thenow);
            butTitle.Enabled = res.titleuse;
            butSearch.Enabled = res.searchuse;
            CoreDirectory = thenow.folderlink;
            if (Properties.Settings.Default.BetaTest) butAutoPost.Visible = true;
            if (Properties.Settings.Default.OldStyle) ThemeSystem.LoadOldStyle(this);
            toolTip.SetToolTip(butTitle, res.titleprocRes);
        }
        public FormResult(PostDataBundle thenow, string code, params string[] para)
        {
            InitializeComponent();
            LoadLocation();
            //For Specific Process
            res = new CustomizePostResult();
            res.SpecificProcess(thenow,this,code,para);
            butTitle.Enabled = res.titleuse;
            butSearch.Enabled = false;
            CoreDirectory = thenow.folderlink;
            if (Properties.Settings.Default.BetaTest) butAutoPost.Visible = true;
            if (Properties.Settings.Default.OldStyle) ThemeSystem.LoadOldStyle(this);
            toolTip.SetToolTip(butTitle, res.titleprocRes);
        }
        public void PostOnly_Service()
        {
            try
            {
                string[] Scopes = { BloggerService.Scope.Blogger };
                string ApplicationName = "MMBS";
                UserCredential credential;

                using (var stream =
                    new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
                {
                    // The file token.json stores the user's access and refresh tokens, and is created
                    // automatically when the authorization flow completes for the first time.
                    string credPath = "token4B.json";
                    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.Load(stream).Secrets,
                        Scopes,
                        "user",
                        CancellationToken.None,
                        new FileDataStore(credPath, true)).Result;
                    Console.WriteLine("Credential file saved to: " + credPath);
                }
                var service1 = new BloggerService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = ApplicationName,
                });
                //var cache = new JObject();
                //cache.Add("name", FormData.appinfo.name +" "+ FormData.modinfo.modtype);

                Google.Apis.Blogger.v3.Data.Post post = new Post();
                post.Title = (string.IsNullOrWhiteSpace(res.titleprocRes) ? "" : res.titleprocRes);
                post.Labels = new List<string>();
                if (res.titleprocRes.ToLower().Contains("mod"))
                    post.Labels.Add("ModdedGames");
                else if (res.titleprocRes.ToLower().Contains("paid"))
                    post.Labels.Add("PaidGames");
                post.Content = !String.IsNullOrWhiteSpace(res.postHtml) ? res.postHtml : "";
                //post.CustomMetaData = "{\"Search_Description\" = \"" + (!String.IsNullOrWhiteSpace(res.searchproRes) ? res.searchproRes : "") + "\"}";
                //post.Labels.Add("A");
                
                PostsResource.InsertRequest request = service1.Posts.Insert(post, Class1.GetToken("offlinemodsID"));
                request.IsDraft = true;
                Post result = request.Execute();
                SystemAlt.Windows_Forms_Clipboard_SetText(!String.IsNullOrWhiteSpace(res.searchproRes) ? res.searchproRes : "");
                //System.Diagnostics.Process.Start("https://draft.blogger.com/blogger.g?blogID=" + Class1.GetToken("offlinemodsID") + "#editor/postID=" + result.Id);
                System.Diagnostics.Process.Start($"https://draft.blogger.com/blog/post/edit/{Class1.GetToken("offlinemodsID")}/{result.Id}");
                if (System.IO.Directory.Exists(CoreDirectory) && !string.IsNullOrEmpty(CoreDirectory) && CoreDirectory != Class1.GetToken("curdir"))
                    System.IO.Directory.Delete(CoreDirectory, true);
                Application.Exit();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public void LoadLocation()
        {
            /*{
                if (Properties.Settings.Default.newPostBlankPosition == new Point(996, 269))
                {
                    if (!(Screen.PrimaryScreen.Bounds.Width == 1536) && Screen.PrimaryScreen.Bounds.Height == 824)
                    {

                        if (DateTime.Now == new DateTime(2019, 01, 14))
                            MessageBox.Show("This is Defalt Setting");

                    }
                    else
                    {
                        //MessageBox.Show(Screen.PrimaryScreen.WorkingArea.Width+ " "+ Screen.PrimaryScreen.WorkingArea.Height);
                        Properties.Settings.Default.newPostBlankPosition = new Point(996 * Screen.PrimaryScreen.Bounds.Height / 824, 269 * Screen.PrimaryScreen.Bounds.Width / 1536);
                    }
                }
            }*/
            
        }
        private void FormResult_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show(e.KeyCode.ToString());
        }

        private void butTitle_Click(object sender, EventArgs e)
        {
            SystemAlt.Windows_Forms_Clipboard_SetText((string.IsNullOrWhiteSpace(res.titleprocRes)?"": res.titleprocRes));
            butPost.Focus();
            if (Properties.Settings.Default.OldStyle) { butTitle.Font = new Font(butTitle.Font, FontStyle.Underline); }
            else
            butTitle.ForeColor = Color.Yellow;
        }

        private void butSearch_Click(object sender, EventArgs e)
        {
            SystemAlt.Windows_Forms_Clipboard_SetText(!String.IsNullOrWhiteSpace(res.searchproRes)? res.searchproRes: "");
            if (Properties.Settings.Default.OldStyle) { butSearch.Font = new Font(butSearch.Font, FontStyle.Underline); }
            else
            butSearch.ForeColor = Color.Yellow;

        }

        private void FormResult_TextChanged(object sender, EventArgs e)
        {

        }

        private void butPost_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(res.postHtml);
            if(!String.IsNullOrWhiteSpace(res.postHtml))
                SystemAlt.Windows_Forms_Clipboard_SetText(res.postHtml);
            if (Properties.Settings.Default.OldStyle) {  butPost.Font = new Font(butPost.Font,FontStyle.Underline); }
            else
            butPost.ForeColor = Color.Yellow;
            butSearch.Focus();
        }

        private void butQuit_Click(object sender, EventArgs e)
        {
            back_call = true;
            this.Close();
        }

        private void FormResult_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            if (back_call)
            {

            }
            else
            {
                this.Hide();
                
                if (System.IO.Directory.Exists(CoreDirectory)&&!string.IsNullOrEmpty(CoreDirectory)&&CoreDirectory!=Class1.GetToken("curdir"))
                System.IO.Directory.Delete(CoreDirectory, true);
                System.Windows.Forms.Application.Exit();
            }
                                    //if (sender as Button != null)
                                    /* {
                                         if (string.Equals((sender as Button).Name, @"CloseButton"))
                                         {
                                             this.Hide();
                                             System.IO.Directory.Delete(CoreDirectory, true);
                                             System.Windows.Forms.Application.Exit();
                                         }
                                         else
                                         { }
                                     }*/
        }

        private void butTitle_EnabledChanged(object sender, EventArgs e)
        {
               butTitle.Visible = butTitle.Enabled;
            if (!butTitle.Visible)
            {
                butPost.Location = new Point(butPost.Location.X, butPost.Location.Y - butTitle.Size.Height);
                butSearch.Location = new Point(butSearch.Location.X, butSearch.Location.Y - butTitle.Size.Height);
                butQuit.Location = new Point(butQuit.Location.X, butQuit.Location.Y - butTitle.Size.Height);
                this.Size = new Size(this.Width, this.Height - butTitle.Size.Height);
            }
        }

        private void butSearch_EnabledChanged(object sender, EventArgs e)
        {
            butSearch.Visible = butSearch.Enabled;
            if (!butSearch.Visible)
            {
                
                
                butQuit.Location = new Point(butQuit.Location.X, butQuit.Location.Y - butSearch.Size.Height);
                this.Size = new Size(this.Width, this.Height - butSearch.Size.Height);
            }
        }

        private void butMore_Click(object sender, EventArgs e)
        {
            
        }

        private void whereIsThisFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this.Location.X+" "+this.Location.Y);
        }

        private void setAsDefaltLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // MessageBox.Show(Properties.Settings.Default.newPostBlankPosition.ToString());
           // Properties.Settings.Default.newPostBlankPosition = this.Location;
            Properties.Settings.Default.Save();
        }//996269

        private void butAutoPost_Click(object sender, EventArgs e)
        {
            SystemAlt.Windows_Forms_Clipboard_SetText(!String.IsNullOrWhiteSpace(res.postHtml) ? res.postHtml : "");
        }
    }
}
