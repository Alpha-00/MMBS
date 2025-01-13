using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MMBS.Misc_Form;

namespace MMBS
{
    public partial class AFForm : Form
    {
        public string[] linkMaskConst = new string[] { "https://play.google.com","https://apkpure.com","https://userscloud.com","https://drive.google.com","https://123link.pro"};
        public string[] linkMaskText = new string[] { "Play://", "APKpure://", "UCloud://", "GDrive://", "123L://" };
        public PostDataBundle formData;
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
            modDescQuickEditor.VisibleChanged += modDescQuickEditor_VisibleChanged;
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
            formData = new PostDataBundle();
            switch (cmd)
            {
                case "new": ResetForm(); break;
            }
        }
        public AFForm(string cmd, PostDataBundle importdata)
        {
            Initialize();
            if (Properties.Settings.Default.OldStyle) ThemeSystem.LoadOldStyle(this);
            formData = new PostDataBundle();
            switch (cmd)
            {
                case "process": ResetForm(); formData = importdata; this.Shown+=RefreshData; break;
            }
        }
        public void ResetForm()
        {
            groupDS.Text = "Data Source";
            groupDL.Text = "Download";
            groupAO.Text = "OBB";
            butModInfo.Text = formData.modInfo.UI.modTypeGetname(formData.modInfo.UI.currentindex);
            if (!Properties.Settings.Default.OldStyle)
            butModInfo.ForeColor = formData.modInfo.UI.modTypegetcolor(formData.modInfo.UI.currentindex);
            boxModInfo.Enabled = formData.modInfo.UI.modTypeAllowData(formData.modInfo.UI.currentindex);
            boxModInfo.Text = formData.modInfo.UI.modTypeGetDat(formData.modInfo.UI.currentindex);
            boxDSlink.Text = formData.appInfo.datasource;
            boxDLlink.Text = formData.downloadlink.Downloadlink.link;
            boxAOlink.Text = formData.downloadlink.OBBlink.link;
            checkAPK.Checked = formData.downloadlink.OBBlink.check;
            boxMirrorDLlink.Text = formData.downloadlink.OMirrorlink.link;
            checkMirror.Checked = formData.downloadlink.OMirrorlink.check;

            checkExtPerms.Checked = formData.appInfo.extpermReq;
            checkInternet.Checked = formData.appInfo.internetReq;
            checkRoot.Checked = formData.appInfo.rootReq;
            checkArmv8a.Checked = formData.appInfo.armv8aReq;
            checkOBB.Checked = formData.appInfo.obbReq;
            checkMenu.Checked = formData.appInfo.menuModFlag;
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
            comboSourceQuery.SelectedIndex = 0;
        }
        public void RefreshData(object sender, EventArgs e)
        {
            boxDSlink.Text = formData.appInfo.datasource;
            boxModInfo.Text = formData.modInfo.moddata;
            checkOBB.Checked = formData.appInfo.obbReq;
            checkRoot.Checked = formData.appInfo.rootReq;
            checkArmv8a.Checked = formData.appInfo.armv8aReq;
            checkMenu.Checked = formData.appInfo.menuModFlag;
            listCredit.SelectedIndex = formData.credit.nowIndex;
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
            listCredit.SelectedIndex = formData.credit.defIndex;
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
                this.butModInfo.ForeColor = formData.modInfo.UI.modTypegetcolor(formData.modInfo.UI.currentindex);
            }
                formData.modInfo.UI.currentindex = formData.modInfo.UI.Getnext();
                this.butModInfo.Text = formData.modInfo.UI.modTypeGetname(formData.modInfo.UI.currentindex);
                
