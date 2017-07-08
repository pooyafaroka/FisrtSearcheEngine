using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

class X_Json_Me
{
    public bool ok { get; set; }
    public Result result { get; set; }
    public String ERROR { get; set; }

    public class Result
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string username { get; set; }
    }


}
