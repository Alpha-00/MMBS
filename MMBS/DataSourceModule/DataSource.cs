using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using HtmlAgilityPack;
using Newtonsoft.Json.Linq;
using static MMBS.OldProcessor;

namespace MMBS.OldProcessorSupporter
{
    /// <summary>
    /// 1. Setup
    /// 2. Init
    /// 3. Get Data
    /// 4. Reset
    /// </summary>
    public class DataSourceBuilder//: DataSourceTemplateRequest
    {
        public static Dictionary<string, DataSourceBuilder> CacheDataSourceModel;
        protected static IEnumerable<DataSourceResponseMessage> recentStream;
        public static DataSourceBuilder recentModel;
        public static void storeCache<T>(T model) where T: DataSourceBuilder
        {
            string key = model.link;
            if (String.IsNullOrEmpty(key)) throw new Exception("No key to store request");
            if (CacheDataSourceModel == null) CacheDataSourceModel = new Dictionary<string, DataSourceBuilder>()
            {
                { key,model }
            };
        }
        public void storeCache()
        {
            storeCache(this);
        }
        // !TODO: Need Reimplement
        public DataSourceBuilder getLatestInstance(bool sameTemplateName = true)
        {
            return recentModel;
            if (!CacheDataSourceModel.Any((x) => x.Value.TemplateName == this.TemplateName)) return this;
            
            return CacheDataSourceModel.Last((x) => x.Value.TemplateName == this.TemplateName).Value;
        }
        #region Internal Static Fields
        /// <summary>
        /// Name of the processing template
        /// 
        /// Use for Exception, and Log purpose
        /// </summary>
        protected virtual string TemplateName => "Data Source";
        protected static string[] DefaultPackageFromUriRegexes => new string[] {
            @"(([a-zA-Z0-9_]+)\.){1,4}(?<appName>[a-zA-Z0-9_]+)",
        };
        #endregion

        #region Constructor
        public DataSourceBuilder()
        {
            //recentModel = this;
        }

        /// <summary>
        /// Construct the process from Url
        /// 
        /// It will passing process to <see cref="fromPackage"/>
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public void initWithLink(string link){
            if (String.IsNullOrEmpty(link)) throw new ArgumentException(TemplateName);
            this.link = link;
            var package = parsePackageFromLink(link);
            initWithPackage(package);
        }

        protected virtual string parsePackageFromLink(string link)
        {
            var uri = new Uri(link);
            var regex = DefaultPackageFromUriRegexes.First((request) => Regex.IsMatch(uri.PathAndQuery, request));
            var package = Regex.Match(uri.PathAndQuery, regex).Value;
            //foreach (var matchRequest in DefaultPackageFromUriRegexes)
            //{
            //    var match = new Regex(matchRequest);
            //    if (match.IsMatch(uri.PathAndQuery)) continue;

            //    package = match.Match(uri.PathAndQuery).Value;
            //    break;
            //}
            //if (String.IsNullOrEmpty(package)) throw new ArgumentException(TemplateName + $"\n{link} request do not supported");
            return package;
        }
        public void initWithUri(Uri link)
        {
            initWithLink(link.ToString());
        }
        public void initWithPackage(string package)
        {
            this.package = package;
            init();
        }
        public void initWithWebpage(string page,string link)
        {
            var process = new DataSourceBuilder();
            process.link = link;
            process.webpage = page;
            initWithLink(link);
        }
        #endregion

        public string link = "";
        public string linkAlias = "";
        public string package = "";
        string _webpage = "";
        public string webpage
        {
            get => _webpage;
            set
            {
                _webpage = value;
                webpageDoc = new HtmlDocument();
                webpageDoc.LoadHtml(value);
            }
        }
        protected HtmlDocument webpageDoc;
        string _tempDirectory = "";
        public string tempDirectory
        {
            get => _tempDirectory;
            set
            {
                _tempDirectory = value;
                if (!System.IO.Directory.Exists(tempDirectory)) System.IO.Directory.CreateDirectory(tempDirectory);
            }
        }
        public IEnumerable<DataSourceResponseMessage> process(bool continueFromPrevious = false)
        {
            if (continueFromPrevious)
            {
                foreach (var response in DataSourceBuilder.recentStream)
                {
                    yield return response;
                }
            }

            yield return new DataSourceResponseMessage() { 
                name=DataSourceResponseProcessName.Init
            };

        }
        public void forceBackupProcess(IEnumerable<DataSourceResponseMessage> process) => recentStream = process;

        public void init(bool strict = false)
        {
            
            if (String.IsNullOrEmpty(link) && strict) throw new Exception("Unable to process without url");
            link = reformatLink(link);

            if (String.IsNullOrEmpty(package))
            {
                package = String.IsNullOrEmpty(link)? "com": parsePackageFromLink(link);
            }

            /// Init temp directory, on desktop
            if (String.IsNullOrEmpty(tempDirectory)) 
            { 
                tempDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), package);

            }

            if (String.IsNullOrEmpty(webpage)) webpage = getHtml();