                this.boxModInfo.Enabled = formData.modInfo.UI.modTypeAllowData(formData.modInfo.UI.currentindex);
                this.boxModInfo.Text = formData.modInfo.UI.modTypeGetDat(formData.modInfo.UI.currentindex);
            
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
                case "butIcon image": butIcon.Image = param == "default" ? Properties.Resources.offlinemods_logo_pns : formData.appInfo.icon.image; break;
                case "linkDLname text": linkDLname.Text = string.IsNullOrWhiteSpace(param)?"":param; break;
                case "linkAOname text": linkAOname.Text = string.IsNullOrWhiteSpace(param) ? "" : param; break;
                case "system savedata download size": formData.appInfo.sizeinbyte = Convert.ToInt64(param);break;
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
            String queryText = "";
            comboSourceQuery.Invoke(new MethodInvoker(delegate() { queryText = comboSourceQuery.Text; }));
            this.Invoke(InfoSeter,"checkvarThreads.+");
            OldProcessor.ProcessDataResourceTextBox processDataResourceTextBox = new OldProcessor.ProcessDataResourceTextBox(boxDSlink.Text, queryText);
            
            this.Invoke(InfoSeter, "checkDS label\n" + processDataResourceTextBox.valid.ToString());
            this.Invoke(InfoSeter, "progressDS value\n0");
            if (processDataResourceTextBox.valid==1)
            {
                
                formData.appInfo.packageName = processDataResourceTextBox.packagename;
                formData.appInfo.datasource = processDataResourceTextBox.link;
                formData.appInfo.datasourcepage = processDataResourceTextBox.webpage;
                formData.appInfo.icon.link = processDataResourceTextBox.coverImageLink;
                formData.appInfo.icon.dir = processDataResourceTextBox.coverImageDir;
                if (processDataResourceTextBox.coverImage!=null)
                formData.appInfo.icon.image = processDataResourceTextBox.coverImage.image;
                formData.appInfo.icon.enable = true;
                formData.folderlink = processDataResourceTextBox.cacheDir;
                formData.appInfo.datasourcetype = processDataResourceTextBox.host;
                formData.appInfo.datasourcemask = (processDataResourceTextBox.host == "play.google.com" ? DSlabelText[1] : (processDataResourceTextBox.host == "apkpure.com" ? DSlabelText[2] : ""));
                datasource_webpage_cache = processDataResourceTextBox.webpage;
                groupDS.Invoke(new MethodInvoker(delegate { groupDS.Text = (processDataResourceTextBox.host == "play.google.com" ? DSlabelText[1] : (processDataResourceTextBox.host == "apkpure.com" ? DSlabelText[2] : DSlabelText[0])); }));
                butIcon.Invoke(new MethodInvoker(delegate { butIcon.Image = processDataResourceTextBox.coverImageDir == "default" ? Properties.Resources.offlinemods_logo_pns : formData.appInfo.icon.image; }));
              //  this.Invoke(InfoSeter, "groupDS text\n" + (processDataResourceTextBox.host == "play.google.com" ? DSlabelText[1] : (processDataResourceTextBox.host == "apkpure.com" ? DSlabelText[2] : DSlabelText[0])));
               // this.Invoke(InfoSeter, "butIcon image\n" + processDataResourceTextBox.coverImageDir);
            }
            else
            {
                this.Invoke(InfoSeter, "groupDS text\n" + DSlabelText[0]);
                this.Invoke(InfoSeter, "butIcon image\ndefault");
            }
            // controlForm("groupDS.Text Change",processDataResourceTextBox.packageName);
            this.Invoke(InfoSeter,"checkvarThreads.-");
        }
        private void boxDSlink_TextChanged(object sender, EventArgs e)
        {
            if (!this.Created) return;
           // if (String.IsNullOrWhiteSpace(e.ToString()))
           
                //MessageBox.Show(e.ToString());
                
                System.Threading.ThreadStart threadStart = new System.Threading.ThreadStart(boxDSproc);
                System.Threading.Thread interfacer = new System.Threading.Thread(threadStart);
                interfacer.Name = "DSlinkProc";
                InfoSeter = new SetInformation(InfoSeterProc);
                //interfacer.ApartmentState = System.Threading.ApartmentState.STA;
                interfacer.Start();
                
             
            if (this.boxDSlink.Text.Contains("apple.com"))
            {
                checkRoot.Text = "Jailbreak";
                checkOBB.Text = "icon";
                checkInternet.Visible = false;
                checkExtPerms.Visible = false;
                
            }
            else 
            { 
                checkRoot.Text = "Root";
                checkOBB.Text = "Obb";
                checkInternet.Visible = true;
                checkExtPerms.Visible = true;
            }
            // Not visible by default
            //comboSourceQuery.Visible = this.boxDSlink.Text.Contains("play.google.com");
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
                formData.appInfo.size = processDownloadLinkTextBox.fsize;
                formData.downloadlink.Downloadlink.link = processDownloadLinkTextBox.link;
                formData.downloadlink.Downloadlink.check = Convert.ToBoolean(processDownloadLinkTextBox.valid);
                formData.downloadlink.Downloadlink.host = processDownloadLinkTextBox.host;
                
            }
            else if (!string.IsNullOrEmpty(processDownloadLinkTextBox.link))
            {
                string cache = Microsoft.VisualBasic.Interaction.InputBox("Server không được hỗ trợ\nVui lòng nhập kích thước file\n Nếu bỏ trống link sẽ không được xử lý\n Có thể điền dấu cách để xử lý", "Nhập kích thước file", "");
                if (!string.IsNullOrEmpty(cache))
                {
                    formData.appInfo.size = cache == " " ? "" : cache;
                    formData.downloadlink.Downloadlink.link = processDownloadLinkTextBox.link;
                    formData.downloadlink.Downloadlink.check = true;
                    formData.downloadlink.Downloadlink.actived = false;
                    formData.downloadlink.Downloadlink.host = processDownloadLinkTextBox.host;
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
                formData.appInfo.size = formData.appInfo.size==""?processAPKLinkTextBox.fsize:formData.appInfo.size;
                formData.downloadlink.OBBlink.link = processAPKLinkTextBox.link;
                formData.downloadlink.OBBlink.check = Convert.ToBoolean(processAPKLinkTextBox.valid);
                formData.downloadlink.OBBlink.host = processAPKLinkTextBox.host;
            }
            else if (!string.IsNullOrEmpty(processAPKLinkTextBox.link))
            {
                /*string cache = Microsoft.VisualBasic.Interaction.InputBox("Server không được hỗ trợ\nVui lòng nhập kích thước file vào đây\n Nếu bỏ trống link sẽ không được xử lý\n Có thể điền dấu cách \" \" để xử lý", "Nhập kích thước file", "");
                if (!string.IsNullOrEmpty(cache))*/
                Microsoft.VisualBasic.MsgBoxResult cache = Microsoft.VisualBasic.Interaction.MsgBox("Server không được hỗ trợ\nBạn có muốn giữ link này không?", Microsoft.VisualBasic.MsgBoxStyle.OkCancel,"LINK KHÁC");
                if (cache == Microsoft.VisualBasic.MsgBoxResult.Ok)
                {
                    formData.downloadlink.OBBlink.link = processAPKLinkTextBox.link;
                    formData.downloadlink.OBBlink.check = true;
                    formData.downloadlink.OBBlink.host = processAPKLinkTextBox.host;
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
            
            OldProcessor.MainProcessor main = new OldProcessor.MainProcessor(datasource_webpage_cache, formData.appInfo.datasourcetype, formData.folderlink);
            formData.appInfo.name = main.title;
            formData.appInfo.version = main.version;
            formData.appInfo.miscellaneous = main.miscellaneous;
            formData.appInfo.androidReq = main.req;
            formData.postMedia.VideoReview.ImportFromLink(main.videolink,main.dir);
            formData.appInfo.description.OldprocessInputProtocoForPlayProc(main.desc, main.Desc_Bold);
            formData.appInfo.description.bold = true;
            formData.appInfo.description.noline = true;
            formData.postMedia.ImageInScript = true;
            
            string cache;
            // Download link box shortening
            if (formData.downloadlink.Downloadlink.host == "drive.google.com")
            {
                cache = OldProcessor.ProcSupporter.ShortenLink(formData.downloadlink.Downloadlink.link);
                //Special Process For megaurl shortenlink
                
                
                ///////
                formData.downloadlink.Downloadlink.link = cache==""? formData.downloadlink.Downloadlink.link:cache;
            }
            if (formData.downloadlink.OBBlink.host == "drive.google.com")
            {
                cache = OldProcessor.ProcSupporter.ShortenLink(formData.downloadlink.OBBlink.link);
                formData.downloadlink.OBBlink.link = cache==""? formData.downloadlink.OBBlink.link:cache;
                
            }
            if (formData.downloadlink.OMirrorlink.link == "drive.google.com")
            {
                cache = OldProcessor.ProcSupporter.ShortenLink(formData.downloadlink.OMirrorlink.link);
                formData.downloadlink.OMirrorlink.link = cache == "" ? formData.downloadlink.OMirrorlink.link : cache;

            }
            // Mirror Link box shortening
            if (!String.IsNullOrEmpty(formData.downloadlink.OBBlink.link))
            {
                cache = OldProcessor.ProcSupporter.ShortenLink(formData.downloadlink.OBBlink.link);
                formData.downloadlink.OBBlink.link = cache == "" ? formData.downloadlink.OBBlink.link : cache;
            }
            if (!String.IsNullOrEmpty(formData.downloadlink.OMirrorlink.link)){
                cache = OldProcessor.ProcSupporter.ShortenLink(formData.downloadlink.OMirrorlink.link);
                formData.downloadlink.OMirrorlink.link = cache == "" ? formData.downloadlink.OMirrorlink.link : cache;
            }
            if (formData.downloadlink.linklist.Count > 0)
            {
                for (int i = 0; i<formData.downloadlink.linklist.Count; i++)
                {
                    cache = OldProcessor.ProcSupporter.ShortenLink(formData.downloadlink.OMirrorlink.link);
                    formData.downloadlink.linklist[i].link = cache == "" ? formData.downloadlink.OMirrorlink.link : cache;
                }
            }
            if (Properties.Settings.Default.PermformCheck)counter = DateTime.FromBinary(DateTime.Now.ToBinary() - counter.ToBinary());
            if (!Properties.Settings.Default.NoDownImage)
            {
                formData.postMedia.ImportImagelistFromImageDownloadList(main.image);
                if (!string.IsNullOrWhiteSpace(formData.folderlink) && (formData.folderlink != Class1.GetToken("curdir")))
                {
                    dialogFile.InitialDirectory = formData.folderlink.Replace('/','\\');
                    var screenshotCount = Directory.GetFiles(dialogFile.InitialDirectory).Count((item) => Regex.IsMatch(item, @"\\Screenshot \d+\..{1,4}$"));
                    if (screenshotCount>0)
                    {

                        dialogFile.Title = ("Image Selection");
                        DialogResult imagelist = dialogFile.ShowDialog();
                        System.IO.FileInfo file;
                        foreach (string i in dialogFile.FileNames)
                        {
                            file = new System.IO.FileInfo(i);
                            formData.postMedia.ImageList[Convert.ToInt32(file.Name.Remove(file.Name.LastIndexOf(".")).Replace("Screenshot ", ""))].enable = true;
                        };
                    }
                }
            }
            //Required for recycle this Form
            else formData.postMedia.ResetImageList();
            
            if (Properties.Settings.Default.PermformCheck) MessageBox.Show("Process Done in "+counter.ToString("mm:ss.ffffff"));
            if (!Properties.Settings.Default.AFFskipFMF)
            {
                FMForm fmf = new FMForm(formData);
                switch (comboExportScript.Items[comboExportScript.SelectedIndex])
                {
                    case "Html Script": break;
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
                string[] cacheSList = MMBStool.SearchKeywordGenerator.AnameAnalyse(formData.appInfo.name);
                formData.appInfo.searchkeyword = "";
                foreach (string cache2 in cacheSList)
                {
                    formData.appInfo.searchkeyword += cache2 + "\n";
                }
                var res = new CustomizePostResult();
                res.SimpleProcess(formData);
                ApiService.BloggerAPI api = new ApiService.BloggerAPI(Class1.GetToken("offlinemodsID"));
                api.NewPost(res.titleprocRes,res.postHtml,new string[] {(formData.modInfo.UI.currentindex == 0? "ModdedGames" : "PaidGames") },"{\n\"search_description\" = "+res.searchproRes+"\n}");
                api.SendPost(true);

                

                MessageBox.Show("Process All Done");
                SystemAlt.Windows_Forms_Clipboard_SetText(!String.IsNullOrWhiteSpace(res.searchproRes) ? res.searchproRes : "");
                api.OpenPostInBrowser();
                if (System.IO.Directory.Exists(formData.folderlink) && !string.IsNullOrEmpty(formData.folderlink) && formData.folderlink != Class1.GetToken("curdir"))
                    System.IO.Directory.Delete(formData.folderlink, true);
                System.Windows.Forms.Application.Exit();
                this.Show();
            }
        }

        private void dialogFile_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void boxModInfo_TextChanged(object sender, EventArgs e)
        {
            formData.modInfo.UI.modTypeSetData(boxModInfo.Text, formData.modInfo.UI.currentindex);
        }

        private void checkInternet_CheckedChanged(object sender, EventArgs e)
        {
            formData.appInfo.internetReq = checkInternet.Checked;
           
        }

        private void checkRoot_CheckedChanged(object sender, EventArgs e)
        {
            formData.appInfo.rootReq = checkRoot.Checked;
        }

        private void checkOBB_CheckedChanged(object sender, EventArgs e)
        {
            formData.appInfo.obbReq = checkOBB.Checked;
        }

        private void checkAPK_CheckedChanged(object sender, EventArgs e)
        {
            formData.downloadlink.OBBlink.check = checkAPK.Checked;
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
            if (formData.downloadlink.linklist.Count < 1) formData.downloadlink.linklist.Add(new DefineInfoPack.Linker("download"));
            formData.downloadlink.linklist[0].linkalias = "Unsigned";
            OldProcessor.MirrorLink DLmirror = new OldProcessor.MirrorLink( formData.downloadlink.linklist[0].linkalias, formData.downloadlink.linklist[0].link);
            this.butMDL.Text = DLmirror.valid > 0 ? (DLmirror.valid == 1 ? "✓" : "✗") : "+";
            this.butMDL.ForeColor = DLmirror.valid > 0 ? (DLmirror.valid == 1 ? System.Drawing.Color.Lime : Color.Red) : Color.White;
            if (DLmirror.valid == 1)
            {
                formData.downloadlink.linklist[0].link = DLmirror.host == "drive.google.com" ? OldProcessor.ProcSupporter.ShortenLink(DLmirror.link) : DLmirror.link;
                formData.downloadlink.linklist[0].linkalias = DLmirror.name;
                formData.downloadlink.linklist[0].host = DLmirror.host;

                //tempcode 211016 signed/unsigned
                formData.downloadlink.linklist[0].linkalias = formData.downloadlink.Downloadlink.linkalias == "Signed" ? "Unsigned" : formData.downloadlink.linklist[0].linkalias;
                checkSign.Checked = true;
            }
            else
            {
                formData.downloadlink.linklist[0].link = "";
                formData.downloadlink.linklist[0].linkalias = "";
                formData.downloadlink.linklist[0].host = "";
            }

            
        }

        private void butMAO_Click(object sender, EventArgs e)
        {
            if (formData.downloadlink.linklist.Count == 0) formData.downloadlink.linklist.Add(new DefineInfoPack.Linker("download"));
            if (formData.downloadlink.linklist.Count == 1) formData.downloadlink.linklist.Add(new DefineInfoPack.Linker("obb"));
            
            OldProcessor.MirrorLink AOmirror = new OldProcessor.MirrorLink(formData.downloadlink.linklist[1].linkalias, formData.downloadlink.linklist[1].link);
            this.butMAO.Text = AOmirror.valid > 0 ? (AOmirror.valid == 1 ? "✓" : "✗") : "+";
            this.butMAO.ForeColor = AOmirror.valid > 0 ? (AOmirror.valid == 1 ? System.Drawing.Color.Lime : Color.Red) : Color.White;
            if (AOmirror.valid == 1)
            {
                formData.downloadlink.linklist[1].link = AOmirror.host == "drive.google.com" ? OldProcessor.ProcSupporter.ShortenLink(AOmirror.link) : AOmirror.link;
                formData.downloadlink.linklist[1].linkalias = AOmirror.name;
                formData.downloadlink.linklist[1].host = AOmirror.host;
            }
            else
            {
                formData.downloadlink.linklist[1].link = "";
                formData.downloadlink.linklist[1].linkalias = "";
                formData.downloadlink.linklist[1].host = "";
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
                    formData.credit.SaveData();
                }
            }
            else
            {
                formData.credit.nowIndex = listCredit.SelectedIndex;
                formData.credit.now = PostDataBundle.creditpack.CreditsList.list[listCredit.SelectedIndex];
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
            formData.appInfo.extpermReq = checkExtPerms.Checked;
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
            formData.downloadlink.Downloadlink.linkalias = groupDL.Text;
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
                formData.appInfo.size = formData.appInfo.size == "" ? processMirrorLinkTextBox.fsize : formData.appInfo.size;
                formData.downloadlink.OMirrorlink.link = processMirrorLinkTextBox.link;
                formData.downloadlink.OMirrorlink.check = Convert.ToBoolean(processMirrorLinkTextBox.valid);
                formData.downloadlink.OMirrorlink.host = processMirrorLinkTextBox.host;
            }
            else if (!string.IsNullOrEmpty(processMirrorLinkTextBox.link))
            {
                /*string cache = Microsoft.VisualBasic.Interaction.InputBox("Server không được hỗ trợ\nVui lòng nhập kích thước file vào đây\n Nếu bỏ trống link sẽ không được xử lý\n Có thể điền dấu cách \" \" để xử lý", "Nhập kích thước file", "");
                if (!string.IsNullOrEmpty(cache))*/
                Microsoft.VisualBasic.MsgBoxResult cache = Microsoft.VisualBasic.Interaction.MsgBox("Server không được hỗ trợ\nBạn có muốn giữ link này không?", Microsoft.VisualBasic.MsgBoxStyle.OkCancel, "LINK KHÁC");
                if (cache == Microsoft.VisualBasic.MsgBoxResult.Ok)
                {
                    formData.downloadlink.OMirrorlink.link = processMirrorLinkTextBox.link;
                    formData.downloadlink.OMirrorlink.check = true;
                    formData.downloadlink.OMirrorlink.host = processMirrorLinkTextBox.host;
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

        private void butCustomData_Click(object sender, EventArgs e)
        {
            CustomDataManager form = new CustomDataManager(formData.custom_data);
            form.ShowDialog();
            formData.custom_data = new Dictionary<string, string>();
            foreach (DataGridViewRow x in form.datatable.Rows)
            {
                if (!x.IsNewRow)
                    if (!formData.custom_data.ContainsKey(x.Cells[0].Value.ToString()))
                    formData.custom_data.Add(x.Cells[0].Value.ToString(), x.Cells[1].Value.ToString());
                
            }
            form.Dispose();
        }

        private void comboSourceQuery_SelectedIndexChanged(object sender, EventArgs e)
        {
            formData.appInfo.dataSourceQuery = comboSourceQuery.Text;
            boxDSlink_TextChanged(comboSourceQuery,e);
        }

        private void checkMenu_CheckedChanged(object sender, EventArgs e)
        {
            formData.appInfo.menuModFlag = checkMenu.Checked;
        }

        protected ModDescriptionQuickEditor modDescQuickEditor = new ModDescriptionQuickEditor();

        private void boxModInfo_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                modDescQuickEditor.Left = Cursor.Position.X - 10;
                modDescQuickEditor.Top = Cursor.Position.Y - 10;
                
                var newSize = new Size(
                    Screen.PrimaryScreen.WorkingArea.Width - modDescQuickEditor.Left,
                    Screen.PrimaryScreen.WorkingArea.Height - modDescQuickEditor.Top
                    );
                modDescQuickEditor.Size = newSize;
                modDescQuickEditor.UpdateOptions(boxModInfo.Text);
                // Add event
                modDescQuickEditor.VisibleChanged += modDescQuickEditor_VisibleChanged;
                modDescQuickEditor.Show();
            }
        }

        private void modDescQuickEditor_VisibleChanged(object sender, EventArgs e)
        {
            boxModInfo.Text = modDescQuickEditor.RenderContent();
            //((ModDescriptionQuickEditor)sender).VisibleChanged -= modDescQuickEditor_VisibleChanged;
        }

        private void checkArmv8a_CheckedChanged(object sender, EventArgs e)
        {
            formData.appInfo.armv8aReq = checkArmv8a.Checked;
        }
    }
}
