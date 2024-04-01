using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RazorLight;
namespace MMBS_Razor.Razor_Template;

public class MmbsTemplateModelv1
{
    #region Basic Data
    public required string appName
    {
        get; init;
    }
    public required string dataSourceLink;
    public required string dataSourceName;
    #endregion

    #region Icon Data
    /// <summary>
    /// <para>Check if link to icon have available</para>
    /// <para>Or have icon link but user don't want to use it</para>
    /// 
    /// <para>For Example:</para>
    /// <code> haveIcon = true;</code>
    /// <code> haveIcon = false;</code>
    /// </summary>
    public required bool haveIcon;

    /// <summary>
    /// <para>Store formatted icon image link</para>
    /// 
    /// <para>For Example</para>
    /// <code>iconLink = ""</code>
    /// </summary>
    public required string iconLink;
    #endregion

    #region Description Data
    /// <summary>
    /// Have description data the same as in FMForm
    /// </summary>
    public required string descriptionRaw;
    /// <summary>
    /// Have description formatted as html
    /// </summary>
    public required string descriptionHtml;
    /// <summary>
    /// Have description clear all format and Html tag
    /// </summary>
    public required string descriptionText;
    /// <summary>
    /// Have description formatted as rtf
    /// </summary>
    public required string descriptionRtf;
    /// <summary>
    /// Have description as raw but split into line by line
    /// </summary>
    public required string[] descriptionLines;
    #endregion

    #region Mod List Data
    /// <summary>
    /// 
    /// </summary>
    public required string modType;
    /// <summary>
    /// 
    /// </summary>
    public required string modItems;
    #endregion

    #region Requirement Data
    public required bool needInternet;
    public required bool needRoot;
    public required bool needObbData;
    public required bool needExternalPerm;
    #endregion

    #region Image and Video Data
    public required string[] imageLinks;
    public required int[] imageWidths;
    public required int[] imageHeights;
    public required bool haveVideo;
    public required string videoLink;
    public required string videoThumbnailLink;
    public required string videoId;
    #endregion

    #region Download Data
    public required string mainDownloadLink;
    public required string obbDownloadLink;
    public required string mirrorDownloadLink;
    public required bool haveAdditionMirrorLinks;
    public required string[] additionMirrorDownloadLinks;
    #endregion

    #region Author Credit Data
    public required string authorName;
    public required bool isVipAuthor;

    #endregion
    /*
    public MmbsTemplateModelv1(string appName, string dataSourceLink, string dataSourceName, bool haveIcon, string iconLink, string descriptionRaw, string descriptionHtml, string descriptionText, string descriptionRtf, string[] descriptionLines, string modType, string modItems, bool needInternet, bool needRoot, bool needObbData, bool needExternalPerm, string[] imageLinks, int[] imageWidths, int[] imageHeights, bool haveVideo, string videoLink, string videoThumbnailLink, string videoId, string mainDownloadLink, string obbDownloadLink, string mirrorDownloadLink, bool haveAdditionMirrorLinks, string[] additionMirrorDownloadLinks, string authorName, bool isVipAuthor)
    {
        this.appName = appName;
        this.dataSourceLink = dataSourceLink;
        this.dataSourceName = dataSourceName;
        this.haveIcon = haveIcon;
        this.iconLink = iconLink;
        this.descriptionRaw = descriptionRaw;
        this.descriptionHtml = descriptionHtml;
        this.descriptionText = descriptionText;
        this.descriptionRtf = descriptionRtf;
        this.descriptionLines = descriptionLines;
        this.modType = modType;
        this.modItems = modItems;
        this.needInternet = needInternet;
        this.needRoot = needRoot;
        this.needObbData = needObbData;
        this.needExternalPerm = needExternalPerm;
        this.imageLinks = imageLinks;
        this.imageWidths = imageWidths;
        this.imageHeights = imageHeights;
        this.haveVideo = haveVideo;
        this.videoLink = videoLink;
        this.videoThumbnailLink = videoThumbnailLink;
        this.videoId = videoId;
        this.mainDownloadLink = mainDownloadLink;
        this.obbDownloadLink = obbDownloadLink;
        this.mirrorDownloadLink = mirrorDownloadLink;
        this.haveAdditionMirrorLinks = haveAdditionMirrorLinks;
        this.additionMirrorDownloadLinks = additionMirrorDownloadLinks;
        this.authorName = authorName;
        this.isVipAuthor = isVipAuthor;
    }*/
}
