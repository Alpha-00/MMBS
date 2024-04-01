using MMBS_Razor.Razor_Template;
using RazorLight;

public class Program
{
    private static async Task Main(string[] args)
    {
        var exePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
        var templatePath = Path.GetFullPath(Path.Combine(exePath, @"..\..\..\..\Razor Template"));

        /*var engine = new RazorLightEngineBuilder()
            .UseFileSystemProject(templatePath)
            .UseMemoryCachingProvider()
            .Build();*/
        var engine = new RazorLightEngineBuilder()
            .UseEmbeddedResourcesProject(typeof(MmbsTemplateModelv1))
            .UseMemoryCachingProvider()
            .Build();

        var model = new MMBS_Razor.Razor_Template.MmbsTemplateModelv1() { 
            appName = "",
            dataSourceLink = "",
            dataSourceName = "",
            haveIcon = true,
            iconLink = "",
            descriptionRaw = "",
            descriptionHtml = "",
            descriptionText = "",
            descriptionRtf = "",
            descriptionLines = [],
            modType = "",
            modItems = "",
            needInternet = true,
            needRoot = true,
            needObbData = true,
            needExternalPerm = true,
            imageLinks = [],
            imageWidths = [],
            imageHeights = [],
            haveVideo = true,
            videoLink = "",
            videoThumbnailLink = "",
            videoId = "",
            mainDownloadLink = "",
            obbDownloadLink = "",
            mirrorDownloadLink = "",
            haveAdditionMirrorLinks = true,
            additionMirrorDownloadLinks = [],
            authorName = "",
            isVipAuthor = true
        };
        string page = System.IO.File.ReadAllText($"{templatePath}\\page.cshtml");
        var result = await engine.CompileRenderStringAsync("page",page, model);

        Console.WriteLine(result);
    }
}