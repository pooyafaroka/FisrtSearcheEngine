using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;

class TelegramInterface
{
    private const String GET_UPDATES = "/getupdates";
    private const String GET_ME = "/getme";
    private const String SEND_MESSAGE = "/sendmessage";
    private const String SEND_DOCUMENT = "/senddocument";
    private const String EDIT_MESSAGE_TEXT = "/editmessagetext";
    private const String GET_USER_PROFILE_PHOTOS = "/getUserProfilePhotos";
    public Uri send_message_url = new Uri(Constance.API_URL + Constance.API_TOKEN + SEND_MESSAGE);
    public Uri send_document_url = new Uri(Constance.API_URL + Constance.API_TOKEN + SEND_DOCUMENT);
    public Uri edit_message_text_url = new Uri(Constance.API_URL + Constance.API_TOKEN + EDIT_MESSAGE_TEXT);
    public Uri get_user_profile_photo_url = new Uri(Constance.API_URL + Constance.API_TOKEN + GET_USER_PROFILE_PHOTOS);

    public X_Json_Update GetUpdates(string toekn, string api_url)
    {
        String telegram_url = api_url + toekn + GET_UPDATES;
        dynamic ret = new X_Json_Update();
        WebService(telegram_url, ref ret);
        return ret;
    }

    public X_Json_Me GetMe(string toekn, string api_url)
    {
        String telegram_url = api_url + toekn + GET_ME;
        dynamic ret = new X_Json_Me();
        WebService(telegram_url, ref ret);
        return ret;
    }

    public X_Json_Send SendMessage(String msg, long chat_id)
    {
        Action_SendMessage param = new Action_SendMessage();
        param.chat_id = chat_id;
        param.text = msg;
        dynamic feedback = new X_Json_Send();
        MakeRequest(param, send_message_url, ref feedback);
        return feedback;
    }

    internal X_Json_Send EditeMessageText(string text, long chat_id, long message_id)
    {
        Action_EditMessageText param = new Action_EditMessageText();
        param.chat_id = chat_id;
        param.message_id = message_id;
        param.text = text;
        dynamic feedback = new X_Json_Send();
        MakeRequest(param, edit_message_text_url, ref feedback);
        return feedback;
    }

    public long getChatId(dynamic messages)
    {
        long ret = -1;
        if (messages.ERROR.Equals("NaN"))
        {
            if (messages is X_Json_WebHook)
            {
                ret = messages.message.from.id;
            }
            else if (messages is X_Json_CallBack)
            {
                ret = messages.callback_query.from.id;
            }
            else
            {
                ret = -1;
            }
        }
        return ret;
    }

    public string getText(dynamic messages)
    {
        String ret = "NaN";
        if (messages.ERROR.Equals("NaN"))
        {
            if (messages is X_Json_WebHook)
            {
                ret = messages.message.text;
            }
            else if (messages is X_Json_CallBack)
            {
                ret = messages.callback_query.data;
            }
            else
            {
                ret = "NaN";
            }
        }
        return ret;
    }

    internal string getFirstName(X_Json_WebHook messages)
    {
        String ret = "";
        ret = messages.message.from.first_name;
        return ret;
    }

    internal dynamic getLastName(X_Json_WebHook messages)
    {
        String ret = "";
        ret = messages.message.from.last_name;
        return ret;
    }

    internal dynamic getUserName(X_Json_WebHook messages)
    {
        String ret = "";
        ret = messages.message.from.username;
        return ret;
    }

