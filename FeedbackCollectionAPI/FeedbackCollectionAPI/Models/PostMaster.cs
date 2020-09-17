using System;
using System.Collections.Generic;

namespace FeedbackCollectionAPI.Models
{
    public partial class PostMaster
    {
        public int Id { get; set; }
        public string PostName { get; set; }
        public string Remarks { get; set; }
        public bool? IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModefiedBy { get; set; }
        public DateTime? ModefiedDate { get; set; }
    }
}
