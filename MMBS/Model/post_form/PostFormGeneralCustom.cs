using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Web.UI;
using System.Web.UI.WebControls.Expressions;
using RTF;
using Scriban;
using Scriban.Parsing;
using Scriban.Runtime;
using Scriban.Syntax;
namespace MMBS.Model.PostForm
{
    public class PostFormGeneralCustom
    {
        public MmbsTemplateModelv1 data;
        public bool exportData;
        public string generate(string templatePath, string fallbackPath = "")
        {
            string template = "";
            if (System.IO.File.Exists(templatePath))
            {
                template = System.IO.File.ReadAllText(templatePath);
            }
            else if (System.IO.File.Exists(fallbackPath))
            {
                template = System.IO.File.ReadAllText(fallbackPath);
            }
            var engine = Template.Parse(template);
            // Render and suppress default member rename 
            var result = engine.Render(data, member => member.Name);
            return result;
        }

        public static string generate(PostDataBundle bundle, string templatePath, string fallbackPath = "")
        {
            PostFormGeneralCustom instance = new PostFormGeneralCustom();
            instance.prepareData(bundle);
            return instance.generate(templatePath, fallbackPath);
        }
        public enum ScribanMessageType
        {
            Compile,
            Runtime
        }
        public class ScribanLogMessage
        {
            public SourceSpan span;
            public string message;
            public ScribanMessageType type;
        }
        public class ScribanException : Exception
        {
            public ScribanLogMessage[] messages;
            public ScribanException(LogMessageBag messages)
            {
                
                this.messages = messages.Select((o)=> new ScribanLogMessage()
                {
                    span = o.Span,
                    message = o.Message,
                    type = ScribanMessageType.Compile   
                }).ToArray();
            }
            public ScribanException(string message, SourceSpan span, ScribanMessageType type = ScribanMessageType.Runtime)
            {
                List<ScribanLogMessage> messages = new List<ScribanLogMessage>();
                messages.Add(new ScribanLogMessage()
                {
                    message = message,
                    span = span,
                    type = type
                }) ;
                this.messages = messages.ToArray();
            }
            public static SourceSpan quickSpan(int start, int end,string fileName = "", string content = "")
            {
                string text = String.IsNullOrEmpty(content)? File.ReadAllText(fileName): content;
                int startLine = text.Substring(0,start-1).Count(x => x == '\n')+1;
                int startColumn = start - text.Substring(0,start-1).LastIndexOf('\n');
                int endLine = text.Substring(0,end-1).Count(x => x == '\n') + 1;
                int endColumn = end - text.Substring(0,end-1).LastIndexOf('\n');

                return new SourceSpan()
                {
                    Start = new TextPosition(start,startLine,startColumn),
                    End = new TextPosition(end,endLine, endColumn),
                    FileName = fileName
                };
            } 
        }
        public static void defaultGenerateAndExport()
        {
            generateAndExport(@"C:\BloggerSupporter\template\page.scriban-html", Directory.GetFiles(@"C:\BloggerSupporter\data\")[0], @"C:\BloggerSupporter\output\default.html");
        }
        public static void generateAndExport(string templatePath, string dataPath, string targetPath)
        {
            PostFormGeneralCustom instance = new PostFormGeneralCustom();
            List<Exception> error = new List<Exception>();
            if (String.IsNullOrEmpty(templatePath)) return;
            if (String.IsNullOrEmpty(dataPath)) return;
            if (String.IsNullOrEmpty(targetPath)) return;
            string template = File.ReadAllText(templatePath);
            MmbsTemplateModelv1 data = Json.Decode(File.ReadAllText(dataPath), typeof(MmbsTemplateModelv1));
            var dataObject = new ScriptObject();
            dataObject.Import(data, renamer: member => member.Name);
            var context = new TemplateContext();
            context.PushGlobal(dataObject);
            context.StrictVariables = true;
            // Not working
            //context.MemberRenamer = new MemberRenamerDelegate(member => member.Name);
            var engine = Template.Parse(template, templatePath, null , null);
            if (engine.HasErrors){
                throw new ScribanException(engine.Messages);
            }
            string result = "";
            try
            {
                result = engine.Render(context);
            }
            catch (ScriptRuntimeException e)
            {
                throw new ScribanException(e.Message,e.Span);
            }
            catch (Exception e)
            {
                throw new Exception("Uncaught Exception\n"+ e.Message);
            }
            string targetFolder = Path.GetDirectoryName(targetPath);
            if (!Directory.Exists(targetFolder))
            {
                Directory.CreateDirectory(targetFolder);
            }
            File.WriteAllText(targetPath, result);
        }
        public string generateForm()
        {
            var pagePath = Class1.GetToken("mmbsprojectFolder") + "template\\page.scriban-html";
            string page = "";
            if (System.IO.File.Exists(pagePath))
            {
                page = System.IO.File.ReadAllText(pagePath);
            }
            else
            {
                string strExeFilePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
                string defaultPagePath = Path.GetFullPath(Path.Combine(strExeFilePath, @"..\Model\post_form\page.scriban-html"));
                page = System.IO.File.ReadAllText(defaultPagePath);
                installDefaultTemplate(new defaultTemplate[] { defaultTemplate.page });
            }

            var template = Template.Parse(page);
            // Render and suppress default member rename 
            var result = template.Render(data, member => member.Name);
            return result;
        }
        public string generateTitle()
        {
            var pagePath = Class1.GetToken("mmbsprojectFolder") + "template\\title.scriban-html";
            string page = "";
            if (System.IO.File.Exists(pagePath))
            {
                page = System.IO.File.ReadAllText(pagePath);
            }
            else
            {
                string strExeFilePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
                string defaultPagePath = Path.GetFullPath(Path.Combine(strExeFilePath, @"..\Model\post_form\title.scriban-html"));
                page = System.IO.File.ReadAllText(defaultPagePath);
                installDefaultTemplate(new defaultTemplate[] { defaultTemplate.title });
            }

            var template = Template.Parse(page);
            // Render and suppress default member rename 
            var result = template.Render(data, member => member.Name);
            return result;
        }
        public enum defaultTemplate
        {
            title,
            page
        }
        public static void installDefaultTemplate(defaultTemplate[] require, DateTime[] checkTime = null, string mmbsTemplatePath = "")
        {
            if (mmbsTemplatePath == "") mmbsTemplatePath = Class1.GetToken("mmbsprojectFolder") + @"template\";
            string strExeFilePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string[] installList = require.Select(x => Path.GetFullPath(Path.Combine(strExeFilePath, $@"..\Model\post_form\{x}.scriban-html"))).ToArray();
            installList = installList.Where(x => System.IO.File.Exists(x)).ToArray();
            if (checkTime != null && checkTime.Length == installList.Length)
            {
                DateTime[] timestamp = installList.Select(x => System.IO.File.GetLastWriteTime(x)).ToArray();
                installList = installList.Where((x, i) => timestamp[i] > checkTime[i]).ToArray();
            }
            if (installList.Length < 1) return;
            for (int i = 0; i < installList.Length; i++)
            {
                bool needOverwrite = true;
                string targetPath = mmbsTemplatePath + System.IO.Path.GetFileName(installList[i]);
                if (File.Exists(targetPath) && checkTime != null)
                {
                    bool response = System.Windows.Forms.MessageBox.Show($"There is new version of '{Path.GetFileName(installList[i])}'. Do you want to overwrite it","Overwrite Prompt", System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes;
                    if (!response) continue;
                }
                System.IO.File.Copy(installList[i], targetPath, needOverwrite);
            }
        }
        public void prepareData(PostDataBundle bundle)
        {

            data = new MmbsTemplateModelv1()
            {
                // Basic
                name = bundle.appInfo.name,
                package = bundle.appInfo.packageName,
                version = bundle.appInfo.version,
                size = bundle.appInfo.size,
                sourceLink = bundle.appInfo.datasource,
                sourceType = bundle.appInfo.datasourcemask,
                // icon
                haveIcon = bundle.appInfo.icon.enable,
                iconPath = bundle.appInfo.icon.link,
                // Desc
                descriptionRaw = bundle.appInfo.description.GetDat(),
                descriptionHtml = _descriptionHtml(bundle),
                descriptionText = _descriptionText(bundle),
                descriptionRtf = bundle.appInfo.description.rtf,
                descriptionLines = _descriptionLines(bundle),
                // Mod
                modType = bundle.modInfo.UI.modTypeGetname(bundle.modInfo.UI.currentindex).ToLower() ?? "",
                modRaw = bundle.modInfo.UI.modTypeGetDat(bundle.modInfo.UI.currentindex) ?? "",
                modItems = _modItems(bundle),
                // Require
                needVersion = bundle.appInfo.androidReq,
                needInternet = bundle.appInfo.internetReq,
                needRoot = bundle.appInfo.rootReq,
                needObbData = bundle.appInfo.obbReq,
                needExternalPermission = bundle.appInfo.extpermReq,
                // Images
                imageLinks = _imageLinks(bundle),
                imageWidths = _imageWidths(bundle),
                imageHeights = _imageHeights(bundle),
                imageNames = _imageNames(bundle),
                // Video
                haveVideo = _haveVideo(bundle),
                videoLink = _videoLink(bundle),
                videoThumbnailLink = _videoThumbnailLink(bundle),
                videoId = _videoId(bundle),
                // Download
                downloadPath = bundle.downloadlink.Downloadlink.link,
                obbPath = bundle.downloadlink.OBBlink.link,
                mirrorPath = bundle.downloadlink.OMirrorlink.link,
                haveMoreMirror = bundle.downloadlink.MListEnable,
                moreMirrorPaths = _additionMirrorDownloadLinks(bundle),
                // Credit
                authorName = bundle.credit.now.GetToUse(),
                isVipAuthor = bundle.credit.now.host == "offlinemods"
            };

            bool needExport = exportData;
#if DEBUG
            needExport = true;
#endif
            if (needExport)
                export();
        }
        public void export()
        {
            var path = Class1.GetToken("mmbsprojectFolder") + "data/" + data.package + ".json";
            var dir = System.IO.Path.GetDirectoryName(path);
            if (!System.IO.Directory.Exists(dir)) { System.IO.Directory.CreateDirectory(dir); }
            var result = Newtonsoft.Json.JsonConvert.SerializeObject(data,Newtonsoft.Json.Formatting.Indented);

            System.IO.File.WriteAllText(path, result);
        }
        internal string _descriptionHtml(PostDataBundle bundle)
        {
            // INIT
            String lineTemplate = "<div><div style=\"text-align: justify;\">"
            + /*param*/ "$$$.descLine$$$$"
            + "</div></div>";
            string result = "";
            // ESCAPE
            if (string.IsNullOrWhiteSpace(bundle.appInfo.description.GetDat()))
            {
                return result;
            }
            // PROCESS
            string[] cache_Desc = bundle.appInfo.description.GetDat().Split('\n');
            if (cache_Desc.Length < 2)
            {
                result = cache_Desc[0];
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

                    result += lineTemplate.Replace("$$$.descLine$$$$", str_edited);
                }
            }
            // RESULT
            return result;
        }
        internal string _descriptionText(PostDataBundle bundle)
        {
            string result = bundle.appInfo.description.GetDat();
            if (String.IsNullOrEmpty(result)) return result;
            result = Regex.Replace(result, @"<[^>\n]*>", "");
            Dictionary<string, string> specialSymbol = new Dictionary<string, string>()
            {
                { "amp", "&"}
            };
            result = Regex.Replace(result, @"@(?<keyword>[^;\n]*);",
                (x) =>
                {
                    if (!specialSymbol.ContainsKey(x.Groups[0].Value)) return "";
                    return specialSymbol[x.Groups[1].Value];
                }
                );
            return result;
        }
        internal string[] _descriptionLines(PostDataBundle bundle)
        {
            string result = bundle.appInfo.description.GetDat();
            return result.Split("\n");
        }

        internal string[] _modItems(PostDataBundle bundle)
        {
            var temp = !String.IsNullOrWhiteSpace(bundle.modInfo.UI.modTypeGetDat(bundle.modInfo.UI.currentindex)) ? bundle.modInfo.UI.modTypeGetDat(bundle.modInfo.UI.currentindex).Split('\n') : new string[] { };
            if (temp == null) return new string[] { };
            return temp;
        }
        private DefineInfoPack.imageinfo[] _selectImages;
        private DefineInfoPack.imageinfo[] selectImages(PostDataBundle bundle)
        {
            if (_selectImages != null) return _selectImages;
            if (bundle.postMedia.ImageList.Count <1) return new DefineInfoPack.imageinfo[] { };
            _selectImages = bundle.postMedia.ImageList.Where(x => x.enable).ToArray();
            return _selectImages;
        }
        internal string[] _imageLinks(PostDataBundle bundle)
        {
            List<string> result = new List<string>();
            var list = selectImages(bundle);
            const int sizefit = 640;
            for (int i = 0; i < list.Length; i++)
            {
                var link = list[i].link;
                if (!string.IsNullOrWhiteSpace(link))
                {
                    
                    if (bundle.appInfo.datasourcetype == "play")
                    {
                        int newHeight = bundle.postMedia.ImageList[i].height >= bundle.postMedia.ImageList[i].width ? sizefit : Convert.ToInt32(Math.Truncate(bundle.postMedia.ImageList[i].height / bundle.postMedia.ImageList[i].width * sizefit));
                        int newWidth = bundle.postMedia.ImageList[i].height <= bundle.postMedia.ImageList[i].width ? sizefit : Convert.ToInt32(Math.Truncate(bundle.postMedia.ImageList[i].width / bundle.postMedia.ImageList[i].height * sizefit));
                        if (link.Contains("-rw")) link = link.Replace("-rw", "");
                        if (link.Contains("=")) link = link.Remove(link.IndexOf("=")) + "=w" + newWidth + "-h" + newHeight;
                    }
                    result.Add(link);
                }
            }
            return result.ToArray();
        }
        internal int[] _imageWidths(PostDataBundle bundle)
        {
            List<int> result = new List<int>();
            var list = selectImages(bundle);
            const int sizefit = 640;
            for (int i = 0; i < list.Length; i++)
            {
                int width = bundle.postMedia.ImageList[i].height <= bundle.postMedia.ImageList[i].width ? sizefit : Convert.ToInt32(Math.Truncate(bundle.postMedia.ImageList[i].width / bundle.postMedia.ImageList[i].height * sizefit));
                result.Add(width);
            }
            return result.ToArray();
        }
        internal int[] _imageHeights(PostDataBundle bundle)
        {
            List<int> result = new List<int>();
            var list = selectImages(bundle);
            const int sizefit = 640;
            for (int i = 0; i < list.Length; i++)
            {
                int height = bundle.postMedia.ImageList[i].height >= bundle.postMedia.ImageList[i].width ? sizefit : Convert.ToInt32(Math.Truncate(bundle.postMedia.ImageList[i].height / bundle.postMedia.ImageList[i].width * sizefit));
                result.Add(height);
            }
            return result.ToArray();
        }
        internal string[] _imageNames(PostDataBundle bundle)
        {
            List<string> result = new List<string>();
            var list = selectImages(bundle);
            for (int i = 0; i < list.Length; i++)
            {
                if (!string.IsNullOrWhiteSpace(list[i].name))
                {
                    result.Add(list[i].name??"");
                }
            }
            return result.ToArray();
        }
        internal bool _haveVideo(PostDataBundle bundle)
        {
            return !String.IsNullOrEmpty(_videoId(bundle));
        }
        internal string _videoLink(PostDataBundle bundle)
        {
            if (!_haveVideo(bundle)) return "";
            return $@"https://www.youtube.com/embed/{_videoId(bundle)}";
        }
        internal string _videoThumbnailLink(PostDataBundle bundle)
        {
            if (!_haveVideo(bundle)) return "";
            return $@"https://i.ytimg.com/vi/{_videoId(bundle)}/0.jpg";
        }
        internal string _videoId(PostDataBundle bundle)
        {
            string result = bundle.postMedia.VideoReview.ID;
            if (string.IsNullOrWhiteSpace(result))
                result = bundle.postMedia.VideoReview.generateID();
            return result;
        }
        internal string[] _additionMirrorDownloadLinks(PostDataBundle bundle)
        {
            List<string> result = new List<string>();
            for (int i = 0; i < bundle.downloadlink.linklist.Count; i++)
            {
                result.Add(bundle.downloadlink.linklist[i].link);
            }
            return result.ToArray();
        }
    }
}
