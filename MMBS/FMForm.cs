using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

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
            PostInit();
        }

        public void PostInit()
        {
            if (this.boxDescription.Rtf != null)
            {
                FormData.appInfo.description.rtf = this.boxDescription.Rtf;
            }
        }

        public void LoadDataFromPostDataBundleToForm(PostDataBundle thenow)
        {
            //app info
            this.boxAppname.Text = thenow.appInfo.name;
            if (thenow.appInfo.icon.image != null) this.boxIcon.Image = thenow.appInfo.icon.image;
            this.boxVersion.Text = thenow.appInfo.version;
            this.boxSize.Text = thenow.appInfo.size;
            this.boxAReq.Text = thenow.appInfo.androidReq;
            this.checkExtPerms.Checked = thenow.appInfo.extpermReq;
            this.checkInternet.Checked = thenow.appInfo.internetReq;
            this.checkRoot.Checked = thenow.appInfo.rootReq;
            this.checkOBB.Checked = thenow.appInfo.obbReq;
            this.checkMenu.Checked = thenow.appInfo.menuModFlag;
            this.checkABold.Checked = thenow.appInfo.description.bold;
            this.checkNoLine.Checked = thenow.appInfo.description.noline;
            if (this.checkABold.Checked && this.checkNoLine.Checked)
                this.boxDescription.Text = thenow.appInfo.description.spec_boldnoline;
            else if (!this.checkABold.Checked && this.checkNoLine.Checked)
                this.boxDescription.Text = thenow.appInfo.description.spec_noline;
            else if (this.checkABold.Checked && !this.checkNoLine.Checked)
                this.boxDescription.Text = thenow.appInfo.description.spec_bold;
            else if (!this.checkABold.Checked && !this.checkNoLine.Checked)
                this.boxDescription.Text = thenow.appInfo.description.rawText;
            this.boxSource.Text = thenow.appInfo.datasource;
            this.boxDownLink.Text = thenow.downloadlink.Downloadlink.link;
            this.boxAPKlink.Text = thenow.downloadlink.OBBlink.link;
            this.boxOMirror.Text = thenow.downloadlink.OMirrorlink.link;
            this.labelAPKlink.Text = thenow.downloadlink.OBBlink.linkalias;
            this.butModInfo.Text = thenow.modInfo.UI.modTypeGetname(thenow.modInfo.UI.currentindex);
            this.butModInfo.ForeColor = thenow.modInfo.UI.modTypegetcolor(thenow.modInfo.UI.currentindex);
            this.boxModInfo.Enabled = thenow.modInfo.UI.modTypeAllowData(thenow.modInfo.UI.currentindex);
            this.boxModInfo.Text = thenow.modInfo.UI.modTypeGetDat(thenow.modInfo.UI.currentindex);
            checkImageinScript.Checked = thenow.postMedia.ImageInScript;
            LoadImageFromList(thenow.postMedia.ImageList);
            LoadVideoReview(thenow.postMedia.VideoReview);
            this.clistMirrorlink.Items.Clear();

            boxPackage.Text = thenow.appInfo.packageName;
            listCredit.Items.Clear();
            ImportCreditList();

            //listCredit.Text = thenow.credit.now.name;

            // UI switch
            if (boxIcon.Image != null) butIconEdit.Visible = false;
            if (boxIcon.Image != null) butIconClipboard.Visible = false;
            processIconCounter = 0;
            processImageCounter = 0;
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

            if (Ilist != null && Ilist.Any((item)=> item.enable)) {
                this.checkImageinScript.Checked = true;
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
            FormData.appInfo.name = boxAppname.Text;
            Process_name();
            
            FormData.appInfo.searchkeyword = boxSearchKey.Text;
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
            FormData.appInfo.internetReq = checkInternet.Checked;
        }
        private void checkOBB_CheckedChanged(object sender, EventArgs e)
        {
            FormData.appInfo.obbReq = checkOBB.Checked;
        }
        private void butModInfo_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.OldStyle) { }
            else
            {
                this.butModInfo.ForeColor = FormData.modInfo.UI.modTypegetcolor(FormData.modInfo.UI.currentindex);
            }
            FormData.modInfo.UI.currentindex = FormData.modInfo.UI.Getnext();
            this.butModInfo.Text = FormData.modInfo.UI.modTypeGetname(FormData.modInfo.UI.currentindex);
            
            this.boxModInfo.Enabled = FormData.modInfo.UI.modTypeAllowData(FormData.modInfo.UI.currentindex);
            this.boxModInfo.Text = FormData.modInfo.UI.modTypeGetDat(FormData.modInfo.UI.currentindex);

        }

        private void boxVersion_TextChanged(object sender, EventArgs e)
        {
            FormData.appInfo.version = boxVersion.Text;
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
            FormData.appInfo.size = boxSize.Text;
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
            FormData.appInfo.androidReq = boxAReq.Text;
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
            FormData.appInfo.rootReq = checkRoot.Checked;
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
                FormData.appInfo.description.spec_boldnoline =this.boxDescription.Text;
            else if (!this.checkABold.Checked && this.checkNoLine.Checked)
                FormData.appInfo.description.spec_noline = this.boxDescription.Text;
            else if (this.checkABold.Checked && !this.checkNoLine.Checked)
                FormData.appInfo.description.spec_bold = this.boxDescription.Text;
            else if (!this.checkABold.Checked && !this.checkNoLine.Checked)
                FormData.appInfo.description.rawText = this.boxDescription.Text;
            try
            {
                FormData.appInfo.description.rtf = this.boxDescription.Rtf;
            }
            catch
            {

            }
        }

        private void boxSource_TextChanged(object sender, EventArgs e)
        {
            FormData.appInfo.datasource = boxSource.Text;
            if (boxSource.Text.Contains("https://play.google.com/"))
            {
                
                FormData.appInfo.datasourcetype = "play";
                FormData.appInfo.datasourcemask = AFForm.DSlabelText[1];
            }
            else
            {
                FormData.appInfo.datasourcetype = "default";
                FormData.appInfo.datasourcemask = AFForm.DSlabelText[0];
            }
            labelSource.Text = FormData.appInfo.datasourcemask;
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
            FormData.downloadlink.Downloadlink.link = boxDownLink.Text;
        }

        private void boxAPKlink_TextChanged(object sender, EventArgs e)
        {
            FormData.downloadlink.OBBlink.link = boxAPKlink.Text;
            FormData.downloadlink.OBBlink.Check();
            if (!checkAPKLink.Checked && FormData.downloadlink.OBBlink.legal) checkAPKLink.Checked = true;
        }

        private void boxAppname_Enter(object sender, EventArgs e)
        {
            boxAppname.SelectionStart = boxAppname.TextLength;

        }

        private void boxSearchKey_TextChanged(object sender, EventArgs e)
        {
            FormData.appInfo.searchkeyword = boxSearchKey.Text;
        }

        private void boxModInfo_TextChanged(object sender, EventArgs e)
        {
            FormData.modInfo.UI.modTypeSetData(boxModInfo.Text,FormData.modInfo.UI.currentindex);
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
        /// <summary>
        /// Search the folder and description content to upload all necessary file
        /// Check the description to identify links and download it to get more information
        /// </summary>
        private async Task imageListRefresh()
        {
            // Check usage tag in description
            var desc = FormData.appInfo.description.GetDat();
            var lines = desc.Split("\n");
            var reqLocalImages = new List<string>();
            var reqNetImages = new List<string>();
            foreach (var line in lines) {
                if (Regex.IsMatch(line, @"<!--.+-->") == false) continue;

                var content = Regex.Match(line, @"<!--(?<content>.+)-->").Groups["content"].Value.Trim();
                if (content.StartsWith("http")) 
                { 
                    reqNetImages.Add(content);
                    continue;
                }
                if (!Regex.IsMatch(content, @"\.(jpg|png|webp|gif)$")) continue;
                if (Uri.IsWellFormedUriString(content, UriKind.Absolute))
                {
                    reqLocalImages.Add(content);
                }
                var folder = FormData.folderlink;
                if (false == (folder.EndsWith("\\") || folder.EndsWith("/"))) folder += "\\";
                content = folder + content;
                reqLocalImages.Add(content);
            }
            // Prepare Local Image
            ApiService.ImgurAPI service = new ApiService.ImgurAPI();
            foreach (var file in reqLocalImages)
            {
                if (!System.IO.File.Exists(file)) { 
                    MessageBox.Show($"Image <!--{file}--> not found.");
                }
                string link = "";
                // 0 is success
                if (await service.Upload(file) == 1)
                {
                    MessageBox.Show($"Imgur API fatal.\n{file}\nPlease call dev support.","Imgur Upload Error");
                    continue;
                } 
               // Prepare data
                var fileName = Path.GetFileNameWithoutExtension(file);
                var image = System.Drawing.Image.FromFile(file);
                DefineInfoPack.imageinfo imageData = new DefineInfoPack.imageinfo(fileName, file, link, image.Height, image.Width, image);
                FormData.postMedia.ImageList.Add(imageData);
                FormData.postMedia.ImageList.Last().enable = true;
            }
            // Prepare Network Image
            var client = new System.Net.Http.HttpClient();
            int i = 0;
            foreach (var link in reqNetImages)
            {
                var message = new System.Net.Http.HttpRequestMessage();
                message.Method = HttpMethod.Head;
                message.RequestUri = new Uri(link);
                var response = await client.SendAsync(message);
                if (!response.Headers.GetValues("content-type").First().StartsWith("image"))
                {
                    MessageBox.Show($"Link <!--{link}--> not valid");
                    continue;
                }
                var fileData = await client.GetByteArrayAsync(link);
                var folder = FormData.folderlink;
                if (false == (folder.EndsWith("\\") || folder.EndsWith("/"))) folder += "\\";
                var file = folder + $"Internet Image {i}.jpg";
                File.WriteAllBytes(file, fileData);
                // Prepare data
                var fileName = Path.GetFileNameWithoutExtension(file);
                var image = System.Drawing.Image.FromFile(file);
                DefineInfoPack.imageinfo imageData = new DefineInfoPack.imageinfo(fileName, file, link, image.Height, image.Width, image);
                FormData.postMedia.ImageList.Add(imageData);
                FormData.postMedia.ImageList.Last().enable = true;
            }
        }
        private async void butDone_Click(object sender, EventArgs e)
        {
            await imageListRefresh();
            if (stripOtherPMT.Checked)
            {
                stripOtherPMT.PerformClick();
                return;
            }
            switch (butDone.Text)
            {
                case "DONE": NormalProcess(); break;
                case "POST": PostingProcess(); break;
            }
            void NormalProcess()
            {
                Hide();
                FormResult formResult = new FormResult(FormData);
                if (!formResult.Visible)
                    formResult.ShowDialog();
                Show();
            }
            void PostingProcess()
            {
                Hide();
                FormResult formResult = new FormResult(FormData);
                formResult.PostOnly_Service();
                Show();
            }
        }

        private void boxVideoLink_TextChanged(object sender, EventArgs e)
        {
            FormData.postMedia.VideoReview.link = boxVideoLink.Text;
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
            FormData.downloadlink.Downloadlink.Check();
        }

        private void boxAPKlink_Leave(object sender, EventArgs e)
        {
            FormData.downloadlink.OBBlink.Check();

        }

        private void checkABold_CheckedChanged(object sender, EventArgs e)
        {
            FormData.appInfo.description.bold = checkABold.Checked;
            if (!Properties.Settings.Default.OldStyle)
            {
                if (FormData.appInfo.description.bold)
                {
                    checkABold.ForeColor = System.Drawing.Color.Lime;
                }
                else checkABold.ForeColor = System.Drawing.Color.White;
            }
        }

        private void checkNoLine_CheckedChanged(object sender, EventArgs e)
        {
            FormData.appInfo.description.noline = checkNoLine.Checked;
            if (!Properties.Settings.Default.OldStyle)
            {
                if (FormData.appInfo.description.noline)
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
            if (FormData.downloadlink.linklist.Count < 1) FormData.downloadlink.linklist.Add(new DefineInfoPack.Linker("download"));
            OldProcessor.MirrorLink DLmirror = new OldProcessor.MirrorLink(FormData.downloadlink.linklist[0].linkalias, FormData.downloadlink.linklist[0].link);
            this.butMDown.Text = DLmirror.valid > 0 ? (DLmirror.valid == 1 ? "✓" : "✗") : "+";
            this.butMDown.ForeColor = DLmirror.valid > 0 ? (DLmirror.valid == 1 ? System.Drawing.Color.Lime : Color.Red) : Color.White;
            if (DLmirror.valid == 1)
            {
                FormData.downloadlink.linklist[0].link = DLmirror.host == "drive.google.com" ? OldProcessor.ProcSupporter.ShortenLink(DLmirror.link) : DLmirror.link;
                FormData.downloadlink.linklist[0].linkalias = DLmirror.name;
                FormData.downloadlink.linklist[0].host = DLmirror.host;
            }
            else
            {
                FormData.downloadlink.linklist[0].link = "";
                FormData.downloadlink.linklist[0].linkalias = "";
                FormData.downloadlink.linklist[0].host = "";
            }
        }

        private void listImageReview_SelectedIndexChanged(object sender, EventArgs e)
        {
           // MessageBox.Show(listImageReview.SelectedIndices.Count.ToString());
            if (listImageReview.SelectedIndices.Count > 0)
            {
                boxImage.Image = FormData.postMedia.ImageList[listImageReview.SelectedIndices[0]].image;
                boxImageLink.Text = FormData.postMedia.ImageList[listImageReview.SelectedIndices[0]].link;
                checkImageUse.Checked = FormData.postMedia.ImageList[listImageReview.SelectedIndices[0]].enable;
                labelImageName.Text = "Screenshot " + listImageReview.SelectedIndices[0].ToString();
            }
        }

        private void checkAPKLink_CheckedChanged(object sender, EventArgs e)
        {
            FormData.downloadlink.OBBlink.check = checkAPKLink.Checked;
        }

        private void butMAPK_Click(object sender, EventArgs e)
        {
            if (FormData.downloadlink.linklist.Count == 0) FormData.downloadlink.linklist.Add(new DefineInfoPack.Linker("download"));
            if (FormData.downloadlink.linklist.Count == 1) FormData.downloadlink.linklist.Add(new DefineInfoPack.Linker("obb"));

            OldProcessor.MirrorLink AOmirror = new OldProcessor.MirrorLink(FormData.downloadlink.linklist[1].linkalias, FormData.downloadlink.linklist[1].link);
            this.butMAPK.Text = AOmirror.valid > 0 ? (AOmirror.valid == 1 ? "✓" : "✗") : "+";
            this.butMAPK.ForeColor = AOmirror.valid > 0 ? (AOmirror.valid == 1 ? System.Drawing.Color.Lime : Color.Red) : Color.White;
            if (AOmirror.valid == 1)
            {
                FormData.downloadlink.linklist[1].link = AOmirror.host == "drive.google.com" ? OldProcessor.ProcSupporter.ShortenLink(AOmirror.link) : AOmirror.link;
                FormData.downloadlink.linklist[1].linkalias = AOmirror.name;
                FormData.downloadlink.linklist[1].host = AOmirror.host;
            }
            else
            {
                FormData.downloadlink.linklist[1].link = "";
                FormData.downloadlink.linklist[1].linkalias = "";
                FormData.downloadlink.linklist[1].host = "";
            }
        }

        private void checkVideo_CheckedChanged(object sender, EventArgs e)
        {
            FormData.postMedia.VideoReview.Cover.enable = checkVideo.Checked;
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
            FormData.postMedia.ImageInScript = checkImageinScript.Checked;
        }

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

        private void contextmenuPublish_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
            switch (e.ClickedItem.Name)
            {
                case "stripOtherPMT": cmdProcess("mmbsOther:PMT:current"); break;
                case "scibanCustomToolStripMenuItem": cmdProcess("mmbsOther:Sciban:default");  break;
                case "scibanCustomExportDataStripItem": cmdProcess("mmbsOther:Sciban:export"); break;
                case "stripOMcurrentver": cmdProcess("mmbsOther:Offlinemods:current"); break;
                case "stripMod977_current": cmdProcess("mmbsOther:Mod977:current"); break;
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
            FormData.appInfo.extpermReq = checkExtPerms.Checked;
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
        private async Task addImageReviewByClipboard(Image input = null)
        {
            processImageCounter++;
            ApiService.ImgurAPI client = new ApiService.ImgurAPI();
            var imgClipboard = input ?? Clipboard.GetImage();
            if (imgClipboard == null) { return; }
            var uploadResult = await client.Upload(imgClipboard.ToStream(System.Drawing.Imaging.ImageFormat.Jpeg));
            if (uploadResult != 0) { MessageBox.Show("Imgur image upload failed with code " + uploadResult, "Upload Failed"); return; }
            var file = "";
            var link = client.GetUrl();
            // Update Data
            var fileName = "img_" + FormData.postMedia.ImageList.Count();
            var image = imgClipboard;
            DefineInfoPack.imageinfo imageData = new DefineInfoPack.imageinfo(fileName, file, link, image.Height, image.Width, image);
            FormData.postMedia.ImageList.Add(imageData);
            FormData.postMedia.ImageList.Last().enable = true;
            // Update UI
            //ilistScreenShot.Images.Add(image);
            LoadImageFromList(FormData.postMedia.ImageList);
            processImageCounter--;
        }
        // TODO: Add progress bar to indicate change
        private async Task addImageReviewByLink(string url)
        {
            processImageCounter++;
            if (String.IsNullOrEmpty(url)) return;
            Image image = null;
            // Load image from internet to memory
            try
            {
                WebClient wc = new WebClient();
                byte[] bytes = wc.DownloadData(url);
                MemoryStream ms = new MemoryStream(bytes);
                image = System.Drawing.Image.FromStream(ms);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Download Image Failed");
                return;
            }
            if (image == null)
            {
                MessageBox.Show("No error detect, please check source code for the issue", "Download Image Failed");
                return;
            }

            
            var link = url;
            // Update Data
            var fileName = "img_"+FormData.postMedia.ImageList.Count();
            
            DefineInfoPack.imageinfo imageData = new DefineInfoPack.imageinfo(fileName, "", link, image.Height, image.Width, image);
            FormData.postMedia.ImageList.Add(imageData);
            FormData.postMedia.ImageList.Last().enable = true;
            // Update UI
            //ilistScreenShot.Images.Add(image);
            LoadImageFromList(FormData.postMedia.ImageList);

            processImageCounter--;
        }
        private async void butAddImg_Click(object sender, EventArgs e)
        {
            processImageCounter++;
            dialogFile.Reset();
            dialogFile.Filter = "Image Files|*.jpg;*.gif;*.png;*.webp|All files (*.*)|*.*";
            dialogFile.InitialDirectory = FormData.folderlink;
            dialogFile.Multiselect = true;
            dialogFile.Title = "Images Select";

            if (dialogFile.ShowDialog() != DialogResult.OK) return;
            if (dialogFile.FileNames.Length == 0) return;

            ApiService.ImgurAPI service = new ApiService.ImgurAPI();
            string[] links = await service.Upload(dialogFile.FileNames);
            if (links.Length == 0) MessageBox.Show("Upload Failed", "Imgur");
            if (links.Length != dialogFile.FileNames.Length) throw new Exception("Fatal Error: Multiple Upload Image Failed");
            for (int i = 0; i < links.Length; i++)
            {
                var file = dialogFile.FileNames[i];
                var link = links[i];
                // Update Data
                var fileName = Path.GetFileNameWithoutExtension(file);
                var image = System.Drawing.Image.FromFile(file);
                DefineInfoPack.imageinfo imageData = new DefineInfoPack.imageinfo(fileName,file, link, image.Height, image.Width, image);
                FormData.postMedia.ImageList.Add(imageData);
                FormData.postMedia.ImageList.Last().enable = true;
                // Update UI
                //ilistScreenShot.Images.Add(image);
                LoadImageFromList(FormData.postMedia.ImageList);

            }
            processImageCounter--;
            //if (dialogFile.FileNames.Length > 0)
            //{

            //    var client = new ApiService.ImgurAPI();
            //    Imgur.API.Endpoints.ImageEndpoint account = new Imgur.API.Endpoints.ImageEndpoint(ApiService.ImgurAPI.apiClient, new System.Net.Http.HttpClient());
            //    foreach (string i in dialogFile.FileNames)
            //    {
            //        try
            //        {
            //            Imgur.API.Models.IImage result;
            //            using (FileStream f = new FileStream(i, FileMode.Open))
            //            {
            //                result = await account.UploadImageAsync(f);
            //                ilistScreenShot.Images.Add(Image.FromFile(i));
            //                if (null != result)
            //                    FormData.postMedia.ImageList.Add(new DefineInfoPack.imageinfo("imgur_" + result.Id, i, result.Link,result.Height, result.Width,Image.FromFile(i)));
            //                        }
            //        }
            //        catch(Exception exc)
            //        {
            //            MessageBox.Show(exc.Message);
            //        }
            //    }
            //}
        }

        private void boxOMirror_TextChanged(object sender, EventArgs e)
        {
            FormData.downloadlink.OMirrorlink.link = boxOMirror.Text;
        }
        private async Task updateIconByLink(string url)
        {
            processIconCounter++;
            if (String.IsNullOrEmpty(url)) return;
            Image image = null;
            // Load image from internet to memory
            try
            {
                WebClient wc = new WebClient();
                byte[] bytes = wc.DownloadData(url);
                MemoryStream ms = new MemoryStream(bytes);
                image = System.Drawing.Image.FromStream(ms);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Download Image Failed");
                return;
            }
            if (image == null)
            {
                MessageBox.Show("No error detect, please check source code for the issue", "Download Image Failed");
                return;
            }
            FormData.appInfo.icon.enable = true;
            FormData.appInfo.icon.link = url;

            FormData.appInfo.icon.dir = "";
            FormData.appInfo.icon.image = image;
            processIconCounter--;
        }
        private async Task updateIconByUploadFile()
        {
            processIconCounter++;
            ApiService.ImgurAPI client = new ApiService.ImgurAPI();
            OpenFileDialog dialogFile = new OpenFileDialog();
            dialogFile.Reset();
            dialogFile.Filter = "Image Files|*.jpg;*.gif;*.png;*.webp|All files (*.*)|*.*";
            dialogFile.Multiselect = false;
            dialogFile.Title = "Avatar Select";
            var res = dialogFile.ShowDialog();
            if (res == DialogResult.OK)
            {
                var uploadResult = await client.Upload(dialogFile.FileName);
                if (uploadResult != 0) { MessageBox.Show("Imgur image upload failed with code "+ uploadResult + "\n" + dialogFile.FileName,"Upload Failed"); processIconCounter--; return;  }
                FormData.appInfo.icon.enable = true;
                FormData.appInfo.icon.link = client.GetUrl();
                FormData.appInfo.icon.dir = dialogFile.FileName;
                FormData.appInfo.icon.image = Image.FromFile(dialogFile.FileName);
                this.boxIcon.Image = FormData.appInfo.icon.image;
            }
            processIconCounter--;
        }

        private async Task updateIconFromClipboard(Image input = null)
        {
            processIconCounter++;
            ApiService.ImgurAPI client = new ApiService.ImgurAPI();
            var imgClipboard = input ?? Clipboard.GetImage();
            if (imgClipboard == null) { processIconCounter--; return;  }


                var uploadResult = await client.Upload(imgClipboard.ToStream(System.Drawing.Imaging.ImageFormat.Jpeg));
                if (uploadResult != 0) { MessageBox.Show("Imgur image upload failed with code " + uploadResult, "Upload Failed"); processIconCounter--; return; }
                FormData.appInfo.icon.enable = true;
                FormData.appInfo.icon.link = client.GetUrl();
                FormData.appInfo.icon.dir = dialogFile.FileName;
                FormData.appInfo.icon.image = imgClipboard;
                this.boxIcon.Image = FormData.appInfo.icon.image;
            processIconCounter--;
        }


        private async void noticeToolTipIcon(string url)
        {
            if (string.IsNullOrEmpty(url)) 
            { 
                //tipIcon.ToolTipTitle = ""; 
                tipIcon.SetToolTip(boxIcon, "");
                return; 
            }
            //tipIcon.ToolTipTitle = url;
            tipIcon.SetToolTip(boxIcon, url);
        }
        private async void boxIcon_DoubleClick(object sender, EventArgs e)
        {
            await updateIconByUploadFile();
        }

        private void boxIcon_Click(object sender, EventArgs e)
        {
            
        }

        private void pasteHtml_Click(object sender, EventArgs e)
        {
            var dat = Clipboard.GetDataObject();
            if (!dat.GetFormats().Contains(DataFormats.Html)) return;
            var html = dat.GetData(DataFormats.Html).ToString();
            html = cleanHtml(html);
            boxDescription.Text = html;
        }
        private string cleanHtml(string html)
        {
            // Extract Body
            html = Regex.Match(html, @"(?<=\<body\>).*(?=\<\/body\>)", RegexOptions.Singleline).Value.Trim();
            /* Test Data
             * <!--StartFragment--><p data-sourcepos="9:1-9:44" style="margin: 24px 0px; white-space: pre-wrap; word-break: break-word; color: rgb(227, 227, 227); font-family: &quot;Google Sans&quot;, &quot;Helvetica Neue&quot;, sans-serif; font-size: 16px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(19, 19, 20); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial;"><strong style="font-weight: 500;">Here are 3 easy tips to get you started:</strong></p><span style="color: rgb(227, 227, 227); font-family: &quot;Google Sans&quot;, &quot;Helvetica Neue&quot;, sans-serif; font-size: 16px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; white-space: normal; background-color: rgb(19, 19, 20); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial;"></span><ol data-sourcepos="11:1-11:26" style="margin: 4px 0px; padding-inline-start: 36px; color: rgb(227, 227, 227); font-family: &quot;Google Sans&quot;, &quot;Helvetica Neue&quot;, sans-serif; font-size: 16px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; white-space: normal; background-color: rgb(19, 19, 20); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial;"><span></span><li data-sourcepos="11:1-11:26" style="margin-bottom: 10px;"><span></span><p data-sourcepos="11:4-11:27" style="margin: 24px 0px; white-space: pre-wrap; word-break: break-word;"><strong style="font-weight: 500;">Take a brain dump.</strong></p><span></span><ul data-sourcepos="12:4-14:0" style="margin: 4px 0px; padding-inline-start: 36px;"><span></span><li data-sourcepos="12:4-12:104" style="margin-bottom: 10px;"><span>Grab a pen and paper,</span><span><span> </span>and write down<span> </span></span><em class="">everything</em><span><span> </span>that's on your mind,</span><span><span> </span>no matter how big or small.</span></li><span></span><li data-sourcepos="13:4-14:0" style="margin-bottom: 10px;"><span>This simple act of releasing your thoughts can help declutter your mind and create space for clarity.</span></li><span></span></ul><span></span></li><span></span><li data-sourcepos="15:1-17:74" style="margin-bottom: 10px;"><span></span><p data-sourcepos="15:4-15:30" style="margin: 24px 0px; white-space: pre-wrap; word-break: break-word;"><strong style="font-weight: 500;">Spend time in nature.</strong></p><span></span><ul data-sourcepos="16:4-17:74" style="margin: 4px 0px; padding-inline-start: 36px;"><span></span><li data-sourcepos="16:4-16:134" style="margin-bottom: 10px;"><span>Immerse yourself in the natural world,</span><span><span> </span>whether it's a walk in the park,</span><span><span> </span>a hike in the woods,</span><span><span> </span>or simply sitting in your backyard.</span></li><span></span><li data-sourcepos="17:4-17:74" style="margin-bottom: 10px;"><span>The<span> </span></span><em class="">calming effects of nature</em><span><span> </span>have been proven to reduce stress and improve mental clarity.</span></li><span></span></ul><span></span></li><span></span><li data-sourcepos="19:1-22:0" style="margin-bottom: 10px;"><span></span><p data-sourcepos="19:4-19:32" style="margin: 24px 0px; white-space: pre-wrap; word-break: break-word;"><strong style="font-weight: 500;">Practice mindfulness.</strong><span> ‍♀️</span></p><span></span><ul data-sourcepos="20:4-22:0" style="margin: 4px 0px; padding-inline-start: 36px;"><span></span><li data-sourcepos="20:4-20:83" style="margin-bottom: 10px;"><span>Take a few minutes each day to focus on the present moment,</span><span><span> </span>without judgment.</span></li><span></span><li data-sourcepos="21:4-22:0" style="margin-bottom: 10px;"><span>Try<span> </span></span><em class="">meditation, deep breathing exercises, or even simple activities like mindful walking or eating.</em></li><span></span></ul><span></span></li><span></span></ol><span style="color: rgb(227, 227, 227); font-family: &quot;Google Sans&quot;, &quot;Helvetica Neue&quot;, sans-serif; font-size: 16px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; white-space: normal; background-color: rgb(19, 19, 20); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial;"></span><p data-sourcepos="23:1-23:183" style="margin: 24px 0px; white-space: pre-wrap; word-break: break-word; color: rgb(227, 227, 227); font-family: &quot;Google Sans&quot;, &quot;Helvetica Neue&quot;, sans-serif; font-size: 16px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(19, 19, 20); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial;"><strong style="font-weight: 500;">Remember, decluttering your mind is an ongoing process.</strong><span> But by incorporating these simple tips into your daily routine,</span><span> you can find more peace,</span><span> focus,</span><span> and clarity in your life.</span><span> ✨</span></p><!--EndFragment-->
             */
            // Clear comment tag
            html = Regex.Replace(html, @"<!--(.*?)-->", "");
            // Replace new line with default new line
            html = Regex.Replace(html, @"<br>", "\n");
            // Remove paragraph text format
            html = Regex.Replace(html, @"<\/?span[^>]*?>", "");
            // Clean Strong and font format tag's attributes
            html = Regex.Replace(html, @"(?<=<(ol|ul|li|strong|b|i|em|mark|small|del|ins|sub|sup))[^>]*(?=>)", "");
            // Replace span tag to new line
            html = Regex.Replace(html, @"<p[^>]*?>", "\n").Trim();
            html = Regex.Replace(html, @"<\/p>", "");
            // Add new line after list tag
            html = Regex.Replace(html, @"(?<=</(ol|ul|li))>", ">\n");
            html = Regex.Replace(html, @"(?<=<(ol|ul))>", ">\n");
            // Remove horizontal rule element
            html = Regex.Replace(html, @"<(hr|\/hr)>", "\n");
            html = html.Trim();
            if (Regex.IsMatch(html, @"^<ol.*ol>"))
            {
                html = removeTagAtLevel(html, new string[] { "ol", "ul" }, new string[] { "li" },level: 1);
                html = Regex.Replace(html, @"<ol[^>]*?>|<\/ol>", "");
            }
            return html;
        }

        
        /// <summary>
        /// Helper method to remove specific tag at level without harm that tag in other level
        /// TODO: Implement
        /// </summary>
        /// <param name="input"></param>
        /// <param name="parrent"></param>
        /// <param name="target">Target Remove Tag name. For example: li, p, s</param>
        /// <param name="level">Level of target tag, meaning how many open parrent tag before</param>
        /// <returns></returns>
        private string removeTagAtLevel(string input, string[] parent, string[] target, int level = 1)
        {
            Dictionary<int, TagIndex[]> pOpenAnchor = new Dictionary<int, TagIndex[]>();
            Dictionary<int, TagIndex[]> pCloseAnchor = new Dictionary<int, TagIndex[]>();

            int pOpenAnchorTotalLenght = 0;
            int pCloseAnchorTotalLenght = 0;

            List<TagIndex> rasterOpenAnchor = new List<TagIndex>();
            List<TagIndex> rasterCloseAnchor = new List<TagIndex>();
            if (target.Length == 0) return input;
            if (parent.Length == 0)
            {
                pOpenAnchor.Add(0, new TagIndex[] { new TagIndex(-1,-1) });
                pCloseAnchor.Add(0, new TagIndex[] { new TagIndex(input.Length, input.Length) });
            }

            for (int i = 0; i < parent.Length; i++)
            {
                pOpenAnchor.Add(i, regexMatchesToArray(Regex.Matches(input, $@"<{parent[i]}[^>]*>")));
                pOpenAnchorTotalLenght += pOpenAnchor[i].Length;
                rasterOpenAnchor.AddRange(pOpenAnchor[i]);
                pCloseAnchor.Add(i, regexMatchesToArray(Regex.Matches(input, $@"<\/{parent[i]}[^>]*>")));
                pCloseAnchorTotalLenght += pCloseAnchor[i].Length;
                rasterCloseAnchor.AddRange(pCloseAnchor[i]);
            }
            rasterOpenAnchor.Sort(TagIndex.comperision);
            rasterCloseAnchor.Sort(TagIndex.comperision);
            List<TagIndex> removeRange = new List<TagIndex>();
            for (int i = 0; i< target.Length; i++)
            {
                
                var match = regexMatchesToArray(Regex.Matches(input, $@"<\/?{target[i]}[^>]*>"));
                for (int j = 0; j < match.Length; j++)
                {
                    int atLevel = 0;
                    
                    int openLevel = rasterOpenAnchor.FindIndex(x => x.begin > match[j].begin)+1;
                    int closeLevel = rasterCloseAnchor.FindIndex(x => x.begin > match[j].begin)+1;
                    if (openLevel < 0) openLevel = rasterOpenAnchor.Count;
                    if (closeLevel < 0) closeLevel = rasterCloseAnchor.Count;
                    atLevel = openLevel - closeLevel;

                    if (atLevel == level)
                    {
                        removeRange.Add(match[j]);
                    }
                }
            }
            
            return input;
        }
        private TagIndex[] regexMatchesToArray(MatchCollection mc)
        {
            TagIndex[] result = new TagIndex[mc.Count];
            for (int i = 0; i < mc.Count; i++)
            {
                var temp = new TagIndex();
                temp.begin = mc[i].Index;
                temp.end = mc[i].Index + mc[i].Length;
                result[i] = temp;
            }
            return result;
        }
        private string stringRemoveRange(string input, TagIndex[] tags)
        {
            StringBuilder builder = new StringBuilder(input.Length);
            int fromIndex = 0;
            for (int i = 0; i <= tags.Length; i++)
            {
                if (fromIndex == tags[i].begin) { fromIndex = tags[i].end + 1; continue; }
                int toIndex = i != tags.Length ? tags[i].begin : input.Length-1;
                builder.Append(input.Substring(fromIndex, toIndex - fromIndex+1));
                fromIndex = tags[i].end + 1;
                if (tags[i].end == input.Length - 1) break;
            }
            return builder.ToString();
        }
        public struct TagIndex
        {
            public int begin;
            public int end;
            public TagIndex(int begin, int end)
            {
                this.begin = begin;
                this.end = end;
            }
            public static int comperision(TagIndex t1, TagIndex t2)
            {
                return t1.begin - t2.begin;
            }
        }
        private void FMForm_Shown(object sender, EventArgs e)
        {
            TopMost = false;
        }

        private void boxDescription_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.V: if (e.Shift && e.Control) pasteHtml_Click(sender, new EventArgs()); break;
            }
        }


        private bool isBoxIconEntered = false;
        private void boxIcon_MouseEnter(object sender, EventArgs e)
        {
            isBoxIconEntered = true;
            if (!butIconEdit.Visible)
            {
                butIconEdit.Visible = true;
            }
            if (!butIconClipboard.Visible)
            {
                butIconClipboard.Visible = true;
            }
        }

        private async void boxIcon_MouseLeave(object sender, EventArgs e)
        {
            isBoxIconEntered = false;
            await Task.Delay(3000);
            if (butIconEdit.Visible)
            {
                butIconEdit.Visible = false;
            }
            if (butIconClipboard.Visible)
            {
                butIconClipboard.Visible = false;
            }
        }

        private async void butIconEdit_Click(object sender, EventArgs e)
        {
            await updateIconByUploadFile();
        }

        private void FMForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private async void FMForm_KeyDown(object sender, KeyEventArgs e)
        {
            Console.WriteLine("Shortcut press " + isBoxIconEntered.ToString() + (char)e.KeyValue);
            if (isBoxIconEntered)
            {
                if (e.Control && e.KeyValue == (int)'V')
                {
                    var text = Clipboard.GetText();
                    // Try to using image clipboard
                    if (String.IsNullOrEmpty(text) || !Uri.IsWellFormedUriString(text, UriKind.Absolute))
                    {
                        await updateIconFromClipboard();
                        noticeToolTipIcon(FormData.appInfo.icon.link);
                        return;
                    }
                    if ((new Uri(text)).IsFile)
                    {
                        await updateIconFromClipboard(Image.FromFile(text));
                        noticeToolTipIcon(FormData.appInfo.icon.link);
                        return;
                    }
                    await updateIconByLink(text);
                    noticeToolTipIcon(FormData.appInfo.icon.link);
                    //MessageBox.Show("Trigger Clipboard Event");

                }
            }
        }

        private async void listImageReview_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyValue == (int)'V')
            {
                var text = Clipboard.GetText();
                // Try to using image clipboard
                if (String.IsNullOrEmpty(text) || !Uri.IsWellFormedUriString(text, UriKind.Absolute))
                {
                    await addImageReviewByClipboard();
                    return;
                }
                if ((new Uri(text)).IsFile) {
                    await addImageReviewByClipboard(Image.FromFile(text));
                    return;
                }
                await updateIconByLink(text);
                //MessageBox.Show("Trigger Clipboard Event");
            }
        }

        private int _progressIconCounter = 0;
        private int processIconCounter
        {
            get => _progressIconCounter;
            set
            {
                _progressIconCounter = value;
                if (_progressIconCounter < 0) { throw new Exception("Progress Manager Fatal Error"); };
                if (_progressIconCounter > 0)
                {
                    progressIcon.Visible = true;
                    return;
                }
                progressIcon.Visible = false;
            }
        }

        private int _progressImageCounter = 0;
        private int processImageCounter
        {
            get => _progressImageCounter;
            set
            {
                _progressImageCounter = value;
                if (_progressImageCounter < 0) { throw new Exception("Progress Manager Fatal Error"); };
                if (_progressImageCounter > 0)
                {
                    progressImage.Visible = true;
                    return;
                }
                progressImage.Visible = false;
            }
        }

        private async void butIconClipboard_Click(object sender, EventArgs e)
        {
            var text = Clipboard.GetText();
            // Try to using image clipboard
            if (String.IsNullOrEmpty(text) || !Uri.IsWellFormedUriString(text, UriKind.Absolute))
            {
                await updateIconFromClipboard();
                noticeToolTipIcon(FormData.appInfo.icon.link);
                return;
            }
            if ((new Uri(text)).IsFile)
            {
                await updateIconFromClipboard(Image.FromFile(text));
                noticeToolTipIcon(FormData.appInfo.icon.link);
                return;
            }
            await updateIconByLink(text);
            noticeToolTipIcon(FormData.appInfo.icon.link);
        }

        private void boxImageLink_TextChanged(object sender, EventArgs e)
        {

        }

        private async void butAddImgClipboard_Click(object sender, EventArgs e)
        {
            var text = Clipboard.GetText();
            // Try to using image clipboard
            if (String.IsNullOrEmpty(text) || !Uri.IsWellFormedUriString(text, UriKind.Absolute))
            {
                await addImageReviewByClipboard();
                return;
            }
            if ((new Uri(text)).IsFile)
            {
                await addImageReviewByClipboard(Image.FromFile(text));
                return;
            }
            await updateIconByLink(text);
            //MessageBox.Show("Trigger Clipboard Event");
        }

        private void boxPackage_TextChanged(object sender, EventArgs e)
        {
            FormData.appInfo.packageName = boxPackage.Text;
        }

        delegate void refreshListCredit();
        void refreshListCreditImplement()
        {
            listCredit.SelectedIndex = FormData.credit.defIndex;
            listCredit.Refresh();
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
            listCredit.SelectedIndex = FormData.credit.nowIndex;
            //listCredit.Invoke(new refreshListCredit(refreshListCreditImplement));
        }

        private void listCredit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listCredit.SelectedIndex == -1)
            {

            }
            else if (listCredit.SelectedIndex == listCredit.Items.Count - 1)
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
                    FormData.credit.SaveData();
                }
            }
            else
            {
                FormData.credit.nowIndex = listCredit.SelectedIndex;
                FormData.credit.now = PostDataBundle.creditpack.CreditsList.list[listCredit.SelectedIndex];
            }
        }

        private void checkOMirror_CheckedChanged(object sender, EventArgs e)
        {
            FormData.downloadlink.OMirrorlink.check = checkOMirror.Checked;
        }

        private void checkMenu_CheckedChanged(object sender, EventArgs e)
        {
            FormData.appInfo.menuModFlag = checkMenu.Checked;
        }
    }
}
