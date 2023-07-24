using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static System.Net.WebRequestMethods;

namespace GarpPractice
{
    internal class Project
    {
        public Project() { }
        public Project(User user) { current = new User(user); }
        public Project(string access) { current.access_token = access; }
        public Project(Project Copy) {
            this.id = id;
            this.title = title;
            this.created_at = created_at;
            this.updated_at = updated_at;
            this.demo = demo;
            this.is_calculating = is_calculating;
            this.absolute_url = absolute_url;
        } 
        public void takeproject (string projson)
        { 
            Console.WriteLine("projson: \n" + projson);

            HttpClient httpClient = new HttpClient();

            JObject projinf = JObject.Parse(projson);
            Console.WriteLine("projinf: \n" + projinf);
            /*
            id = (int)projinf["id"]; 
            this.title = (string)projinf["title"];
            created_at = (string)projinf["created_at"];
            updated_at = (string)projinf["updated_at"];
            demo = (bool)projinf["bool"];
            is_calculating = (bool)projinf["bool"];
            absolute_url = (string)projinf["absolute_url"];
            */
        }
        public async Task<string> postproject(string title)
        {
            HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", current.access_token);

            string json = $"{{\"title\": \"{title}\"}}";
            Console.WriteLine("\nnew\n"+json+"\nnew\n");


            string titl = new string(title);
            JsonContent content = JsonContent.Create(json);
            using var response = await httpClient.PostAsync("https://back.glsystem.net/api/v1/project/", content);
            string conetent = await response.Content.ReadAsStringAsync();
            return await Task.FromResult(conetent);
            
        }
        public async Task<string> getproject(string ordering, int page,int page_size,string title_icontains)
        {
            HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", current.access_token);

            string geturl = "https://back.glsystem.net/api/v1/project/";
            if (ordering != null || page != 0 || page_size != 0 || title_icontains != null)
                geturl += "?";
            if (ordering != null)
                geturl += $"&ordering={ordering}";
            if (page != 0)
                geturl += $"&page={page}";
            if (page_size != 0)
                geturl += $"&page_size={page_size}";
            if (title_icontains != null)
                geturl += $"title_icontains={page_size}";
     
            using var response = await httpClient.GetAsync(geturl);
            string getres = await response.Content.ReadAsStringAsync();
            return getres;
            /*
            JObject o = JObject.Parse(conetent);
            return o;
            */
        }
        public async Task<string> getbyid(int id)
        {
            HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", current.access_token);

            string geturl = "https://back.glsystem.net/api/v1/project/";
            geturl += $"{id}/";

            using var response = await httpClient.GetAsync(geturl);
            string getres = await response.Content.ReadAsStringAsync();
            return getres;
            /*
            JObject o = JObject.Parse(conetent);
            return o;
            */
        }
        public async Task<string> patchbyid(int id,string title)
        {
            HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", current.access_token);

            JsonContent content = JsonContent.Create(title);
            string geturl = "https://back.glsystem.net/api/v1/project/";
            geturl += $"{id}/";

            using var response = await httpClient.PatchAsync(geturl,content);
            string getres = await response.Content.ReadAsStringAsync();
            return getres;
            /*
            JObject o = JObject.Parse(conetent);
            return o;
            */
        }
        public async void deleteid(int id)
        {
            HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", current.access_token);

            string geturl = "https://back.glsystem.net/api/v1/project/";
            geturl += $"{id}/";

            using var response = await httpClient.DeleteAsync(geturl);
        }
        public async Task<string> copyid(int id)
        {
            HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", current.access_token);

            string posturl = $"https://back.glsystem.net/api/v1/project/{id}/copy/";
            JsonContent content = JsonContent.Create(this);
            using var response = await httpClient.PostAsync("https://back.glsystem.net/api/v1/project/", content);
            string conetent = await response.Content.ReadAsStringAsync();
            return conetent;
        }
        public async Task<string> historyid(int id)
        {
            HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", current.access_token);

            string geturl = $"https://back.glsystem.net/api/v1/project/{id}/history/";

            using var response = await httpClient.GetAsync(geturl);
            string getres = await response.Content.ReadAsStringAsync();
            return getres;
        }
        //public async void upload(string file) { }
        public async Task<string> sample()
        {
            HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", current.access_token);

            string geturl = $"https://back.glsystem.net/api/v1/project/sample/";

            using var response = await httpClient.GetAsync(geturl);
            string getres = await response.Content.ReadAsStringAsync();
            return getres;
        }

        int id { get; set; }
        string title { get; set; }
        string created_at { get;set; }
        string updated_at { get; set; }
        bool demo { get; set; }
        bool is_calculating { get; set; }
        string absolute_url { get; set; }
        HttpClient httpClient = new HttpClient();
        
        public User current { get; set; }
    }
}
