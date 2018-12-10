using AapjesTesten.Models;
using Models.DB;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static AapjesTesten.Models.FetchToken;

namespace AapjesTesten
{
    class Apie
    {
        public static string base_url = "http://311038-1.api.pasys.nl/";
        public static string Ensure { get; set; }
        public static FetchTokenResponse TokenInfo;

        public static class API
        {
            public static async Task<string> HTTPPost(string AParams)
            {
                string LResult = "";
                try
                {
                    string LUrl = base_url + Ensure;

                    HttpClient HC = new HttpClient();

                    if (TokenInfo != null)
                        HC.DefaultRequestHeaders.Add("Authorization", TokenInfo.access_token);

                    StringContent S = new StringContent(AParams, Encoding.UTF8, "application/json");

                    HttpResponseMessage HR = await HC.PostAsync(LUrl, S);

                    LResult = await HR.Content.ReadAsStringAsync();

                    return LResult;
                }
                catch (Exception)
                {
                }
                return LResult;
            }

            public static async Task<string> HTTPGet(string path)
            {
                string LResult = "";
                try
                {
                    string LUrl = base_url + Ensure;

                    HttpClient HC = new HttpClient();

                    if (TokenInfo != null)
                        HC.DefaultRequestHeaders.Add("Authorization", TokenInfo.access_token);

                    HC.BaseAddress = new Uri(LUrl);
    
                    HttpResponseMessage HR = await HC.GetAsync(path);
                    LResult = await HR.Content.ReadAsStringAsync();

                    return LResult;
                }
                catch(Exception)
                {
                }
                return LResult;
            }

            public static void GetToken(string username, string password, string cmp_id)
            {
                try
                {
                    Dictionary<string, string> Params = new Dictionary<string, string>
                {
                    {"userName", username},
                    {"password", password},
                    {"cmp_id", cmp_id}
                };
                    string LParams = JsonConvert.SerializeObject(Params);

                    string LResult = Task.Run<string>(() => HTTPPost(LParams)).Result;
                    Task.WaitAll();

                    FetchTokenResponse FR = JsonConvert.DeserializeObject<FetchTokenResponse>(LResult);
                    TokenInfo = FR;
                }
                catch (Exception)
                {
                }
            }
        }
    }
}
