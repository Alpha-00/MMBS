using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Drive.v3.Data;
using System.Web.UI.WebControls.Expressions;
using System.Text.RegularExpressions;

namespace MMBS.Model.PostForm
{
    public class PostForm241128_Ya4r : PostFormBase<TemplateData241128_Ya4r>
    {
        /// <summary>
        /// Need to run follow sequence
        /// 1. generateForm()
        /// </summary>
        /// <param name="data"></param>
        public PostForm241128_Ya4r(PostDataBundle data)
            : base(data, new TemplateData241128_Ya4r())
        {

        }

        public override String generateForm()
        {
            
            //Icon Script
            string SP_IconScipt = "";
            if (data.appInfo.icon.enable)
            {
                if (!String.IsNullOrWhiteSpace(data.appInfo.icon.link))
                {
                    data.appInfo.icon.link = data.appInfo.icon.link.Replace(" ", "");
                    SP_IconScipt = template.iconScript.Replace("$$$.iconUrl$$$$", data.appInfo.icon.link);
                }
            }

            //Description Script
            string SP_DescScript = "";
            if (!string.IsNullOrWhiteSpace(data.appInfo.description.GetDat()))
            {
                string[] cache_Desc = data.appInfo.description.GetDat().Split('\n');
                if (cache_Desc.Length <= 1)
                {
                    SP_DescScript = cache_Desc[0];
                }
                else
                {
                    string tmpcache = "";
                    int limitCounter = 2;
                    foreach (string str in cache_Desc)
                    {
                        // Special Comment Match
                        if (Regex.IsMatch(str, @"<!--.+-->"))
                        {
                            string link = Regex.Match(str, @"<!--(?<content>.+)-->").Groups["content"].Value;
                            var id = data.postMedia.ImageList.FindIndex((info) =>
                                {
                                    bool isSameFileName = info.dir.EndsWith(link);
                                    bool isSameLink = info.link == link;
                                    return isSameFileName || isSameLink;
                                });
                            // No data yet, process upload
                            if (id == -1)
                            {
                                System.Windows.Forms.MessageBox.Show($"Rendering Error: PostForm: Image {link} not found");
                                //throw new Exception("Image Not Founded");
                                //// Need to create the path first
                                //data.postMedia.ImageList.Add(ApiService.ImgurAPI.quickUploadImageSync(link));
                                //id = data.postMedia.ImageList.FindIndex((path) => path.dir.EndsWith(link));
                            }
                            var imageInfo = data.postMedia.ImageList[id];
                            data.postMedia.ImageList[id].enable = false;
                            string imageScript = MyFunction.MultiReplace(template.imageCardScript, "$$$:.imageLink$$$$", imageInfo.link);
                            SP_DescScript += imageScript;
                            continue;
                        }
                        SP_DescScript += str;
                    }
                }
            }
            SP_DescScript = template.descScript.Replace("$$$.descContent$$$$", SP_DescScript);
            //Infogroup
            string SP_iGroupScript = "";
            string _SP_title = "";
            if (!string.IsNullOrWhiteSpace(data.appInfo.name))
            {
                string modSurfix = data.modInfo.UI.modTypeGetname(data.modInfo.UI.currentindex);
                string modApkMessage = data.appInfo.menuModFlag ? "Mod Menu APK" : "Mod APK";
                modSurfix = modSurfix.ToLower() == "mod" ? modApkMessage : MyFunction.FirstCharEachWordUpcase(modSurfix);
                _SP_title = (data.appInfo.name).Trim(' ') + " " + modSurfix;
                string[] items = (!String.IsNullOrWhiteSpace(data.modInfo.UI.modTypeGetDat(data.modInfo.UI.currentindex)) ? data.modInfo.UI.modTypeGetDat(data.modInfo.UI.currentindex).Split('\n') : new string[] { });
                items = items.Where(x => !String.IsNullOrEmpty(x)).ToArray();
                if (items.Length > 0)
                {

                    for (int i = 0; i < items.Length; i++)
                    {
                        if (items[i].Length > 50) continue;
                        items[i] = items[i].Trim();
                        items[i] = Regex.Replace(items[i], "^-|^\\+|\\.$", "");
                        items[i] = MyFunction.CapitalizeEachWord(items[i]);
                        items[i] = items[i].Trim();
                        // Add "|" if not first index 
                        //titleprocRes += i != 0 ? " | " : " ";
                        _SP_title += " | ";
                        _SP_title += items[i];
                    }
                }
            }
            SP_iGroupScript = MyFunction.MultiReplace(
            template.igroupHtml, 
            "$$$.datAReq$$$$", data.appInfo.androidReq, 
            "$$$.datVer$$$$", data.appInfo.version,
            "$$$.datSize$$$$", data.appInfo.size,
            "$$$.package$$$$", data.appInfo.packageName,
            "$$$.modContent$$$$", data.modInfo.UI.modTypeGetDat(data.modInfo.UI.currentindex)
                );
            SP_iGroupScript = template.igroupScript.Replace("$$$.igroupHtml$$$$", SP_iGroupScript);

            //Link Script
            string SP_SourceLinkScript = template.sourceLinkScript.Replace("$$$.sourceUrl$$$$", data.appInfo.datasource);
            
            string SP_DownloadScript = "";
            List<string> linkList = new List<string>();
            {
                string tempLink = data.downloadlink.Downloadlink.link;
                if (String.IsNullOrEmpty(tempLink)) linkList.Add(tempLink);
            }
            {
                string tempLink = data.downloadlink.OBBlink.link;
                if (String.IsNullOrEmpty(tempLink)) linkList.Add(tempLink);
            }
            {
                string tempLink = data.downloadlink.OMirrorlink.link;
                if (String.IsNullOrEmpty(tempLink)) linkList.Add(tempLink);
            }
            foreach (string link in linkList)
            {
                var temp = template.linkScript.Replace("$$$.downloadUrl$$$$", data.downloadlink.Downloadlink.link);
                temp =  temp.Replace("$$$.title$$$$", _SP_title);

                SP_DownloadScript += temp + "\n";
            }
            if (SP_DownloadScript.EndsWith("\n")) SP_DownloadScript = SP_DownloadScript.Remove(SP_DownloadScript.Length - 1);
            
            //Summary
            return MyFunction.MultiReplace(template.layout, 
                "$$$.iconScript$$$$", SP_IconScipt, 
                "$$$.descScript$$$$", SP_DescScript, 
                "$$$.igroupScript$$$$", SP_iGroupScript,  
                "$$$.linkScript$$$$", SP_DownloadScript,
                "$$$.sourceLinkScript", SP_SourceLinkScript);
        }
    }
    public class TemplateData241128_Ya4r : PostFormTemplate
    {
        public TemplateData241128_Ya4r()
        {
        }
        /// <summary>
        ///     <para>
        ///         Static information about version of the script for tracking and future refactor
        ///     </para>
        /// </summary>
        public String toolscript => "<!--MMBS:240603:240603-->";

