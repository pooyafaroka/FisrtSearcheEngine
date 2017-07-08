using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Action_SendMessage
{
    public long chat_id { get; set; }
    public string text { get; set; }

    public ReplyMarkup reply_markup { get; set; }

    public class ReplyMarkup
    {
        public List<List<inline_keyboard>> inline_keyboard { get; set; }
    }

    public class inline_keyboard
    {
        public string text { get; set; }
        public string callback_data { get; set; }
    }


}
