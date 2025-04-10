﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Drive.v3.Data;

namespace MMBS.Model.PostForm
{
    public class PostForm240104 : PostFormBase<TemplateData240104>
    {
        public PostForm240104(PostDataBundle data)
            : base(data, new TemplateData240104())
        {

        }

        public override String generateForm()
        {
            //cache for special style using in the whole post
            string SP_styleCard = "";
            SP_styleCard += template.styleWrapBreakable;
            //icon Script
            string SP_IconScipt = "";
            if (data.appInfo.icon.enable)
            {
                if (!String.IsNullOrWhiteSpace(data.appInfo.icon.link))
                {
                    data.appInfo.icon.link = data.appInfo.icon.link.Replace(" ", "");
                    SP_IconScipt = template.iconScript.Replace("$$$!?.iconlink$$$$", data.appInfo.icon.link);
                }
            }
            //description Script
            string SP_DescScript = "";
            if (!string.IsNullOrWhiteSpace(data.appInfo.description.GetDat()))
            {
                string[] cache_Desc = data.appInfo.description.GetDat().Split('\n');
                if (cache_Desc.Length < 2)
                {
                    SP_DescScript = cache_Desc[0];
                }
                else
                {
                    string tmpcache = "";
                    int limitCounter = 2;
                    foreach (string str in cache_Desc)
                    {
                        string str_edited = str;
                        //special process for multiple line <b>
                        string str_proc = str.Replace(" ", ""); ;
                        if (str_proc.Contains("</b>") && tmpcache == "<b>") { str_edited = tmpcache + str_edited; tmpcache = ""; }
                        if (str_proc.Contains("</b>") && tmpcache == "<b>") { str_edited = tmpcache + str_edited + tmpcache.Insert(1, "/"); }
                        if (!string.IsNullOrWhiteSpace(str_proc))
                            if (str_proc.Contains("<") && str_proc.Contains(">"))
                            {

                                while (str_proc.Contains("<b>"))
                                {
                                    str_proc = str_proc.Substring(str_proc.IndexOf("<b>") + 3);
                                    if (!str_proc.Contains("</b>"))
                                    {
                                        tmpcache = "<b>";
                                        str_edited = str_edited + "</b>";
                                    }
                                }
                            }
                        //str_edited = System.Web.HttpUtility.HtmlEncode(str_edited);
                        str_edited = str_edited.Replace("&", "&amp;");
                        SP_DescScript += template.descLineScript.Replace("$$$.descLine$$$$", str_edited);
                        if (--limitCounter == 0) { SP_DescScript += template.limitMoreScript; }
                    }
                }
            }
            SP_DescScript = template.descScript.Replace("$$$.descHtml$$$$", SP_DescScript);
            //Infogroup
            string SP_iGroupScript = "";
            string cache_modList = "";
            if (data.modInfo.UI.modTypeAllowData(data.modInfo.UI.currentindex))
            {
                string[] subcache = !String.IsNullOrWhiteSpace(data.modInfo.UI.modTypeGetDat(data.modInfo.UI.currentindex)) ? data.modInfo.UI.modTypeGetDat(data.modInfo.UI.currentindex).Split('\n') : new string[1] { "" };
                if (subcache.Length < 2)
                {
                    cache_modList = " " + subcache[0];

                }
                else
                {
                    foreach (string str in subcache)
                    {
                        cache_modList += !String.IsNullOrWhiteSpace(str) ? template.modListItem.Replace("$$$.modItem$$$$", str) : "";
                    }
                    cache_modList = template.modListHtml.Replace("$$$.modListPack$$$$", cache_modList);
                }
            }
            else
            {
                cache_modList = " " + MyFunction.CapitalizeEachWord(data.modInfo.UI.modTypeGetname(data.modInfo.UI.currentindex));
            }
            string cache_reqList = "";
            if (data.appInfo.rootReq) { cache_reqList += template.igroupRequireItem["rootReq"]; }
            if (data.appInfo.internetReq) { cache_reqList += template.igroupRequireItem["internetReq"]; }
            if (data.appInfo.obbReq) { cache_reqList += template.igroupRequireItem["obbReq"]; }
            if (data.appInfo.extpermReq) { cache_reqList += template.igroupRequireItem["permReq"]; }
            SP_iGroupScript = MyFunction.MultiReplace(
            template.igroupHtml, 
            "$$$.datAReq$$$$", data.appInfo.androidReq, 
            "$$$.datVer$$$$", data.appInfo.version,
            "$$$.datSize$$$$", data.appInfo.size,
            "$$$.sourceUrl$$$$", data.appInfo.datasource,
            "$$$.package$$$$", data.appInfo.packageName,
            "$$$.modListHtml$$$$", cache_modList,
            "$$$.igroupReqHtml$$$$", cache_reqList,
            "$$$.rootReqHtml$$$$", template.rootReqHtml[data.appInfo.rootReq ?
                // temp implement
                (!string.IsNullOrWhiteSpace(data.downloadlink.Downloadlink.linkalias) ? (data.downloadlink.Downloadlink.linkalias == "Signed" ? 2 : 1) : 1)
            : 0],
            "$$$.obbReqHtml$$$$", template.obbReqHtml[data.appInfo.obbReq ? 1 : 0],
            "$$$.internetReqHtml$$$$", template.internetReqHtml[data.appInfo.internetReq ? 1 : 0],
            "$$$.extpermReqHtml$$$$", template.extpermReqHtml[data.appInfo.extpermReq ? 1 : 0]
                );
            SP_iGroupScript = template.igroupScript.Replace("$$$.igroupHtml$$$$", SP_iGroupScript);
            //Image Script //Undone
            string SP_ImageScript = "";
            const int sizefit = 640;
            if (data.postMedia.ImageList.Count > 0 && data.postMedia.ImageInScript)
            {
                for (int i = 0; i < data.postMedia.ImageList.Count; i++)
                {
                    if (data.postMedia.ImageList[i].enable)
                    {
                        int NewHeight = data.postMedia.ImageList[i].height >= data.postMedia.ImageList[i].width ? sizefit : Convert.ToInt32(Math.Truncate(data.postMedia.ImageList[i].height / data.postMedia.ImageList[i].width * sizefit));
                        int NewWidth = data.postMedia.ImageList[i].height <= data.postMedia.ImageList[i].width ? sizefit : Convert.ToInt32(Math.Truncate(data.postMedia.ImageList[i].width / data.postMedia.ImageList[i].height * sizefit));
                        string SP_ImageLink_cache = data.postMedia.ImageList[i].link;

                        if (data.appInfo.datasourcetype == "play" || SP_ImageLink_cache.Split('/')[2] == "play-lh.googleusercontent.com")
                        {
                            if (SP_ImageLink_cache.Contains("-rw")) SP_ImageLink_cache = SP_ImageLink_cache.Replace("-rw", "");
                            if (SP_ImageLink_cache.Contains("=")) SP_ImageLink_cache = SP_ImageLink_cache.Remove(SP_ImageLink_cache.IndexOf("=")) + "=w" + NewWidth + "-h" + NewHeight;
                        }
                        SP_ImageScript += MyFunction.MultiReplace(template.imagecardScript, "$$$:.imageLink$$$$", SP_ImageLink_cache, "$$$:.imageOHeight$$$$", data.postMedia.ImageList[i].height.ToString(), "$$$:.imageOWidth$$$$", data.postMedia.ImageList[i].width.ToString(), "$$$:.imageNHeight$$$$", NewHeight.ToString(), "$$$:.imageNWidth$$$$", NewWidth.ToString());
                    }
                    //Đây là code tạm để thêm separate, nhớ sửa
                    if (i != data.postMedia.ImageList.Count - 1)
                        if (data.postMedia.ImageList[i].enable && data.postMedia.ImageList[i + 1].enable)
                        {
                            SP_ImageScript += "";
                        }
                }
            }
            SP_ImageScript = template.imageScript.Replace("$$$.imageHtml$$$$", SP_ImageScript);
            //Video Script //Undone
            string SP_VideoScript = "";

            SP_VideoScript = (string.IsNullOrWhiteSpace(data.postMedia.VideoReview.ID)) ? data.postMedia.VideoReview.generateID() : data.postMedia.VideoReview.ID;
            if (!String.IsNullOrWhiteSpace(SP_VideoScript))
            {
                SP_VideoScript = template.videoScript.Replace("$$$!?.videoID$$$$", SP_VideoScript);
                // if (SP_ImageScript != imageScript.Replace("$$$.imageHtml$$$$", ""))
                //     SP_VideoScript = /*seperateLineScript +*/ SP_VideoScript;
            }
            else
            {
                if (SP_ImageScript == template.imageScript.Replace("$$$.imageHtml$$$$", ""))
                    SP_VideoScript = template.seperateLineScript;

            }
            //Link Script // Undone
            string SP_DownloadScript = "";//* Fatal Param
            string SP_SourceScript = "";
            //Additional Script after main script
            string script_postDownload = "";
            if (!string.IsNullOrEmpty(data.appInfo.datasource))
            {
                SP_SourceScript = data.appInfo.datasourcetype == "play" ? MyFunction.MultiReplace(template.linkoneScript, "$$$:.downLink$$$$", data.appInfo.datasource, "$$$:.downName$$$$", data.appInfo.datasourcemask, "$$$:.downFAicon$$$$", "link") : "";
                //Temporarily v200516
                SP_SourceScript = data.appInfo.datasourcetype != "play" ? MyFunction.MultiReplace(template.linkoneScript, "$$$:.downLink$$$$", data.appInfo.datasource, "$$$:.downName$$$$", data.appInfo.datasourcemask, "$$$:.downFAicon$$$$", "link") : SP_SourceScript;
            }
            //Todo: Hot fix- Need refactor
            

            if (String.IsNullOrWhiteSpace(data.downloadlink.Downloadlink.link + data.downloadlink.OBBlink.link + data.downloadlink.OMirrorlink.link))
            {
                data.downloadlink.Downloadlink.link = "/";
                data.downloadlink.Downloadlink.check = true;
                data.downloadlink.Downloadlink.host = "";
            }
            if (data.downloadlink.Downloadlink.check || data.downloadlink.OBBlink.check)
            {
                data.downloadlink.MListEnable = data.downloadlink.linklist.Count > 0;//Delete it When done
                                                                                     // Two Download Link Only
                if (!data.downloadlink.MListEnable)
                {
                    /* Download link with no Mirror */
                    if (data.downloadlink.Downloadlink.check && !string.IsNullOrWhiteSpace(data.downloadlink.Downloadlink.link))
                        SP_DownloadScript += MyFunction.MultiReplace(template.linkoneScript, "$$$:.downLink$$$$", data.downloadlink.Downloadlink.link, "$$$:.downName$$$$", data.downloadlink.Downloadlink.linkalias, "$$$:.downFAicon$$$$", data.downloadlink.Downloadlink.FAicon);
                    if (data.downloadlink.OBBlink.check && !string.IsNullOrWhiteSpace(data.downloadlink.OBBlink.link))
                    {
                        SP_DownloadScript += MyFunction.MultiReplace(template.linkoneScript, "$$$:.downLink$$$$", data.downloadlink.OBBlink.link, "$$$:.downName$$$$", data.downloadlink.OBBlink.linkalias, "$$$:.downFAicon$$$$", data.downloadlink.OBBlink.FAicon);
                    }
                    if (data.downloadlink.OMirrorlink.check && !string.IsNullOrWhiteSpace(data.downloadlink.OMirrorlink.link)) {
                        if (data.downloadlink.OMirrorlink.linkalias == "Mirror")
                            data.downloadlink.OMirrorlink.linkalias = "Support Us";
                        SP_DownloadScript += MyFunction.MultiReplace(template.linkoneScript2, "$$$:.downLink$$$$", data.downloadlink.OMirrorlink.link, "$$$:.downName$$$$", data.downloadlink.OMirrorlink.linkalias, "$$$:.downFAicon$$$$", data.downloadlink.OMirrorlink.FAicon);
                    }
                    SP_DownloadScript = template.linkScript.Replace("$$$:.downlinkBundleScript$$$$", SP_DownloadScript);
                }

                else
                {
                    /* Download link with Mirror */
                    string cache_downloadbundle = "";
                    if (data.downloadlink.Downloadlink.check && !string.IsNullOrWhiteSpace(data.downloadlink.Downloadlink.link))
                    {
                        cache_downloadbundle = MyFunction.MultiReplace(template.linkoneScript2, "$$$:.downLink$$$$", data.downloadlink.Downloadlink.link, "$$$:.downName$$$$", data.downloadlink.Downloadlink.linkalias, "$$$:.downFAicon$$$$", data.downloadlink.Downloadlink.FAicon);
                    }
                    if (data.downloadlink.linklist.Count > 0)
                    {
                        // Temp replace Mirror for Support Us
                        //data.downloadlink.linklist[0].linkalias = data.downloadlink.linklist[0].linkalias == "Mirror" ? "Support Us" : data.downloadlink.linklist[0].linkalias;

                        cache_downloadbundle += MyFunction.MultiReplace(template.linkoneScript, "$$$:.downLink$$$$", data.downloadlink.linklist[0].link, "$$$:.downName$$$$", data.downloadlink.linklist[0].linkalias, "$$$:.downFAicon$$$$", "rocket").Replace("class=\"btn-slide2\"", "class=\"btn-slide\"");
                    }

                    //Separately process
                    if (data.downloadlink.OBBlink.check && !string.IsNullOrWhiteSpace(data.downloadlink.OBBlink.link))
                    {
                        // Temp replace Mirror for Support Us
                        //data.downloadlink.OBBlink.linkalias = data.downloadlink.OBBlink.linkalias == "Mirror" ? "Support Us" : data.downloadlink.OBBlink.linkalias;

                        cache_downloadbundle += MyFunction.MultiReplace(template.linkoneScript, "$$$:.downLink$$$$", data.downloadlink.OBBlink.link, "$$$:.downName$$$$", data.downloadlink.OBBlink.linkalias, "$$$:.downFAicon$$$$", data.downloadlink.Downloadlink.FAicon);
                    }

                    //todo: Refactor code to match generateForm layout
                    if (data.downloadlink.OMirrorlink.check && !string.IsNullOrWhiteSpace(data.downloadlink.OMirrorlink.link))
                    {
                        data.downloadlink.OMirrorlink.linkalias = data.downloadlink.OMirrorlink.linkalias == "Mirror" ? "Support Us" : data.downloadlink.OMirrorlink.linkalias;
                        cache_downloadbundle += MyFunction.MultiReplace(template.linkoneScript, "$$$:.downLink$$$$", data.downloadlink.OMirrorlink.link, "$$$:.downName$$$$", data.downloadlink.OMirrorlink.linkalias, "$$$:.downFAicon$$$$", data.downloadlink.Downloadlink.FAicon);
                    }
                    SP_DownloadScript = template.linkScript.Replace("$$$:.downlinkBundleScript$$$$", cache_downloadbundle);
                }

            }

            SP_DownloadScript = SP_DownloadScript.Replace("$$$:.sourcelink$$$$", SP_SourceScript);
            //*/
            //Credit
            string SP_CreditScript = "";
            if (data.credit.now != null)
            {
                SP_CreditScript = string.IsNullOrWhiteSpace(data.credit.now.GetPreview(true)) ? "" : template.credit.Replace("$$$?.creditString$$$$", data.credit.now.GetToUse());
                if (SP_CreditScript == "OfflineMods.Net") SP_CreditScript = "乡HULҜ™";
                string cache_creditLevel = "";
                var vipCheck = new List<String>() { "乡HULҜ™", "Apksmodᵗᵘᵇᵒᵗᵒᶜᵈᵒ" };
                try
                {
                    var vipFile = System.IO.File.ReadAllText(Class1.GetToken("creditVipFile"));
                    if (!String.IsNullOrEmpty(vipFile))
                    {
                        var temp = vipFile.Split("\n").ToList();
                        temp.ForEach((x) => vipCheck.Append(x));
                    }
                }
                catch (System.IO.FileNotFoundException)
                {
                    Console.WriteLine("Vip File Not Found");
                }
                var isVip = vipCheck.Any((x) => x == data.credit.now.GetToUse());
                if (data.credit.now.host == "offlinemods" || isVip)
                {
                    cache_creditLevel = "VIPadmin";
                    SP_styleCard += template.styleVIPadmin;
                }
                SP_CreditScript = SP_CreditScript.Replace("$$$?.creditLevel$$$$", cache_creditLevel);

            }
            
            //Summary
            return MyFunction.MultiReplace(template.layout, "$$$.styleCard$$$$", SP_styleCard, "$$$.iconScript$$$$", SP_IconScipt, "$$$.descScript$$$$", SP_DescScript, "$$$.igroupScript$$$$", SP_iGroupScript, "$$$.imageScript$$$$", SP_ImageScript, "$$$.videoScript$$$$", SP_VideoScript, "$$$.linkScript$$$$", SP_DownloadScript, "$$$.credit$$$$", SP_CreditScript, "$$$.lastword$$$$", template.lastword);
        }
    }
    public class TemplateData240104 : PostFormTemplate
    {
        public TemplateData240104()
        {
        }
        /// <summary>
        ///     <para>
        ///         Static information about version of the script for tracking and future refactor
        ///     </para>
        /// </summary>
        public String toolscript => "<!--MMBS:240105:240105-->";

