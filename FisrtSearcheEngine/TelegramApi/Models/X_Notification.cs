using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.Models
{
    public class X_Notification
    {
        public string id { get; set; }
        public string msg { get; set; }
        public string updatetime { get; set; }
        public string users { get; set; }
        public string date { get; set; }

        public string apk_name { get; set; }
        public string upload_date { get; set; }
        public string update_time { get; set; }
    }
    //{ "id": "17", "msg": "hello pooya kocholo empty", "updatetime": "896888154510822",  "users": "NaN", "date": "2017-03-30 18:48:38" }

}