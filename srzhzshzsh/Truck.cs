using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace GarpPractice
{
    class Truck
    {
        public async void taketruck(string title)
        {
            JObject o = JObject.Parse(title);
            id = (int)o["id"];
            this.title = (string)o["title"];
            created_at = (string)o["created_at"];
            updated_at = (string)o["updated_at"];
            demo = (bool)o["bool"];
            mass = (long)o["mass"];
            carrying_capacity = (long)o["carrying_capacity"];
            width = (long)o["width"];
            height = (long)o["height"];
            length = (long)o["length"];
            loading_width = (long)o["loading_width"];
            loading_height = (long)o["loading_height"];
            loading_length = (long)o["loading_length"];
            indentation_height = (long)o["indentation_height"];
            indentation_height_top = (long)o["indentation_height_top"];
            indentation_length = (long)o["indentation_length"];
            indentation_length_end = (long)o["indentation_length_end"];
            created_at = (string)o["created_at"];
            updated_at = (string)o["updated_at"];
            demo = (bool)o["bool"];
            user = (string)o["user"];

            hitch_load = (long)o["hitch_load"];
            hitch_max_load = (long)o["hitch_max_load"];
            hitch_distance = (long)o["hitch_distance"];

            //доделать!!!
        }
        public Truck() { }
        public Truck(int id) { this.id = id; }

        public class Axles
        {
            public Axles() { }
            int id { get; set; }
            string title { get; set; }
            int distance { get; set; }
            int length { get; set; }
            long default_load { get; set; }
            long max_load { get; set; }
        }
        public class Tractor
        {
            
            public Tractor() { }
            public int id { get; set; }
            public string title { get; set; }
            public long length { get; set; }
            public long hitch_distnce { get; set; }
            public long mass { get; set; }
            public string created_at { get; set; }
            public string updated_at { get; set; }

            public List<Axles> axles = new List<Axles>();
        }
        public async Task<string> gettruck(bool demo, int page, int page_size, string titletitle__icontains)
        {
            HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", current.access_token);

            string geturl = $"https://back.glsystem.net/api/v1/truck/?demo={demo}&page={page}&page_size={page_size}&title__icontains={titletitle__icontains}";


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

            string geturl = $"https://back.glsystem.net/api/v1/cargo-space/sample/";

            using var response = await httpClient.GetAsync(geturl);
            string getres = await response.Content.ReadAsStringAsync();
            return getres;
        }
        public async Task<string> posttruck()
        {
            HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", current.access_token);

            string posturl = $"https://back.glsystem.net/api/v1/truck/";
            JsonContent content = JsonContent.Create(this);
            using var response = await httpClient.PostAsync("https://back.glsystem.net/api/v1/project/", content);
            string conetent = await response.Content.ReadAsStringAsync();
            return conetent;
        }
        public async Task<string> getbyid(int id)
        {
            HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", current.access_token);

            string geturl = $"https://back.glsystem.net/api/v1/container/{id}/";

            using var response = await httpClient.GetAsync(geturl);
            string getres = await response.Content.ReadAsStringAsync();
            return getres;
        }
        public async Task<string> puttruck(int id)
        {
            HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", current.access_token);

            JsonContent content = JsonContent.Create(this);
            string geturl = $"https://back.glsystem.net/api/v1/truck/{id}/";

            using var response = await httpClient.PutAsync(geturl, content);
            string getres = await response.Content.ReadAsStringAsync();
            return getres;
        }
        public async void deleteid(int id)
        {
            HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", current.access_token);

            string geturl = $"https://back.glsystem.net/api/v1/truck/{id}/";
            using var response = await httpClient.DeleteAsync(geturl);
        }
        public async Task<string> copyid(int id)
        {
            HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", current.access_token);

            string posturl = $"https://back.glsystem.net/api/v1/truck/{id}/copy/";
            JsonContent content = JsonContent.Create(this);
            using var response = await httpClient.PostAsync("https://back.glsystem.net/api/v1/project/", content);
            string conetent = await response.Content.ReadAsStringAsync();
            return conetent;
        }

        public int id { get; set; }
        public string title { get; set; }
        long mass { get; set; }
        long carrying_capacity { get; set; }
        long width { get; set; }
        long height { get; set; }
        long length { get; set; }
        long loading_width { get; set; }
        long loading_height { get; set; }
        long loading_length { get; set; }
        long indentation_width { get; set; }
        long indentation_width_right { get; set; }
        long indentation_height { get; set; }
        long indentation_height_top { get; set; }
        long indentation_length { get; set; }
        long indentation_length_end { get; set; }
        string created_at { get; set; }
        string updated_at { get; set; }
        bool demo { get; set; }
        string user { get; set; }

        public List<Axles> axles = new List<Axles>();
        public Tractor tractor = new Tractor();
        long hitch_load { get; set; }
        long hitch_max_load { get; set; }
        long hitch_distance { get; set; }


        HttpClient httpClient = new HttpClient();
        User current { get; set; }
    }

}