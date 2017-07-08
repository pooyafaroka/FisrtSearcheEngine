using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FisrtSearcheEngine.Controllers
{
    public class DoroBarController : ApiController
    {

        [Route("DoroBar")]
        [HttpPost]
        public void Post()
        {
            String result = Request.Content.ReadAsStringAsync().Result;
            TelegramInterface _interface = new TelegramInterface();
            //HackTelegram core = new HackTelegram();
            dynamic messages = new X_Json_WebHook();
            _interface.ParseTelegramJson(result, ref messages);
            if (messages.message != null)
            {
                //core.Start(messages, !HAS_CALLBACK);
            }
            else
            {
                messages = new X_Json_CallBack();
                _interface.ParseTelegramJson(result, ref messages);
                //core.Start(messages, HAS_CALLBACK);
            }
        }
    }
}
