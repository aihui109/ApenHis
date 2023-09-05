using ApenHis.AppIServices;
using ApenHis.Dtos;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Net;
using System;
using RestSharp;
using System.Linq;

namespace ApenHis.AppServices
{
    [Route("api/[controller]/[action]")]
    public class OnlyOfficeAppService : ApenHisAppService, IOnlyOfficeAppService
    {
        [HttpPost]
        public async Task<OnlyofficeCallback> CallBack([FromBody] OnlyofficeCallbackInput input)
        {
            try
            {
                if (input.status.IsIn(2,6,7))
                {
                    var strs = input.url.Split('/');
                    RestClient restClient = new(new Uri(string.Join('/',strs.Take(3))), useClientFactory: true);
                    RestRequest restRequest = new(string.Join('/', strs.Skip(3)), Method.Get);
                    using var stream = await restClient.DownloadStreamAsync(restRequest);
                    using var fs = File.Open(@"E:\repos\ApenHis\src\ApenHis.HttpApi.Host\wwwroot\new.docx", FileMode.Create);
                    var buffer = new byte[4096];
                    int readed;
                    while ((readed = stream.Read(buffer, 0, 4096)) != 0)
                        fs.Write(buffer, 0, readed);
                }
                return new OnlyofficeCallback { error = 0 };
            }
            catch (Exception)
            {
                throw;
            }

        }

        [HttpPost]
        public async Task<OnlyofficeCallback> CallBack2([FromBody] OnlyofficeCallbackInput input)
        {
            try
            {
                if (input.status.IsIn(2,6,7))
                {
                    var strs = input.url.Split('/');
                    RestClient restClient = new(new Uri(string.Join('/',strs.Take(3))), useClientFactory: true);
                    RestRequest restRequest = new(string.Join('/', strs.Skip(3)), Method.Get);
                    using var stream = await restClient.DownloadStreamAsync(restRequest);
                    using var fs = File.Open(@"E:\repos\ApenHis\src\ApenHis.HttpApi.Host\wwwroot\sample.oform", FileMode.Create);
                    var buffer = new byte[4096];
                    int readed;
                    while ((readed = stream.Read(buffer, 0, 4096)) != 0)
                        fs.Write(buffer, 0, readed);
                }
                return new OnlyofficeCallback { error = 0 };
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