        /// <summary>
        ///     <para>
        ///         Raise Flag in description Snippet. This using to help JavaScript in theme to modify
        ///     </para>
        /// </summary>
        public String flagDesc => "<!--MMBS:contentDesc-->\n";

        /// <summary>
        ///     <para>
        ///         Template for a single line separator    
        /// </para>
        /// </summary>
        public String seperateLineScript => "<div><br></div>\n";
        /// <summary>
        ///     <para>
        ///         Script to split content, hint that Blogger will break description
        ///     </para>
        /// </summary>
        public String limitMoreScript => "<!--more-->\n"+ seperateLineScript;
        /// <summary>
        ///     <para>
        ///         General structure of the article
        ///     </para>
        /// </summary>
        public String layout => toolscript
                + "\n\n"
                + "$$$.styleCard$$$$"
                + "\n"
                + "$$$.iconScript$$$$"
                + "\n"
                + "$$$.descScript$$$$"
                //+ "<!--more-->\n"//Halt the page content for better Indexing
                + "$$$.videoScript$$$$"
                + "$$$.imageScript$$$$"
                + "$$$.igroupScript$$$$"/*infogroup script*/
                + "$$$.linkScript$$$$"//For 3 link box
                + "$$$.credit$$$$"
                + "$$$.lastword$$$$"
                + "\n"
                + "\n";

