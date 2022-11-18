
using Newtonsoft.Json;
using RestSharp;


namespace FlareApiTest.Support
{
    public class HttpRestClient
    {
        
        private const string baseUrl = "https://api.thecatapi.com/v1/favourites";
        public static RestResponse GetOrDeleteRequest(string method, string endpoint, string? token = null)
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest();
            switch (method)
            {
                case "GET":
                    request = new RestRequest(endpoint, Method.Get);
                    break;

                case "DELETE":
                    request = new RestRequest(endpoint, Method.Delete);
                    break;
            }
            request.AddHeader("x-api-key", "DEMO-API-KEY");
            var response = client.Execute(request);
            return response;
        }

       
        public static RestResponse CreateOrUpdateRequest(string method, object bodyData,string? endpoint =null)
        {

            using (var clients = new HttpClient())
            {
                clients.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            }


            var client = new RestSharp.RestClient(baseUrl);


            var request = new RestRequest();
            switch (method)
            {
                case "POST":
                    request = new RestRequest(endpoint,Method.Post) { RequestFormat = DataFormat.Json };
                    var json = JsonConvert.SerializeObject(bodyData);
                    request.AddHeader("Content-Type", "application/json");
                    request.AddHeader("x-api-key", "DEMO-API-KEY");
                    request.AddJsonBody(json);
                    break;

                
            }

            return client.Execute(request);

        }

        
    }

}

