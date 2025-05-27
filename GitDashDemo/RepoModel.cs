using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitDashDemo
{
    internal class RepoModel
    {
        [JsonProperty("html_url")]
        public string Url { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("stargazers_count")]
        public int Stars { get; set; }

        [JsonProperty("forks_count")]
        public int Forks { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}
