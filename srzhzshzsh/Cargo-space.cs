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
    class Cargo_space
    {
        public Cargo_space() { }
        public Cargo_space(int id) { this.id = id; }
        public Cargo_space(User user) { current = new User(user); }
        public async void takespace(string title)
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
            cargo_space_type = (string)o["cargo_space_type"];
        }
        public async Task<string> getspace(string cargo_space_type, bool demo, string ordering,int page,int page_size,string titletitle__icontains)
        {
            HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", current.access_token);

            string geturl = $"https://back.glsystem.net/api/v1/cargo-space/?cargo_space_type={cargo_space_type}&demo={demo}&ordering={ordering}&page={page}&page_size={page_size}&title__icontains={titletitle__icontains}";
            

            using var response = await httpClient.GetAsync(geturl);
            string getres = await response.Content.ReadAsStringAsync();
            return getres;
            /*
            JObject o = JObject.Parse(conetent);
            return o;
            */
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
        string cargo_space_type { get; set; } 

        HttpClient httpClient = new HttpClient();
        User current { get; set; }
    }

}
  


