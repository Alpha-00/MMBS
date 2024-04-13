using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MMBS.DataModule
{
    public static class LocalImageUpload
    {
        [Obsolete("No maintain code, Please do not use")]
        public static async Task<DefineInfoPack.imageinfo>  uploadImage(string path) 
        {
            var data = new DefineInfoPack.imageinfo();
            data.dir = path;
            data.image = System.Drawing.Image.FromFile(path);
            data.height = data.image.Height;
            data.width = data.image.Width;
            data.name = Path.GetFileNameWithoutExtension(path);

            var client = new ApiService.ImgurAPI();
            Imgur.API.Endpoints.ImageEndpoint account = new Imgur.API.Endpoints.ImageEndpoint(ApiService.ImgurAPI.apiClient, new System.Net.Http.HttpClient());
            try
            {
                Imgur.API.Models.IImage result;
                using (FileStream f = new FileStream(path, FileMode.Open))
                {
                    result = await account.UploadImageAsync(f);
                    if (null == result)
                    {
                        throw new Exception("Upload Failed");
                    }
                    data.link = result.Link;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            return data;
        }
    }
}
