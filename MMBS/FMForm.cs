using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MMBS
{
    public partial class FMForm : Form
    {
        public static PostDataBundle FormData;
        public FMForm()
        {
            InitializeComponent();
            initFormData();
            LoadDataFromPostDataBundleToForm(FormData);
            if (Properties.Settings.Default.OldStyle) ThemeSystem.LoadOldStyle(this);
            if (Properties.Settings.Default.FMFtopmost) this.TopMost = true;
            else { this.TopMost = true; this.TopMost = false; }
#if DEBUG
            { this.TopMost = true; this.TopMost = false; }
#endif
        }
        public FMForm (string initcmd)
        {
            switch (initcmd)
            {
                case "initFromDataClass": break;
                case "null":
                    {

                    }
                    break;
                case "stableFMF_version":
                    InitializeComponent();
                    initFormData();
                    LoadDataFromPostDataBundleToForm(FormData);
                    groupImage.Enabled = false;
                    boxVideoLink.Enabled = false;
                    boxVreview.Enabled = false;
                    checkVideo.Enabled = false;
                    labelVideo.Enabled = false;
                    if (Properties.Settings.Default.OldStyle) ThemeSystem.LoadOldStyle(this);
                    break;
            }
           // if (Properties.Settings.Default.FMFtopmost) this.TopMost = true;
           // else { this.TopMost = true; this.TopMost = false; }
        }

        public  FMForm(PostDataBundle thenow)
        {
            InitializeComponent();
            initFormData(thenow);
            LoadDataFromPostDataBundleToForm(thenow);
            if (Properties.Settings.Default.OldStyle) ThemeSystem.LoadOldStyle(this);

            //Support Function
            if (Properties.Settings.Default.FMFtopmost) this.TopMost = true;
            else { this.TopMost = true; this.TopMost = false; }

            SystemCallExecute();
        }
        public void LoadDataFromPostDataBundleToForm(PostDataBundle thenow)
        {
            //app info
            this.boxAppname.Text = thenow.appinfo.name;
            if (thenow.appinfo.Icon.image != null) this.boxIcon.Image = thenow.appinfo.Icon.image;
            this.boxVersion.Text = thenow.appinfo.version;
            this.boxSize.Text = thenow.appinfo.size;
            this.boxAReq.Text = thenow.appinfo.androidReq;
            this.checkInternet.Checked = thenow.appinfo.internetReq;
            this.checkRoot.Checked = thenow.appinfo.rootReq;
            this.checkABold.Checked = thenow.appinfo.Description.bold;
            this.checkNoLine.Checked = thenow.appinfo.Description.noline;
            if (this.checkABold.Checked && this.checkNoLine.Checked)
                this.boxDescription.Text = thenow.appinfo.Description.spec_boldnoline;
            else if (!this.checkABold.Checked && this.checkNoLine.Checked)
                this.boxDescription.Text = thenow.appinfo.Description.spec_noline;
            else if (this.checkABold.Checked && !this.checkNoLine.Checked)
                this.boxDescription.Text = thenow.appinfo.Description.spec_bold;
            else if (!this.checkABold.Checked && !this.checkNoLine.Checked)
                this.boxDescription.Text = thenow.appinfo.Description.stockdata;
            this.boxSource.Text = thenow.appinfo.datasource;
            this.boxDownLink.Text = thenow.Downloadlink.Downloadlink.link;
            this.boxAPKlink.Text = thenow.Downloadlink.OBBlink.link;
            this.boxOMirror.Text = thenow.Downloadlink.OMirrorlink.link;
            this.labelAPKlink.Text = thenow.Downloadlink.OBBlink.linkalias;
            this.butModInfo.Text = thenow.modinfo.UI.modTypeGetname(thenow.modinfo.UI.currentindex);
            this.butModInfo.ForeColor = thenow.modinfo.UI.modTypegetcolor(thenow.modinfo.UI.currentindex);
            this.boxModInfo.Enabled = thenow.modinfo.UI.modTypeAllowData(thenow.modinfo.UI.currentindex);
            this.boxModInfo.Text = thenow.modinfo.UI.modTypeGetDat(thenow.modinfo.UI.currentindex);
            checkImageinScript.Checked = thenow.postmedia.ImageInScript;
            LoadImageFromList(thenow.postmedia.ImageList);
            LoadVideoReview(thenow.postmedia.VideoReview);
            this.clistMirrorlink.Items.Clear();
        }
        public int initFormData()
        {
            FormData = new PostDataBundle();
            FormData.folderlink = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "Data/";
            //MessageBox.Show(FormData.folderlink);
            
            return 0;
        }
        public int initFormData(PostDataBundle postData)
        {
            FormData = new PostDataBundle();
            FormData = postData;
            return 0;
         }
        public void LoadImageFromList(List<DefineInfoPack.imageinfo> Ilist)
        {
            listImageReview.Clear();
            ilistScreenShot = new ImageList();
            ilistScreenShot.ImageSize = new System.Drawing.Size(100, 100);
            if (Ilist != null)
            {
                if (Ilist.Count > 0)
                {
                    //listImageReview.LargeImageList = new ImageList();
                    for (int i = 0; i < Ilist.Count; i++)
                    {

                        listImageReview.Items.Add("Image " + i.ToString());
                        ilistScreenShot.Images.Add(Ilist[i].image);
                        listImageReview.Items[i].ImageIndex = i;
                        listImageReview.Items[i].ForeColor = Ilist[i].enable ? System.Drawing.Color.Lime : System.Drawing.Color.Red;
                    }
                    listImageReview.LargeImageList = ilistScreenShot;
                    listImageReview.Refresh();
                }
            }
            
        }
        public void LoadVideoReview(PostDataBundle.PostMediapack.VideoReviewpack v)
        {
            checkVideo.Checked = v.Cover.enable;
            boxVideoLink.Text = v.link;
            if (v.Cover.image != null) boxVreview.Image = v.Cover.image;
            else
            if (v.Cover.local)
            {
                boxVreview.Image = Image.FromFile(v.Cover.dir);
            }
            
        }
        public string[] GetSearchKeyData()
        {
            return boxSearchKey.Text.Split('\n');
        }
        Dictionary<string, string> WebBrowser_Queuer = new Dictionary<string, string>();
        public void SystemCallExecute()
        {
            Dictionary<string, string> SClist = new Dictionary<string, string>();
            FindSC();
            DoSC();
            void DoSC()
            {
                foreach (KeyValuePair<string,string> item in SClist)
                {
                    if (item.Value.StartsWith("MegaurlExc:"))
                        WebBrowser_Queuer.Add(item.Key,item.Value.Substring("MegaurlExc:".Length));
                }
                if (WebBrowser_Queuer.Count > 0)
                {
                    webBrowser1.Navigate(WebBrowser_Queuer.First().Value);
                }
            }
            void FindSC()
            {
                List<Control> needtoCheck = new List<Control>() { boxDownLink, boxAPKlink};
                Dictionary<Type, Action<Control>> @switch = new Dictionary<Type, Action<Control>>()
                {
                    {typeof(TextBox),
                        (Control cache)=>
                            {
                                if (cache.Text.StartsWith("SYSCall:"))
                                {
                                    SClist.Add(cache.Name,cache.Text.Substring("SYSCall:".Length));
                                }
                            } }
                };
                foreach (Control x in needtoCheck)
                {
                    if (@switch.ContainsKey(x.GetType())) @switch[x.GetType()](x);
                }
            }
        }
        private void FMForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void FMForm_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Size size = TextRenderer.MeasureText(boxAppname.Text, boxAppname.Font);
            boxAppname.Width = size.Width+10;
            if (size.Width + 10 > MaximumSize.Width)
            {
                boxAppname.ScrollBars = ScrollBars.Horizontal;
            }
            else
            {
                boxAppname.ScrollBars = ScrollBars.None;
            }
            //textBox1.Height = size.Height;
            FormData.appinfo.name = boxAppname.Text;
            Process_name();
            FormData.appinfo.searchkeyword = boxSearchKey.Text;
            void Process_name()
            {
                string[] cache = MMBStool.SearchKeywordGenerator.AnameAnalyse(boxAppname.Text);
                boxSearchKey.Text = "";
                foreach (string cache2 in cache)
                {
                    boxSearchKey.Text += cache2 + "\n" ;
                }
            }
        }
        protected string Appnamecache;

        private void boxAppname_Leave(object sender, EventArgs e)
        {
            //Save to Data

            //Resize Focus Content
            /* Size size = TextRenderer.MeasureText(boxAppname.Text, boxAppname.Font);
            if (size.Width>boxAppname.Size.Width)
            {
                boxAppname.RightToLeft = RightToLeft.Yes;
            }*/
            boxAppname.SelectionStart = 0;
        }

        private void checkInternet_CheckedChanged(object sender, EventArgs e)
        {
            FormData.appinfo.internetReq = checkInternet.Checked;
        }

        private void butModInfo_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.OldStyle) { }
            else
            {
                this.butModInfo.ForeColor = FormData.modinfo.UI.modTypegetcolor(FormData.modinfo.UI.currentindex);
            }
            FormData.modinfo.UI.currentindex = FormData.modinfo.UI.Getnext();
            this.butModInfo.Text = FormData.modinfo.UI.modTypeGetname(FormData.modinfo.UI.currentindex);
            
            this.boxModInfo.Enabled = FormData.modinfo.UI.modTypeAllowData(FormData.modinfo.UI.currentindex);
            this.boxModInfo.Text = FormData.modinfo.UI.modTypeGetDat(FormData.modinfo.UI.currentindex);

        }

        private void boxVersion_TextChanged(object sender, EventArgs e)
        {
            FormData.appinfo.version = boxVersion.Text;
        }

        private void boxVersion_KeyPress(object sender, KeyPressEventArgs e)
        {

           // MessageBox.Show(char.GetNumericValue(e.KeyChar).ToString()+'?'+char.IsControl(e.KeyChar).ToString()+" ? "+char.GetUnicodeCategory(e.KeyChar).ToString() +" ? "+e.KeyChar.ToString());
        }

        private void boxVersion_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case 13: SelectNextControl(boxVersion, true, true, true, false); break;
            }
        }

        private void boxSize_TextChanged(object sender, EventArgs e)
        {
            FormData.appinfo.size = boxSize.Text;
        }

        private void boxSize_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case 13: SelectNextControl(boxSize, true, true, true, false); break;
            }
        }

        private void boxAReq_TextChanged(object sender, EventArgs e)
        {
            FormData.appinfo.androidReq = boxAReq.Text;
        }

        private void boxAReq_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case 13: SelectNextControl(boxAReq, true, true, true, false); break;
            }
        }

        private void boxAReq_Leave(object sender, EventArgs e)
        {
            string[] U_in = new string[] { "2.3", "4.0", "4.1", "4.4", "5.0", "6.0", "7.0", "8.0", "9.0" , "vari" };
            string[] U_out = new string[] { "Android 2.3+", "Android 4.0+", "Android 4.1+", "Android 4.4+", "Android 5.0+", "Android 6.0+", "Android 7.0+", "Android 8.0+", "Android 9.0+", "Varies with device" };
            for (int i = 0; i< U_in.Length; i++)
            {
                if (boxAReq.Text.ToLower()== U_in[i])
                {
                    boxAReq.Text = U_out[i];
                    break;
                }
            }
            /*switch (boxAReq.Text.ToLower())
            {
                case "4.0": boxAReq.Text = "Android 4.0+"; break;
                case "vari": boxAReq.Text = "Varies with device"; break;
            }*/
        }

        private void checkInternet_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Shift && e.KeyValue == 13)
            {
                checkInternet.Checked = !checkInternet.Checked;
            }
        }

        private void checkRoot_CheckedChanged(object sender, EventArgs e)
        {
            FormData.appinfo.rootReq = checkRoot.Checked;
        }

        private void checkRoot_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Shift && e.KeyValue == 13)
            {
                checkRoot.Checked = !checkRoot.Checked;
            }
        }

        private void boxDescription_TextChanged(object sender, EventArgs e)
        {
            if (this.checkABold.Checked && this.checkNoLine.Checked)
                FormData.appinfo.Description.spec_boldnoline =this.boxDescription.Text;
            else if (!this.checkABold.Checked && this.checkNoLine.Checked)
                FormData.appinfo.Description.spec_noline = this.boxDescription.Text;
            else if (this.checkABold.Checked && !this.checkNoLine.Checked)
                FormData.appinfo.Description.spec_bold = this.boxDescription.Text;
            else if (!this.checkABold.Checked && !this.checkNoLine.Checked)
                FormData.appinfo.Description.stockdata = this.boxDescription.Text;
        }

        private void boxSource_TextChanged(object sender, EventArgs e)
        {
            FormData.appinfo.datasource = boxSource.Text;
            if (boxSource.Text.Contains("https://play.google.com/"))
            {
                
                FormData.appinfo.datasourcetype = "play";
                FormData.appinfo.datasourcemask = AFForm.DSlabelText[1];
            }
            else
            {
                FormData.appinfo.datasourcetype = "default";
                FormData.appinfo.datasourcemask = AFForm.DSlabelText[0];
            }
            labelSource.Text = FormData.appinfo.datasourcemask;
        }

        private void boxSource_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case 13: SelectNextControl(boxSource, true, true, true, false); break;
            }
        }

        private void boxDownLink_TextChanged(object sender, EventArgs e)
        {
            FormData.Downloadlink.Downloadlink.link = boxDownLink.Text;
        }

        private void boxAPKlink_TextChanged(object sender, EventArgs e)
        {
            FormData.Downloadlink.OBBlink.link = boxAPKlink.Text;
            FormData.Downloadlink.OBBlink.Check();
            if (!checkAPKLink.Checked && FormData.Downloadlink.OBBlink.legal) checkAPKLink.Checked = true;
        }

        private void boxAppname_Enter(object sender, EventArgs e)
        {
            boxAppname.SelectionStart = boxAppname.TextLength;

        }

        private void boxSearchKey_TextChanged(object sender, EventArgs e)
        {
            FormData.appinfo.searchkeyword = boxSearchKey.Text;
        }

        private void boxModInfo_TextChanged(object sender, EventArgs e)
        {
            FormData.modinfo.UI.modTypeSetData(boxModInfo.Text,FormData.modinfo.UI.currentindex);
        }

        private void labelVideo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(boxVideoLink.Text))
                {
                    System.Diagnostics.Process.Start(boxVideoLink.Text);
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        private void boxAppname_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case 13: SelectNextControl(boxAppname, true, true, true, false); break;
            }
        }

        private void boxModInfo_EnabledChanged(object sender, EventArgs e)
        {
           
                boxModInfo.Visible = boxModInfo.Enabled;
            
        }

        private void butDone_Click(object sender, EventArgs e)
        {
            Hide();
            FormResult formResult = new FormResult(FormData);
            if (!formResult.Visible)
            formResult.ShowDialog();
            Show();
        }

        private void boxVideoLink_TextChanged(object sender, EventArgs e)
        {
            FormData.postmedia.VideoReview.link = boxVideoLink.Text;
        }

        private void boxDownLink_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) {
                if (e.Shift == true) butMDown.PerformClick();
                else
                    SelectNextControl(boxDownLink, true, true, true, false);
                    }
        }

        private void boxAPKlink_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (e.Shift == true) butMAPK.PerformClick();
                else
                    SelectNextControl(boxAPKlink, true, true, true, false);
            }
        }

        private void boxDownLink_Leave(object sender, EventArgs e)
        {
            FormData.Downloadlink.Downloadlink.Check();
        }

        private void boxAPKlink_Leave(object sender, EventArgs e)
        {
            FormData.Downloadlink.OBBlink.Check();

        }

        private void checkABold_CheckedChanged(object sender, EventArgs e)
        {
            FormData.appinfo.Description.bold = checkABold.Checked;
            if (!Properties.Settings.Default.OldStyle)
            {
                if (FormData.appinfo.Description.bold)
                {
                    checkABold.ForeColor = System.Drawing.Color.Lime;
                }
                else checkABold.ForeColor = System.Drawing.Color.White;
            }
        }

        private void checkNoLine_CheckedChanged(object sender, EventArgs e)
        {
            FormData.appinfo.Description.noline = checkNoLine.Checked;
            if (!Properties.Settings.Default.OldStyle)
            {
                if (FormData.appinfo.Description.noline)
                {
                    checkNoLine.ForeColor = System.Drawing.Color.Lime;
                }
                else checkNoLine.ForeColor = System.Drawing.Color.White;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void butMDown_Click(object sender, EventArgs e)
        {
            if (FormData.Downloadlink.linklist.Count < 1) FormData.Downloadlink.linklist.Add(new DefineInfoPack.Linker("download"));
            OldProcessor.MirrorLink DLmirror = new OldProcessor.MirrorLink(FormData.Downloadlink.linklist[0].linkalias, FormData.Downloadlink.linklist[0].link);
            this.butMDown.Text = DLmirror.valid > 0 ? (DLmirror.valid == 1 ? "✓" : "✗") : "+";
            this.butMDown.ForeColor = DLmirror.valid > 0 ? (DLmirror.valid == 1 ? System.Drawing.Color.Lime : Color.Red) : Color.White;
            if (DLmirror.valid == 1)
            {
                FormData.Downloadlink.linklist[0].link = DLmirror.host == "drive.google.com" ? OldProcessor.ProcSupporter.ShortenLink(DLmirror.link) : DLmirror.link;
                FormData.Downloadlink.linklist[0].linkalias = DLmirror.name;
                FormData.Downloadlink.linklist[0].host = DLmirror.host;
            }
            else
            {
                FormData.Downloadlink.linklist[0].link = "";
                FormData.Downloadlink.linklist[0].linkalias = "";
                FormData.Downloadlink.linklist[0].host = "";
            }
        }

        private void listImageReview_SelectedIndexChanged(object sender, EventArgs e)
        {
           // MessageBox.Show(listImageReview.SelectedIndices.Count.ToString());
            if (listImageReview.SelectedIndices.Count > 0)
            {
                boxImage.Image = FormData.postmedia.ImageList[listImageReview.SelectedIndices[0]].image;
                boxImageLink.Text = FormData.postmedia.ImageList[listImageReview.SelectedIndices[0]].link;
                checkImageUse.Checked = FormData.postmedia.ImageList[listImageReview.SelectedIndices[0]].enable;
                labelImageName.Text = "Screenshot " + listImageReview.SelectedIndices[0].ToString();
            }
        }

        private void checkAPKLink_CheckedChanged(object sender, EventArgs e)
        {
            FormData.Downloadlink.OBBlink.check = checkAPKLink.Checked;
        }

        private void butMAPK_Click(object sender, EventArgs e)
        {
            if (FormData.Downloadlink.linklist.Count == 0) FormData.Downloadlink.linklist.Add(new DefineInfoPack.Linker("download"));
            if (FormData.Downloadlink.linklist.Count == 1) FormData.Downloadlink.linklist.Add(new DefineInfoPack.Linker("obb"));

            OldProcessor.MirrorLink AOmirror = new OldProcessor.MirrorLink(FormData.Downloadlink.linklist[1].linkalias, FormData.Downloadlink.linklist[1].link);
            this.butMAPK.Text = AOmirror.valid > 0 ? (AOmirror.valid == 1 ? "✓" : "✗") : "+";
            this.butMAPK.ForeColor = AOmirror.valid > 0 ? (AOmirror.valid == 1 ? System.Drawing.Color.Lime : Color.Red) : Color.White;
            if (AOmirror.valid == 1)
            {
                FormData.Downloadlink.linklist[1].link = AOmirror.host == "drive.google.com" ? OldProcessor.ProcSupporter.ShortenLink(AOmirror.link) : AOmirror.link;
                FormData.Downloadlink.linklist[1].linkalias = AOmirror.name;
                FormData.Downloadlink.linklist[1].host = AOmirror.host;
            }
            else
            {
                FormData.Downloadlink.linklist[1].link = "";
                FormData.Downloadlink.linklist[1].linkalias = "";
                FormData.Downloadlink.linklist[1].host = "";
            }
        }

        private void checkVideo_CheckedChanged(object sender, EventArgs e)
        {
            FormData.postmedia.VideoReview.Cover.enable = checkVideo.Checked;
        }

        private void boxVreview_Click(object sender, EventArgs e)
        {

        }

        private void butCacheFolder_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(FormData.folderlink) && (FormData.folderlink != Class1.GetToken("curdir")))
                System.Diagnostics.Process.Start(FormData.folderlink);
        }
        public KeyValuePair<string, string> RecallCmd = new KeyValuePair<string, string>();
        public bool needRecall = false;
        private void WebBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

            needRecall = true;
            RecallCmd = new KeyValuePair<string, string>("MegaWebBrowserGet", WebBrowser_Queuer.First().Key);
            this.Close();
            
        }

        private void FMForm_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                if (this.RecallCmd.Key == "MegaWebBrowserGet")
                {
                    
                    if (RecallCmd.Value == "boxDownLink")
                        boxDownLink.Text = webBrowser1.Document.Body.InnerText;
                    else if (RecallCmd.Value == "boxAPKlink")
                        boxAPKlink.Text = webBrowser1.Document.Body.InnerText;
                    RecallCmd = new KeyValuePair<string, string>();
                    WebBrowser_Queuer.Remove(WebBrowser_Queuer.First().Key);
                    if (WebBrowser_Queuer.Count > 0) webBrowser1.Navigate(WebBrowser_Queuer.First().Value);
                    needRecall = false;
                    
                }
            }
        }

        private void CheckImageinScript_CheckedChanged(object sender, EventArgs e)
        {
            FormData.postmedia.ImageInScript = checkImageinScript.Checked;
        }
