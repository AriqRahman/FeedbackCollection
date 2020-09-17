using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackCollectionSolution.Models
{
    public class ResponseModel
    {
        public int responseCode { get; set; }
        public string responseStatus { get; set; }
        public string responseMessage { get; set; }

        public List<PostInfo> resultData { get; set; }
    }
}
