using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMBS.Model.PostForm
{
    /// <summary>
    ///     <para>
    ///         Base class for building form
    ///     </para>
    ///     <para>
    ///         Containing all basic function implementation for all form version
    ///     </para>
    ///     <para>
    ///         This is used instead of GeneralPostForm in the meanwhile
    ///     </para>
    /// </summary>
    public class PostFormBase<TemplateCustomVersionType> where TemplateCustomVersionType:  PostFormTemplate
    {
        internal TemplateCustomVersionType template;
        internal Type t = typeof(TemplateCustomVersionType);
        internal PostDataBundle data;
        internal Dictionary<String, String> elements = new Dictionary<string, string>();
        public PostFormBase(PostDataBundle data, TemplateCustomVersionType template)
        {
            this.data = data;
            this.template = template;
            /*template = (TemplateCustomVersionType)Activator.CreateInstance(typeof(TemplateCustomVersionType).MakeGenericType());*/
        }
        /// <summary>
        /// 
        /// </summary>
        public virtual void prepareElements()
        {
            
        }
        public virtual String generateForm()
        {
            return "";
        }
        public virtual String quickGenerate()
        {
            prepareElements();
            return generateForm();
        }
    }
    /// <summary>
    /// Using for basic template element
    /// </summary>
    public class PostFormTemplate
    {
        public PostFormTemplate()
        {
        }
        /// <summary>
        ///     <para>
        ///         Static information about version of the script for tracking and future refactor
        ///     </para>
        /// </summary>
        static String toolscript;

        /// <summary>
        ///     <para>
        ///         General structure of the article
        ///     </para>
        /// </summary>
        static String layout;

        /// <summary>
        ///     <para>
        ///         Raise Flag in Description Snippet. This using to help JavaScript in theme to modify
        ///     </para>
        /// </summary>
        static String flagDesc;

        /// <summary>
        ///     <para>
        ///         Javascript element to help reveal description
        ///     </para>
        /// </summary>
        static String descButReveal;

        /// <summary>
        /// 
        /// </summary>
        static String styleVIPadmin;

        /// <summary>
        /// 
        /// </summary>
        static String seperateLineScript;

        /// <summary>
        /// 
        /// </summary>
        static String iconScript;

        /// <summary>
        /// 
        /// </summary>
        static String descScript;

        /// <summary>
        /// 
        /// </summary>
        static String descLineScript;

        /// <summary>
        /// 
        /// </summary>
        static String igroupScript;

        /// <summary>
        /// 
        /// </summary>
        static String igroupHtml;

        /// <summary>
        /// 
        /// </summary>
        static String modListHtml;

        /// <summary>
        /// 
        /// </summary>
        static String modListItem;

        /// <summary>
        /// 
        /// </summary>
        static String imageScript;

        /// <summary>
        /// 
        /// </summary>
        static String imagecardScript;

        /// <summary>
        /// 
        /// </summary>
        static String videoScript;

        /// <summary>
        /// 
        /// </summary>
        static String linkScript;

        /// <summary>
        /// 
        /// </summary>
        static String linkoneScript;

        /// <summary>
        /// 
        /// </summary>
        static String linkoneScript2;

        /// <summary>
        /// 
        /// </summary>
        static String credit;

        /// <summary>
        /// 
        /// </summary>
        static String lastword;

        /// <summary>
        /// 
        /// </summary>
        static String codeWrapLine;

    }
}