        /// <summary>
        ///     <para>
        ///         General structure of the article
        ///     </para>
        /// </summary>
        public String layout =>
                "$$$.descScript$$$$"
                + "\n"
                + "$$$.iconScript$$$$"
                + "\n"
                + "$$$.sourceLinkScript"
                + "$$$.igroupScript$$$$"
                + "\n"
                + "$$$.linkScript$$$$"//For 3 link box
            ;

        /// <summary>
        /// 
        /// </summary>
        public String iconScript => "\n[img]" + "$$$.iconUrl$$$$" + "[/img]";

        /// <summary>
        /// 
        /// </summary>
        public String descScript => /*param*/ "$$$.descContent$$$$";

        /// <summary>
        /// 
        /// </summary>
        public String igroupScript => "[color=red][b]Thông tin MOD[/b][/color]" + "\n"
                    +/*param*/ "$$$.igroupHtml$$$$" + "\n";

        /// <summary>
        /// </summary>
        /// 
        public String igroupHtml =>
            "[i]Tên gói:[/i] [b]$$$.package$$$$[/b]" + "\n"
            + "[i]Yêu cầu:[/i] [b]$$$.datAReq$$$$[/b]" + "\n"
            + "[i]Phiên bản:[/i] [b]$$$.datVer$$$$[/b]" + "\n"
            + "[i]Tính năng MOD:[/i]" + "\n"
            + "[b][color=blue]$$$.modContent$$$$[/color][/b]" + "\n"
            + "[i]Kích thước file MOD:[/i] [b]$$$.datSize$$$$[/b]";

        public String sourceLinkScript => "\n[url=$$$.sourceUrl$$$$]Xem thêm thông tin tại Cửa hàng[/url]\n";
        /// <summary>
        /// 
        /// </summary>
        public String imageCardScript => "[img]$$$.imageUrl$$$$[/img]";

        /// <summary>
        /// 
        /// </summary>
        public String linkScript => "[color=red][b]Tải ngay $$$.title$$$$[/b][/color]" + "\n"+ "[camon]$$$.downloadUrl$$$$[/camon]";
    }
}
