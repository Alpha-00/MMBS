﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Blogger.v3;
using Google.Apis.Blogger.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Google.Apis.Auth.OAuth2;
using System.Threading;

using Newtonsoft.Json.Linq;
namespace MMBS
{
    public partial class SMForm : Form
    {
        PostDataBundle FormData;
        public SMForm()
        {
            InitializeComponent();
            FormData = new PostDataBundle();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            FormData.appinfo.androidReq = (boxAreq.Text == "Vary") ? "Varies with device" : "Android " + boxAreq.Text + "+";
        }

        private void boxAppName_Enter(object sender, EventArgs e)
        {
            FormData.appinfo.name = boxAppName.Text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            FormData.appinfo.size = boxSize.Text;
        }

        private void boxDataSource_TextChanged(object sender, EventArgs e)
        {
            FormData.appinfo.datasource = boxDataSource.Text;
            if (FormData.appinfo.name == "")
            {

            }
        }

        private void boxDesc_TextChanged(object sender, EventArgs e)
        {
            FormData.appinfo.Description.stockdata = boxDesc.Text;
        }

        private void boxDownloadlink_TextChanged(object sender, EventArgs e)
        {
            FormData.Downloadlink.Downloadlink.link = boxDownloadlink.Text;
        }

        private void boxAPKlink_TextChanged(object sender, EventArgs e)
        {
            FormData.Downloadlink.OBBlink.link = boxDownloadlink.Text;
        }

        private void boxVideo_TextChanged(object sender, EventArgs e)
        {
            FormData.postmedia.VideoReview.link = boxVideo.Text;
        }

        private void boxMod_TextChanged(object sender, EventArgs e)
        {
            FormData.modinfo.moddata = boxMod.Text;
            FormData.modinfo.modtype = (boxMod.Text.ToLower() == "paid") ? "Paid" : "Mod";
        }

        private void butPost_Click(object sender, EventArgs e)
        {
            this.Hide();
            string[] Scopes = { BloggerService.Scope.Blogger };
            string ApplicationName = "MMBS";
            UserCredential credential;

            using (var stream =
                new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                // The file token.json stores the user's access and refresh tokens, and is created
                // automatically when the authorization flow completes for the first time.
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }
            var service1 = new BloggerService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });
            //var cache = new JObject();
            //cache.Add("name", FormData.appinfo.name +" "+ FormData.modinfo.modtype);
            
            Google.Apis.Blogger.v3.Data.Post post = new Post();
            post.Title = "Bye";
            
            post.Content = "Hello";
            post.CustomMetaData = "{\"Search Keywords\" = \"abc\"}";
            //post.Labels.Add("A");
            PostsResource.InsertRequest request = service1.Posts.Insert(post, Properties.Settings.Default.BetaTest ? Class1.GetToken("nothinghereID") : Class1.GetToken("offlinemodsID"));
            request.IsDraft = true;
           
            Post result = request.Execute();
            System.Diagnostics.Process.Start("https://draft.blogger.com/blogger.g?blogID="+ (Properties.Settings.Default.BetaTest ? Class1.GetToken("nothinghereID") : Class1.GetToken("offlinemodsID")) + "#editor/postID=" + result.Id);
            this.Show();
        }
        
    }
}