        /// <summary>
        ///     <para>
        ///         Javascript element to help reveal description
        ///     </para>
        /// </summary>
        public String descButReveal => "<input " +
                    "onclick=\"if (this.parentNode.parentNode.getElementsByTagName('div')[1].getElementsByTagName('div')[0].style.display != '') { this.parentNode.parentNode.getElementsByTagName('div')[1].getElementsByTagName('div')[0].style.display = '';this.innerText = ''; this.value = 'Hide'; } else { this.parentNode.parentNode.getElementsByTagName('div')[1].getElementsByTagName('div')[0].style.display = 'none'; this.innerText = ''; this.value = 'Show Game Descriptions'; }\" " +
                    "onmouseover=\"this.style.backgroundColor = 'rgb(28,28,28)';\" onmouseout=\"this.style.backgroundColor = '#28A6E2';\"" +
                    " style=\"font-size: 20px; margin: 3px; padding: 5px; width: 300px; background-color: #28A6E2; border: none; border-radius: 2px; color: white;\"" +
                    " type=\"button\" value=\"Show Game Descriptions\">";

        /// <summary>
        /// <para>
        ///     Predefined style for VIP author
        /// </para>
        /// </summary>
        public String styleVIPadmin => "<!--Animation CSS by Daniel Riemer--> \n <style>@-webkit-keyframes aitf { 0% { background-position: 0% 50%; } 100% { background-position: 50% 100%; } }\n"
                + " #VIPadmin {background: url(https://i.imgur.com/u59ftm6t.jpg) repeat-y; background-size: cover;-webkit-background-clip: text!important;background-clip: text;text-shadow: 0 0 44px rgba(40, 166, 266);-webkit-text-fill-color: transparent;-webkit-animation: aitf 8s linear infinite;-webkit-transform: translate3d(0,0,0);-webkit-backface-visibility: hidden;-webkit-background-clip: text !important;}</style>\n";
        /// <summary>
        /// Predefined style for breakable group of button
        /// </summary>
        public String styleWrapBreakable => "<style>div.wrap-breakable#wrap {\r\n    display: flex;\r\n    flex-wrap: wrap;\r\n    justify-content: center;\r\n    gap: 12px;\r\n    margin: auto;\r\n    max-width: 500px;\r\n}</style>\n";
        /// <summary>
        /// 
        /// </summary>
        public String iconScript => "<div class=\"separator\" style=\"clear: both; text-align: center;\">"
                + "\n"
                + "<a href=\"" +/*param*/ "$$$!?.iconlink$$$$" + "\" style=\"margin-left: 1em; margin-right: 1em;\">"
                + "<img border=\"0\" data-original-height=\"180\" data-original-width=\"180\" src=\""
                +/*param*/ "$$$!?.iconlink$$$$"
                + "\" />"
                + "</a>"
                + "\n"
                + "</div>"
                + "\n"
                + seperateLineScript;

