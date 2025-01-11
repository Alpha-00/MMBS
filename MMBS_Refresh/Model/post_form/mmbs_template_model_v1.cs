using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MmbsTemplateModelv1
{
    #region Basic Data
    public string name;
    public string version;
    public string package;
    public string size;
    public string sourceLink;
    public string sourceType;
    #endregion

    #region Icon Data
    public bool haveIcon;
    public string iconPath;
    #endregion

    #region Description Data
    public string descriptionRaw;
    public string descriptionHtml;
    public string descriptionText;
    public string descriptionRtf;
    public string[] descriptionLines;
    #endregion

    #region Mod List Data
    public string modType;
    public string modRaw;
    public string[] modItems;
    #endregion

    #region Requirement Data
    public string needVersion;
    public bool needInternet;
    public bool needRoot;
    public bool needObbData;
    public bool needExternalPermission;
    #endregion

    #region Image and Video Data
    public string[] imageLinks;
    public int[] imageWidths;
    public int[] imageHeights;
    public string[] imageNames;
    public bool haveVideo;
    public string videoLink;
    public string videoThumbnailLink;
    public string videoId;
    #endregion

    #region Download Data
    public string downloadPath;
    public string obbPath;
    public string mirrorPath;
    public bool haveMoreMirror;
    public string[] moreMirrorPaths;
    #endregion

    #region Author Credit Data
    public string authorName;
    public bool isVipAuthor;
    #endregion
}
