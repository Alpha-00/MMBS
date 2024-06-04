using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMBS.Model.PostForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MMBS.Model.PostFormTests
{
    [TestClass()]
    public class PostForm240603_Mod977Tests
    {
        private TestContext _testContext;
        /// <summary>
        /// Gets or sets the test context which provides
        /// information about and functionality for the current test run.
        /// </summary>
        public TestContext TestContext
        {
            get
            {
                return _testContext;
            }
            set
            {
                _testContext = value;
            }
        }
        [TestMethod()]
        public void PostForm240603_Mod977Test()
        {
            PostDataBundle bundle = new PostDataBundle()
            {
                appInfo = new PostDataBundle.appinfopack()
                {
                    name = "Cooking Tteokbokki King",
                    datasource = "https://play.google.com/store/apps/details?id=kr.cookingttbk.nurijoy.com",
                    packageName = "kr.cookingttbk.nurijoy.com",
                    size = "64.33 MB",
                    version = "1.0.13",
                    androidReq = "Android 4.4+",
                    icon = new DefineInfoPack.imageinfo()
                    {
                        name = "icon",
                        height = 480,
                        width = 240,
                        link = "https://play-lh.googleusercontent.com/YVTK8Bmm1N6dC8VjcNGaG7vXVqDJ7b70eCv4JrnIeVOwkIYFkI4QcMtdWJinVrcuk1U=w240-h480",
                        enable = true,
                    },
                    description = new PostDataBundle.appinfopack.Descriptionpack()
                    {
                        rawText = "Bước vào thế giới ẩm thực Hàn Quốc với Cooking Tteokbokki King, nay được nâng cấp với phiên bản MOD cung cấp vàng, kim cương và thẻ không giới hạn! Được phát triển bởi Nurijoy, trò chơi Android này mang đến cho bạn trải nghiệm nấu ăn phong phú và hấp dẫn, khiến bạn không thể rời mắt khỏi màn hình.\r\n\r\nCác tính năng nổi bật:\r\nKhông Giới Hạn Vàng, Kim Cương và Thẻ: Với phiên bản MOD, bạn có không giới hạn vàng, kim cương và thẻ, cho phép bạn mở khóa và nâng cấp các nguyên liệu, công thức và trang bị mà không cần lo lắng về tài nguyên. Tính năng này giúp bạn dễ dàng chinh phục mọi thử thách nấu ăn trong trò chơi.\r\nTrải Nghiệm Nấu Ăn Đỉnh Cao: Thỏa sức sáng tạo và nấu nướng với hàng loạt công thức tteokbokki (bánh gạo cay) đa dạng. Từ việc chọn nguyên liệu đến chế biến, bạn sẽ trải nghiệm từng bước để tạo ra những món ăn ngon mắt và hấp dẫn.\r\nĐồ Họa và Âm Thanh Sống Động: Đắm chìm trong thế giới ẩm thực với đồ họa rực rỡ và âm thanh sống động. Mỗi món ăn, từ nguyên liệu đến thành phẩm, đều được thiết kế chi tiết và sống động, mang lại cảm giác chân thực và thú vị.\r\nThử Thách Đa Dạng: Tham gia vào các thử thách nấu ăn khác nhau để kiểm tra kỹ năng và sự sáng tạo của bạn. Hoàn thành các nhiệm vụ và thử thách để mở khóa những công thức và nguyên liệu mới, làm phong phú thêm trải nghiệm nấu ăn của bạn.\r\nChế Độ Chơi Không Giới Hạn: Với vàng, kim cương và thẻ không giới hạn, bạn có thể thoải mái khám phá và trải nghiệm mọi chế độ chơi mà không bị giới hạn bởi tài nguyên. Điều này giúp bạn tập trung vào việc nấu nướng và tận hưởng trò chơi một cách trọn vẹn.\r\nNâng Cấp và Tùy Chỉnh: Sử dụng tài nguyên không giới hạn để nâng cấp và tùy chỉnh bếp của bạn, từ trang thiết bị đến nguyên liệu nấu ăn. Điều này giúp bạn tạo ra những món tteokbokki tuyệt vời hơn và đạt điểm số cao hơn trong các thử thách.\r\nTổng kết lại, Cooking Tteokbokki King MOD với vàng, kim cương và thẻ không giới hạn là một trò chơi không thể bỏ qua đối với những ai yêu thích nấu ăn và ẩm thực Hàn Quốc. Với đồ họa tuyệt đẹp, lối chơi gây nghiện và các tính năng nâng cao của phiên bản MOD, Cooking Tteokbokki King hứa hẹn sẽ mang đến cho bạn hàng giờ giải trí và sáng tạo. Tải ngay Cooking Tteokbokki King MOD và bắt đầu hành trình trở thành vua nấu ăn tteokbokki của bạn ngay hôm nay!"
                    }

                },
                downloadlink = new PostDataBundle.DownloadLinkpack()
                {
                    Downloadlink = new DefineInfoPack.Linker()
                    {
                        link = "https://modsfire.com/WAF8FQ5O93lGMtF"
                    }
                },
                credit = new PostDataBundle.creditpack()
                {
                    now = new PostDataBundle.creditpack.CreditsList.CreditItem()
                    {
                        host = "Mod977",
                        name = "OfflineMods.Net"
                    }
                },
                modInfo = new PostDataBundle.modinfopack()
                {
                    modtype = "MOD",
                    moddata = "Không giới hạn vàng, kim cương, thẻ (cards)",
                    usedata = true

                },
                postMedia = new PostDataBundle.PostMediapack()
                {
                    ImageInScript = true,
                    ImageList = new List<DefineInfoPack.imageinfo>()
                    {
                        new DefineInfoPack.imageinfo()
                        {
                            link = "https://play-lh.googleusercontent.com/_JGrRxAv6owVk6061kw4reOV6Vp0fdeobabGmrwW3TTgL5Q73RyTavJa-KUbTLOzHg=w640-h360",
                            
                        }
                    }
                }
            };
            PostForm240603_Mod977 post = new PostForm240603_Mod977(bundle);
            String result = post.generateForm();
            _testContext.WriteLine(result);
            Clipboard.SetText(result);
            
        }

        [TestMethod()]
        public void generateFormTest()
        {

		}
	}
}