        /// <summary>
        /// 
        /// </summary>
        public String descScript =>
            //"<h3 style=\"text-align: left;\">About this game</h3>"
                 "<div>"
                    + /*param*/ "$$$.descHtml$$$$"
                + "</div>\n";

        /// <summary>
        /// 
        /// </summary>
        public String descLineScript => "<div><div style=\"text-align: justify;\">" 
            + /*param*/ "$$$.descLine$$$$" 
            + "</div></div>";

        /// <summary>
        /// 
        /// </summary>
        public String igroupScript => seperateLineScript
                + "<h3>Mod Info</h3>" + "\n"
                    +/*param*/ "$$$.igroupHtml$$$$" + "\n";

        /// <summary>
        /// 
        /// </summary>
        public String igroupHtml => "<ul>" + "\n"
                                        + "<li>Package:&nbsp;<a href=\"$$$.sourceUrl$$$$\" rel=\"nofollow\" target=\"_blank\"><span style=\"color: red;\"><b>$$$.package$$$$</b></span></a></li>"
                                        + "<li>Require: " + "$$$.datAReq$$$$" + "</li>" + "\n"
                                        + "<li>Version: " + "$$$.datVer$$$$" + "</li>" + "\n"
                                        + "<li>Mod feature(s):" + "$$$.modListHtml$$$$" + "</li>" + "\n"
                                        + "<li>File size: " + "$$$.datSize$$$$" + "</li>" + "\n"
                                        + "$$$.igroupReqHtml$$$$"
                                        + "</ul>" + "\n";

