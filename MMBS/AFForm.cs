using OpenQA.Selenium.DevTools.V105.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MMBS
{
    public partial class AFForm : Form
    {
        public string[] linkMaskConst = new string[] { "https://play.google.com","https://apkpure.com","https://userscloud.com","https://drive.google.com","https://123link.pro"};
        public string[] linkMaskText = new string[] { "Play://", "APKpure://", "UCloud://", "GDrive://", "123L://" };
        public PostDataBundle AFFinputer;
        public int _checkvarThreads=0;
        /// <summary>
        /// Number of Threads on Working<br/>
        /// If It's back to 0, the progress bar will disappear
        /// </summary>
        public int checkvarThreads
        {
            get => _checkvarThreads;
            set
            {
                _checkvarThreads = value;
                progressOnProc.Visible = _checkvarThreads != 0;
            }
        }
        public class LinkMaskDat
        {
            public string mask;
            public string data;
            public bool ismask;
            public LinkMaskDat(string link)
            {
                mask = link;
                data = link;
                ismask = false;
            }
        }
        /// <summary>
        /// For Form special setup only
        /// </summary>
        public void Initialize()
        {
            InitializeComponent();
            tipOne.SetToolTip(checkExtPerms, checkExtPerms.Checked ? "External Storage" : "Overlay");
        }
        public AFForm()
        {
            Initialize();
            if (Properties.Settings.Default.OldStyle) ThemeSystem.LoadOldStyle(this);
        }
        public AFForm(string cmd)
        {
            Initialize();
            if (Properties.Settings.Default.OldStyle) ThemeSystem.LoadOldStyle(this);
            AFFinputer = new PostDataBundle();
            switch (cmd)
            {
                case "new": ResetForm(); break;
            }
        }
        public AFForm(string cmd, PostDataBundle importdata)
        {
            Initialize();
            if (Properties.Settings.Default.OldStyle) ThemeSystem.LoadOldStyle(this);
            AFFinputer = new PostDataBundle();
            switch (cmd)
            {
                case "process": ResetForm(); AFFinputer = importdata; this.Shown+=RefreshData; break;
            }
        }
        public void ResetForm()
        {
            groupDS.Text = "Data Source";
            groupDL.Text = "Download";
            groupAO.Text = "OBB";
            butModInfo.Text = AFFinputer.modinfo.UI.modTypeGetname(AFFinputer.modinfo.UI.currentindex);
            if (!Properties.Settings.Default.OldStyle)
            butModInfo.ForeColor = AFFinputer.modinfo.UI.modTypegetcolor(AFFinputer.modinfo.UI.currentindex);
            boxModInfo.Enabled = AFFinputer.modinfo.UI.modTypeAllowData(AFFinputer.modinfo.UI.currentindex);
            boxModInfo.Text = AFFinputer.modinfo.UI.modTypeGetDat(AFFinputer.modinfo.UI.currentindex);
            boxDSlink.Text = AFFinputer.appinfo.datasource;
            boxDLlink.Text = AFFinputer.Downloadlink.Downloadlink.link;
            boxAOlink.Text = AFFinputer.Downloadlink.OBBlink.link;
            checkAPK.Checked = AFFinputer.Downloadlink.OBBlink.check;
            boxMirrorDLlink.Text = AFFinputer.Downloadlink.OMirrorlink.link;
            checkMirror.Checked = AFFinputer.Downloadlink.OMirrorlink.check;

            checkExtPerms.Checked = AFFinputer.appinfo.extpermReq;
            checkInternet.Checked = AFFinputer.appinfo.internetReq;
            checkRoot.Checked = AFFinputer.appinfo.rootReq;
            checkOBB.Checked = AFFinputer.appinfo.obbReq;
            labelValidDS.Visible = false;
            labelUnvalidDS.Visible = false;
            labelValidDL.Visible = false;
            labelUnvalidDL.Visible = false;
            labelValidAO.Visible = false;
            labelUnvalidAO.Visible = false;
            progressDS.Value = 0;
            progressDL.Value = 0;
            progressAO.Value = 0;
            linkDLname.Text = "";
            linkDLname.Visible = false;
            linkAOname.Text = "";
            linkAOname.Visible = false;
            butIcon.Image = (Properties.Resources.offlinemods_logo_pns);
            listCredit.Items.Clear();

            comboExportScript.SelectedIndex = 0;
                      ImportCreditList();
        }
        public void RefreshData(object sender, EventArgs e)
        {
            boxDSlink.Text = AFFinputer.appinfo.datasource;
            boxModInfo.Text = AFFinputer.modinfo.moddata;
            checkOBB.Checked = AFFinputer.appinfo.obbReq;
            checkRoot.Checked = AFFinputer.appinfo.rootReq;
            listCredit.SelectedIndex = AFFinputer.credit.nowIndex;
        }
        public void ImportCreditList()
        {
            int selected = 0;
            listCredit.Items.Clear();
            if (PostDataBundle.creditpack.CreditsList.list != null && PostDataBundle.creditpack.CreditsList.list.Count > 0)
            {
                foreach (PostDataBundle.creditpack.CreditsList.CreditItem credit in PostDataBundle.creditpack.CreditsList.list)
                {
                    listCredit.Items.Add(credit.GetPreview(true));
                }
            }
            listCredit.Items.Add("...other");
            listCredit.SelectedIndex = AFFinputer.credit.defIndex;
        }
        private void ShowWARNING()
        {
            Label Comming_Soon = new Label(); ;
            Size size = new Size();
            size.Width = 0;
            float i = 0;
            while (size.Width < this.Width)
            {
                size = TextRenderer.MeasureText("Comming soon", new System.Drawing.Font("Product Sans", ++i));
            }

            Comming_Soon.AutoSize = false;
            Comming_Soon.Font = new System.Drawing.Font("Product Sans", (i > 1 ? i - 1 : 10f));
            Comming_Soon.ForeColor = System.Drawing.Color.Red;
            Comming_Soon.Location = new System.Drawing.Point(1, (int)Math.Round((this.Height - TextRenderer.MeasureText("Comming soon", new System.Drawing.Font("Product Sans", i - 1)).Height) / 2f));
            Comming_Soon.Name = "commingsoonNotice";
            //this.Size.Height = TextRenderer.MeasureText("Comming soon", new System.Drawing.Font("Product Sans", ++i)).Height + 10;
            Comming_Soon.Size = new System.Drawing.Size(this.Width, this.Height);
            Comming_Soon.TabIndex = 13;
            Comming_Soon.Text = "Comming soon";
            Comming_Soon.Visible = true;

            this.Controls.Add(Comming_Soon);


            Comming_Soon.BringToFront();
        }
        private void butModInfo_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.OldStyle) { }
            else
            {
                this.butModInfo.ForeColor = AFFinputer.modinfo.UI.modTypegetcolor(AFFinputer.modinfo.UI.currentindex);
            }
                AFFinputer.modinfo.UI.currentindex = AFFinputer.modinfo.UI.Getnext();
                this.butModInfo.Text = AFFinputer.modinfo.UI.modTypeGetname(AFFinputer.modinfo.UI.currentindex);
                
                this.boxModInfo.Enabled = AFFinputer.modinfo.UI.modTypeAllowData(AFFinputer.modinfo.UI.currentindex);
                this.boxModInfo.Text = AFFinputer.modinfo.UI.modTypeGetDat(AFFinputer.modinfo.UI.currentindex);
            
        }
        public static string Proccontentcache;
        
        public void controlForm(string cmd, string param)
        {
            string[] cache = new string[] { param };
            //controlForm(cmd, cache);
        }
        /*private delegate void SetPropertyThreadSafeDelegate<TResult>(
    Control @this,
    Expression<Func<TResult>> property,
    TResult value);

        public static void SetPropertyThreadSafe<TResult>(
            this Control @this,
            Expression<Func<TResult>> property,
            TResult value)
        {
            var propertyInfo = (property.Body as MemberExpression).Member
                as PropertyInfo;

            if (propertyInfo == null ||
                !@this.GetType().IsSubclassOf(propertyInfo.ReflectedType) ||
                @this.GetType().GetProperty(
                    propertyInfo.Name,
                    propertyInfo.PropertyType) == null)
            {
                throw new ArgumentException("The lambda expression 'property' must reference a valid property on this Control.");
            }

            if (@this.InvokeRequired)
            {
                @this.Invoke(new SetPropertyThreadSafeDelegate<TResult>
                (SetPropertyThreadSafe),
                new object[] { @this, property, value });
            }
            else
            {
                @this.GetType().InvokeMember(
                    propertyInfo.Name,
                    BindingFlags.SetProperty,
                    null,
                    @this,
                    new object[] { value });
            }
        }*/
        public delegate void SetInformation(string cmd);
        public SetInformation InfoSeter = null;
        public SetInformation InfoSeterDown = null;
        public SetInformation InfoSeterAPK = null;
        public string datasource_webpage_cache;
        public void InfoSeterProc(string cmd)
        {
            string title = cmd.Contains("\n")?cmd.Remove(cmd.IndexOf('\n')):cmd;
            string param = cmd.Contains("\n") ? cmd.Substring(cmd.IndexOf('\n') + 1):cmd;
            switch (title)
            {
                case "groupDS text": groupDS.Text = param; break;
                case "checkDS label": labelValidDS.Visible = Convert.ToInt32(param)==1; labelUnvalidDS.Visible = (Convert.ToInt32(param) == 2); break;
                case "progressDS value": progressDS.Value = Convert.ToInt32(param);break;
                case "progressDS max": progressDS.Maximum = Convert.ToInt32(param);break;
                case "boxDSlink mask": boxDSlink.TextChanged -= boxDSlink_TextChanged;
                    boxDSlink.Text = param;
                    boxDSlink.TextChanged += boxDSlink_TextChanged;
                    break;
                case "butIcon image": butIcon.Image = param == "default" ? Properties.Resources.offlinemods_logo_pns : AFFinputer.appinfo.Icon.image; break;
                case "linkDLname text": linkDLname.Text = string.IsNullOrWhiteSpace(param)?"":param; break;
                case "linkAOname text": linkAOname.Text = string.IsNullOrWhiteSpace(param) ? "" : param; break;
                case "system savedata download size": AFFinputer.appinfo.sizeinbyte = Convert.ToInt64(param);break;
                case "checkDL label": labelValidDL.Visible = Convert.ToInt32(param) == 1; labelUnvalidDL.Visible = (Convert.ToInt32(param) == 2); break;
                case "checkAO label": labelValidAO.Visible = Convert.ToInt32(param) == 1; labelUnvalidAO.Visible = (Convert.ToInt32(param) == 2); break;
                case "checkAPK check": checkAPK.Checked = Convert.ToBoolean(param);break;

                case "checkvarThreads.+": checkvarThreads++;break;
                case "checkvarThreads.-": checkvarThreads--; break;
            }
            
        }
        public static string[] DSlabelText = new string[] { "Original APK", "Play Store","APKpure"};
        public void boxDSproc()
        {
            this.Invoke(InfoSeter,"checkvarThreads.+");
            OldProcessor.ProcessDataResourceTextBox processDataResourceTextBox = new OldProcessor.ProcessDataResourceTextBox(boxDSlink.Text);
            
            this.Invoke(InfoSeter, "checkDS label\n" + processDataResourceTextBox.valid.ToString());
            this.Invoke(InfoSeter, "progressDS value\n0");
            if (processDataResourceTextBox.valid==1)
            {
                
                AFFinputer.appinfo.packedname = processDataResourceTextBox.packagename;
                AFFinputer.appinfo.datasource = processDataResourceTextBox.link;
                AFFinputer.appinfo.datasourcepage = processDataResourceTextBox.webpage;
                AFFinputer.appinfo.Icon.link = processDataResourceTextBox.coverImagelink;
                AFFinputer.appinfo.Icon.dir = processDataResourceTextBox.coverImageDir;
                if (processDataResourceTextBox.coverImage!=null)
                AFFinputer.appinfo.Icon.image = processDataResourceTextBox.coverImage.image;
                AFFinputer.appinfo.Icon.enable = true;
                AFFinputer.folderlink = processDataResourceTextBox.cacheDir;
                AFFinputer.appinfo.datasourcetype = processDataResourceTextBox.host;
                AFFinputer.appinfo.datasourcemask = (processDataResourceTextBox.host == "play.google.com" ? DSlabelText[1] : (processDataResourceTextBox.host == "apkpure.com" ? DSlabelText[2] : ""));
                datasource_webpage_cache = processDataResourceTextBox.webpage;
                groupDS.Invoke(new MethodInvoker(delegate { groupDS.Text = (processDataResourceTextBox.host == "play.google.com" ? DSlabelText[1] : (processDataResourceTextBox.host == "apkpure.com" ? DSlabelText[2] : DSlabelText[0])); }));
                butIcon.Invoke(new MethodInvoker(delegate { butIcon.Image = processDataResourceTextBox.coverImageDir == "default" ? Properties.Resources.offlinemods_logo_pns : AFFinputer.appinfo.Icon.image; }));
              //  this.Invoke(InfoSeter, "groupDS text\n" + (processDataResourceTextBox.host == "play.google.com" ? DSlabelText[1] : (processDataResourceTextBox.host == "apkpure.com" ? DSlabelText[2] : DSlabelText[0])));
               // this.Invoke(InfoSeter, "butIcon image\n" + processDataResourceTextBox.coverImageDir);
            }
            else
            {
                this.Invoke(InfoSeter, "groupDS text\n" + DSlabelText[0]);
                this.Invoke(InfoSeter, "butIcon image\ndefault");
            }
            // controlForm("groupDS.Text Change",processDataResourceTextBox.packagename);
            this.Invoke(InfoSeter,"checkvarThreads.-");
        }
        private void boxDSlink_TextChanged(object sender, EventArgs e)
        {
           // if (String.IsNullOrWhiteSpace(e.ToString()))
           if (this.Created)
            {
                //MessageBox.Show(e.ToString());
                
                System.Threading.ThreadStart threadStart = new System.Threading.ThreadStart(boxDSproc);
                System.Threading.Thread interfacer = new System.Threading.Thread(threadStart);
                interfacer.Name = "DSlinkProc";
                InfoSeter = new SetInformation(InfoSeterProc);
                //interfacer.ApartmentState = System.Threading.ApartmentState.STA;
                interfacer.Start();
                
                
            }
        }
       // [STAThread]
        public void boxDLproc()
        {
            Console.WriteLine("checkinvoke");
            this.Invoke(InfoSeterDown,"checkvarThreads.+");
            Console.WriteLine("st");
            User_DebugSystem.Command(boxDLlink.Text);
            OldProcessor.ProcessDownloadLinkTextBox processDownloadLinkTextBox = new OldProcessor.ProcessDownloadLinkTextBox(boxDLlink.Text);
            User_DebugSystem.Command("call\nHoàn tất và nhập dữ liệu vào Form\n"+ (processDownloadLinkTextBox.valid==1 ?"Thành công":"Thất bại"));
            
            if (processDownloadLinkTextBox.valid > 0)
            {
                AFFinputer.appinfo.size = processDownloadLinkTextBox.fsize;
                AFFinputer.Downloadlink.Downloadlink.link = processDownloadLinkTextBox.link;
                AFFinputer.Downloadlink.Downloadlink.check = Convert.ToBoolean(processDownloadLinkTextBox.valid);
                AFFinputer.Downloadlink.Downloadlink.host = processDownloadLinkTextBox.host;
                
            }
            else if (!string.IsNullOrEmpty(processDownloadLinkTextBox.link))
            {
                string cache = Microsoft.VisualBasic.Interaction.InputBox("Server không được hỗ trợ\nVui lòng nhập kích thước file\n Nếu bỏ trống link sẽ không được xử lý\n Có thể điền dấu cách để xử lý", "Nhập kích thước file", "");
                if (!string.IsNullOrEmpty(cache))
                {
                    AFFinputer.appinfo.size = cache == " " ? "" : cache;
                    AFFinputer.Downloadlink.Downloadlink.link = processDownloadLinkTextBox.link;
                    AFFinputer.Downloadlink.Downloadlink.check = true;
                    AFFinputer.Downloadlink.Downloadlink.actived = false;
                    AFFinputer.Downloadlink.Downloadlink.host = processDownloadLinkTextBox.host;
                }
                else
                {
                    //Try to get Html Data
                    /* try
                    {
                        System.Net.WebClient webClient = new System.Net.WebClient();
                        string GetCache = webClient.DownloadString(boxDLlink.Text);
                        if (!string.IsNullOrWhiteSpace(GetCache))
                        {
                            this.Invoke(new MethodInvoker(delegate { Clipboard.SetText(GetCache); }));
                            MessageBox.Show("Catch Html Data For Clipboard");
                        }
                        if (boxDLlink.Text.Contains("4file.net"))
                        {

                        }
                    }
                    finally
                    {

                    }*/
                }
            }
            labelValidDL.Invoke(new MethodInvoker( delegate { labelValidDL.Visible = processDownloadLinkTextBox.valid == 1; }));
            labelUnvalidDL.Invoke(new MethodInvoker(delegate { labelUnvalidDL.Visible = processDownloadLinkTextBox.valid == 2; }));
            linkDLname.Invoke(new MethodInvoker(delegate { linkDLname.Text = processDownloadLinkTextBox.fname; }));
            //this.Invoke(InfoSeter, "checkDL label\n" + processDownloadLinkTextBox.valid);
            // this.Invoke(InfoSeter, "linkDLname text\n" + processDownloadLinkTextBox.fname);

            //labelValidDL.Visible = Convert.ToInt32(param) == 1; labelUnvalidDL.Visible = (Convert.ToInt32(param) == 2); break;

            // SetPropertyThreadSafe(labelValidDL,labelValidDL.Visible,);
            this.Invoke(InfoSeterDown, "checkvarThreads.-");
        }
        private void boxDLlink_TextChanged(object sender, EventArgs e)
        {
            if (this.Created)
            {
                System.Threading.ThreadStart threadStart = new System.Threading.ThreadStart(boxDLproc);
                System.Threading.Thread interfacer = new System.Threading.Thread(threadStart);
                interfacer.Name = "DLlinkProc";
                InfoSeterDown = new SetInformation(InfoSeterProc);
                interfacer.Start();
            }
        }
        public void boxAOproc()
        {
            this.Invoke(InfoSeterDown, "checkvarThreads.+");
            OldProcessor.ProcessDownloadLinkTextBox processAPKLinkTextBox = new OldProcessor.ProcessDownloadLinkTextBox(boxAOlink.Text,OldProcessor.ProcessDownloadLinkTextBox.request_code.SimpleInfo);
           /* this.Invoke(InfoSeter, "checkAO label\n" + processAPKLinkTextBox.valid);
            this.Invoke(InfoSeter, "linkAOname text\n" + processAPKLinkTextBox.fname);*/
            if (processAPKLinkTextBox.valid > 0)
            {
                AFFinputer.appinfo.size = AFFinputer.appinfo.size==""?processAPKLinkTextBox.fsize:AFFinputer.appinfo.size;
                AFFinputer.Downloadlink.OBBlink.link = processAPKLinkTextBox.link;
                AFFinputer.Downloadlink.OBBlink.check = Convert.ToBoolean(processAPKLinkTextBox.valid);
                AFFinputer.Downloadlink.OBBlink.host = processAPKLinkTextBox.host;
            }
            else if (!string.IsNullOrEmpty(processAPKLinkTextBox.link))
            {
                /*string cache = Microsoft.VisualBasic.Interaction.InputBox("Server không được hỗ trợ\nVui lòng nhập kích thước file vào đây\n Nếu bỏ trống link sẽ không được xử lý\n Có thể điền dấu cách \" \" để xử lý", "Nhập kích thước file", "");
                if (!string.IsNullOrEmpty(cache))*/
                Microsoft.VisualBasic.MsgBoxResult cache = Microsoft.VisualBasic.Interaction.MsgBox("Server không được hỗ trợ\nBạn có muốn giữ link này không?", Microsoft.VisualBasic.MsgBoxStyle.OkCancel,"LINK KHÁC");
                if (cache == Microsoft.VisualBasic.MsgBoxResult.Ok)
                {
                    AFFinputer.Downloadlink.OBBlink.link = processAPKLinkTextBox.link;
                    AFFinputer.Downloadlink.OBBlink.check = true;
                    AFFinputer.Downloadlink.OBBlink.host = processAPKLinkTextBox.host;
                }
            }
            labelValidAO.Invoke(new MethodInvoker(delegate { labelValidAO.Visible = processAPKLinkTextBox.valid == 1; }));
            labelUnvalidAO.Invoke(new MethodInvoker(delegate { labelUnvalidAO.Visible = processAPKLinkTextBox.valid == 2; }));
            linkAOname.Invoke(new MethodInvoker(delegate { linkAOname.Text = processAPKLinkTextBox.fname; }));
            this.Invoke(InfoSeterDown, "checkvarThreads.-");
        }
        private void boxAOlink_TextChanged(object sender, EventArgs e)
        {
            if (this.Created)
            {
                checkAPK.Checked = boxAOlink.Text != "";
                System.Threading.ThreadStart threadStart = new System.Threading.ThreadStart(boxAOproc);
                System.Threading.Thread interfacer = new System.Threading.Thread(threadStart);
                interfacer.Name = "AOlinkProc";
                InfoSeterDown = new SetInformation(InfoSeterProc);
                interfacer.Start();
            }
        }
        
        private async void butIcon_Click(object sender, EventArgs e)
        {
            this.Hide();
            DateTime counter = new DateTime();
            if (Properties.Settings.Default.PermformCheck) counter = DateTime.Now;
            
            OldProcessor.MainProcessor main = new OldProcessor.MainProcessor(datasource_webpage_cache, AFFinputer.appinfo.datasourcetype, AFFinputer.folderlink);
            AFFinputer.appinfo.name = main.title;
            AFFinputer.appinfo.version = main.version;
            AFFinputer.appinfo.miscellaneous = main.miscellaneous;
            AFFinputer.appinfo.androidReq = main.req;
            AFFinputer.postmedia.VideoReview.ImportFromLink(main.videolink,main.dir);
            AFFinputer.appinfo.Description.OldprocessInputProtocoForPlayProc(main.desc, main.Desc_Bold);
            AFFinputer.appinfo.Description.bold = true;
            AFFinputer.appinfo.Description.noline = true;
            AFFinputer.postmedia.ImageInScript = true;
            
            string cache;
            if (AFFinputer.Downloadlink.Downloadlink.host == "drive.google.com")
            {
                cache = OldProcessor.ProcSupporter.ShortenLink(AFFinputer.Downloadlink.Downloadlink.link);
                ///Special Process For megaurl shortenlink
                
                
                ///////
                AFFinputer.Downloadlink.Downloadlink.link = cache==""? AFFinputer.Downloadlink.Downloadlink.link:cache;
            }
            if (AFFinputer.Downloadlink.OBBlink.host == "drive.google.com")
            {
                cache = OldProcessor.ProcSupporter.ShortenLink(AFFinputer.Downloadlink.OBBlink.link);
                AFFinputer.Downloadlink.OBBlink.link = cache==""? AFFinputer.Downloadlink.OBBlink.link:cache;
                
            }
            if (AFFinputer.Downloadlink.OMirrorlink.link == "drive.google.com")
            {
                cache = OldProcessor.ProcSupporter.ShortenLink(AFFinputer.Downloadlink.OMirrorlink.link);
                AFFinputer.Downloadlink.OMirrorlink.link = cache == "" ? AFFinputer.Downloadlink.OMirrorlink.link : cache;

            }


            if (Properties.Settings.Default.PermformCheck)counter = DateTime.FromBinary(DateTime.Now.ToBinary() - counter.ToBinary());
            if (!Properties.Settings.Default.NoDownImage)
            {
                AFFinputer.postmedia.ImportImagelistFromImageDownloadList(main.image);
                if (!string.IsNullOrWhiteSpace(AFFinputer.folderlink) && (AFFinputer.folderlink != Class1.GetToken("curdir")))
                {
                    dialogFile.InitialDirectory = AFFinputer.folderlink.Replace('/','\\');
                    dialogFile.Title = ("Image Selection");
                    DialogResult imagelist = dialogFile.ShowDialog();
                    System.IO.FileInfo file;
                    foreach (string i in dialogFile.FileNames) { 
                        file = new System.IO.FileInfo(i); 
                        AFFinputer.postmedia.ImageList[Convert.ToInt32(file.Name.Remove(file.Name.LastIndexOf(".")).Replace("Screenshot ", ""))].enable = true; };
                }
            }
            //Required for recycle this Form
            else AFFinputer.postmedia.ResetImageList();
            
            if (Properties.Settings.Default.PermformCheck) MessageBox.Show("Process Done in "+counter.ToString("mm:ss.ffffff"));
            if (!Properties.Settings.Default.AFFskipFMF)
            {
                FMForm fmf = new FMForm(AFFinputer);
                switch (comboExportScript.Items[comboExportScript.SelectedIndex])
                {
                    case "Offlinemods Html Script": break;
                    case "PMT BBcode Script": fmf.execute("checkPublish:PMT"); break;
                }
                do
                {
                    fmf.needRecall = false;
                    
                    if (fmf.needRecall)
                    {
                        switch (fmf.RecallCmd.Key)
                        {
                            case "MegaWebBrowserGet":
                                
                                    
                                
                                break;
                        }
                    }
                    fmf.ShowDialog();
                }
                while (fmf.needRecall);
                this.Show();
            }
            else
            {
                string[] cacheSList = MMBStool.SearchKeywordGenerator.AnameAnalyse(AFFinputer.appinfo.name);
                AFFinputer.appinfo.searchkeyword = "";
                foreach (string cache2 in cacheSList)
                {
                    AFFinputer.appinfo.searchkeyword += cache2 + "\n";
                }
                var res = new CustomizePostResult();
                res.SimpleProcess(AFFinputer);
                ApisCall.BloggerAPI api = new ApisCall.BloggerAPI(Class1.GetToken("offlinemodsID"));
                api.NewPost(res.titleprocRes,res.postHtml,new string[] {(AFFinputer.modinfo.UI.currentindex == 0? "ModdedGames" : "PaidGames") },"{\n\"search_description\" = "+res.searchproRes+"\n}");
                api.SendPost(true);

                

                MessageBox.Show("Process All Done");
                SystemAlt.Windows_Forms_Clipboard_SetText(!String.IsNullOrWhiteSpace(res.searchproRes) ? res.searchproRes : "");
                api.OpenPostInBrowser();
                if (System.IO.Directory.Exists(AFFinputer.folderlink) && !string.IsNullOrEmpty(AFFinputer.folderlink) && AFFinputer.folderlink != Class1.GetToken("curdir"))
                    System.IO.Directory.Delete(AFFinputer.folderlink, true);
                System.Windows.Forms.Application.Exit();
                this.Show();
            }
        }

        private void dialogFile_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void boxModInfo_TextChanged(object sender, EventArgs e)
        {
            AFFinputer.modinfo.UI.modTypeSetData(boxModInfo.Text, AFFinputer.modinfo.UI.currentindex);
        }

        private void checkInternet_CheckedChanged(object sender, EventArgs e)
        {
            AFFinputer.appinfo.internetReq = checkInternet.Checked;
           
        }

        private void checkRoot_CheckedChanged(object sender, EventArgs e)
        {
            AFFinputer.appinfo.rootReq = checkRoot.Checked;
        }

        private void checkOBB_CheckedChanged(object sender, EventArgs e)
        {
            AFFinputer.appinfo.obbReq = checkOBB.Checked;
        }

        private void checkAPK_CheckedChanged(object sender, EventArgs e)
        {
            AFFinputer.Downloadlink.OBBlink.check = checkAPK.Checked;
        }
        public string processDisplayFileName(string fname, Font font, Size SizeLimit)
        {
            if (!string.IsNullOrEmpty(fname))
            {
                Size size = TextRenderer.MeasureText(fname, font);
                if (size.Width <= SizeLimit.Width) { return fname; }
                else
                {
                    if (fname.Contains("."))
                    {
                        string ext = fname.Substring(fname.LastIndexOf("."));
                        size = TextRenderer.MeasureText(".." + ext, font);
                        if (size.Width < SizeLimit.Width)
                        {
                            for (int i = 1; i <= fname.Length; i++)
                            {
                                size = TextRenderer.MeasureText(fname.Remove(i) + ".." + ext, font);
                                if (size.Width > SizeLimit.Width) return (fname.Remove(i - 1) + ".." + ext);
                            }
                        }
                    }
                    for (int i = 1; i <= fname.Length; i++)
                    {
                        size = TextRenderer.MeasureText(fname.Remove(i) + "...", font);
                        if (size.Width > SizeLimit.Width) return (fname.Remove(i - 1) + "...");
                    }

                }
            }
            return "";
        }
        private void linkDLname_TextChanged(object sender, EventArgs e)
        {
            linkDLname.Visible = !String.IsNullOrWhiteSpace(linkDLname.Text);
            Size size = TextRenderer.MeasureText(linkDLname.Text, linkDLname.Font);
            if (size.Width > linkDLname.MaximumSize.Width)
            {
                linkDLname.Text = processDisplayFileName(linkDLname.Text, linkDLname.Font, linkDLname.MaximumSize);
                //size = TextRenderer.MeasureText(linkDLname.Text, linkDLname.Font);
            }
            else
            {
                linkDLname.Location = new Point(239 + 98 - (size.Width < linkDLname.MaximumSize.Width ? size.Width : linkDLname.MaximumSize.Width), linkDLname.Location.Y);
                linkDLname.LinkArea = new LinkArea(0, linkDLname.Text.Length);
            }
             
        }

        private void linkAOname_TextChanged(object sender, EventArgs e)
        {
            linkAOname.Visible = !String.IsNullOrWhiteSpace(linkAOname.Text);
            Size size = TextRenderer.MeasureText(linkAOname.Text, linkAOname.Font);
            if (size.Width > linkAOname.MaximumSize.Width)
            {
                linkAOname.Text = processDisplayFileName(linkAOname.Text, linkAOname.Font, linkAOname.MaximumSize);
                //size = TextRenderer.MeasureText(linkDLname.Text, linkDLname.Font);
            }
            else
            {
                linkAOname.Location = new Point(233 + 103 - (size.Width < linkAOname.MaximumSize.Width ? size.Width : linkAOname.MaximumSize.Width), linkAOname.Location.Y);
                linkAOname.LinkArea = new LinkArea(0, linkAOname.Text.Length);
            }
        }

        private void linkDLname_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if ((labelValidDL.Visible || labelUnvalidDL.Visible) && !string.IsNullOrWhiteSpace(boxDLlink.Text))
            {
                System.Diagnostics.Process.Start(boxDLlink.Text);
            }
        }

        private void butMDL_Click(object sender, EventArgs e)
        {
            if (AFFinputer.Downloadlink.linklist.Count < 1) AFFinputer.Downloadlink.linklist.Add(new DefineInfoPack.Linker("download"));
            AFFinputer.Downloadlink.linklist[0].linkalias = "Unsigned";
            OldProcessor.MirrorLink DLmirror = new OldProcessor.MirrorLink( AFFinputer.Downloadlink.linklist[0].linkalias, AFFinputer.Downloadlink.linklist[0].link);
            this.butMDL.Text = DLmirror.valid > 0 ? (DLmirror.valid == 1 ? "✓" : "✗") : "+";
            this.butMDL.ForeColor = DLmirror.valid > 0 ? (DLmirror.valid == 1 ? System.Drawing.Color.Lime : Color.Red) : Color.White;
            if (DLmirror.valid == 1)
            {
                AFFinputer.Downloadlink.linklist[0].link = DLmirror.host == "drive.google.com" ? OldProcessor.ProcSupporter.ShortenLink(DLmirror.link) : DLmirror.link;
                AFFinputer.Downloadlink.linklist[0].linkalias = DLmirror.name;
                AFFinputer.Downloadlink.linklist[0].host = DLmirror.host;

                //tempcode 211016 signed/unsigned
                AFFinputer.Downloadlink.linklist[0].linkalias = AFFinputer.Downloadlink.Downloadlink.linkalias == "Signed" ? "Unsigned" : AFFinputer.Downloadlink.linklist[0].linkalias;
                checkSign.Checked = true;
            }
            else
            {
                AFFinputer.Downloadlink.linklist[0].link = "";
                AFFinputer.Downloadlink.linklist[0].linkalias = "";
                AFFinputer.Downloadlink.linklist[0].host = "";
            }

            
        }

        private void butMAO_Click(object sender, EventArgs e)
        {
            if (AFFinputer.Downloadlink.linklist.Count == 0) AFFinputer.Downloadlink.linklist.Add(new DefineInfoPack.Linker("download"));
            if (AFFinputer.Downloadlink.linklist.Count == 1) AFFinputer.Downloadlink.linklist.Add(new DefineInfoPack.Linker("obb"));
            
            OldProcessor.MirrorLink AOmirror = new OldProcessor.MirrorLink(AFFinputer.Downloadlink.linklist[1].linkalias, AFFinputer.Downloadlink.linklist[1].link);
            this.butMAO.Text = AOmirror.valid > 0 ? (AOmirror.valid == 1 ? "✓" : "✗") : "+";
            this.butMAO.ForeColor = AOmirror.valid > 0 ? (AOmirror.valid == 1 ? System.Drawing.Color.Lime : Color.Red) : Color.White;
            if (AOmirror.valid == 1)
            {
                AFFinputer.Downloadlink.linklist[1].link = AOmirror.host == "drive.google.com" ? OldProcessor.ProcSupporter.ShortenLink(AOmirror.link) : AOmirror.link;
                AFFinputer.Downloadlink.linklist[1].linkalias = AOmirror.name;
                AFFinputer.Downloadlink.linklist[1].host = AOmirror.host;
            }
            else
            {
                AFFinputer.Downloadlink.linklist[1].link = "";
                AFFinputer.Downloadlink.linklist[1].linkalias = "";
                AFFinputer.Downloadlink.linklist[1].host = "";
            }
        }

        private void linkAOname_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if ((labelValidAO.Visible || labelUnvalidAO.Visible) && !string.IsNullOrWhiteSpace(boxAOlink.Text))
            {
                System.Diagnostics.Process.Start(boxAOlink.Text);
            }
        }

        private void skipFMFToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void skipFMFToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            //Properties.Settings.Default.Save();
        }

        private void skipFMFToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Properties.Settings.Default.AFFskipFMF = skipFMFToolStripMenuItem.Checked;
        }

        private void ListCredit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listCredit.SelectedIndex == -1)
            {

            }
            else if (listCredit.SelectedIndex == listCredit.Items.Count-1)
            {
                string cache = Microsoft.VisualBasic.Interaction.InputBox("Vui lòng nhập Credit.\nGợi ý Format: [Tên] ([Tên website])", "Credit Input");
                if (!string.IsNullOrEmpty(cache))
                {
                    if (cache.Contains(" (") && cache.Contains(")") && cache.LastIndexOf("(") < cache.LastIndexOf(")") && cache.Trim(' ').LastIndexOf(")") == cache.Trim().Count() - 1)
                    {
                        string mini = cache.Substring(cache.LastIndexOf("(") + 1).Trim(' ');
                        mini = mini.Remove(mini.Count() - 1);
                        PostDataBundle.creditpack.CreditsList.New(cache.Remove(cache.LastIndexOf("(")).Trim(' '), mini);
                    }
                    else
                        PostDataBundle.creditpack.CreditsList.New(cache, "");
                    ImportCreditList();
                    listCredit.SelectedIndex = listCredit.Items.Count - 2;
                    AFFinputer.credit.SaveData();
                }
            }
            else
            {
                AFFinputer.credit.nowIndex = listCredit.SelectedIndex;
                AFFinputer.credit.now = PostDataBundle.creditpack.CreditsList.list[listCredit.SelectedIndex];
            }
        }

        private void WebBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
           
        }

        private void AFForm_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.Shift | Keys.V))
            {
                MessageBox.Show($"App Version: {Properties.Settings.Default.appver}");
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void MenuClipboard_Opening(object sender, CancelEventArgs e)
        {
            if (Clipboard.ContainsText())
                if (!(string.IsNullOrWhiteSpace(Clipboard.GetText())))
                {
                    


                    foreach (ToolStripItem cache in menuClipboard.Items) if (cache.Text == Clipboard.GetText()) return;
                    if (menuClipboard.Items.Count == 0) isFirstClipboardMenuOpen = true ;
                    menuClipboard.Items.Add(Clipboard.GetText());
                }

        }

        private void MenuClipboard_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ((ContextMenuStrip)sender).SourceControl.Text = e.ClickedItem.Text;
        }
        public bool isFirstClipboardMenuOpen = false;

        private void stripNoDownImage_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.NoDownImage = stripNoDownImage.Checked;
        }

        private void checkExtPerms_CheckedChanged(object sender, EventArgs e)
        {
            AFFinputer.appinfo.extpermReq = checkExtPerms.Checked;
            tipOne.SetToolTip(checkExtPerms, checkExtPerms.Checked ? "External Storage" : "Overlay");

        }

        private void comboExportScript_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
        }

        private void checkNoImgs_Syswarn_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.NoDownImage = checkNoImgs_Syswarn.Checked;
        }

        private void checkSign_CheckedChanged(object sender, EventArgs e)
        {
            //todo:on progress
            groupDL.Text = checkSign.Checked ? "Signed" : "Download";
            checkRoot.Checked = checkSign.Checked;
            //checkRoot.CheckState = CheckState.Indeterminate;
            checkRoot.Enabled = !checkSign.Checked;
        }

        private void groupDL_TextChanged(object sender, EventArgs e)
        {
            AFFinputer.Downloadlink.Downloadlink.linkalias = groupDL.Text;
        }

        private void checkRoot_CheckStateChanged(object sender, EventArgs e)
        {

        }

        private void groupAO_Enter(object sender, EventArgs e)
        {

        }

        private void AFForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void boxMirrorDLlink_TextChanged(object sender, EventArgs e)
        {
            //todo:Third Download Box
            if (this.Created)
            {
                checkMirror.Checked = boxMirrorDLlink.Text != "";
                System.Threading.ThreadStart threadStart = new System.Threading.ThreadStart(boxMirrorDLproc);
                System.Threading.Thread interfacer = new System.Threading.Thread(threadStart);
                interfacer.Name = "MirrorlinkProc";
                InfoSeterDown = new SetInformation(InfoSeterProc);
                interfacer.Start();
            }
        }
        public void boxMirrorDLproc()
        {
            this.Invoke(InfoSeterDown, "checkvarThreads.+");
            OldProcessor.ProcessDownloadLinkTextBox processMirrorLinkTextBox = new OldProcessor.ProcessDownloadLinkTextBox(boxMirrorDLlink.Text, OldProcessor.ProcessDownloadLinkTextBox.request_code.SimpleInfo);
            /* this.Invoke(InfoSeter, "checkAO label\n" + processAPKLinkTextBox.valid);
             this.Invoke(InfoSeter, "linkAOname text\n" + processAPKLinkTextBox.fname);*/
            if (processMirrorLinkTextBox.valid > 0)
            {
                AFFinputer.appinfo.size = AFFinputer.appinfo.size == "" ? processMirrorLinkTextBox.fsize : AFFinputer.appinfo.size;
                AFFinputer.Downloadlink.OMirrorlink.link = processMirrorLinkTextBox.link;
                AFFinputer.Downloadlink.OMirrorlink.check = Convert.ToBoolean(processMirrorLinkTextBox.valid);
                AFFinputer.Downloadlink.OMirrorlink.host = processMirrorLinkTextBox.host;
            }
            else if (!string.IsNullOrEmpty(processMirrorLinkTextBox.link))
            {
                /*string cache = Microsoft.VisualBasic.Interaction.InputBox("Server không được hỗ trợ\nVui lòng nhập kích thước file vào đây\n Nếu bỏ trống link sẽ không được xử lý\n Có thể điền dấu cách \" \" để xử lý", "Nhập kích thước file", "");
                if (!string.IsNullOrEmpty(cache))*/
                Microsoft.VisualBasic.MsgBoxResult cache = Microsoft.VisualBasic.Interaction.MsgBox("Server không được hỗ trợ\nBạn có muốn giữ link này không?", Microsoft.VisualBasic.MsgBoxStyle.OkCancel, "LINK KHÁC");
                if (cache == Microsoft.VisualBasic.MsgBoxResult.Ok)
                {
                    AFFinputer.Downloadlink.OMirrorlink.link = processMirrorLinkTextBox.link;
                    AFFinputer.Downloadlink.OMirrorlink.check = true;
                    AFFinputer.Downloadlink.OMirrorlink.host = processMirrorLinkTextBox.host;
                }
            }
            labelValidMirrorDL.Invoke(new MethodInvoker(delegate { labelValidMirrorDL.Visible = processMirrorLinkTextBox.valid == 1; }));
            labelUnvalidMirrorDL.Invoke(new MethodInvoker(delegate { labelUnvalidMirrorDL.Visible = processMirrorLinkTextBox.valid == 2; }));
            linkMirrorDownload.Invoke(new MethodInvoker(delegate { linkMirrorDownload.Text = processMirrorLinkTextBox.fname; }));
            this.Invoke(InfoSeterDown, "checkvarThreads.-");
        }

        private void AFForm_MouseHover(object sender, EventArgs e) {
            
        }

        private void AFForm_MouseEnter(object sender, EventArgs e) {
            this.Activate();
        }
    }
}
