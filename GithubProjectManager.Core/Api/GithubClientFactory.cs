using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.Extensions.Configuration;
using Refit;

namespace GithubProjectManager.Core.Api
{
    public class GithubClientFactory
    {
        private readonly IConfiguration _configuration;

        public GithubClientFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IGithubApi Create()
        {
            var token = _configuration[ConfigurationConstants.TokenPath];
            var baseUrl = _configuration[ConfigurationConstants.BaseUrl];
            var userAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/60.0.3112.113 Safari/537.36";

            var httpClient = new HttpClient
            {
                BaseAddress = new Uri(baseUrl)
            };
            httpClient.DefaultRequestHeaders.Add("user-Agent",userAgent);
            httpClient.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse($"Bearer {token}");

            return RestService.For<IGithubApi>(httpClient);
        }
    }
}