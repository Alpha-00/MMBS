//For const and experience
using OpenQA.Selenium.DevTools.V107.Debugger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MMBS
{
    static class Class1
    {
        const string ggappapitoken = "AIzaSyBNPMve6QROuvOXKwgL98xpBfl6U_ILFTc";
        const string token123link = "796632dc0627534f171fd34fe0ab7c80072696ad";
        const string tokenMegaurl = "a077dbfd036c0cc4bae16c329ec7ea592d48dacc";
        const string deepai = "f27ac8c8-04fb-4de4-a60c-38f4aa009ef3";
        const string nothinghereID = "7428959711553198398";
        const string offlinemodsID = "4254511517437771877";
        const string bth = "C:\\BloggerSupporter\\buithanhhieu.txt";


        public static string GetToken(string code)
        {

            switch (code)
            {
                case "gg": return ggappapitoken; break;
                case "123": return token123link; break;
                case "Murl": try { if (System.IO.File.Exists("C:\\BloggerSupporter\\megaurlToken.txt")) return System.IO.File.ReadAllLines("C:\\BloggerSupporter\\megaurlToken.txt")[0]; else return tokenMegaurl; } catch (Exception e) { System.Windows.Forms.MessageBox.Show("Lỗi đọc file megaurlToken");} break;//Megaurl.in
                case "Dai": return deepai; break;
                case "curdir": return System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath); break;//Current Dir
                case "userdir": return System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData).Remove(System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData).LastIndexOf("\\AppData\\Local")); break;
                case "nothinghereID": return nothinghereID;break;
                case "offlinemodsID": return offlinemodsID; break;
                case "mmbsprojectFolder": {
                        if (!System.IO.Directory.Exists("C:\\BloggerSupporter")) System.IO.Directory.CreateDirectory("C:\\BloggerSupporter");
                        return "C:\\BloggerSupporter\\";
                            } break;
                case "BTH": return bth;
                           
            }
            return "";
        }
        static string appbuildver = "0.0";
        public static void GlobalAssign(params string[] x)
        {
            if (x == null) return;
            if (x.Length == 1)
            {

            }
            if (x.Length > 1)
            {
                switch (x[0])
                {
                    case "appbuildver": appbuildver = x[1]; break;
                }
            }

        }
        
    }
   public partial class WorldVar
    {

    }
    public class CustomizePostResult
    {
        /* $$$  : start param get
         * !    : nospace
         * ?    : require this content for all string
         * :    : require one of all content for a string
         * .    : end custom
         * $$$$ : Stop param
         */
        public PostDataBundle cachenow;
        //sample //For version v180000
        public string layout = "$$$.iconScript$$$$" + "\n"
                                + "$$$.descScript$$$$" + "\n"
                                + "$$$.igroupScript$$$$"/*infogroup script*/ + "\n"
                                + "$$$.imageScript$$$$"
                                    + "$$$.videoScript$$$$"
                                    + "$$$.downloadScript$$$$"
                                    + "$$$.creadit$$$$" 
                                    + "$$$.lastword";
        public string iconScript = "<div class=\"separator\" style=\"clear: both; text-align: center;\">"
            + "\n" + "<a href=\"" +/*param*/ "$$$!?.iconlink$$$$" + "\" imageanchor=\"1\" style=\"margin-left: 1em; margin-right: 1em;\">"
            + "<img border=\"0\" data-original-height=\"180\" data-original-width=\"180\" src=\"" +/*param*/ "$$$!?.iconlink$$$$" + "\" /></a>"
            + "</div>" + "\n" + "<div class=\"separator\" style=\"clear: both; text-align: center;\"><br /></div>";
        public string descScript = "<h2>" + "\n" + "Descriptions</h2>" + "\n" +/*param*/ "$$$.descHtml$$$$" + "\n" + "<br />";
        public string descLineScript = "<div>" + "$$$.descLine$$$$" + "</div>" + "\n";
        public string igroupScript = "<h2>" + "\n" + "Information and Requirements</h2>" + "\n" +/*param*/ "$$$.igroupHtml$$$$" + "\n" + "<br />";
        public string igroupHtml = "<ul>" + "\n"
                                    + "<li>Requirement: " + "$$$.datAReq$$$$" + "</li>" + "\n"
                                    + "<li>Current version: " + "$$$.datVer$$$$" + "</li>" + "\n"
                                    + "<li>Size: " + "$$$.datSize$$$$" + "</li>" + "\n"
                                    + "<li>Mod:" + "$$$.modListHtml$$$$" + "</li>" + "\n"
                                    + "<li>$$$.datSourceType$$$$:&nbsp;<a href=\"" + "$$$.datSourceLink$$$$" + "\" target=\"_blank\">" + "$$$.datSourceLink$$$$" + "</a></li>" + "\n"
                                    + "<li>Internet: " + "$$$.internetReqHtml$$$$" + "</li>" + "\n"
                                    + "<li>Root: " + "$$$.rootReqHtml$$$$" + "</li>" + "\n"
                                    + "</ul>" + "\n";
        public string modListHtml = "<ul>"+"\n"+ "$$$.modListPack$$$$" + "</ul>";
        public string modListItem = "<li>"+ "$$$.modItem$$$$" + "</li>"+"\n";
        public string[] internetReqHtml;
        public string[] rootReqHtml;
        public string[] obbReqHtml;
        public string[] extpermReqHtml;
        public string imageScript = "<h2>" + "\n" + "Screenshots</h2>" + "\n" + "$$$.imageHtml$$$$";
        public string imagecardScript = "<div class=\"separator\" style=\"clear: both; text-align: center;\">"+"\n"+ "<a href="+"\""+ "$$$:.imageLink$$$$"+ "\" imageanchor=\"1\" style=\"margin-left: 1em; margin-right: 1em;\">"
                                    + "<img border=\"0\" data-original-height=\""+ "$$$:.imageOHeight$$$$"+ "\"data-original-width=\""+ "$$$:.imageOWidth$$$$"+ "\"height=\""+ "$$$:.imageNHeight$$$$"+ "\"src=\"" + "$$$:.imageLink$$$$"+ "\"width=\"" + "$$$:.imageNWidth$$$$"+ "\" /></a ></div >"+"\n";
        public string seperateLineScript = "<div><br/></div>\n";
        public string videoScript = "<h2>" + "\n" + "Review Game</h2>" + "\n"
            + "<div class=\"separator\" style=\"clear: both; text-align: center;\">" + "\n"
            + "<iframe allowfullscreen=\"\" class=\"YOUTUBE-iframe-video\" data-thumbnail-src=\"https://i.ytimg.com/vi/"
            + "$$$!?.videoID$$$$" + "/0.jpg\" frameborder=\"0\" height=\"266\" src=\"https://www.youtube.com/embed/"
            + "$$$!?.videoID$$$$" + "?feature=player_embedded\" width=\"320\"></iframe></div>" + "\n";
        public string downloadScript = "<div id=\"wrap\">" + "\n" + "$$$:.downlinkBundleScript$$$$" + "</div>" + "\n";
        
        public string downoneScript = "<a class=\"btn-slide2\" href=\"" + "$$$:.downLink$$$$" + "\" target=\"_blank\">" + "\n" + "<span class=\"circle2\"><i class=\"fa fa-$$$:.downFAicon$$$$\"></i></span>" + "\n" + "<span class=\"title2\">" + "$$$:.downName$$$$" + "</span>" + "\n" + "<span class=\"title-hover2\">Click here</span>" + "\n" + "</a>" + "\n";
        //public static string credit = "<h3>" + "\n" + "<span style=\"color: red;\">*** Credit for the mod: TigerOMs (offlinemods)</span></h3>";//Model//Another Comment:<i class=\"fa fa-download\"></i></span>"
        public static string credit = "<h3>" + "\n" + "<span style=\"color: red;\">*** Credit for the mod: <span style=\"color: #2EC849\">$$$?.creditString$$$$</span></span></h3>" + "\n";
        //public string lastword = "<h3>" + "\n" + "<span style=\"color: orange;\">*** Do not re-upload the mods without asking me. Be aware!</span></h3>";//This is the old one
        public string lastword = "<h3>" + "\n" + "<span style=\"color: red;\">*** Don't modify the toast to make it yours. If you are about to leech this mod without leaving a credit then...f*ck you, leechers!</span></h3>";//<-----HIDEN HERE
       
        public void simpleInit()
        {
            /*
            internetReqHtml = new string[2] {   ("Not required."),    ("<span style=\"color: red; \"><b>Yes</b></span>")};
            rootReqHtml = new string[2] {       ("NO."),              ("<span style=\"color: red; \"><b>Yes</b></span>") };
            obbReqHtml = new string[2] {        ("NO."),              ("<span style=\"color: red; \"><b>Yes</b></span>") };
            extpermReqHtml = new string[]{      ("NO"),              ("<span style=\"color: red; \"><b>Yes</b></span>") };
            */
            /// <!--MMBS:191130:200516-->
            internetReqHtml = new string[2] {   ("<span style=\"color: #2ec849; \"><b>Not Required</b></span>"),   ("<span style=\"color: #2ec849; \"><b>Yes</b></span>") };
            rootReqHtml = new string[3] {       ("<span style=\"color: #2ec849; \"><b>No</b></span>"),             ("<a href=\"https://www.offlinemods.net/2017/10/how-to-install-unsigned-apks-on-your.html\" title= \"How to install unsigned apks on your phone?\" target=\"_blank\" style=\"color: red;\"><b>Yes</b></a>"), ("<a href=\"https://www.offlinemods.net/2017/10/how-to-install-unsigned-apks-on-your.html\" title= \"How to install unsigned apks on your phone?\" target=\"_blank\" style=\"color: red;\"><b>Yes/No</b></a>") };
            obbReqHtml = new string[2] {        ("<span style=\"color: #2ec849; \"><b>No</b></span>"),             ("<a href=\"https://www.offlinemods.net/2016/10/how-to-install-game-which-has-obb-file.html\" title= \"How to install game which has obb file?\" target=\"_blank\" style=\"color: red;\"><b>Yes</b></a>") };
            //extpermReqHtml = new string[2] {    ("<a href=\"https://www.offlinemods.net/\" " +/*title= \"\"*/" target=\"_blank\" style=\"color: #2ec849; \"><b>Overlay</b></a>"),             ("<a href=\"https://www.offlinemods.net/2019/10/how-to-grant-storage-permission-on-android.html\" title= \"How to grant storage permission on android?\" target=\"_blank\" style=\"color: red;\"><b>External storage</b></a>") };
            extpermReqHtml = new string[2] { ("<span style=\"color: #2ec849; \"><b>No</b></span>"), ("<a href=\"https://www.offlinemods.net/2019/10/how-to-grant-storage-permission-on-android.html\" title= \"How to grant storage permission on android?\" target=\"_blank\" style=\"color: red;\"><b>Yes</b></a>") };
        }
        public CustomizePostResult()
        {
            simpleInit();
        }
        public CustomizePostResult (PostDataBundle thenow)
        {
            simpleInit();
        }
       
        //varible of Simple Process

        public string titleprocRes;
        public bool titleuse;
        public string searchproRes;
        public bool searchuse;
        public string postHtml;//default version
        public string postHtml2;//other version //to test beta or to preserve old ver
        public void SimpleProcess(PostDataBundle thenow)
        {
            //Title Process
            titleprocRes = "";
            titleuse = false;
            if (!string.IsNullOrWhiteSpace(thenow.appinfo.name))
            {
                titleprocRes = (thenow.appinfo.name).Trim(' ') +" " + MyFunction.FirstCharEachWordUpcase(thenow.modinfo.UI.modTypeGetname(thenow.modinfo.UI.currentindex));
                titleuse = true;
            }
            //SearchKeyword Process
            searchproRes = "";
            searchuse = false;
            if (!string.IsNullOrWhiteSpace(thenow.appinfo.searchkeyword))
            {
                searchproRes = Module.SearchKeywordModule.GetResStr(thenow.modinfo.UI.modTypeGetkey(thenow.modinfo.UI.currentindex), thenow.appinfo.searchkeyword.Split('\n'));
                searchproRes = searchproRes.Substring(0, searchproRes.Length - 2);
                //System.Windows.Forms.MessageBox.Show(thenow.appinfo.name.Split(':').Length.ToString());
                searchuse = true;
            }
            if (!string.IsNullOrEmpty(searchproRes))
            if (thenow.appinfo.miscellaneous != null)
                    if (thenow.appinfo.miscellaneous.Count > 0)
                    {
                        for (int i = 0;  i< thenow.appinfo.miscellaneous.Count; i++)
                        {
                            searchproRes += ", "+ thenow.appinfo.miscellaneous.ElementAt(i).Value;
                        }
                    }
            //For html process
            ////postHtml_v180000_Processor(thenow);
            ////postHtml_v191130_Processor(thenow);
            postHtml_v211016_Processor(thenow);
        }
        string postHtml_v180000_Processor(PostDataBundle thenow)
        {
            //Icon Script
            string SP_IconScipt = "";
            if (thenow.appinfo.Icon.enable)
            {
                if (!String.IsNullOrWhiteSpace(thenow.appinfo.Icon.link))
                {
                    thenow.appinfo.Icon.link = thenow.appinfo.Icon.link.Replace(" ", "");
                    SP_IconScipt = iconScript.Replace("$$$!?.iconlink$$$$", thenow.appinfo.Icon.link);
                }
            }
            //Description Script
            string SP_DescScript = "";
            if (!string.IsNullOrWhiteSpace(thenow.appinfo.Description.GetDat()))
            {
                string[] cache_Desc = thenow.appinfo.Description.GetDat().Split('\n');
                if (cache_Desc.Length < 2)
                {
                    SP_DescScript = cache_Desc[0];
                }
                else
                {
                    foreach (string str in cache_Desc)
                    {
                        SP_DescScript += descLineScript.Replace("$$$.descLine$$$$", str);
                    }
                }
            }
            SP_DescScript = descScript.Replace("$$$.descHtml$$$$", SP_DescScript);
            //Infogroup
            string SP_iGroupScript = "";
            string cache_modList = "";
            if (thenow.modinfo.UI.modTypeAllowData(thenow.modinfo.UI.currentindex))
            {
                string[] subcache = (!String.IsNullOrWhiteSpace(thenow.modinfo.UI.modTypeGetDat(thenow.modinfo.UI.currentindex)) ? thenow.modinfo.UI.modTypeGetDat(thenow.modinfo.UI.currentindex).Split('\n') : new string[1] { "" });
                if (subcache.Length < 2)
                {
                    cache_modList = " " + subcache[0];

                }
                else
                {
                    foreach (string str in subcache)
                    {
                        cache_modList += (!String.IsNullOrWhiteSpace(str) ? modListItem.Replace("$$$.modItem$$$$", str) : "");
                    }
                    cache_modList = modListHtml.Replace("$$$.modListPack$$$$", cache_modList);
                }
            }
            else
            {
                cache_modList = " " + MyFunction.FirstCharEachWordUpcase(thenow.modinfo.UI.modTypeGetname(thenow.modinfo.UI.currentindex));
            }
            SP_iGroupScript = MyFunction.MultiReplace(igroupHtml, "$$$.datAReq$$$$", thenow.appinfo.androidReq, "$$$.datVer$$$$", thenow.appinfo.version,
                "$$$.datSize$$$$", thenow.appinfo.size, "$$$.modListHtml$$$$", cache_modList, "$$$.datSourceType$$$$", thenow.appinfo.datasourcemask,
                "$$$.datSourceLink$$$$", thenow.appinfo.datasource, "$$$.internetReqHtml$$$$", internetReqHtml[thenow.appinfo.internetReq ? 1 : 0], "$$$.rootReqHtml$$$$", rootReqHtml[thenow.appinfo.rootReq ? 1 : 0]);
            SP_iGroupScript = igroupScript.Replace("$$$.igroupHtml$$$$", SP_iGroupScript);
            //Image Script //Undone
            string SP_ImageScript = "";
            const int sizefit = 640;
            if (thenow.postmedia.ImageList.Count > 0 && thenow.postmedia.ImageInScript)
            {
                for (int i = 0; i < thenow.postmedia.ImageList.Count; i++)
                {
                    if (thenow.postmedia.ImageList[i].enable)
                    {
                        int NewHeight = thenow.postmedia.ImageList[i].height >= thenow.postmedia.ImageList[i].width ? sizefit : Convert.ToInt32(Math.Truncate(thenow.postmedia.ImageList[i].height / thenow.postmedia.ImageList[i].width * sizefit));
                        int NewWidth = thenow.postmedia.ImageList[i].height <= thenow.postmedia.ImageList[i].width ? sizefit : Convert.ToInt32(Math.Truncate(thenow.postmedia.ImageList[i].width / thenow.postmedia.ImageList[i].height * sizefit));
                        string SP_ImageLink_cache = thenow.postmedia.ImageList[i].link;
                        if (thenow.appinfo.datasourcetype == "play")
                        {
                            if (SP_ImageLink_cache.Contains("-rw")) SP_ImageLink_cache = SP_ImageLink_cache.Replace("-rw", "");
                            if (SP_ImageLink_cache.Contains("=")) SP_ImageLink_cache = SP_ImageLink_cache.Remove(SP_ImageLink_cache.IndexOf("=")) + "=w" + NewWidth + "-h" + NewHeight;
                        }
                        SP_ImageScript += MyFunction.MultiReplace(imagecardScript, "$$$:.imageLink$$$$", SP_ImageLink_cache, "$$$:.imageOHeight$$$$", thenow.postmedia.ImageList[i].height.ToString(), "$$$:.imageOWidth$$$$", thenow.postmedia.ImageList[i].width.ToString(), "$$$:.imageNHeight$$$$", NewHeight.ToString(), "$$$:.imageNWidth$$$$", NewWidth.ToString());
                    }
                    //Đây là code tạm để thêm separate, nhớ sửa
                    if (i != thenow.postmedia.ImageList.Count - 1)
                        if (thenow.postmedia.ImageList[i].enable && thenow.postmedia.ImageList[i + 1].enable)
                        {
                            SP_ImageScript += seperateLineScript;
                        }
                }
            }
            SP_ImageScript = imageScript.Replace("$$$.imageHtml$$$$", SP_ImageScript);
            //Video Script //Undone
            string SP_VideoScript = "";

            SP_VideoScript = (string.IsNullOrWhiteSpace(thenow.postmedia.VideoReview.ID)) ? thenow.postmedia.VideoReview.generateID() : thenow.postmedia.VideoReview.ID;
            if (!String.IsNullOrWhiteSpace(SP_VideoScript))
            {
                SP_VideoScript = videoScript.Replace("$$$!?.videoID$$$$", SP_VideoScript);
                if (SP_ImageScript != imageScript.Replace("$$$.imageHtml$$$$", ""))
                    SP_VideoScript = seperateLineScript + SP_VideoScript;
            }
            else
            {
                if (SP_ImageScript == imageScript.Replace("$$$.imageHtml$$$$", ""))
                    SP_VideoScript = seperateLineScript;

            }
            //Download Script // Undone
            string SP_DownloadScript = "";///* Fatal Param
            

            if (thenow.Downloadlink.Downloadlink.check || thenow.Downloadlink.OBBlink.check)
            {
                thenow.Downloadlink.MListEnable = thenow.Downloadlink.linklist.Count > 0;//Delete it When done
                if (!thenow.Downloadlink.MListEnable)
                {
                    if (thenow.Downloadlink.Downloadlink.check && !string.IsNullOrWhiteSpace(thenow.Downloadlink.Downloadlink.link))
                        SP_DownloadScript = MyFunction.MultiReplace(downoneScript, "$$$:.downLink$$$$", thenow.Downloadlink.Downloadlink.link, "$$$:.downName$$$$", thenow.Downloadlink.Downloadlink.linkalias, "$$$:.downFAicon$$$$", thenow.Downloadlink.Downloadlink.FAicon);
                    if (thenow.Downloadlink.OBBlink.check && !string.IsNullOrWhiteSpace(thenow.Downloadlink.OBBlink.link))
                        SP_DownloadScript += MyFunction.MultiReplace(downoneScript, "$$$:.downLink$$$$", thenow.Downloadlink.OBBlink.link, "$$$:.downName$$$$", thenow.Downloadlink.OBBlink.linkalias, "$$$:.downFAicon$$$$", thenow.Downloadlink.OBBlink.FAicon);
                    SP_DownloadScript = downloadScript.Replace("$$$:.downlinkBundleScript$$$$", SP_DownloadScript);
                }
                else
                {
                    string cache_downloadbundle = "";
                    if (thenow.Downloadlink.Downloadlink.check && !string.IsNullOrWhiteSpace(thenow.Downloadlink.Downloadlink.link))
                    {
                        cache_downloadbundle = MyFunction.MultiReplace(downoneScript, "$$$:.downLink$$$$", thenow.Downloadlink.Downloadlink.link, "$$$:.downName$$$$", thenow.Downloadlink.Downloadlink.linkalias, "$$$:.downFAicon$$$$", thenow.Downloadlink.Downloadlink.FAicon);
                        if (thenow.Downloadlink.linklist.Count > 0)
                        {
                            cache_downloadbundle += MyFunction.MultiReplace(downoneScript, "$$$:.downLink$$$$", thenow.Downloadlink.linklist[0].link, "$$$:.downName$$$$", "Mirror", "$$$:.downFAicon$$$$", "rocket");
                        }
                        SP_DownloadScript = downloadScript.Replace("$$$:.downlinkBundleScript$$$$", cache_downloadbundle);
                    }
                    if (thenow.Downloadlink.OBBlink.check && !string.IsNullOrWhiteSpace(thenow.Downloadlink.OBBlink.link))
                    {
                        SP_DownloadScript += MyFunction.MultiReplace(downoneScript, "$$$:.downLink$$$$", thenow.Downloadlink.OBBlink.link, "$$$:.downName$$$$", thenow.Downloadlink.OBBlink.linkalias, "$$$:.downFAicon$$$$", thenow.Downloadlink.Downloadlink.FAicon);
                        if (thenow.Downloadlink.linklist.Count > 1)
                        {
                            cache_downloadbundle += MyFunction.MultiReplace(downoneScript, "$$$:.downLink$$$$", thenow.Downloadlink.linklist[1].link, "$$$:.downName$$$$", "Mirror", "$$$:.downFAicon$$$$", "rocket");
                        }
                        SP_DownloadScript += downloadScript.Replace("$$$:.downlinkBundleScript$$$$", cache_downloadbundle);
                    }
                }
            }//*/
            //Credit
            string SP_CreditScript = "";
            if (thenow.credit.now != null)
                SP_CreditScript = string.IsNullOrWhiteSpace(thenow.credit.now.GetPreview(true)) ? "" : credit.Replace("$$$?.creditString$$$$", thenow.credit.now.GetToUse());
            //Summary
            return postHtml2 = MyFunction.MultiReplace(layout, "$$$.iconScript$$$$", SP_IconScipt, "$$$.descScript$$$$", SP_DescScript, "$$$.igroupScript$$$$", SP_iGroupScript, "$$$.imageScript$$$$", SP_ImageScript, "$$$.videoScript$$$$", SP_VideoScript, "$$$.downloadScript$$$$", SP_DownloadScript, "$$$.creadit$$$$", SP_CreditScript, "$$$.lastword", lastword);
            // System.Windows.Forms.MessageBox.Show(postHtml);
        }
        
        /// <summary>
        /// Custom form post v191130
        /// 
        /// ///v200116
        /// ///Fix some bug
        /// 
        /// ///v200216
        /// ///Change Download Link Arrangement
        /// 
        /// ///v200218
        /// ///Add contentsDesc Flag
        /// 
        /// ///v200516
        /// ///Temporarily Support APKpure
        /// 
        /// ///v200619
        /// ///Add extpermReq to Form
        /// ///Add link to Req when they required (Update simple Init)
        /// 
        /// ///v200620
        /// ///Upgrade Html Descript Processor
        /// </summary>
        /// <param name="para"></param>
        string postHtml_v191130_Processor(PostDataBundle thenow)
        {
            string toolscript = "<!--MMBS:191130:200620-->";
            string flagDesc = "<!--MMBS:contentDesc-->\n";
            //New Define script structure
            layout = toolscript +"\n"
                +"$$$.iconScript$$$$" + "\n"
                + "$$$.linkScript$$$$"//For 3 link box
                + "$$$.igroupScript$$$$"/*infogroup script*/
                + "$$$.videoScript$$$$"
                + "$$$.imageScript$$$$"
                                + "$$$.descScript$$$$" + "\n"
                                 + "\n"
                                    + "$$$.creadit$$$$" 
                                    + "$$$.lastword";
        iconScript = "<div class=\"separator\" style=\"clear: both; text-align: center;\">"
            + "\n" + "<a href=\"" +/*param*/ "$$$!?.iconlink$$$$" + "\" imageanchor=\"1\" style=\"margin-left: 1em; margin-right: 1em;\">"
            + "<img border=\"0\" data-original-height=\"180\" data-original-width=\"180\" src=\"" +/*param*/ "$$$!?.iconlink$$$$" + "\" /></a>"
            + "</div>" + "\n" + "<div class=\"separator\" style=\"clear: both; text-align: center;\"><br /></div>";
        string descButReveal = "<input " +
                "onclick=\"if (this.parentNode.parentNode.getElementsByTagName('div')[1].getElementsByTagName('div')[0].style.display != '') { this.parentNode.parentNode.getElementsByTagName('div')[1].getElementsByTagName('div')[0].style.display = '';this.innerText = ''; this.value = 'Hide'; } else { this.parentNode.parentNode.getElementsByTagName('div')[1].getElementsByTagName('div')[0].style.display = 'none'; this.innerText = ''; this.value = 'Show Game Descriptions'; }\" " +
                "onmouseover=\"this.style.backgroundColor = 'rgb(28,28,28)';\" onmouseout=\"this.style.backgroundColor = 'rgb(244,67,54)';\"" +
                " style=\"font-size: 20px; margin: 3px; padding: 5px; width: 300px; background-color: rgb(244, 67, 54); border: none; border-radius: 2px; color: white;\"" +
                " type=\"button\" value=\"Show Game Descriptions\">";
        descScript = "<div><br></div>"+ "<div>\n<div style=\"display: flex; align-items: center; justify-content: center;\">\n" +descButReveal+"</div><div>"
                            + "<div style=\"display:none\">" +"<div><br></div>" + flagDesc +/*param*/ "$$$.descHtml$$$$" +"</div>"+ "\n" + "</div>\n</div>\n<br />";
        descLineScript = "<div>" + "$$$.descLine$$$$" + "</div>" + "\n";
        igroupScript = "<h3>" + "\n" + "Mod Info:</h3>" + "\n" +/*param*/ "$$$.igroupHtml$$$$" + "\n" + "<br />";
        igroupHtml = "<ul>" + "\n"
                                    + "<li>Requirement: " + "$$$.datAReq$$$$" + "</li>" + "\n"
                                    + "<li>Current version: " + "$$$.datVer$$$$" + "</li>" + "\n"
                                    + "<li>Mod:" + "$$$.modListHtml$$$$" + "</li>" + "\n"
                                    + "<li>Size: " + "$$$.datSize$$$$" + "</li>" + "\n"
                                    //+ "<li>Internet: " + "$$$.internetReqHtml$$$$" + "</li>" + "\n"
                                    + "<li>Needs Root: " + "$$$.rootReqHtml$$$$" + "</li>" + "\n"
                                    + "<li>Needs Obb: " + "$$$.obbReqHtml$$$$" + "</li>" + "\n"
                                    + "<li>Needs special permission: " + "$$$.extpermReqHtml$$$$" + "</li>" + "\n"
                                    + "</ul>" + "\n";
         modListHtml = "<ul>"+"\n"+ "$$$.modListPack$$$$" + "</ul>";
         modListItem = "<li>"+ "$$$.modItem$$$$" + "</li>"+"\n";
         //internetReqHtml;
         //rootReqHtml;
         imageScript = "<h3>" + "\n" + "Some images in the game:</h3>" + "\n" + "$$$.imageHtml$$$$";
         imagecardScript = "<div class=\"separator\" style=\"clear: both; text-align: center;\">"+"\n"+ "<a href="+"\""+ "$$$:.imageLink$$$$"+ "\" imageanchor=\"1\" style=\"margin-left: 1em; margin-right: 1em;\">"
                                    + "<img border=\"0\" data-original-height=\""+ "$$$:.imageOHeight$$$$"+ "\"data-original-width=\""+ "$$$:.imageOWidth$$$$"+ "\"height=\""+ "$$$:.imageNHeight$$$$"+ "\"src=\"" + "$$$:.imageLink$$$$"+ "\"width=\"" + "$$$:.imageNWidth$$$$"+ "\" /></a ></div >"+"\n";
         seperateLineScript = "<div><br></div>\n";
         videoScript = "<h3>" + "\n" + "Preview video:</h3>" + "\n"
            + "<div class=\"separator\" style=\"clear: both; text-align: center;\">" + "\n"
            + "<iframe allowfullscreen=\"\" class=\"YOUTUBE-iframe-video\" data-thumbnail-src=\"https://i.ytimg.com/vi/"
            + "$$$!?.videoID$$$$" + "/0.jpg\" frameborder=\"0\" height=\"266\" src=\"https://www.youtube.com/embed/"
            + "$$$!?.videoID$$$$" + "?feature=player_embedded\" width=\"320\"></iframe></div>" + "\n" + "<div><br></div>";
         string linkScript = "<div id=\"wrap\">" +"\n"+"$$$:.sourcelink$$$$"+ "\n" + "$$$:.downlinkBundleScript$$$$" + "</div>" + "\n";
        
         string linkoneScript = "<a class=\"btn-slide\" href=\"" + "$$$:.downLink$$$$" + "\" target=\"_blank\">" + "\n" + "<span class=\"circle\"><i class=\"fa fa-$$$:.downFAicon$$$$\"></i></span>" + "\n" + "<span class=\"title\">" + "$$$:.downName$$$$" + "</span>" + "\n" + "<span class=\"title-hover\">Click here</span>" + "\n" + "</a>" + "\n";
         string linkoneScript2 = "<a class=\"btn-slide2\" href=\"" + "$$$:.downLink$$$$" + "\" target=\"_blank\">" + "\n" + "<span class=\"circle2\"><i class=\"fa fa-$$$:.downFAicon$$$$\"></i></span>" + "\n" + "<span class=\"title2\">" + "$$$:.downName$$$$" + "</span>" + "\n" + "<span class=\"title-hover2\">Click here</span>" + "\n" + "</a>" + "\n";
            //public static string credit = "<h3>" + "\n" + "<span style=\"color: red;\">*** Credit for the mod: TigerOMs (offlinemods)</span></h3>";//Model//Another Comment:<i class=\"fa fa-download\"></i></span>"
            credit = "<h3>" + "\n" + "<span style=\"color: red;\">*** Credit for the mod: <span style=\"color: #2EC849\">$$$?.creditString$$$$</span></span></h3>" + "\n";
        // lastword = "<h3>" + "\n" + "<span style=\"color: orange;\">*** Do not re-upload the mods without asking me. Be aware!</span></h3>";//This is the old one
         lastword = "<h3>" + "\n" + "<span style=\"color: red;\">Don't modify the toast to make it yours. Thanks</span></h3>";
            //***Multiuser preset HTML
            string codeWrapLine = "<div id=\"wrap\">"+"\n"+"$$$:.var$$$$"+"\n"+"</div>"+"\n";
            //Icon Script
            string SP_IconScipt = "";
            if (thenow.appinfo.Icon.enable)
            {
                if (!String.IsNullOrWhiteSpace(thenow.appinfo.Icon.link))
                {
                    thenow.appinfo.Icon.link = thenow.appinfo.Icon.link.Replace(" ", "");
                    SP_IconScipt = iconScript.Replace("$$$!?.iconlink$$$$", thenow.appinfo.Icon.link);
                }
            }
            //Description Script
            string SP_DescScript = "";
            if (!string.IsNullOrWhiteSpace(thenow.appinfo.Description.GetDat()))
            {
                string[] cache_Desc = thenow.appinfo.Description.GetDat().Split('\n');
                if (cache_Desc.Length < 2)
                {
                    SP_DescScript = cache_Desc[0];
                }
                else
                {
                    string tmpcache = "";
                    foreach (string str in cache_Desc)
                    {
                        string str_edited = str;
                        //special process for multiple line <b>
                        string str_proc = str.Replace(" ", ""); ;
                        if (str_proc.Contains("</b>") && tmpcache == "<b>") { str_edited = tmpcache + str_edited; tmpcache = ""; }
                        if (str_proc.Contains("</b>") && tmpcache == "<b>") { str_edited = tmpcache + str_edited + tmpcache.Insert(1,"/"); }
                        if (!string.IsNullOrWhiteSpace(str_proc))
                        if (str_proc.Contains("<")&&str_proc.Contains(">"))
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
                        SP_DescScript += descLineScript.Replace("$$$.descLine$$$$", str_edited);
                    }
                }
            }
            SP_DescScript = descScript.Replace("$$$.descHtml$$$$", SP_DescScript);
            //Infogroup
            string SP_iGroupScript = "";
            string cache_modList = "";
            if (thenow.modinfo.UI.modTypeAllowData(thenow.modinfo.UI.currentindex))
            {
                string[] subcache = (!String.IsNullOrWhiteSpace(thenow.modinfo.UI.modTypeGetDat(thenow.modinfo.UI.currentindex)) ? thenow.modinfo.UI.modTypeGetDat(thenow.modinfo.UI.currentindex).Split('\n') : new string[1] { "" });
                if (subcache.Length < 2)
                {
                    cache_modList = " " + subcache[0];

                }
                else
                {
                    foreach (string str in subcache)
                    {
                        cache_modList += (!String.IsNullOrWhiteSpace(str) ? modListItem.Replace("$$$.modItem$$$$", str) : "");
                    }
                    cache_modList = modListHtml.Replace("$$$.modListPack$$$$", cache_modList);
                }
            }
            else
            {
                cache_modList = " " + MyFunction.FirstCharEachWordUpcase(thenow.modinfo.UI.modTypeGetname(thenow.modinfo.UI.currentindex));
            }
            SP_iGroupScript = MyFunction.MultiReplace(
                igroupHtml, "$$$.datAReq$$$$", 
                thenow.appinfo.androidReq, "$$$.datVer$$$$", thenow.appinfo.version,
                "$$$.datSize$$$$", thenow.appinfo.size, "$$$.modListHtml$$$$", cache_modList, 
                /*"$$$.internetReqHtml$$$$", internetReqHtml[thenow.appinfo.internetReq ? 1 : 0],*/ 
                "$$$.rootReqHtml$$$$", rootReqHtml[thenow.appinfo.rootReq ? 1 : 0], 
                "$$$.obbReqHtml$$$$", obbReqHtml[thenow.appinfo.obbReq ? 1 : 0],
                "$$$.extpermReqHtml$$$$", extpermReqHtml[thenow.appinfo.extpermReq ? 1 : 0]
                );
            SP_iGroupScript = igroupScript.Replace("$$$.igroupHtml$$$$", SP_iGroupScript);
            //Image Script //Undone
            string SP_ImageScript = "";
            const int sizefit = 640;
            if (thenow.postmedia.ImageList.Count > 0 && thenow.postmedia.ImageInScript)
            {
                for (int i = 0; i < thenow.postmedia.ImageList.Count; i++)
                {
                    if (thenow.postmedia.ImageList[i].enable)
                    {
                        int NewHeight = thenow.postmedia.ImageList[i].height >= thenow.postmedia.ImageList[i].width ? sizefit : Convert.ToInt32(Math.Truncate(thenow.postmedia.ImageList[i].height / thenow.postmedia.ImageList[i].width * sizefit));
                        int NewWidth = thenow.postmedia.ImageList[i].height <= thenow.postmedia.ImageList[i].width ? sizefit : Convert.ToInt32(Math.Truncate(thenow.postmedia.ImageList[i].width / thenow.postmedia.ImageList[i].height * sizefit));
                        string SP_ImageLink_cache = thenow.postmedia.ImageList[i].link;
                        if (thenow.appinfo.datasourcetype == "play")
                        {
                            if (SP_ImageLink_cache.Contains("-rw")) SP_ImageLink_cache = SP_ImageLink_cache.Replace("-rw", "");
                            if (SP_ImageLink_cache.Contains("=")) SP_ImageLink_cache = SP_ImageLink_cache.Remove(SP_ImageLink_cache.IndexOf("=")) + "=w" + NewWidth + "-h" + NewHeight;
                        }
                        SP_ImageScript += MyFunction.MultiReplace(imagecardScript, "$$$:.imageLink$$$$", SP_ImageLink_cache, "$$$:.imageOHeight$$$$", thenow.postmedia.ImageList[i].height.ToString(), "$$$:.imageOWidth$$$$", thenow.postmedia.ImageList[i].width.ToString(), "$$$:.imageNHeight$$$$", NewHeight.ToString(), "$$$:.imageNWidth$$$$", NewWidth.ToString());
                    }
                    //Đây là code tạm để thêm separate, nhớ sửa
                    if (i != thenow.postmedia.ImageList.Count - 1)
                        if (thenow.postmedia.ImageList[i].enable && thenow.postmedia.ImageList[i + 1].enable)
                        {
                            SP_ImageScript += seperateLineScript;
                        }
                }
            }
            SP_ImageScript = imageScript.Replace("$$$.imageHtml$$$$", SP_ImageScript);
            //Video Script //Undone
            string SP_VideoScript = "";

            SP_VideoScript = (string.IsNullOrWhiteSpace(thenow.postmedia.VideoReview.ID)) ? thenow.postmedia.VideoReview.generateID() : thenow.postmedia.VideoReview.ID;
            if (!String.IsNullOrWhiteSpace(SP_VideoScript))
            {
                SP_VideoScript = videoScript.Replace("$$$!?.videoID$$$$", SP_VideoScript);
               // if (SP_ImageScript != imageScript.Replace("$$$.imageHtml$$$$", ""))
               //     SP_VideoScript = /*seperateLineScript +*/ SP_VideoScript;
            }
            else
            {
                if (SP_ImageScript == imageScript.Replace("$$$.imageHtml$$$$", ""))
                    SP_VideoScript = seperateLineScript;

            }
            //Link Script // Undone
            string SP_DownloadScript = "";///* Fatal Param
            string SP_SourceScript = "";
            ///Additional Script after main script
            string script_postDownload = "";
            if (!string.IsNullOrEmpty(thenow.appinfo.datasource))
            {
                SP_SourceScript = thenow.appinfo.datasourcetype =="play"?MyFunction.MultiReplace(linkoneScript, "$$$:.downLink$$$$", thenow.appinfo.datasource, "$$$:.downName$$$$", thenow.appinfo.datasourcemask, "$$$:.downFAicon$$$$", "link"):"";
                //Temporarily v200516
                SP_SourceScript = thenow.appinfo.datasourcetype != "play" ? MyFunction.MultiReplace(linkoneScript, "$$$:.downLink$$$$", thenow.appinfo.datasource, "$$$:.downName$$$$", thenow.appinfo.datasourcemask, "$$$:.downFAicon$$$$", "link") : SP_SourceScript;
            }
            if (thenow.Downloadlink.Downloadlink.check || thenow.Downloadlink.OBBlink.check)
            {
                thenow.Downloadlink.MListEnable = thenow.Downloadlink.linklist.Count > 0;//Delete it When done
                if (!thenow.Downloadlink.MListEnable)
                {
                    if (thenow.Downloadlink.Downloadlink.check && !string.IsNullOrWhiteSpace(thenow.Downloadlink.Downloadlink.link))
                        SP_DownloadScript += MyFunction.MultiReplace(linkoneScript2, "$$$:.downLink$$$$", thenow.Downloadlink.Downloadlink.link, "$$$:.downName$$$$", thenow.Downloadlink.Downloadlink.linkalias, "$$$:.downFAicon$$$$", thenow.Downloadlink.Downloadlink.FAicon);
                    if (thenow.Downloadlink.OBBlink.check && !string.IsNullOrWhiteSpace(thenow.Downloadlink.OBBlink.link))
                        SP_DownloadScript += MyFunction.MultiReplace(linkoneScript2, "$$$:.downLink$$$$", thenow.Downloadlink.OBBlink.link, "$$$:.downName$$$$", thenow.Downloadlink.OBBlink.linkalias, "$$$:.downFAicon$$$$", thenow.Downloadlink.OBBlink.FAicon);
                    SP_DownloadScript = linkScript.Replace("$$$:.downlinkBundleScript$$$$", SP_DownloadScript);
                }
                /*v200116
                else
                {
                    string cache_downloadbundle = "";
                    if (thenow.Downloadlink.Downloadlink.check && !string.IsNullOrWhiteSpace(thenow.Downloadlink.Downloadlink.link))
                    {
                        cache_downloadbundle = MyFunction.MultiReplace(linkoneScript2, "$$$:.downLink$$$$", thenow.Downloadlink.Downloadlink.link, "$$$:.downName$$$$", thenow.Downloadlink.Downloadlink.linkalias, "$$$:.downFAicon$$$$", thenow.Downloadlink.Downloadlink.FAicon);
                        if (thenow.Downloadlink.linklist.Count > 0)
                        {
                            cache_downloadbundle += MyFunction.MultiReplace(linkoneScript, "$$$:.downLink$$$$", thenow.Downloadlink.linklist[0].link, "$$$:.downName$$$$", "Mirror", "$$$:.downFAicon$$$$", "rocket").Replace("class=\"btn-slide2\"", "class=\"btn-slide\"");
                        }
                        SP_DownloadScript += linkScript.Replace("$$$:.downlinkBundleScript$$$$", cache_downloadbundle);
                    }
                    if (thenow.Downloadlink.APKlink.check && !string.IsNullOrWhiteSpace(thenow.Downloadlink.APKlink.link))
                    {
                        SP_DownloadScript += MyFunction.MultiReplace(linkoneScript2, "$$$:.downLink$$$$", thenow.Downloadlink.APKlink.link, "$$$:.downName$$$$", thenow.Downloadlink.APKlink.linkalias, "$$$:.downFAicon$$$$", thenow.Downloadlink.Downloadlink.FAicon);
                        if (thenow.Downloadlink.linklist.Count > 1)
                        {
                            cache_downloadbundle += MyFunction.MultiReplace(linkoneScript, "$$$:.downLink$$$$", thenow.Downloadlink.linklist[1].link, "$$$:.downName$$$$", "Mirror", "$$$:.downFAicon$$$$", "rocket").Replace("class=\"btn-slide2\"", "class=\"btn-slide\"");
                        }
                        SP_DownloadScript += linkScript.Replace("$$$:.downlinkBundleScript$$$$", cache_downloadbundle);
                    }
                }*/
                else
                {
                    string cache_downloadbundle = "";
                    if (thenow.Downloadlink.Downloadlink.check && !string.IsNullOrWhiteSpace(thenow.Downloadlink.Downloadlink.link))
                    {
                        cache_downloadbundle = MyFunction.MultiReplace(linkoneScript2, "$$$:.downLink$$$$", thenow.Downloadlink.Downloadlink.link, "$$$:.downName$$$$", thenow.Downloadlink.Downloadlink.linkalias, "$$$:.downFAicon$$$$", thenow.Downloadlink.Downloadlink.FAicon);
                        if (thenow.Downloadlink.linklist.Count > 0)
                        {
                            cache_downloadbundle += MyFunction.MultiReplace(linkoneScript, "$$$:.downLink$$$$", thenow.Downloadlink.linklist[0].link, "$$$:.downName$$$$", "Mirror", "$$$:.downFAicon$$$$", "rocket").Replace("class=\"btn-slide2\"", "class=\"btn-slide\"");
                        }
                        SP_DownloadScript += linkScript.Replace("$$$:.downlinkBundleScript$$$$", cache_downloadbundle);
                    }

                    //Separately process
                    if (thenow.Downloadlink.OBBlink.check && !string.IsNullOrWhiteSpace(thenow.Downloadlink.OBBlink.link))
                    {
                        cache_downloadbundle = MyFunction.MultiReplace(linkoneScript2, "$$$:.downLink$$$$", thenow.Downloadlink.OBBlink.link, "$$$:.downName$$$$", thenow.Downloadlink.OBBlink.linkalias, "$$$:.downFAicon$$$$", thenow.Downloadlink.Downloadlink.FAicon);
                        if (thenow.Downloadlink.linklist.Count > 1)
                        {
                            cache_downloadbundle += MyFunction.MultiReplace(linkoneScript, "$$$:.downLink$$$$", thenow.Downloadlink.linklist[1].link, "$$$:.downName$$$$", "Mirror", "$$$:.downFAicon$$$$", "rocket").Replace("class=\"btn-slide2\"", "class=\"btn-slide\"");
                        }
                        script_postDownload=codeWrapLine.Replace("$$$:.var$$$$", cache_downloadbundle);
                    }
                }

            }
            SP_DownloadScript = SP_DownloadScript.Replace("$$$:.sourcelink$$$$", SP_SourceScript) + script_postDownload;
            //*/
            //Credit
            string SP_CreditScript = "";
            if (thenow.credit.now != null)
                SP_CreditScript = string.IsNullOrWhiteSpace(thenow.credit.now.GetPreview(true)) ? "" : credit.Replace("$$$?.creditString$$$$", thenow.credit.now.GetToUse());
            //Summary
            return postHtml = MyFunction.MultiReplace(layout, "$$$.iconScript$$$$", SP_IconScipt, "$$$.descScript$$$$", SP_DescScript, "$$$.igroupScript$$$$", SP_iGroupScript, "$$$.imageScript$$$$", SP_ImageScript, "$$$.videoScript$$$$", SP_VideoScript, "$$$.linkScript$$$$", SP_DownloadScript, "$$$.creadit$$$$", SP_CreditScript, "$$$.lastword", lastword);

        } // <----- HIDEN HERE
        
        /// <summary>
        /// Custom form post v211016
        /// </summary>
        /// 
        /// ///v211124
        /// ///add <!--more--> tag
        /// <param name="thenow"></param>
        /// <returns></returns>
        string postHtml_v211016_Processor(PostDataBundle thenow)
        {
            string toolscript = "<!--MMBS:211016:211124-->";
            string flagDesc = "<!--MMBS:contentDesc-->\n";
            string descButReveal = "<input " +
                    "onclick=\"if (this.parentNode.parentNode.getElementsByTagName('div')[1].getElementsByTagName('div')[0].style.display != '') { this.parentNode.parentNode.getElementsByTagName('div')[1].getElementsByTagName('div')[0].style.display = '';this.innerText = ''; this.value = 'Hide'; } else { this.parentNode.parentNode.getElementsByTagName('div')[1].getElementsByTagName('div')[0].style.display = 'none'; this.innerText = ''; this.value = 'Show Game Descriptions'; }\" " +
                    "onmouseover=\"this.style.backgroundColor = 'rgb(28,28,28)';\" onmouseout=\"this.style.backgroundColor = '#28A6E2';\"" +
                    " style=\"font-size: 20px; margin: 3px; padding: 5px; width: 300px; background-color: #28A6E2; border: none; border-radius: 2px; color: white;\"" +
                    " type=\"button\" value=\"Show Game Descriptions\">";
            string styleVIPadmin = "<!--Animation CSS by Daniel Riemer--> \n <style>@-webkit-keyframes aitf { 0% { background-position: 0% 50%; } 100% { background-position: 50% 100%; } }\n"
                + " #VIPadmin {background: url(https://imgur.com/u59ftm6t.jpg) repeat-y; background-size: cover;-webkit-background-clip: text!important;background-clip: text;text-shadow: 0 0 44px rgba(40, 166, 266);-webkit-text-fill-color: transparent;-webkit-animation: aitf 8s linear infinite;-webkit-transform: translate3d(0,0,0);-webkit-backface-visibility: hidden;}</style>\n";
            seperateLineScript = "<div><br></div>\n";
            //New Define script structure
            layout = toolscript 
                + "\n\n"
                + "$$$.styleCard$$$$"
                + "\n"
                + "$$$.iconScript$$$$" 
                + "\n"
                + "$$$.linkScript$$$$"//For 3 link box
                + "$$$.igroupScript$$$$"/*infogroup script*/
                + "<!--more-->\n"//Halt the page content for better Indexing
                + "$$$.videoScript$$$$"
                + "$$$.imageScript$$$$"
                + "$$$.descScript$$$$" 
                + "\n"
                + "\n"
                + "$$$.creadit$$$$"
                + "$$$.lastword";

            iconScript =
                "<div class=\"separator\" style=\"clear: both; text-align: center;\">"
                + "\n"
                + "<a href=\"" +/*param*/ "$$$!?.iconlink$$$$" + "\" style=\"margin-left: 1em; margin-right: 1em;\">"
                + "<img border=\"0\" data-original-height=\"180\" data-original-width=\"180\" src=\"" 
                +/*param*/ "$$$!?.iconlink$$$$" 
                + "\" />"
                + "</a>"
                + "\n"
                + "</div>"
                + "\n";
            
            descScript = 
                "<div><br></div>" 
                + "<div>\n<div style=\"display: flex; align-items: center; justify-content: center;\">\n" 
                + descButReveal 
                + "</div>"
                + "<div>"
                + "<div style=\"display:none\">" 
                + "<div><br></div>"
                + flagDesc
                    + /*param*/ "$$$.descHtml$$$$" 
                + "</div>" + "\n" 
                + "</div>\n</div>\n<br />";
            descLineScript = 
                "<div>"
                    + /*param*/ "$$$.descLine$$$$" 
                + "</div>" 
                + "\n";
            igroupScript = 
                seperateLineScript
                + "<h3>" + "\n" 
                + "Mod Info:</h3>" + "\n" 
                    +/*param*/ "$$$.igroupHtml$$$$" + "\n" 
                + "<br />";
            igroupHtml = "<ul>" + "\n"
                                        + "<li>Require: " + "$$$.datAReq$$$$" + "</li>" + "\n"
                                        + "<li>Version: " + "$$$.datVer$$$$" + "</li>" + "\n"
                                        + "<li>Mod feature(s):" + "$$$.modListHtml$$$$" + "</li>" + "\n"
                                        + "<li>File size: " + "$$$.datSize$$$$" + "</li>" + "\n"
                                        //+ "<li>Internet: " + "$$$.internetReqHtml$$$$" + "</li>" + "\n"
                                        + "<li>Needs Root: " + "$$$.rootReqHtml$$$$" + "</li>" + "\n"
                                        + "<li>Needs Obb: " + "$$$.obbReqHtml$$$$" + "</li>" + "\n"
                                        + "<li>Needs Special Permission: " + "$$$.extpermReqHtml$$$$" + "</li>" + "\n"
                                        + "</ul>" + "\n";
            modListHtml = "<ul>" + "\n" + "$$$.modListPack$$$$" + "</ul>";
            modListItem = "<li>" + "$$$.modItem$$$$" + "</li>" + "\n";
            //internetReqHtml;
            //rootReqHtml;
            imageScript = "<h3>" + "\n" + "Some images in the game:</h3>" + "\n" + "$$$.imageHtml$$$$";
            imagecardScript = "<div class=\"separator\" style=\"clear: both; text-align: center;\">" + "\n" + "<a href=" + "\"" + /*param*/ "$$$:.imageLink$$$$" + "\" imageanchor=\"1\" style=\"margin-left: 1em; margin-right: 1em;\">"
                                       + "<img border=\"0\" data-original-height=\"" + /*param*/ "$$$:.imageOHeight$$$$" + "\"data-original-width=\"" + /*param*/ "$$$:.imageOWidth$$$$" + "\"height=\"" + /*param*/ "$$$:.imageNHeight$$$$" + "\"src=\"" + /*param*/ "$$$:.imageLink$$$$" + "\"width=\"" + /*param*/ "$$$:.imageNWidth$$$$" + "\" /></a ></div >" + "\n";
           
            videoScript = "<h3>" + "\n" + "Preview video:</h3>" + "\n"
               + "<div class=\"separator\" style=\"clear: both; text-align: center;\">" + "\n"
               + "<iframe allowfullscreen=\"\" class=\"YOUTUBE-iframe-video\" data-thumbnail-src=\"https://i.ytimg.com/vi/"
               + /*param*/ "$$$!?.videoID$$$$" + "/0.jpg\" frameborder=\"0\" height=\"266\" src=\"https://www.youtube.com/embed/"
               + /*param*/ "$$$!?.videoID$$$$" + "?feature=player_embedded\" width=\"320\"></iframe></div>" + "\n" + "<div><br></div>";
            string linkScript = "<div id=\"wrap\">" + "\n" + "$$$:.sourcelink$$$$" + "\n" + "$$$:.downlinkBundleScript$$$$" + "</div>" + "\n";

            //"<a class=\"btn-slide\" href=\"" + "$$$:.downLink$$$$" + "\" target=\"_blank\">" + "\n" + "<span class=\"circle\"><i class=\"fa fa-$$$:.downFAicon$$$$\"></i></span>" + "\n" + "<span class=\"title\">" + "$$$:.downName$$$$" + "</span>" + "\n" + "<span class=\"title-hover\">Click here</span>" + "\n" + "</a>" + "\n";
            string linkoneScript = "<div class=\"buttons\"><button class=\"btn-hover color-1\" onclick=\"window.open('$$$:.downLink$$$$')\">$$$:.downName$$$$</button></div>";
            string linkoneScript2 = "<div class=\"buttons\"><button class=\"btn-hover color-9\" onclick=\"window.open('$$$:.downLink$$$$')\">$$$:.downName$$$$</button></div>";
            credit = "<h3>" + "\n" + "<span style=\"color: red;\">*** Credit for the mod: <span id=\"$$$?.creditLevel$$$$\" style=\"color: #28A6E2\">$$$?.creditString$$$$</span></span></h3>" + "\n";
            lastword = "<h3>" + "\n" + "<span style=\"color: red;\">Don't modify the toast to make it yours. Thanks</span></h3>";
            //***Multiuser preset HTML
            string codeWrapLine = "<div id=\"wrap\">" + "\n" + "$$$:.var$$$$" + "\n" + "</div>" + "\n";
            //cache for special style using in the whole post
            string SP_styleCard = "";
            //Icon Script
            string SP_IconScipt = "";
            if (thenow.appinfo.Icon.enable)
            {
                if (!String.IsNullOrWhiteSpace(thenow.appinfo.Icon.link))
                {
                    thenow.appinfo.Icon.link = thenow.appinfo.Icon.link.Replace(" ", "");
                    SP_IconScipt = iconScript.Replace("$$$!?.iconlink$$$$", thenow.appinfo.Icon.link);
                }
            }
            //Description Script
            string SP_DescScript = "";
            if (!string.IsNullOrWhiteSpace(thenow.appinfo.Description.GetDat()))
            {
                string[] cache_Desc = thenow.appinfo.Description.GetDat().Split('\n');
                if (cache_Desc.Length < 2)
                {
                    SP_DescScript = cache_Desc[0];
                }
                else
                {
                    string tmpcache = "";
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
                        SP_DescScript += descLineScript.Replace("$$$.descLine$$$$", str_edited);
                    }
                }
            }
            SP_DescScript = descScript.Replace("$$$.descHtml$$$$", SP_DescScript);
            //Infogroup
            string SP_iGroupScript = "";
            string cache_modList = "";
            if (thenow.modinfo.UI.modTypeAllowData(thenow.modinfo.UI.currentindex))
            {
                string[] subcache = !String.IsNullOrWhiteSpace(thenow.modinfo.UI.modTypeGetDat(thenow.modinfo.UI.currentindex)) ? thenow.modinfo.UI.modTypeGetDat(thenow.modinfo.UI.currentindex).Split('\n') : new string[1] { "" };
                if (subcache.Length < 2)
                {
                    cache_modList = " " + subcache[0];

                }
                else
                {
                    foreach (string str in subcache)
                    {
                        cache_modList += !String.IsNullOrWhiteSpace(str) ? modListItem.Replace("$$$.modItem$$$$", str) : "";
                    }
                    cache_modList = modListHtml.Replace("$$$.modListPack$$$$", cache_modList);
                }
            }
            else
            {
                cache_modList = " " + MyFunction.FirstCharEachWordUpcase(thenow.modinfo.UI.modTypeGetname(thenow.modinfo.UI.currentindex));
            }
            SP_iGroupScript = MyFunction.MultiReplace(
                igroupHtml, "$$$.datAReq$$$$",
                thenow.appinfo.androidReq, "$$$.datVer$$$$", thenow.appinfo.version,
                "$$$.datSize$$$$", thenow.appinfo.size, "$$$.modListHtml$$$$", cache_modList,
                /*"$$$.internetReqHtml$$$$", internetReqHtml[thenow.appinfo.internetReq ? 1 : 0],*/
                "$$$.rootReqHtml$$$$", rootReqHtml[thenow.appinfo.rootReq ? 
                // temp implement
                (!string.IsNullOrWhiteSpace(thenow.Downloadlink.Downloadlink.linkalias)? (thenow.Downloadlink.Downloadlink.linkalias == "Signed"?2:1): 1)
                : 0],
                "$$$.obbReqHtml$$$$", obbReqHtml[thenow.appinfo.obbReq ? 1 : 0],
                "$$$.extpermReqHtml$$$$", extpermReqHtml[thenow.appinfo.extpermReq ? 1 : 0]
                );
            SP_iGroupScript = igroupScript.Replace("$$$.igroupHtml$$$$", SP_iGroupScript);
            //Image Script //Undone
            string SP_ImageScript = "";
            const int sizefit = 640;
            if (thenow.postmedia.ImageList.Count > 0 && thenow.postmedia.ImageInScript)
            {
                for (int i = 0; i < thenow.postmedia.ImageList.Count; i++)
                {
                    if (thenow.postmedia.ImageList[i].enable)
                    {
                        int NewHeight = thenow.postmedia.ImageList[i].height >= thenow.postmedia.ImageList[i].width ? sizefit : Convert.ToInt32(Math.Truncate(thenow.postmedia.ImageList[i].height / thenow.postmedia.ImageList[i].width * sizefit));
                        int NewWidth = thenow.postmedia.ImageList[i].height <= thenow.postmedia.ImageList[i].width ? sizefit : Convert.ToInt32(Math.Truncate(thenow.postmedia.ImageList[i].width / thenow.postmedia.ImageList[i].height * sizefit));
                        string SP_ImageLink_cache = thenow.postmedia.ImageList[i].link;
                        
                        if (thenow.appinfo.datasourcetype == "play" || SP_ImageLink_cache.Split('/')[2]=="play-lh.googleusercontent.com")
                        {
                            if (SP_ImageLink_cache.Contains("-rw")) SP_ImageLink_cache = SP_ImageLink_cache.Replace("-rw", "");
                            if (SP_ImageLink_cache.Contains("=")) SP_ImageLink_cache = SP_ImageLink_cache.Remove(SP_ImageLink_cache.IndexOf("=")) + "=w" + NewWidth + "-h" + NewHeight;
                        }
                        SP_ImageScript += MyFunction.MultiReplace(imagecardScript, "$$$:.imageLink$$$$", SP_ImageLink_cache, "$$$:.imageOHeight$$$$", thenow.postmedia.ImageList[i].height.ToString(), "$$$:.imageOWidth$$$$", thenow.postmedia.ImageList[i].width.ToString(), "$$$:.imageNHeight$$$$", NewHeight.ToString(), "$$$:.imageNWidth$$$$", NewWidth.ToString());
                    }
                    //Đây là code tạm để thêm separate, nhớ sửa
                    if (i != thenow.postmedia.ImageList.Count - 1)
                        if (thenow.postmedia.ImageList[i].enable && thenow.postmedia.ImageList[i + 1].enable)
                        {
                            SP_ImageScript += "";
                        }
                }
            }
            SP_ImageScript = imageScript.Replace("$$$.imageHtml$$$$", SP_ImageScript);
            //Video Script //Undone
            string SP_VideoScript = "";

            SP_VideoScript = (string.IsNullOrWhiteSpace(thenow.postmedia.VideoReview.ID)) ? thenow.postmedia.VideoReview.generateID() : thenow.postmedia.VideoReview.ID;
            if (!String.IsNullOrWhiteSpace(SP_VideoScript))
            {
                SP_VideoScript = videoScript.Replace("$$$!?.videoID$$$$", SP_VideoScript);
                // if (SP_ImageScript != imageScript.Replace("$$$.imageHtml$$$$", ""))
                //     SP_VideoScript = /*seperateLineScript +*/ SP_VideoScript;
            }
            else
            {
                if (SP_ImageScript == imageScript.Replace("$$$.imageHtml$$$$", ""))
                    SP_VideoScript = seperateLineScript;

            }
            //Link Script // Undone
            string SP_DownloadScript = "";///* Fatal Param
            string SP_SourceScript = "";
            ///Additional Script after main script
            string script_postDownload = "";
            if (!string.IsNullOrEmpty(thenow.appinfo.datasource))
            {
                SP_SourceScript = thenow.appinfo.datasourcetype == "play" ? MyFunction.MultiReplace(linkoneScript, "$$$:.downLink$$$$", thenow.appinfo.datasource, "$$$:.downName$$$$", thenow.appinfo.datasourcemask, "$$$:.downFAicon$$$$", "link") : "";
                //Temporarily v200516
                SP_SourceScript = thenow.appinfo.datasourcetype != "play" ? MyFunction.MultiReplace(linkoneScript, "$$$:.downLink$$$$", thenow.appinfo.datasource, "$$$:.downName$$$$", thenow.appinfo.datasourcemask, "$$$:.downFAicon$$$$", "link") : SP_SourceScript;
            }
            if (thenow.Downloadlink.Downloadlink.check || thenow.Downloadlink.OBBlink.check)
            {
                thenow.Downloadlink.MListEnable = thenow.Downloadlink.linklist.Count > 0;//Delete it When done
                // Two Download Link Only
                if (!thenow.Downloadlink.MListEnable)
                {
                    if (thenow.Downloadlink.Downloadlink.check && !string.IsNullOrWhiteSpace(thenow.Downloadlink.Downloadlink.link))
                        SP_DownloadScript += MyFunction.MultiReplace(linkoneScript2, "$$$:.downLink$$$$", thenow.Downloadlink.Downloadlink.link, "$$$:.downName$$$$", thenow.Downloadlink.Downloadlink.linkalias, "$$$:.downFAicon$$$$", thenow.Downloadlink.Downloadlink.FAicon);
                    if (thenow.Downloadlink.OBBlink.check && !string.IsNullOrWhiteSpace(thenow.Downloadlink.OBBlink.link))
                        SP_DownloadScript += MyFunction.MultiReplace(linkoneScript2, "$$$:.downLink$$$$", thenow.Downloadlink.OBBlink.link, "$$$:.downName$$$$", thenow.Downloadlink.OBBlink.linkalias, "$$$:.downFAicon$$$$", thenow.Downloadlink.OBBlink.FAicon);
                    if (thenow.Downloadlink.OMirrorlink.check && !string.IsNullOrWhiteSpace(thenow.Downloadlink.OMirrorlink.link))
                        SP_DownloadScript += MyFunction.MultiReplace(linkoneScript2, "$$$:.downLink$$$$", thenow.Downloadlink.OMirrorlink.link, "$$$:.downName$$$$", thenow.Downloadlink.OMirrorlink.linkalias, "$$$:.downFAicon$$$$", thenow.Downloadlink.OMirrorlink.FAicon);
                    SP_DownloadScript = linkScript.Replace("$$$:.downlinkBundleScript$$$$", SP_DownloadScript);
                }
               
                else
                {
                    string cache_downloadbundle = "";
                    if (thenow.Downloadlink.Downloadlink.check && !string.IsNullOrWhiteSpace(thenow.Downloadlink.Downloadlink.link))
                    {
                        cache_downloadbundle = MyFunction.MultiReplace(linkoneScript2, "$$$:.downLink$$$$", thenow.Downloadlink.Downloadlink.link, "$$$:.downName$$$$", thenow.Downloadlink.Downloadlink.linkalias, "$$$:.downFAicon$$$$", thenow.Downloadlink.Downloadlink.FAicon);
                       
                        /*if (thenow.Downloadlink.APKlink.check && !string.IsNullOrWhiteSpace(thenow.Downloadlink.APKlink.link))
                            SP_DownloadScript += MyFunction.MultiReplace(linkoneScript2, "$$$:.downLink$$$$", thenow.Downloadlink.APKlink.link, "$$$:.downName$$$$", thenow.Downloadlink.APKlink.linkalias, "$$$:.downFAicon$$$$", thenow.Downloadlink.APKlink.FAicon);*/
                        //SP_DownloadScript += linkScript.Replace("$$$:.downlinkBundleScript$$$$", cache_downloadbundle);
                    }
                    if (thenow.Downloadlink.linklist.Count > 0)
                    {
                        cache_downloadbundle += MyFunction.MultiReplace(linkoneScript, "$$$:.downLink$$$$", thenow.Downloadlink.linklist[0].link, "$$$:.downName$$$$", thenow.Downloadlink.linklist[0].linkalias, "$$$:.downFAicon$$$$", "rocket").Replace("class=\"btn-slide2\"", "class=\"btn-slide\"");
                        //SP_DownloadScript += linkScript.Replace("$$$:.downlinkBundleScript$$$$", cache_downloadbundle);
                    }
                    //Separately process
                    if (thenow.Downloadlink.OBBlink.check && !string.IsNullOrWhiteSpace(thenow.Downloadlink.OBBlink.link))
                    {
                        cache_downloadbundle += MyFunction.MultiReplace(linkoneScript2, "$$$:.downLink$$$$", thenow.Downloadlink.OBBlink.link, "$$$:.downName$$$$", thenow.Downloadlink.OBBlink.linkalias, "$$$:.downFAicon$$$$", thenow.Downloadlink.Downloadlink.FAicon);
                        /*if (thenow.Downloadlink.linklist.Count > 1)
                        {
                            cache_downloadbundle += MyFunction.MultiReplace(linkoneScript, "$$$:.downLink$$$$", thenow.Downloadlink.linklist[1].link, "$$$:.downName$$$$", "Mirror", "$$$:.downFAicon$$$$", "rocket").Replace("class=\"btn-slide2\"", "class=\"btn-slide\"");
                        }
                        script_postDownload = codeWrapLine.Replace("$$$:.var$$$$", cache_downloadbundle);*/
                    }
                    //todo: Refactor code to match export layout
                    if (thenow.Downloadlink.OMirrorlink.check && !string.IsNullOrWhiteSpace(thenow.Downloadlink.OMirrorlink.link))
                    {
                        cache_downloadbundle += MyFunction.MultiReplace(linkoneScript2, "$$$:.downLink$$$$", thenow.Downloadlink.OMirrorlink.link, "$$$:.downName$$$$", thenow.Downloadlink.OMirrorlink.linkalias, "$$$:.downFAicon$$$$", thenow.Downloadlink.Downloadlink.FAicon);
                        /*if (thenow.Downloadlink.linklist.Count > 1)
                        {
                            cache_downloadbundle += MyFunction.MultiReplace(linkoneScript, "$$$:.downLink$$$$", thenow.Downloadlink.linklist[1].link, "$$$:.downName$$$$", "Mirror", "$$$:.downFAicon$$$$", "rocket").Replace("class=\"btn-slide2\"", "class=\"btn-slide\"");
                        }
                        script_postDownload = codeWrapLine.Replace("$$$:.var$$$$", cache_downloadbundle);*/
                    }
                    SP_DownloadScript = linkScript.Replace("$$$:.downlinkBundleScript$$$$", cache_downloadbundle);
                }

            }
            
            SP_DownloadScript = SP_DownloadScript.Replace("$$$:.sourcelink$$$$", SP_SourceScript) /*+ script_postDownload*/;
            //*/
            //Credit
            string SP_CreditScript = "";
            if (thenow.credit.now != null)
            {
                SP_CreditScript = string.IsNullOrWhiteSpace(thenow.credit.now.GetPreview(true)) ? "" : credit.Replace("$$$?.creditString$$$$", thenow.credit.now.GetToUse());
                string cache_creditLevel = "";
                if (thenow.credit.now.host == "offlinemods")
                {
                    cache_creditLevel = "VIPadmin";
                    SP_styleCard += styleVIPadmin;
                }
                SP_CreditScript = SP_CreditScript.Replace("$$$?.creditLevel$$$$",cache_creditLevel );

            }
            //Summary
            return postHtml = MyFunction.MultiReplace(layout, "$$$.styleCard$$$$", SP_styleCard, "$$$.iconScript$$$$", SP_IconScipt, "$$$.descScript$$$$", SP_DescScript, "$$$.igroupScript$$$$", SP_iGroupScript, "$$$.imageScript$$$$", SP_ImageScript, "$$$.videoScript$$$$", SP_VideoScript, "$$$.linkScript$$$$", SP_DownloadScript, "$$$.creadit$$$$", SP_CreditScript, "$$$.lastword", lastword);

        }
        public void SpecificProcess(PostDataBundle thenow,Form UI,string code, params string[] para)
        {
            string[] codeseg = code.Split(':');
            switch (codeseg[0])
            {
                case "mmbsOther":
                    switch (codeseg[1])
                    {
                        case "PMT":
                            switch (codeseg[2]) {
                                case "current": PMT();
                                    break;
                            }break;

                    }break;
            }
            void PMT()
            {
                //tmp code for BTH
                if (System.IO.File.Exists(Class1.GetToken("BTH")))
                {
                    BTH(); return;
                }
                //Title Process
                titleprocRes = "";
                titleuse = false;
                if (!string.IsNullOrWhiteSpace(thenow.appinfo.name))
                {
                    if (thenow.appinfo.version == "Varies with device") MessageBox.Show("Data is not ready to use: Ver. Varies with device", "WARNING");
                    titleprocRes = (thenow.appinfo.name).Trim(' ') + (thenow.appinfo.version == "Varies with device"?"":" v" +thenow.appinfo.version) +" Mod APK";
                    titleuse = true;
                }
                //SearchKeyword Process
                searchproRes = "";
                searchuse = false;
                //For codepage process
                //v20200608PMT
                string toolscript = "<!--MMBS:230301PMT-->";
                layout = "$$$.iconScript$$$$" + "\n\n"
                + "$$$.datasourceScript$$$$" + "\n\n"
                + "$$$.igroupScript$$$$"/*infogroup script*/+ "\n\n\n"
                + "$$$.modfeatureScript$$$$" + "\n\n\n"
                + "$$$.credit$$$$" + "\n\n\n"
                + "$$$.howtoScript$$$$" + "\n\n\n\n"
                + "$$$.downlinkScript$$$$" +"\n\n\n\n"
                + "$$$.tutorialslinkScript$$$$";
                string iconScript = string.IsNullOrWhiteSpace(thenow.appinfo.Icon.link)?"":$"[IMG]{thenow.appinfo.Icon.link}[/IMG]";
                string datasourceScript = thenow.appinfo.datasourcetype == "play" 
                    ? $"Playstore Link: [URL='{thenow.appinfo.datasource}']{thenow.appinfo.name} - Apps on Google Play[/URL]"
                    : $"Original APK: [URL='{thenow.appinfo.datasource}']{thenow.appinfo.name}[/URL]";
                string igroupScript =
                    $"[COLOR=#ff0000]Game Name: {thenow.appinfo.name}[/COLOR]\n"
                    + $"Game Version: {(thenow.appinfo.version == "Varies with device" ? "" : thenow.appinfo.version)}"
                    + $"\nNeeds OBB: [COLOR=#80ff00]{(thenow.appinfo.obbReq ? "Yes" : "No")}[/COLOR]"
                    + $"\nNeeds Root: [COLOR=#00ff00]{(thenow.appinfo.rootReq ? "Yes" : "No")}[/COLOR]"
                    ;
                    //+ $"\nNeeds external permission: [COLOR=#00ff00]{(thenow.appinfo.extpermReq ? "Yes" : "No")}[/COLOR]";
                string modfeatureScript = "[COLOR=#ff0000]*MOD Features*[/COLOR]\n";
                string credit = 
                    thenow.credit.now != null
                    ? $"[COLOR=rgb(255, 0, 0)]***Credit for the mod:[/COLOR] [B][COLOR=rgb(0, 255, 0)]" +
                    $"{(string.IsNullOrWhiteSpace(thenow.credit.now.GetPreview(true)) ? "" : (thenow.credit.now.GetPreview(true)== "OfflineMods.Net (offlinemods)" ? "OfflineMods.Net" : thenow.credit.now.GetToUse()))}" +
                    $"[/COLOR][/B]":"";
                string howtoScript = 
                    "[COLOR=#ff0000]*How to install (click the spoilers to read)*[/COLOR]\n\n" +
                    "[SPOILER=\"Signed APKs\"]\r\n" +
                    "Signed APKs do work on all Android devices (rooted + non-rooted).\r\n" +
                    "Signed APKs are in the most cases the only provided files by the mod publisher as they work for everyone.\r\n\r\n" +
                    "1.) Remove the original game/app.\r\n" +
                    "2.) Download the MOD APK.\r\n" +
                    "3.) Install the downloaded MOD APK.\r\n" +
                    "4.) Enjoy.\r\n\r\n" +
                    "Google login possible? [COLOR=#ff0000]No.[/COLOR]\r\n" +
                    "Facebook login possible? [COLOR=#00ff00]Yes. But you have to remove the Facebook App from your device.[/COLOR]\r\n" +
                    "Specific game account login possible (for example: E-Mail, HIVE, Kakao)? [COLOR=#00ff00]Yes.[/COLOR]\r\n\r\n" +
                    "[B]Notes:[/B]\r\n" +
                    "- If you used our MOD APK before and just want to update, you can install the new MOD APK on top of the old without removing the game/app first.\r\n" +
                    "- In-App purchases are not possible on signed APKs as they require Google services similar to the Google login process.[/SPOILER]\r\n\r\n" +
                    "[SPOILER=\"Unsigned APKs\"]\r\n" +
                    "Unsigned APKs do only work on rooted and patched devices/environments.\r\n" +
                    "These are not always provided by the mod publisher as they do only work under certain circumstances.\r\n\r\n" +
                    "1.) Your device must be rooted.\r\n" +
                    "2.) Your device must be patched to ignore app signatures. This can be done with the help of tools such as Luckypatcher or Xposed.\r\n\r\n" +
                    "Once you fill that requirements the process is the same as with signed APKs with the difference that you can overwrite the original game/app with the MOD APK without removing it first.\r\n\r\n" +
                    "1.) Download the unsigned MOD APK.\r\n" +
                    "2.) Install the unsigned MOD APK.\r\n" +
                    "3.) Enjoy.\r\n\r\n" +
                    "[B]Note:[/B]\r\n" +
                    "For the case the unsigned APK does fail to install: Your device patch is not done correctly!\r\n\r\n" +
                    "Google login possible? [COLOR=#00ff00]Yes.[/COLOR]\r\n" +
                    "Facebook login possible? [COLOR=#00ff00]Yes. Even with Facebook App installed.[/COLOR]\r\n" +
                    "Specific game account login possible (for example: E-Mail, HIVE, Kakao)? [COLOR=#00ff00]Yes.[/COLOR]\r\n\r\n" +
                    "You are rooted and want to know how to patch your device? Please [URL='https://platinmods.com/threads/.15/']click here[/URL] for more information.[/SPOILER]\r\n\r\n" +
                    "[SPOILER=\"How to install OBB files\"]\r\n\r\n" +
                    "OBB files are not required by every game/app. If necessary, the mod publisher will [U]usually[/U] provide them and tell you that they are needed.\r\n\r\n" +
                    "1.) Download the OBB file/files.\r\n" +
                    "2.) Download the MOD APK.\r\n" +
                    "3.) Move the OBB files with the help of a filemanager to Android/obb/<packagecode> on your device.\r\n" +
                    "4.) Install the downloaded MOD APK.\r\n" +
                    "5.) Enjoy.\r\n\r\n" +
                    "The OBB files are either provided as \".obb\" files or as \".zip\" files. ZIP files do require to be extracted first.\r\n\r\n" +
                    "Still facing issues? Please [URL='https://platinmods.com/threads/.178664/']click here[/URL] for more details.[/SPOILER]\r\n\r\n\r\n";
                string downlinkScript = $"[COLOR=#00ff00][U]Free Download:[/U][/COLOR]\n" +
                    $"[HIDE]{thenow.Downloadlink.Downloadlink.link}\n\nMirror:\n{thenow.Downloadlink.OMirrorlink.link}[/HIDE]";
                string tutorialslinkScript = "[COLOR=#ff0000]Tutorials:[/COLOR]\r\n" +
                    "[URL='https://platinmods.com/threads/.220/']How to sign up and download on Platinmods.com[/URL]\r\n" +
                    "[URL='https://platinmods.com/threads/.178666/']List of useful tutorials about how to use this website and its content[/URL]";
                
                
                string cache_modList = "";
                if (thenow.modinfo.UI.modTypeAllowData(thenow.modinfo.UI.currentindex))
                {
                    string[] subcache = (!String.IsNullOrWhiteSpace(thenow.modinfo.UI.modTypeGetDat(thenow.modinfo.UI.currentindex)) ? thenow.modinfo.UI.modTypeGetDat(thenow.modinfo.UI.currentindex).Split('\n') : new string[1] { "" });
                    if (subcache.Length < 2)
                    {
                        if (subcache.Length>0)
                        cache_modList = "• " + subcache[0];

                    }
                    else
                    {
                        for (int count=0;count< subcache.Length;count++)
                        {
                            string str = subcache[count];
                            cache_modList += (!String.IsNullOrWhiteSpace(str) ? $"{count+1}. {str}{(count+1==subcache.Length?"":"\n")}" : "");
                        }
                    }
                }
                modfeatureScript = modfeatureScript+cache_modList;

                postHtml = MyFunction.MultiReplace(layout, 
                    "$$$.iconScript$$$$", iconScript, 
                    "$$$.datasourceScript$$$$", datasourceScript,
                    "$$$.igroupScript$$$$", igroupScript,
                    "$$$.modfeatureScript$$$$", modfeatureScript,
                    "$$$.credit$$$$", credit,
                    "$$$.howtoScript$$$$", howtoScript,
                    "$$$.downlinkScript$$$$", downlinkScript,
                    "$$$.tutorialslinkScript$$$$", tutorialslinkScript);
                if (!string.IsNullOrWhiteSpace(postHtml)) UI.Controls["butPost"].Text = "BBcodes";

            }
            //No update
            void BTH()
            {
                try
                {

                    string SP_ImageList = "";
                    if (thenow.postmedia.ImageList.Count > 0 && thenow.postmedia.ImageInScript)
                    {
                        for (int i = 0; i < thenow.postmedia.ImageList.Count; i++)
                        {
                            if (thenow.postmedia.ImageList[i].enable)
                            {
                                string SP_ImageLink_cache = thenow.postmedia.ImageList[i].link;
                                SP_ImageList += $"[img]{SP_ImageLink_cache}[/img]\n";
                            }
                        }
                    }

                    string cache = System.IO.File.ReadAllText("C:\\BloggerSupporter\\buithanhhieu.txt");
                    postHtml = MyFunction.MultiReplace(cache,
                        "{{icon}}", (string.IsNullOrWhiteSpace(thenow.appinfo.Icon.link) ? "" : thenow.appinfo.Icon.link),
                        "{{source}}",thenow.appinfo.datasource,
                        "{{name}}", thenow.appinfo.name,
                        "{{version}}", (thenow.appinfo.version == "Varies with device" ? "" : thenow.appinfo.version),
                        "{{filesize}}", thenow.appinfo.size,
                        "{{reqAndroid}}", thenow.appinfo.androidReq,
                        "{{modinfo}}", thenow.modinfo.UI.modTypeGetDat(thenow.modinfo.UI.currentindex),
                        "{{desc}}", thenow.appinfo.Description.GetDat(),
                        "{{downloadlink}}", thenow.Downloadlink.Downloadlink.link,
                        "{{obblink}}", thenow.Downloadlink.OBBlink.link,
                        "{{mirrorlink}}", thenow.Downloadlink.OMirrorlink.link,
                        "{{videolink}}", thenow.postmedia.VideoReview.link,
                        "{{imglist}}", SP_ImageList
                        );
                    if (!string.IsNullOrWhiteSpace(postHtml)) UI.Controls["butPost"].Text = "BBcodes";
                } catch(Exception e)
                {
                    System.Windows.Forms.MessageBox.Show(e.Message);
                }
            }
        }
        public string Get()
        {
            return "";
        }
    }
    
    class Module
    {
        public class SearchKeywordModule
        {
            // Spiral Tower, Spiral Tower mod, Spiral Tower mod apk, download Spiral Tower mod, download Spiral Tower mod apk
            static string[] keyword = new string[] { "*name*", "*name* *type*", "*name* *type* apk", "download *name* *type*", "download *name* *type* apk", "Game *name* *type* APK" };

            public string GetResStr(string modtype, string name, int keycode)
            {
                if (keyword.Length >= keycode)
                {
                    return keyword[keycode].Replace("*name*", name).Replace("*type*", modtype);
                }
                return "";
            }
            public static string GetResStr(string modtype, params string[] name)
            {
                string cache = "";
                if (name != null)
                {
                    for (int i = 0; i < name.Length; i++)
                    {
                        string cache1 = name[i];
                        if (!String.IsNullOrWhiteSpace(cache1))
                        {
                            for (int j = 0; j < keyword.Length; j++)
                            {
                                cache += keyword[j].Replace("*name*", cache1).Replace("*type*", modtype) + ((j == keyword.Length - 1) && (i == name.Length - 1) ? "" : ", ");
                            }
                        }
                    }
                }
                return cache;

            }

        }
    }
   public static class ProjectInterfaceData
    {
        public class ModType
        {
            private List<BoxType> modTypeList;
            public int currentindex=0;
            public ModType()
            {
                initdata();
               
            }
            public ModType(int current)
            {
                initdata();
                currentindex = current;
            }
            public void initdata()
            {
                ModTypeList = new List<BoxType>();
                modTypeList.Add(new BoxType("MOD", "mod", true, System.Drawing.Color.Lime));
                modTypeList.Add(new BoxType("PAID", "paid", false, System.Drawing.Color.Aqua));
                // modTypeList.Add(new BoxType('SALE', 'sale', false, System.Drawing.Color.Yellow));
            }
            public string modTypeGetname(int index) => modTypeList[index].name;
            public string modTypeGetkey(int index) => modTypeList[index].keyword;
            public bool modTypeSetData(string dat, int index)
            {
                modTypeList[index].Data = dat;
                return true;
            }
            public string modTypeGetDat(int index) => modTypeList[index].Data;
            public bool modTypeAllowData(int index) => modTypeList[index].allowEdit;
            public System.Drawing.Color modTypegetcolor(int index) => modTypeList[index].Maincolor;
            public int Getnext() => (currentindex + 1) % modTypeList.Count();
            private List<BoxType> ModTypeList { get => modTypeList; set => modTypeList = value; }

            class BoxType
            {
                public bool allowEdit;
                public string Data;
                public string name;
                public string keyword;
                public System.Drawing.Color Maincolor;
                public  BoxType(string name, string keyword, bool allowEdit, System.Drawing.Color Maincolor)
                {
                    this.name = name;
                    this.keyword = keyword;
                    this.allowEdit = allowEdit;
                    this.Maincolor = Maincolor;
                }
            }
        }
    }
    
}
