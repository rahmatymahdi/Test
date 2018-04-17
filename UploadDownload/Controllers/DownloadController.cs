using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using UploadDownload.Classes;

namespace UploadDownload.Controllers
{
    public class DownloadController : BaseWebApiController
    {
        public HttpResponseMessage Post([FromBody] FormDataCollection formDataCollection)
        {
            var token = formDataCollection.Get("Token");
            //اعتبار سنجی توکن
            TokenBiz.Instance.ValidateToken(token);

            var fileId = formDataCollection.Get("Id");

            var obj = FileBiz.Instance.Find(fileId);
            var stream = new MemoryStream();
            stream.Write(obj.FileBytes, 0, obj.FileBytes.Length);
            var result = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ByteArrayContent(stream.ToArray())
            };
            result.Content.Headers.ContentDisposition =
                new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
                {
                    FileName = obj.FileName
                };
            result.Content.Headers.ContentType =
                new MediaTypeHeaderValue("application/octet-stream");
            return result;
        }
        ////public HttpResponseMessage Get(string id)
        ////{
        ////    var obj = FileBiz.Instance.Find(id);
        ////    var stream = new MemoryStream();
        ////    stream.Write(obj.FileBytes, 0, obj.FileBytes.Length);
        ////    var result = new HttpResponseMessage(HttpStatusCode.OK)
        ////    {
        ////        Content = new ByteArrayContent(stream.ToArray())
        ////    };
        ////    result.Content.Headers.ContentDisposition =
        ////        new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
        ////        {
        ////            FileName = obj.FileName
        ////        };
        ////    result.Content.Headers.ContentType =
        ////        new MediaTypeHeaderValue("application/octet-stream");
        ////    return result;
        ////}
    }
}
