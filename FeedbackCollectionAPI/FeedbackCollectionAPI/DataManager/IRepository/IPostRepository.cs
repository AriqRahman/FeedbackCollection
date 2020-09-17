using FeedbackCollectionAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackCollectionAPI.DataManager.IRepository
{
    public interface IPostRepository
    {
        List<PostInfoVM> GetPostInformation();
    }
}