        public Dictionary<String, String> igroupRequireItem => new Dictionary<String, String> {
            { "rootReq", "<li>Needs Root: " + "$$$.rootReqHtml$$$$" + "</li>" + "\n" }
            ,{ "internetReq", "<li>Internet: " + "$$$.internetReqHtml$$$$" + "</li>" + "\n" }
            ,{ "obbReq", "<li>Needs Obb: " + "$$$.obbReqHtml$$$$" + "</li>" + "\n" }
            ,{ "permReq", "<li>Needs Special Permission: " + "$$$.extpermReqHtml$$$$" + "</li>" + "\n" }
        };

        /// <summary>
        /// 
        /// </summary>
        public String modListHtml => "<ul>" + "\n" + "$$$.modListPack$$$$" + "</ul>";

        /// <summary>
        /// 
        /// </summary>
        public String modListItem => "<li>" + "$$$.modItem$$$$" + "</li>" + "\n";

        /// <summary>
        /// 
        /// </summary>
        public String imageScript => seperateLineScript + "<h3>" + "\n" + "In-Game Images</h3>" + "\n" + "$$$.imageHtml$$$$";

        /// <summary>
        /// 
        /// </summary>
        public String imagecardScript => "<div class=\"separator\" style=\"clear: both; text-align: center;\">" + "\n" + "<a href=" + "\"" + /*param*/ "$$$:.imageLink$$$$" + "\" imageanchor=\"1\" style=\"margin-left: 1em; margin-right: 1em;\">"
                                       + "<img border=\"0\" data-original-height=\"" + /*param*/ "$$$:.imageOHeight$$$$" + "\"data-original-width=\"" + /*param*/ "$$$:.imageOWidth$$$$" + "\"height=\"" + /*param*/ "$$$:.imageNHeight$$$$" + "\"src=\"" + /*param*/ "$$$:.imageLink$$$$" + "\"width=\"" + /*param*/ "$$$:.imageNWidth$$$$" + "\" /></a >" +
                                       "</div >" + "\n";

