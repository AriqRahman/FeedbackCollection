using System;
using System.Collections.Generic;

namespace FeedbackCollectionAPI.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool? IsActive { get; set; }
        public string Remarks { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModefiedBy { get; set; }
        public DateTime? ModefiedDate { get; set; }
    }
}
