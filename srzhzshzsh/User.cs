using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net;
using System;
namespace GarpPractice
{
      
    class User
    {
        public User() { }
        public User(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
        public User(string access_token)
        {
            this.access_token = access_token;
        }
        public User(User user) { this.username = user.username; this.password = user.password; this.access_token = new string (user.access_token); this.refresh_token = user.refresh_token; }

        public async Task login()
        {
            HttpClient httpClient = new HttpClient();

            JsonContent content = JsonContent.Create(this);
            using var response =  await httpClient.PostAsync("https://back.glsystem.net/api/v1/auth/login/", content);
            string resp = await response.Content.ReadAsStringAsync();

            JObject o = JObject.Parse(resp);
            access_token = new string((string)o["access_token"]);
            refresh_token = new string((string)o["refresh_token"]);
        }
        public void addaccess(string access_token)
        {
            HttpClient httpClient = new HttpClient();

            this.access_token = access_token;  
        }  
        public void addrefresh(string refresh_token)
        {
            HttpClient httpClient = new HttpClient();

            this.refresh_token = refresh_token;
        }
        public async void logout()
        {
            HttpClient httpClient = new HttpClient();

            JsonContent content = JsonContent.Create(this);
            httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", this.access_token);
            if (access_token!= null)
            {
                using var response = await httpClient.PostAsync("https://back.glsystem.net/api/v1/auth/logout/",content);
            }
        }
        public async void refresh()
        {
            HttpClient httpClient = new HttpClient();

            JsonContent content = JsonContent.Create(this);
            using var response = await httpClient.PostAsync("https://back.glsystem.net/api/v1/auth/refresh/", content);
            string respcont = await response.Content.ReadAsStringAsync();

            JObject o = JObject.Parse(respcont);
            string access_token = (string)o["access_token"];

            Console.WriteLine($"Status: {response.StatusCode}\n");
            Console.WriteLine(o);

        }

        HttpClient httpClient = new HttpClient();
        public string username { get; set; } = "";
        public string password { get; set; } = "";
        public string access_token { get; set; }
        public string refresh_token { get; set; }


    }
}