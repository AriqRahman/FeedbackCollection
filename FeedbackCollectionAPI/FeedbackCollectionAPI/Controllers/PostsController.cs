using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FeedbackCollectionAPI.DataManager.IRepository;
using FeedbackCollectionAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FeedbackCollectionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostRepository _postRep;
        public PostsController(IPostRepository postRep)
        {
            _postRep = postRep;
        }


        // GET: api/Posts/GetPostInfo
        [HttpGet("GetPostInfo")]
        public IActionResult GetPostInfo() 
        {
            var data = _postRep.GetPostInformation();
            if (data != null && data.Count > 0)
            {
                return Ok(data);
                //return Ok(new { responseCode = "200", responseStatus = "Success", responseMessage = string.Empty, resultData = data });
            }
            else
            {
                return NoContent();
                //return Ok(new { responseCode = "200", responseStatus = "Fail", responseMessage = "No Data Found !!", resultData = string.Empty });
            }
        }


    }
}