using Newtonsoft.Json;
using System.Net;


namespace APICurso.Helpers
{
    public  static class ClientFactory
    {           

        public  static HttpResponseMessage buildresponsemessage(HttpStatusCode statuscode, object responseContent)
        {
            HttpResponseMessage response = new HttpResponseMessage(statuscode);
            JsonSerializerSettings setting = new JsonSerializerSettings();
            setting.NullValueHandling = NullValueHandling.Ignore;

            response.Content = new StringContent(JsonConvert.SerializeObject(responseContent, Newtonsoft.Json.Formatting.None, setting), System.Text.Encoding.UTF8, "application/json");
            return response;
        }

        public static string converttojson(Object data)
        {
            string json = JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented);
            return json;
        }
        
    }
}
