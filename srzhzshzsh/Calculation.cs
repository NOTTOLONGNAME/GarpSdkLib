using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json.Linq;

namespace GarpPractice
{
    class Calculation {
        public Calculation() { }
        public Calculation(Project project) { this.project = project; }
        async Task<string> getcalclation(bool favourite,bool is_history,bool is_recalculate,string ordering,int page,int page_size,int project_id,string status)
        {
            HttpClient httpClient = new HttpClient();

            using var request = new HttpRequestMessage(HttpMethod.Get, $"https://back.glsystem.net/api/v1/calculation/?favorite={favourite}&is_history={is_history}&is_recalculate={is_recalculate}&ordering={ordering}&page={page}&page_size={page_size}&status={status}");
            request.Headers.Add("Authorization", $"Bearer {current.access_token}");

            using HttpResponseMessage response = await httpClient.SendAsync(request);

            Console.WriteLine($"Status: {response.StatusCode}\n");
            string content = await response.Content.ReadAsStringAsync();
            return content;
        }
        async Task<string> postcalculation() 
        {
            HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", current.access_token);

            string posturl = $"https://back.glsystem.net/api/v1/calculation/";
            JsonContent content = JsonContent.Create(this);
            using var response = await httpClient.PostAsync(posturl, content);
            string postreturn = await response.Content.ReadAsStringAsync();
            return postreturn;
        }
        async Task<string> getbyid(int id)
        {
            HttpClient httpClient = new HttpClient();

            using var request = new HttpRequestMessage(HttpMethod.Get, $"https://back.glsystem.net/api/v1/calculation/{id}/");
            request.Headers.Add("Authorization", $"Bearer {current.access_token}");

            using HttpResponseMessage response = await httpClient.SendAsync(request);

            Console.WriteLine($"Status: {response.StatusCode}\n");
            string content = await response.Content.ReadAsStringAsync();
            return content;
        }
        public async Task<string> patchbyid(int id, bool favourite)
        {
            HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", current.access_token);

            JsonContent content = JsonContent.Create(favourite);
            string geturl = $"https://back.glsystem.net/api/v1/calculation/{id}/";

            using var response = await httpClient.PatchAsync(geturl, content);
            string getres = await response.Content.ReadAsStringAsync();
            return getres;
        }
        public async void deleteid(int id)
        {
            HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", current.access_token);

            string geturl = $"https://back.glsystem.net/api/v1/calculation/{id}/";

            using var response = await httpClient.DeleteAsync(geturl);
        }
        async Task<string> errorbyid(int id)
        {
            HttpClient httpClient = new HttpClient();

            using var request = new HttpRequestMessage(HttpMethod.Get, $"https://back.glsystem.net/api/v1/calculation/{id}/calculation_errors/");
            request.Headers.Add("Authorization", $"Bearer {current.access_token}");

            using HttpResponseMessage response = await httpClient.SendAsync(request);

            Console.WriteLine($"Status: {response.StatusCode}\n");
            string content = await response.Content.ReadAsStringAsync();
            return content;
        }
        async Task<string> pivotrep(int id,string file_type )
        {
            HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", current.access_token);

            string posturl = $"https://back.glsystem.net/api/v1/calculation/{id}/calculation_pivot_report/";
            JsonContent conetent = JsonContent.Create(this + file_type);
            using var response = await httpClient.PostAsync(posturl, conetent);
            string postreturn = await response.Content.ReadAsStringAsync();
            return postreturn; //ljltkfnm!!!
        }
        async Task<string> calculationrep(int id, string content)
        {
            HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", current.access_token);

            string posturl = $"https://back.glsystem.net/api/v1/calculation/{id}/calculation_report/";
            JsonContent conetent = JsonContent.Create(content);
            using var response = await httpClient.PostAsync(posturl, conetent);
            string postreturn = await response.Content.ReadAsStringAsync();
            return postreturn; //ljltkfnm!!!
        }
        


