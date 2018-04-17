using System;
using System.Net.Http;
using System.Web;
using UploadDownload.Classes;

namespace UploadDownload.Controllers
{
    public class UploadController : BaseWebApiController
    {
        public HttpResponseMessage Post()
        {
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count < 1)
            {
                throw new Exception("فایل معتبر نمی باشد");
            }
            if (httpRequest.Files.Count > 1)
            {
                throw new Exception("لطفا فقط بک فایل ارسال کنید");
            }
            //foreach (string file in httpRequest.Files)
            //{
            var postedFile = httpRequest.Files[0];
            var token = httpRequest.Form.Get("Token");
            //اعتبار سنجی توکن
            TokenBiz.Instance.ValidateToken(token);

            var fileId = FileBiz.Instance.Add(postedFile);
            
            return new HttpResponseMessage()
            {
                Content = new StringContent(fileId)
            };
        }
    }
}
