using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class X_Json_CallBack
{
    public String ERROR { get; set; }
    public int update_id { get; set; }
    public CallbackQuery callback_query { get; set; }

    public class From
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string username { get; set; }
        public string language_code { get; set; }
    }

    public class From2
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string username { get; set; }
    }

    public class Chat
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string username { get; set; }
        public string type { get; set; }
    }

    public class Message
    {
        public int message_id { get; set; }
        public From2 from { get; set; }
        public Chat chat { get; set; }
        public int date { get; set; }
        public string text { get; set; }
    }

    public class CallbackQuery
    {
        public string id { get; set; }
        public From from { get; set; }
        public Message message { get; set; }
        public string chat_instance { get; set; }
        public string data { get; set; }
    }





}