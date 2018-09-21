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

            var httpClient = new HttpClient
            {
                BaseAddress = new Uri(baseUrl)
            };
            httpClient.DefaultRequestHeaders.UserAgent.Add(ProductInfoHeaderValue.Parse("zexuz"));
            httpClient.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse($"Bearer {token}");

            return RestService.For<IGithubApi>(httpClient);
        }
    }
}