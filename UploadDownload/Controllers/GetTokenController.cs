using System.Net.Http;
using UploadDownload.Classes;

namespace UploadDownload.Controllers
{

    public class GetTokenController : BaseWebApiController
    {
        public HttpResponseMessage Get()
        {
            var token = TokenBiz.Instance.Add();
            return new HttpResponseMessage()
            {
                Content = new StringContent(token)
            };
        }
    }
}