        /// <summary>
        /// 
        /// </summary>
        public String videoScript => "<h3>" + "\n" + "Preview Video</h3>" + "\n"
               + "<div class=\"separator\" style=\"clear: both; text-align: center;\">" + "\n"
               + "<iframe allowfullscreen=\"\" class=\"YOUTUBE-iframe-video\" data-thumbnail-src=\"https://i.ytimg.com/vi/"
               + /*param*/ "$$$!?.videoID$$$$" + "/0.jpg\" frameborder=\"0\" height=\"266\" src=\"https://www.youtube.com/embed/"
               + /*param*/ "$$$!?.videoID$$$$" + "?feature=player_embedded\" width=\"320\"></iframe></div>" + "\n" + "<div><br></div>";

        /// <summary>
        /// 
        /// </summary>
        public String linkScript => "<br><div id=\"wrap\" class =\"breakable\">" + "\n" + "$$$:.downlinkBundleScript$$$$" + "</div>" + "\n";

        /// <summary>
        /// 
        /// </summary>
        public String linkoneScript =>
            "<div class=\"buttons\">\r\n\t<a rel=\"noopener noreferrer\" href=\"$$$:.downLink$$$$\" target=\"_blank\">\r\n\t\t<button class=\"btn-hover color-9\">$$$:.downName$$$$</button>\r\n\t</a>\r\n</div>";
        

