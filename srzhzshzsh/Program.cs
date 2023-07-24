using GarpPractice;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json.Nodes;


    User newuser = new User("zf.5120@gmail.com", "Lego2010");
    newuser.login().Wait();
    //Console.WriteLine(JsonConvert.SerializeObject(newuser));

JObject o = JObject.Parse(JsonConvert.SerializeObject(newuser));

Console.WriteLine(o.ToString());

