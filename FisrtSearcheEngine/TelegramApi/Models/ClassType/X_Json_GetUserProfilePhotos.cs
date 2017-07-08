using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class X_Json_GetUserProfilePhotos
{
    public bool ok { get; set; }
    public Result result { get; set; }
    public String ERROR { get; set; }

    public class Result
    {
        public int total_count { get; set; }
        public List<List<String>> photos { get; set; }
    }

}