        /// <summary>
        /// 
        /// </summary>
        public String linkoneScript2 => "<div class=\"buttons\">\r\n\t<a rel=\"noopener noreferrer\" href=\"$$$:.downLink$$$$\" target=\"_blank\">\r\n\t\t<button class=\"btn-hover color-10\">$$$:.downName$$$$</button>\r\n\t</a>\r\n</div>";

        /// <summary>
        /// 
        /// </summary>
        public String credit => "<br/><h3 style=\"text-align: center;\">" + "\n" + "<span style=\"color: red;\">Credit to <span id=\"$$$?.creditLevel$$$$\" style=\"color: #28A6E2\">$$$?.creditString$$$$</span></span></h3>" + "\n";

        /// <summary>
        /// 
        /// </summary>
        public String lastword => "<h3 style=\"text-align: center;\">" + "\n" + "<span style=\"color: red;\">Don't change the toast to make this yours. Thanks!</span></h3>";

        /// <summary>
        /// 
        /// </summary>
        public String codeWrapLine => "<div id=\"wrap\">" + "\n" + "$$$:.var$$$$" + "\n" + "</div>" + "\n";
        public String[] internetReqHtml => new string[2] 
                {   ("<span style=\"color: #2ec849; \"><b>No</b></span>"),   
                    ("<span style=\"color: red; \"><b>Yes</b></span>") 
                };
    public String[] rootReqHtml => new string[3] 
                {
                    ("<span style=\"color: #2ec849; \"><b>No</b></span>"),
                    ("<a href=\"https://www.offlinemods.net/2017/10/how-to-install-unsigned-apks-on-your.html\" title= \"How to install unsigned apks on your phone?\" target=\"_blank\" style=\"color: red;\"><b>Yes</b></a>"),
                    ("<a href=\"https://www.offlinemods.net/2017/10/how-to-install-unsigned-apks-on-your.html\" title= \"How to install unsigned apks on your phone?\" target=\"_blank\" style=\"color: red;\"><b>Yes/No</b></a>")
                };
public String[] obbReqHtml => new string[2]
    {
                    ("<span style=\"color: #2ec849; \"><b>No</b></span>"),(
                    "<a href=\"https://www.offlinemods.net/2016/10/how-to-install-game-which-has-obb-file.html\" title= \"How to install game which has obb file?\" target=\"_blank\" style=\"color: red;\"><b>Yes</b></a>")
    };
//extpermReqHtml = new string[2] {    ("<a href=\"https://www.offlinemods.net/\" " +/*title= \"\"*/" target=\"_blank\" style=\"color: #2ec849; \"><b>Overlay</b></a>"),             ("<a href=\"https://www.offlinemods.net/2019/10/how-to-grant-storage-permission-on-android.html\" title= \"How to grant storage permission on android?\" target=\"_blank\" style=\"color: red;\"><b>External storage</b></a>") };
public String[] extpermReqHtml => new string[2]
    {
                    ("<span style=\"color: #2ec849; \"><b>No</b></span>"),
                    ("<a href=\"https://www.offlinemods.net/2019/10/how-to-grant-storage-permission-on-android.html\" title= \"How to grant storage permission on android?\" target=\"_blank\" style=\"color: red;\"><b>Yes</b></a>")
    };
    }
}