        async Task<string> reppage(int id)
        {
            HttpClient httpClient = new HttpClient();

            using var request = new HttpRequestMessage(HttpMethod.Get, $"https://back.glsystem.net/api/v1/calculation/{id}/calculation_report_page/");
            request.Headers.Add("Authorization", $"Bearer {current.access_token}");

            using HttpResponseMessage response = await httpClient.SendAsync(request);

            Console.WriteLine($"Status: {response.StatusCode}\n");
            string content = await response.Content.ReadAsStringAsync();
            return content;
        }
        async Task<string> calccancel(int id)
        {
            HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", current.access_token);

            string posturl = $"https://back.glsystem.net/api/v1/calculation/{id}/cancel/";
            JsonContent conetent = JsonContent.Create("");
            using var response = await httpClient.PostAsync(posturl, conetent);
            string postreturn = await response.Content.ReadAsStringAsync();
            return postreturn; 
        }
        async Task<string> calcspace(int id,int uid)
        {
            HttpClient httpClient = new HttpClient();

            using var request = new HttpRequestMessage(HttpMethod.Get, $"https://back.glsystem.net/api/v1/calculation/{id}/cargo_space/{uid}/");
            request.Headers.Add("Authorization", $"Bearer {current.access_token}");

            using HttpResponseMessage response = await httpClient.SendAsync(request);

            Console.WriteLine($"Status: {response.StatusCode}\n");
            string content = await response.Content.ReadAsStringAsync();
            return content;
        }
        async Task<string> idcargoes(int id)
        {
            HttpClient httpClient = new HttpClient();

            using var request = new HttpRequestMessage(HttpMethod.Get, $"https://back.glsystem.net/api/v1/calculation/{id}/cargoes/");
            request.Headers.Add("Authorization", $"Bearer {current.access_token}");

            using HttpResponseMessage response = await httpClient.SendAsync(request);

            Console.WriteLine($"Status: {response.StatusCode}\n");
            string content = await response.Content.ReadAsStringAsync();
            return content;
        }
        async Task<string> fullpivot(int id, string cont)
        {
            HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", current.access_token);

            string posturl = $"https://back.glsystem.net/api/v1/calculation/{id}/full_pivot_report/";
            JsonContent content = JsonContent.Create(cont);
            using var response = await httpClient.PostAsync(posturl, content);
            string postreturn = await response.Content.ReadAsStringAsync();
            return postreturn; //!!!!!gsegEGawge cont
        }
        async Task<string> pivotexcluding(int id, string cont)
        {
            HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", current.access_token);

            string posturl = $"https://back.glsystem.net/api/v1/calculation/{id}/pivot_report_excluding_pallets/";
            JsonContent content = JsonContent.Create(cont);
            using var response = await httpClient.PostAsync(posturl, content);
            string postreturn = await response.Content.ReadAsStringAsync();
            return postreturn; //!!!!!!EAGAEG cont
        }
        public async Task<string> updatedesigned(int id)
        {
            HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", current.access_token);

            JsonContent content = JsonContent.Create(this);
            string geturl = $"https://back.glsystem.net/api/v1/calculation/{id}/update_designed/";

            using var response = await httpClient.PatchAsync(geturl, content);
            string getres = await response.Content.ReadAsStringAsync();
            return getres;
        }
        async Task<string> createdesigned()
        {
            HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", current.access_token);

            string posturl = $"https://back.glsystem.net/api/v1/calculation/create_designed/";
            JsonContent conetent = JsonContent.Create(this);
            using var response = await httpClient.PostAsync(posturl, conetent);
            string postreturn = await response.Content.ReadAsStringAsync();
            return postreturn;
        }
        async Task<string> createwproj()
        {
            HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", current.access_token);

            string posturl = $"https://back.glsystem.net/api/v1/calculation/create_with_project/";
            JsonContent conetent = JsonContent.Create(this);
            using var response = await httpClient.PostAsync(posturl, conetent);
            string postreturn = await response.Content.ReadAsStringAsync();
            return postreturn;
        }
        async Task<string> history()
        {
            HttpClient httpClient = new HttpClient();

            using var request = new HttpRequestMessage(HttpMethod.Get, $"https://back.glsystem.net/api/v1/calculation/history/");
            request.Headers.Add("Authorization", $"Bearer {current.access_token}");

            using HttpResponseMessage response = await httpClient.SendAsync(request);

            Console.WriteLine($"Status: {response.StatusCode}\n");
            string content = await response.Content.ReadAsStringAsync();
            return content;
        }


        public class Input_data
        {
            public Input_data() { }
            public List<Cargo_space> cargo_spaces = new List <Cargo_space>();
            public class Groups
            {
                public class Cargoes : Cargo
                {
                    public Cargoes() { }
                    public Cargoes(string name) { title = name; }
                    public int count { get; set; } 
                    public struct Info
                    {
                        public string additionalProp1 { get; set; }
                        public string additionalProp2 { get; set; }
                        public string additionalProp3 { get; set; }
                    }
                    public Info info { get; set; }
                }
                public string title { get; set; } = "";
                public Groups() { }
                public Groups(string title) { this.title = title; }
                public List<Cargoes> cargoes = new List<Cargoes>();
                /*
                {
                string title { get; set; } = "";
                   long length { get; set; } = 0;
                    long width { get; set; } = 0;
                   long height { get; set; } = 0;
                    int mass { get; set; } = 0;
                 bool stacking { get; set; } = true;
                 long stacking_limit { get; set; } = 0;
                 bool turnover { get; set; } = true;
                 string article { get; set; } = "";
                 long margin_length { get; set; } = 0;
                 long margin_width { get; set; } = 0;
                 string color { get; set; } = "#57FF41";
                 bool demo { get; set; } = true;
                 int last_changed_user { get; set; } = 0;
                 int count { get; set; } = 0;
                 struct info{
                 public info() { }
                 string additionalProp1 { get; set; } = "";
                 string additionalProp2 { get; set; } = "";
                 string additionalProp3 { get; set; } = "";
          }
}*/
                public int sort { get; set; } = 1;
                public int pallet { get; set; }

                public void add_cargo(string title) { cargoes.Add(new Cargoes(title)); }
            }
            public List<Groups> groups = new List<Groups>();
            public bool userSort { get; set; }
            public void new_cargospace(int cargospaceid) { cargo_spaces.Add(new Cargo_space(cargospaceid)); }
            public void new_group(string grouptitle) { groups.Add(new Groups(grouptitle)); }
        }
        
        public Input_data input_data = new Input_data();  
        public Project project { get; set; }
        public string status { get; set; }
        public string callback_url { get; set; }
        public string external_api { get; set; }
        //Cargo_space Space;
        HttpClient httpClient = new HttpClient(); //перенести из User
        public User current { get; set; } = new User();

    }
}
