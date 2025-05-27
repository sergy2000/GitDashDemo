using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GitDashDemo
{
    class GithubApiService 
    {

        private readonly HttpClient _client = new HttpClient();

		public GithubApiService()
		{
			_client.DefaultRequestHeaders.UserAgent.ParseAdd("GitDashDemo");
		}

		public async Task<GitUserModel> GetUserAsync(string username)
		{
			var resp = await _client.GetAsync($"https://api.github.com/users/{username}");
			if (!resp.IsSuccessStatusCode) return null;
			var json = await resp.Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<GitUserModel>(json);
		}

        public async Task<List<RepoModel>> GetReposAsync(string username)
        {
            var resp = await _client.GetAsync($"https://api.github.com/users/{username}/repos");
            if (!resp.IsSuccessStatusCode) return new List<RepoModel>();
            var json = await resp.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<RepoModel>>(json);
        }
    }
}
