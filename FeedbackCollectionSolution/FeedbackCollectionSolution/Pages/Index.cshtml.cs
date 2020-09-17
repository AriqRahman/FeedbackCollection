using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using FeedbackCollectionSolution.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace FeedbackCollectionSolution.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public List<PostInfo> postList { get; set; }
        public List<PostInfo> distinctPostIdList { get; set; }
        public async Task OnGet()
        {
            

            var url = "https://localhost:44350/api/Posts/GetPostInfo";

            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient client = new HttpClient(clientHandler);
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
            var responseTask = client.GetAsync(url);
            responseTask.Wait();

            var result = responseTask.Result;

            if (result.IsSuccessStatusCode)
            {
                var contentString = await result.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<PostInfo>>(contentString);

                if (values != null)
                {
                    postList = values;

                    if (postList != null && postList.Count > 0)
                    {
                        //distinctPostIdList = postList.Distinct()
                        var ListOfPostId = postList.GroupBy(x => x.postId)
                                  .Select(g => g.First())
                                  .ToList();

                        List<PostInfo> distinctList = new List<PostInfo>();
                        foreach (var tData in ListOfPostId)
                        {
                            distinctList.Add(tData);
                            
                        }

                        if (distinctList != null && distinctList.Count > 0)
                        {
                            distinctPostIdList = distinctList;
                        }
                        

                    }

                }
                else
                {
                    postList = new List<PostInfo>();
                }

            }


        }
    }
}