            recentModel = this;
            //forceBackup();
        }
        public void forceBackup()
        {
            var key = String.IsNullOrEmpty(linkAlias) ? link : linkAlias;
            CacheDataSourceModel.Add(key, this);
        }
        public string reformatLink(string link)
        {
            if (link.Contains("/vn/")) link = link.Replace("/vn/", "/");
            if (link.Contains("/vi/")) link = link.Replace("/vi/", "/en/");
            if (link.Contains("?hl=vi")) link = link.Replace("?hl=vi", "?hl=en");
            return link;
        }
        public string getHtml()
        {
            CookieContainer cookieJar = new CookieContainer();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(link);
            request.CookieContainer = cookieJar;
            request.Accept = @"text/html, application/xhtml+xml, */*";
            request.Headers.Add("Accept-Language", "en-GB");
            request.UserAgent = @"Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; Trident/6.0)";
            request.UseDefaultCredentials = true;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string pageString;
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                pageString = reader.ReadToEnd();
            }
            return pageString;

        }
        public static RenderData prepareData<T>(T model) where T:DataSourceBuilder, DataSourceTemplatePrepare
        {
            model.initPreparation();
            var result = new RenderData()
            {
                title = model.prepareAppTitle(),
                videoRemotePath = model.prepareVideoSource(),
                version = model.prepareAppVersion(),
                osRequirement = model.prepareOsRequirement(),
                description = model.prepareDescription().Values.ToArray(),
                images = model.prepareImageFiles()
            };
            result = model.postDataCleanup(result);
            model.data = result;
            return result;

        }
        public RenderData data;
        public class RenderData
        {
            public string title;
            public string videoRemotePath;
            public string osRequirement;
            public string version;
            public string[] description;
            public ProcSupporter.ImageDownloader[] images;
            public Dictionary<string, string> miscellaneous;
            public static void ApplyData<T>(DataSourceBuilder.RenderData source, out string destinateTitle,out string destinateVideoLink, out string destinateReq, out string destinateVersion, out string destinateDesc, out string destinateDescBold, out string[] destinateImageLinks, out ProcSupporter.ImageDownloader[] destinateImages) where T : DataSourceBuilder
            {
                if (source == null) throw new KeyNotFoundException("Need preparation before get data");
                destinateTitle = source.title;
                destinateVideoLink = source.videoRemotePath;
                destinateReq = source.osRequirement;
                destinateVersion = source.version;
                destinateDesc = source.description[0];
                destinateDescBold = destinateDesc;
                if (source.description.Length>1)
                    destinateDescBold = source.description[1];
                destinateImages = source.images;
                destinateImageLinks = source.images.Select((item) => item.Link).ToArray();
            }
        }
        //public virtual DefineInfoPack.imageinfo getCover()
        //{
        //    throw new NotImplementedException();
        //    // Example of APKPure
        //    var coverImageLink = webpageDoc.DocumentNode.SelectSingleNode("//body/section[@id=\"main\"]//div[@class=\"avatar\"]/img").Attributes["data-src"].Value;
        //    coverImageLink = coverImageLink.Substring(coverImageLink.IndexOf("f=auto/") + "f=auto/".Length);
        //    if (!coverImageLink.ToLower().StartsWith("http")) coverImageLink = "https:" + coverImageLink;
        //    if (string.IsNullOrEmpty(coverImageLink)) throw new Exception("Can't find cover image");
        //    if (coverImageLink.Contains("-rw")) coverImageLink = coverImageLink.Remove(coverImageLink.Length - 2);
        //    if (!coverImageLink.Contains("http")) coverImageLink = "https://" + coverImageLink;
        //    if (coverImageLink.Contains("="))
        //        coverImageLink = coverImageLink.Remove(coverImageLink.IndexOf("=")) + "=w240-h480";
        //    string temp_coverthumbnailLink = coverImageLink;
        //    if (coverImageLink.Contains("="))
        //        temp_coverthumbnailLink = coverImageLink.Remove(coverImageLink.IndexOf("=") + 1) + "s140";
        //    return new DefineInfoPack.imageinfo("avatar",tempDirectory, temp_coverthumbnailLink, 0,0,null);
        //}
    }

    

    public interface DataSourceTemplateRequest
    {
        DefineInfoPack.imageinfo getCover();

        //string getAppTitle();
        //string getVideoLink();
        //string getOsRequirement();
        //string getAppVersion();
        //Dictionary<DataSourceDescriptionType, string> getDescription();
        //string getImageLinks();
        //ProcSupporter.ImageDownloader[] getImageFiles();

    }

    public interface DataSourceTemplatePrepare
    {
        void initPreparation();
        //
        string prepareAppTitle();
        string prepareAppVersion();
        string prepareVideoSource();
        string prepareOsRequirement();
        Dictionary<DataSourceDescriptionType, string> prepareDescription();
        ProcSupporter.ImageDownloader[] prepareImageFiles();
        Dictionary<string, string> prepareMiscellaneous();
        //
        DataSourceBuilder.RenderData postDataCleanup(DataSourceBuilder.RenderData data);
    }
    public enum DataSourceDescriptionType
    {
        normal,
        bold
    }
    public enum DataSourceResponseProcessName
    {
        Init,
        Cover,
    }
    public class DataSourceResponseMessage
    {
        public DataSourceResponseProcessName name;
        public dynamic data;
        public dynamic getData<T>()
        {
            if (typeof(T) == typeof(string)) return this.data;
            if (typeof(T) == typeof(int)) return this.data;
            return JsonSerializer.Deserialize<T>((string)this.data);
        }
        public int responseCode;
    }
}