using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;


namespace WSCore.WorkingBack
{
    public class backgroundworking
    {
        /*
         * rEFERENCIA:GET: https://www.youtube.com/watch?v=-t-5OZBGmVU
         *              POST: https://www.youtube.com/watch?v=YSGCkHBFBZQ
         */

        public async Task<string> Post(string Url,string json,string autorizacion=null){
            /*  var client = new RestClient(Url);
              var request = new RestRequest(Method.Post.ToString() );
              request.AddHeader("content-type", "application/json");
              request.AddParameter("application/json",json,ParameterType.RequestBody);
              if (autorizacion != null)
              {
                  request.AddHeader("Authorization", autorizacion);
              }

              //            var response = await client.GetAsync(request);
              var response = await client.PostAsync(request);
              */
            HttpClient oHttpClient = new HttpClient();
            var content = new StringContent(json,Encoding.UTF8,"application/json");
            var respuesta = await oHttpClient.PostAsync(Url, content);


            return respuesta.ToString();
        }
        public async Task<string> Leer() {
            {
                var client = new HttpClient();
                var response = await client.GetAsync("https://httpbin.org/get");
                var responseString = await response.Content.ReadAsStringAsync();

                return responseString;
            }
        
        }
    }
}