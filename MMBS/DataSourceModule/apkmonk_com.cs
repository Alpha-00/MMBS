using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using static MMBS.OldProcessor;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Web.Helpers;
using System.Text.Json.Nodes;
using System.Text.Json;
using System.Xml.Linq;
using System.Net;

namespace MMBS.OldProcessorSupporter
{
    public class Apkmonk : DataSourceBuilder, DataSourceTemplateRequest,DataSourceTemplatePrepare
    {
        protected new string TemplateName => "ApkMonk";
        // Pre Process
        public DefineInfoPack.imageinfo getCover() {
            var node = webpageDoc.DocumentNode.SelectSingleNode("/html/body//div[@class=\"box-header\"]/../div[@class=\"row\"]//img");
            var coverLink = node.Attributes["data-src"].Value;
            coverLink = coverLink.Replace("_150_150", "");
            return new DefineInfoPack.imageinfo("avatar", tempDirectory, coverLink, 0, 0, null);
        }

        void DataSourceTemplatePrepare.initPreparation()
        {
            if (webpageDoc == null) throw new System.Exception("Missing Data");

        }
        RenderData DataSourceTemplatePrepare.postDataCleanup(RenderData data) => data;


        string DataSourceTemplatePrepare.prepareAppTitle()
        {
            var node = webpageDoc.DocumentNode.SelectSingleNode("/html/head/title");
            var title = node.InnerText;
            title = Regex.Match(title, "^(.+) Apk Download").Value;
            return title;
        }
        string DataSourceTemplatePrepare.prepareAppVersion()
        {
            // Get version from title
            var node = webpageDoc.DocumentNode.SelectSingleNode("/html/head/title");
            var title = node.InnerText;
            title = Regex.Match(title, "version (.+)(?=- )").Value;
            return title;
        }
        Dictionary<DataSourceDescriptionType, string> DataSourceTemplatePrepare.prepareDescription()
        {
            //var content = ProcSupporter.httpreqDownloadString(new Uri($"https://www.apkmonk.com/get_description/{package}/"));
            /// 
            var content = "";
            //var node = webpageDoc.DocumentNode.SelectSingleNode("html/body//p[@id=\"descr\"]/div[@id=\"morecontent\"]");
            //var desc = node.InnerText;
            var desc = content;
            desc = ProcSupporter.HtmlSpecialProcess(desc);
            var output = new Dictionary<DataSourceDescriptionType, string>();
            output[DataSourceDescriptionType.normal] = desc;

            return output;
        }
        
        OldProcessor.ProcSupporter.ImageDownloader[] DataSourceTemplatePrepare.prepareImageFiles()
        {
            var nodes = webpageDoc.DocumentNode.SelectSingleNode("//img[@title]");
            var remotePath = nodes.Attributes["data-src"].Value;
            var image = new ProcSupporter.ImageDownloader(remotePath, $"Screenshot", this.tempDirectory);
            // External Image Editor
            var service = new MMBS.ApiService.QuickWatermarkApi();
            //service.screenshotSplitImage(image.ImageDir);
            //image
            return null;
        }
        OldProcessor.ProcSupporter.ImageDownloader[] prepareImageFilesExample() 
        {
            var output = new List<ProcSupporter.ImageDownloader>();
            // TODO: Need to change xpath
            var nodes = webpageDoc.DocumentNode.SelectNodes("//img[@title]");
            var remotePaths = nodes.Select((item) => item.Attributes["src"].Value).ToList();
            if (remotePaths.Count() <= 0) return output.ToArray();

            remotePaths = remotePaths.Select(
                    (item) => reformatRemotePath(item)
            ).ToList();
            var loopOption = new ParallelOptions { MaxDegreeOfParallelism = 8 };
            var images = new ConcurrentBag<ProcSupporter.ImageDownloader>();
            var result = Parallel.ForEach(remotePaths, loopOption,
                (item, state, i) => 
                images.Add(new ProcSupporter.ImageDownloader(item, $"Screenshot {i}", this.tempDirectory))
                );

            return images.ToList().OrderBy((item) => remotePaths.IndexOf(item.Link)).ToArray();
            
            string reformatRemotePath(string path)
            {
                return path;
            }
        }
        Dictionary<string, string> DataSourceTemplatePrepare.prepareMiscellaneous() => null;
        string DataSourceTemplatePrepare.prepareOsRequirement()
        {
            var node = webpageDoc.DocumentNode.SelectSingleNode("//td[text()=\"Support Android Version\"]/../td[2]/span");
            var osReq = node.InnerText;
            return osReq;
        }
        string DataSourceTemplatePrepare.prepareVideoSource() => "";
    }
}