    public bool hasError(X_Json_WebHook messages)
    {
        if (messages.ERROR.Equals("NaN"))
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    internal static Uri getBaseAddress()
    {
        Uri baseAddress = new Uri(Constance.API_URL + Constance.API_TOKEN + "/");
        return baseAddress;
    }

    internal static string getToken()
    {
        return Constance.API_TOKEN;
    }

    internal X_Json_Send CreatInlineButton(string text, long chat_id, List<List<Action_SendMessage.inline_keyboard>> inline_keyboard)
    {
        Action_SendMessage sendMessage = new Action_SendMessage();
        sendMessage.text = text;
        sendMessage.chat_id = chat_id;
        Action_SendMessage.ReplyMarkup replay_markup = new Action_SendMessage.ReplyMarkup();

        replay_markup.inline_keyboard = inline_keyboard;
        sendMessage.reply_markup = replay_markup;
        dynamic feedback = new X_Json_Send();
        MakeRequest(sendMessage, send_message_url, ref feedback);
        return feedback;
    }

    internal void SendDocument(long chat_id, string caption, string url_file)
    {
        Action_SendDocument document = new Action_SendDocument();
        document.chat_id = chat_id;
        document.caption = caption;
        document.document = url_file;
        dynamic output = null;
        MakeRequest(document, send_document_url, ref output);
    }

    internal void SendDocument(long chat_id, string url_file)
    {
        Action_SendDocument document = new Action_SendDocument();
        document.chat_id = chat_id;
        document.caption = "";
        document.document = url_file;
        dynamic output = null;
        MakeRequest(document, send_document_url, ref output);
    }

    internal void UploadFile(long chat_id, string name, string caption, string url)
    {
        HttpClient httpClient = new HttpClient();
        MultipartFormDataContent form = new MultipartFormDataContent();
        WebClient h = new WebClient();

        //byte[] imagebytearraystring = System.IO.File.ReadAllBytes(url);
        byte[] imagebytearraystring = h.DownloadData(url);

        form.Add(new StringContent(chat_id.ToString()), "chat_id");
        form.Add(new StringContent(caption), "caption");
        form.Add(new ByteArrayContent(imagebytearraystring, 0, imagebytearraystring.Count()), "document", name);
        httpClient.PostAsync(send_document_url, form);
    }

    internal X_Json_GetUserProfilePhotos getUserProfilePhoto(long chat_id)
    {
        Action_GetUserProfilePhotos profile_photos = new Action_GetUserProfilePhotos();
        profile_photos.user_id = chat_id;
        dynamic output = null;
        MakeRequest(profile_photos, get_user_profile_photo_url, ref output);
        return output;
    }
    ///////////////////////////////////////////////////////////////////////////////////

    private void WebService(String telegram_url, ref dynamic output)
    {
        if (output is X_Json_Update)
        {
            output = new X_Json_Update();
        }
        else if (output is X_Json_Me)
        {
            output = new X_Json_Me();
        }
        else if (output is X_Json_Send)
        {
            output = new X_Json_Send();
        }
        else if (output is X_Json_WebHook)
        {
            output = new X_Json_WebHook();
        }

        byte[] byteReceiveData = null;
        String error = "";

        using (var wc = new System.Net.WebClient())
        {
            try
            {
                byteReceiveData = wc.DownloadData(telegram_url);
            }
            catch (Exception ex)
            {
                error = "E001: " + ex.Message;
                output.ERROR = error;
            }
        }
        if (byteReceiveData != null)
        {
            Stream streamMemory = null;
            try
            {
                streamMemory = new MemoryStream(byteReceiveData);
            }
            catch (Exception ex)
            {
                error = "E002: " + ex.Message;
                output.ERROR = error;
            }

            if (streamMemory != null)
            {
                byte[] byteCopyData = new byte[byteReceiveData.Length];
                for (int i = 0; i < byteReceiveData.Length; i++)
                {
                    byteCopyData[i] = byteReceiveData[i];
                }

                string result = System.Text.Encoding.UTF8.GetString(byteCopyData);

                try
                {
                    if (!string.IsNullOrEmpty(result))
                    {
                        try
                        {
                            dynamic deserializedMessages = null;
                            if (output is X_Json_Update)
                            {
                                deserializedMessages = new X_Json_Update();
                                deserializedMessages = JsonConvert.DeserializeObject<X_Json_Update>(result);
                            }
                            else if (output is X_Json_Me)
                            {
                                deserializedMessages = new X_Json_Me();
                                deserializedMessages = JsonConvert.DeserializeObject<X_Json_Me>(result);
                            }
                            else if (output is X_Json_Send)
                            {
                                deserializedMessages = new X_Json_Send();
                                deserializedMessages = JsonConvert.DeserializeObject<X_Json_Send>(result);
                            }
                            else if (output is X_Json_WebHook)
                            {
                                deserializedMessages = new X_Json_WebHook();
                                deserializedMessages = JsonConvert.DeserializeObject<X_Json_WebHook>(result);
                            }
                            if (deserializedMessages == null)
                            {
                                error = "E003: " + "Deserialized Messages are NULL";
                                output.ERROR = error;
                            }
                            else
                            {
                                if (deserializedMessages.ok)
                                {
                                    output = deserializedMessages;
                                    output.ERROR = "NaN";
                                }
                                else
                                {
                                    error = "E004: " + "Deserialized Messages are NOT OK!";
                                    output.ERROR = error;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            error = "E005: " + ex.Message;
                            output.ERROR = error;
                        }
                    }
                }
                catch (Exception ex)
                {
                    error = "E006: " + ex.Message;
                    output.ERROR = error;
                }
            }
        }
        else
        {
            error = "E007: " + "Received Data(byte) is NULL";
            output.ERROR = error;
        }

    }

    public void ParseTelegramJson(String json, ref dynamic output)
    {
        if (output is X_Json_Update)
        {
            output = new X_Json_Update();
        }
        else if (output is X_Json_Me)
        {
            output = new X_Json_Me();
        }
        else if (output is X_Json_Send)
        {
            output = new X_Json_Send();
        }
        else if (output is X_Json_WebHook)
        {
            output = new X_Json_WebHook();
        }
        else if (output is X_Json_CallBack)
        {
            output = new X_Json_CallBack();
        }

        String error = "";

        string result = json;
        try
        {
            if (!string.IsNullOrEmpty(result))
            {
                try
                {
                    dynamic deserializedMessages = null;
                    if (output is X_Json_Update)
                    {
                        deserializedMessages = new X_Json_Update();
                        deserializedMessages = JsonConvert.DeserializeObject<X_Json_Update>(result);
                    }
                    else if (output is X_Json_Me)
                    {
                        deserializedMessages = new X_Json_Me();
                        deserializedMessages = JsonConvert.DeserializeObject<X_Json_Me>(result);
                    }
                    else if (output is X_Json_Send)
                    {
                        deserializedMessages = new X_Json_Send();
                        deserializedMessages = JsonConvert.DeserializeObject<X_Json_Send>(result);
                    }
                    else if (output is X_Json_WebHook)
                    {
                        deserializedMessages = new X_Json_WebHook();
                        deserializedMessages = JsonConvert.DeserializeObject<X_Json_WebHook>(result);
                    }
                    else if (output is X_Json_CallBack)
                    {
                        deserializedMessages = new X_Json_CallBack();
                        deserializedMessages = JsonConvert.DeserializeObject<X_Json_CallBack>(result);
                    }

                    if (deserializedMessages == null)
                    {
                        error = "E003: " + "Deserialized Messages are NULL";
                        output.ERROR = error;
                    }
                    else
                    {
                        if (output is X_Json_WebHook)
                        {
                            output = deserializedMessages;
                            output.ERROR = "NaN";
                        }
                        else if (output is X_Json_CallBack)
                        {
                            output = deserializedMessages;
                            output.ERROR = "NaN";
                        }
                        else
                        {
                            if (deserializedMessages.ok)
                            {
                                output = deserializedMessages;
                                output.ERROR = "NaN";
                            }
                            else
                            {
                                error = "E004: " + "Deserialized Messages are NOT OK!";
                                output.ERROR = error;
                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                    error = "E005: " + ex.Message;
                    output.ERROR = error;
                }
            }
        }
        catch (Exception ex)
        {
            error = "E006: " + ex.Message;
            output.ERROR = error;
        }
    }

    //public static readonly JsonSerializerSettings JsonSettings = new JsonSerializerSettings
    //{
    //    ContractResolver = new NetTelegramBotApi.Util.JsonLowerCaseUnderscoreContractResolver(),
    //    NullValueHandling = NullValueHandling.Ignore,
    //};


    //protected T DeserializeMessage<T>(string json)
    //{
    //    return JsonConvert.DeserializeObject<T>(json, JsonSettings);
    //}

    //public IWebProxy WebProxy { get; set; }

    //protected virtual HttpClientHandler MakeHttpMessageHandler()
    //{
    //    return new HttpClientHandler
    //    {
    //        Proxy = WebProxy,
    //        UseProxy = (WebProxy != null)
    //    };
    //}

    //public async Task<T> MakeRequestAsync<T>(RequestBase<T> request)
    //{
    //    using (var client = new HttpClient(MakeHttpMessageHandler()))
    //    {
    //        client.BaseAddress = getBaseAddress();
    //        using (var httpMessage = new HttpRequestMessage(HttpMethod.Get, request.MethodName))
    //        {
    //            var postContent = request.CreateHttpContent();
    //            if (postContent != null)
    //            {
    //                httpMessage.Method = HttpMethod.Post;
    //                httpMessage.Content = postContent;
    //            }

    //            using (var response = await client.SendAsync(httpMessage).ConfigureAwait(false))
    //            {
    //                if ((int)response.StatusCode >= 500)
    //                {
    //                    response.EnsureSuccessStatusCode();
    //                }

    //                var responseText = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
    //                var result = DeserializeMessage<BotResponse<T>>(responseText);
    //                if (!result.Ok || !response.IsSuccessStatusCode)
    //                {
    //                    var exceptionMessage = "Request failed (status code {(int)response.StatusCode}): {result.Description}";
    //                    throw new BotRequestException(exceptionMessage)
    //                    {
    //                        StatusCode = response.StatusCode,
    //                        ResponseBody = responseText,
    //                        Description = result.Description,
    //                        ErrorCode = result.ErrorCode,
    //                        Parameters = result.Parameters,
    //                    };
    //                }

    //                var retVal = result.Result;
    //                var forPostProcessing = retVal as IPostProcessingRequired;
    //                if (forPostProcessing != null)
    //                {
    //                    forPostProcessing.PostProcess(getToken());
    //                }

    //                return retVal;
    //            }
    //        }
    //    }
    //}

    public void MakeRequest(object obj, Uri url, ref dynamic output)
    {
        dynamic ret = null;
        if (output is X_Json_Send)
        {
            ret = new X_Json_Send();
        }
        var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
        httpWebRequest.ContentType = "application/json";
        httpWebRequest.Method = "POST";

        using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
        {
            string json = JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.None,
                        new JsonSerializerSettings
                        {
                            NullValueHandling = NullValueHandling.Ignore
                        });
            streamWriter.Write(json);
            streamWriter.Flush();
            streamWriter.Close();
        }

        try
        {
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                if (output != null)
                {
                    ParseTelegramJson(result, ref ret);
                    output = ret;
                }
                else
                {
                    output = result;
                }

            }
        }
        catch (Exception ex)
        {

        }
    }


}