<<<<<<< HEAD

        private void ListImageReview_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            MessageBox.Show("How many time it draw?");
        }
       // public DateTime waittoChangemode;
        const int changemodeSensitive = 1500;
        Timer timerCM = new Timer();
        private void butDone_MouseDown(object sender, MouseEventArgs e)
        {
            //waittoChangemode = DateTime.Now;
            if (e.Button.HasFlag(MouseButtons.Left))
            {
                timerCM.Interval = changemodeSensitive;

                timerCM.Tick += new EventHandler(ChangeMode);
                timerCM.Start();
            }
            void ChangeMode(object sender1, EventArgs e1)
            {
                if (butDone.Text == "DONE") butDone.Text = "POST";
                else butDone.Text = "DONE";
                timerCM.Stop();
                
            }
        }

        private void butDone_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button.HasFlag(MouseButtons.Left) && e.Button.HasFlag(MouseButtons.Left)) {
                if (butDone.Text == "DONE") butDone.Text = "DONE";
                else butDone.Text = "DONE";
                if (timerCM.Enabled) { timerCM.Stop(); timerCM.Interval = changemodeSensitive; }
            }
            else
            if (e.Button.HasFlag(MouseButtons.Left))
            {
                if (timerCM.Enabled) { timerCM.Stop(); timerCM.Interval = changemodeSensitive; }

            }
        }

        private void checkOBB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Shift && e.KeyValue == 13)
            {
                checkOBB.Checked = !checkOBB.Checked;
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void stripOtherPMT_Click(object sender, EventArgs e)
        {

        }

        private void contextmenuPublish_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                case "stripOtherPMT": cmdProcess("mmbsOther:PMT:current"); break;
            }
        bool cmdProcess(string code,params string[] para)
        {
                Hide();
                FormResult formResult = new FormResult(FormData, code, para);
                if (!formResult.Visible)
                    formResult.ShowDialog();
                Show();
                return true;
        }
        }

        private void checkExtPerms_CheckedChanged(object sender, EventArgs e)
        {
            FormData.appinfo.extpermReq = checkExtPerms.Checked;
        }
        public bool execute(string cmd)
        {
            string[] cache = cmd.Split(':');
            switch (cache[0])
            {
                case "checkPublish": this.stripOtherPMT.Checked = cache[1]=="PMT"; stripOMcurrentver.Checked = !stripOMcurrentver.Checked; break;
            }
            return true;
        }

        private void dialogFile_FileOk(object sender, CancelEventArgs e)
        {
            
        }

        private async void butAddImg_Click(object sender, EventArgs e)
        {
            dialogFile.InitialDirectory = FormData.folderlink;
            DialogResult x = dialogFile.ShowDialog();
            if (dialogFile.FileNames.Length > 0)
            {
                
                Imgur.API.Authentication.ApiClient client = new Imgur.API.Authentication.ApiClient("9334e3b9906c667", "4760edc37bb7d130163d31e3d445db3b4fc89db8");
                Imgur.API.Endpoints.ImageEndpoint account = new Imgur.API.Endpoints.ImageEndpoint(client, new System.Net.Http.HttpClient());
                foreach (string i in dialogFile.FileNames)
                {
                    try
                    {
                        Imgur.API.Models.IImage result;
                        using (FileStream f = new FileStream(i, FileMode.Open))
                        {
                            result = await account.UploadImageAsync(f);
                            ilistScreenShot.Images.Add(Image.FromFile(i));
                            if (null != result)
                                FormData.postmedia.ImageList.Add(new DefineInfoPack.imageinfo("imgur_" + result.Id, i, result.Link,result.Height, result.Width,Image.FromFile(i)));
                                    }
                    }
                    catch(Exception exc)
                    {
                        MessageBox.Show(exc.Message);
                    }
                }
            }
        }

        private void boxOMirror_TextChanged(object sender, EventArgs e)
        {
            FormData.Downloadlink.OMirrorlink.link = boxOMirror.Text;
        }
=======
>>>>>>> parent of 74612af (first commit)
    }
}
