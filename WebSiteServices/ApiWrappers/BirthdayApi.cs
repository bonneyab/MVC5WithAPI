using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Contract.DTO;
using WebSiteServices.ApiWrappers.Interfaces;


namespace WebSiteServices.ApiWrappers
{
    class BirthdayApi : IBirthdayApi
    {
        public async Task<List<Birthday>>  GetBirthdaysAsync()
        {
            var httpClientHandler = new HttpClientHandler {UseDefaultCredentials = true};
            using (var client = new HttpClient(httpClientHandler))
            {
                //TODO set up configuration for this.
                client.BaseAddress = new Uri("http://adamsmv01.dev.gatesfoundation.org:88/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // New code:
                var response = await client.GetAsync("api/birthday");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsAsync<List<Birthday>>();
            }
        }
    }
}
