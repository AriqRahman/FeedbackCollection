using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackCollectionAPI.ViewModel
{
    public class PostInfoVM
    {
        public int PostId { get; set; }
        public string PostName { get; set; }
        public string PostComments { get; set; }
        public string UserName { get; set; }
        public DateTime CreatedDate { get; set; }

        public string LikeCount { get; set; }
        public string DislikeCount { get; set; }

    }
}
