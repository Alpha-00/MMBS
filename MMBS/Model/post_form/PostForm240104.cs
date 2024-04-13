using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Drive.v3.Data;
using System.Web.UI.WebControls.Expressions;

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
            //Icon Script
            string SP_IconScipt = "";
            if (data.appinfo.Icon.enable)
            {
                if (!String.IsNullOrWhiteSpace(data.appinfo.Icon.link))
                {
                    data.appinfo.Icon.link = data.appinfo.Icon.link.Replace(" ", "");
                    SP_IconScipt = template.iconScript.Replace("$$$!?.iconlink$$$$", data.appinfo.Icon.link);
                }
            }
            //Description Script
            string SP_DescScript = "";
            if (!string.IsNullOrWhiteSpace(data.appinfo.Description.GetDat()))
            {
                string[] cache_Desc = data.appinfo.Description.GetDat().Split('\n');
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
            if (data.modinfo.UI.modTypeAllowData(data.modinfo.UI.currentindex))
            {
                string[] subcache = !String.IsNullOrWhiteSpace(data.modinfo.UI.modTypeGetDat(data.modinfo.UI.currentindex)) ? data.modinfo.UI.modTypeGetDat(data.modinfo.UI.currentindex).Split('\n') : new string[1] { "" };
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
                cache_modList = " " + MyFunction.CapitalizeEachWord(data.modinfo.UI.modTypeGetname(data.modinfo.UI.currentindex));
            }
            string cache_reqList = "";
            if (data.appinfo.rootReq) { cache_reqList += template.igroupRequireItem["rootReq"]; }
            if (data.appinfo.internetReq) { cache_reqList += template.igroupRequireItem["internetReq"]; }
            if (data.appinfo.obbReq) { cache_reqList += template.igroupRequireItem["obbReq"]; }
            if (data.appinfo.extpermReq) { cache_reqList += template.igroupRequireItem["permReq"]; }
            SP_iGroupScript = MyFunction.MultiReplace(
            template.igroupHtml, 
            "$$$.datAReq$$$$", data.appinfo.androidReq, 
            "$$$.datVer$$$$", data.appinfo.version,
            "$$$.datSize$$$$", data.appinfo.size,
            "$$$.sourceUrl$$$$", data.appinfo.datasource,
            "$$$.package$$$$", data.appinfo.packagename,
            "$$$.modListHtml$$$$", cache_modList,
            "$$$.igroupReqHtml$$$$", cache_reqList,
            "$$$.rootReqHtml$$$$", template.rootReqHtml[data.appinfo.rootReq ?
                // temp implement
                (!string.IsNullOrWhiteSpace(data.Downloadlink.Downloadlink.linkalias) ? (data.Downloadlink.Downloadlink.linkalias == "Signed" ? 2 : 1) : 1)
            : 0],
            "$$$.obbReqHtml$$$$", template.obbReqHtml[data.appinfo.obbReq ? 1 : 0],
            "$$$.internetReqHtml$$$$", template.internetReqHtml[data.appinfo.internetReq ? 1 : 0],
            "$$$.extpermReqHtml$$$$", template.extpermReqHtml[data.appinfo.extpermReq ? 1 : 0]
                );
            SP_iGroupScript = template.igroupScript.Replace("$$$.igroupHtml$$$$", SP_iGroupScript);
            //Image Script //Undone
            string SP_ImageScript = "";
            const int sizefit = 640;
            if (data.postmedia.ImageList.Count > 0 && data.postmedia.ImageInScript)
            {
                for (int i = 0; i < data.postmedia.ImageList.Count; i++)
                {
                    if (data.postmedia.ImageList[i].enable)
                    {
                        int NewHeight = data.postmedia.ImageList[i].height >= data.postmedia.ImageList[i].width ? sizefit : Convert.ToInt32(Math.Truncate(data.postmedia.ImageList[i].height / data.postmedia.ImageList[i].width * sizefit));
                        int NewWidth = data.postmedia.ImageList[i].height <= data.postmedia.ImageList[i].width ? sizefit : Convert.ToInt32(Math.Truncate(data.postmedia.ImageList[i].width / data.postmedia.ImageList[i].height * sizefit));
                        string SP_ImageLink_cache = data.postmedia.ImageList[i].link;

                        if (data.appinfo.datasourcetype == "play" || SP_ImageLink_cache.Split('/')[2] == "play-lh.googleusercontent.com")
                        {
                            if (SP_ImageLink_cache.Contains("-rw")) SP_ImageLink_cache = SP_ImageLink_cache.Replace("-rw", "");
                            if (SP_ImageLink_cache.Contains("=")) SP_ImageLink_cache = SP_ImageLink_cache.Remove(SP_ImageLink_cache.IndexOf("=")) + "=w" + NewWidth + "-h" + NewHeight;
                        }
                        SP_ImageScript += MyFunction.MultiReplace(template.imagecardScript, "$$$:.imageLink$$$$", SP_ImageLink_cache, "$$$:.imageOHeight$$$$", data.postmedia.ImageList[i].height.ToString(), "$$$:.imageOWidth$$$$", data.postmedia.ImageList[i].width.ToString(), "$$$:.imageNHeight$$$$", NewHeight.ToString(), "$$$:.imageNWidth$$$$", NewWidth.ToString());
                    }
                    //Đây là code tạm để thêm separate, nhớ sửa
                    if (i != data.postmedia.ImageList.Count - 1)
                        if (data.postmedia.ImageList[i].enable && data.postmedia.ImageList[i + 1].enable)
                        {
                            SP_ImageScript += "";
                        }
                }
            }
            SP_ImageScript = template.imageScript.Replace("$$$.imageHtml$$$$", SP_ImageScript);
            //Video Script //Undone
            string SP_VideoScript = "";

            SP_VideoScript = (string.IsNullOrWhiteSpace(data.postmedia.VideoReview.ID)) ? data.postmedia.VideoReview.generateID() : data.postmedia.VideoReview.ID;
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
            if (!string.IsNullOrEmpty(data.appinfo.datasource))
            {
                SP_SourceScript = data.appinfo.datasourcetype == "play" ? MyFunction.MultiReplace(template.linkoneScript, "$$$:.downLink$$$$", data.appinfo.datasource, "$$$:.downName$$$$", data.appinfo.datasourcemask, "$$$:.downFAicon$$$$", "link") : "";
                //Temporarily v200516
                SP_SourceScript = data.appinfo.datasourcetype != "play" ? MyFunction.MultiReplace(template.linkoneScript, "$$$:.downLink$$$$", data.appinfo.datasource, "$$$:.downName$$$$", data.appinfo.datasourcemask, "$$$:.downFAicon$$$$", "link") : SP_SourceScript;
            }
            //Todo: Hot fix- Need refactor
            

            if (String.IsNullOrWhiteSpace(data.Downloadlink.Downloadlink.link + data.Downloadlink.OBBlink.link + data.Downloadlink.OMirrorlink.link))
            {
                data.Downloadlink.Downloadlink.link = "/";
                data.Downloadlink.Downloadlink.check = true;
                data.Downloadlink.Downloadlink.host = "";
            }
            if (data.Downloadlink.Downloadlink.check || data.Downloadlink.OBBlink.check)
            {
                data.Downloadlink.MListEnable = data.Downloadlink.linklist.Count > 0;//Delete it When done
                                                                                     // Two Download Link Only
                if (!data.Downloadlink.MListEnable)
                {
                    /* Download link with no Mirror */
                    if (data.Downloadlink.Downloadlink.check && !string.IsNullOrWhiteSpace(data.Downloadlink.Downloadlink.link))
                        SP_DownloadScript += MyFunction.MultiReplace(template.linkoneScript, "$$$:.downLink$$$$", data.Downloadlink.Downloadlink.link, "$$$:.downName$$$$", data.Downloadlink.Downloadlink.linkalias, "$$$:.downFAicon$$$$", data.Downloadlink.Downloadlink.FAicon);
                    if (data.Downloadlink.OBBlink.check && !string.IsNullOrWhiteSpace(data.Downloadlink.OBBlink.link))
                    {
                        SP_DownloadScript += MyFunction.MultiReplace(template.linkoneScript, "$$$:.downLink$$$$", data.Downloadlink.OBBlink.link, "$$$:.downName$$$$", data.Downloadlink.OBBlink.linkalias, "$$$:.downFAicon$$$$", data.Downloadlink.OBBlink.FAicon);
                    }
                    if (data.Downloadlink.OMirrorlink.check && !string.IsNullOrWhiteSpace(data.Downloadlink.OMirrorlink.link)) {
                        if (data.Downloadlink.OMirrorlink.linkalias == "Mirror")
                            data.Downloadlink.OMirrorlink.linkalias = "Support Us";
                        SP_DownloadScript += MyFunction.MultiReplace(template.linkoneScript2, "$$$:.downLink$$$$", data.Downloadlink.OMirrorlink.link, "$$$:.downName$$$$", data.Downloadlink.OMirrorlink.linkalias, "$$$:.downFAicon$$$$", data.Downloadlink.OMirrorlink.FAicon);
                    }
                    SP_DownloadScript = template.linkScript.Replace("$$$:.downlinkBundleScript$$$$", SP_DownloadScript);
                }

                else
                {
                    /* Download link with Mirror */
                    string cache_downloadbundle = "";
                    if (data.Downloadlink.Downloadlink.check && !string.IsNullOrWhiteSpace(data.Downloadlink.Downloadlink.link))
                    {
                        cache_downloadbundle = MyFunction.MultiReplace(template.linkoneScript2, "$$$:.downLink$$$$", data.Downloadlink.Downloadlink.link, "$$$:.downName$$$$", data.Downloadlink.Downloadlink.linkalias, "$$$:.downFAicon$$$$", data.Downloadlink.Downloadlink.FAicon);
                    }
                    if (data.Downloadlink.linklist.Count > 0)
                    {
                        // Temp replace Mirror for Support Us
                        //data.Downloadlink.linklist[0].linkalias = data.Downloadlink.linklist[0].linkalias == "Mirror" ? "Support Us" : data.Downloadlink.linklist[0].linkalias;

                        cache_downloadbundle += MyFunction.MultiReplace(template.linkoneScript, "$$$:.downLink$$$$", data.Downloadlink.linklist[0].link, "$$$:.downName$$$$", data.Downloadlink.linklist[0].linkalias, "$$$:.downFAicon$$$$", "rocket").Replace("class=\"btn-slide2\"", "class=\"btn-slide\"");
                    }

                    //Separately process
                    if (data.Downloadlink.OBBlink.check && !string.IsNullOrWhiteSpace(data.Downloadlink.OBBlink.link))
                    {
                        // Temp replace Mirror for Support Us
                        //data.Downloadlink.OBBlink.linkalias = data.Downloadlink.OBBlink.linkalias == "Mirror" ? "Support Us" : data.Downloadlink.OBBlink.linkalias;

                        cache_downloadbundle += MyFunction.MultiReplace(template.linkoneScript, "$$$:.downLink$$$$", data.Downloadlink.OBBlink.link, "$$$:.downName$$$$", data.Downloadlink.OBBlink.linkalias, "$$$:.downFAicon$$$$", data.Downloadlink.Downloadlink.FAicon);
                    }

                    //todo: Refactor code to match generateForm layout
                    if (data.Downloadlink.OMirrorlink.check && !string.IsNullOrWhiteSpace(data.Downloadlink.OMirrorlink.link))
                    {
                        data.Downloadlink.OMirrorlink.linkalias = data.Downloadlink.OMirrorlink.linkalias == "Mirror" ? "Support Us" : data.Downloadlink.OMirrorlink.linkalias;
                        cache_downloadbundle += MyFunction.MultiReplace(template.linkoneScript, "$$$:.downLink$$$$", data.Downloadlink.OMirrorlink.link, "$$$:.downName$$$$", data.Downloadlink.OMirrorlink.linkalias, "$$$:.downFAicon$$$$", data.Downloadlink.Downloadlink.FAicon);
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
                string cache_creditLevel = "";
                if (data.credit.now.host == "offlinemods")
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
        ///         Raise Flag in Description Snippet. This using to help JavaScript in theme to modify
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
                + " #VIPadmin {background: url(https://imgur.com/u59ftm6t.jpg) repeat-y; background-size: cover;-webkit-background-clip: text!important;background-clip: text;text-shadow: 0 0 44px rgba(40, 166, 266);-webkit-text-fill-color: transparent;-webkit-animation: aitf 8s linear infinite;-webkit-transform: translate3d(0,0,0);-webkit-backface-visibility: hidden;-webkit-background-clip: text !important;}</style>\n";
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
                + "\n";

        /// <summary>
        /// 
        /// </summary>
        public String descScript =>
            "<h3 style=\"text-align: left;\">About this game</h3>"
                + "<div>"
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
                                        + "<li>Package:&nbsp;<a href=\"$$$.sourceUrl$$$$\" rel=\"nofollow\" target=\"_blank\"><span style=\"color: #04ff00;\"><b>$$$.package$$$$</b></span></a></li>"
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
