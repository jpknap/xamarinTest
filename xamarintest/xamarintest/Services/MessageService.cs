using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace xamarintest.Services
{
    public class MessageService
    {
        public async Task<string> enviarRegistroMensaje(string sender, string receiver, int question, string answer)
        {

            dynamic jsonObjectPayload = new JObject();
            jsonObjectPayload.message = new JObject();
            jsonObjectPayload.message.sender = sender;
            jsonObjectPayload.message.receiver = receiver;
            jsonObjectPayload.message.question = question;
            jsonObjectPayload.message.answer = answer;
            jsonObjectPayload.message.sent_at = DateTime.Now;
            string url = "http://api-test-fabianprado.c9users.io";
          

            using (HttpClient client = new HttpClient())
            {
                string content = JsonConvert.SerializeObject(jsonObjectPayload);
                StringContent body = new StringContent(content, Encoding.UTF8, "application/json");
                HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, url);
                requestMessage.Headers.Add("Authentication", "qwer1234");
                HttpResponseMessage result  = await client.SendAsync(requestMessage);
                if (result.IsSuccessStatusCode)
                {
                    return "true";

                }
                else
                {
                    return "false";
                }
            }
        }
    }    
}
