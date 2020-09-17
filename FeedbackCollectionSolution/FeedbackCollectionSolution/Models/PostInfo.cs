using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackCollectionSolution.Models
{
    public class PostInfo
    {
        public int postId { get; set; }
        public string postName { get; set; }
        public string postComments { get; set; }
        public string userName { get; set; }
        public DateTime createdDate { get; set; }
        public string likeCount { get; set; }
        public string dislikeCount { get; set; }
    }
}
