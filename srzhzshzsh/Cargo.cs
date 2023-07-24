using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarpPractice
{
    class Cargo
    {
        public Cargo() { }
        public Cargo(string title) { this.title = title; }
        public async void takeCargo(string title)
        {
            JObject o = JObject.Parse(title);
            id = (int)o["id"];
            this.title = (string)o["title"];
            
            length = (int)o["length"];
            width = (int)o["width"];
            height = (int)o["height"];
            mass = (int)o["mass"];
            stacking = (bool)o["stacking"];
            stacking_limit = (int)o["stacking_limit"];
            turnover = (bool)o["turnover"];
            article = (string)o["article"];
            margin_length = (int)o["margin_length"];
            margin_width = (int)o["margin_width"];
            color = (string)o["colour"];
            demo = (bool)o["bool"];
            created_at = (string)o["created_at"];
            updated_at = (string)o["updated_at"];
            last_changed_user = (int)o["last_changed_user"];
            user = (int)o["user"];

        }
        public int id { get; set; }
        public string title { get; set; }
        public int length { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public int mass { get; set; }
        public bool stacking { get; set; } 
        public int stacking_limit { get; set; }
        public bool turnover { get; set; } 
        public string article { get; set; } 
        public int margin_length { get; set; }
        public int margin_width { get; set; }
        public string color { get; set; } 
        public bool demo { get; set; }
        string created_at { get; set; }
        string updated_at { get; set; }
        public int last_changed_user { get; set; } 
        public int user { get; set; }

        
    }
}
