using BusinessObjects;
using BusinessObjects.Request;
using BussinessObjects;
using BussinessObjects.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Impl;

namespace KidPartyHostingSystemAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PostController : ControllerBase
    {
        private IPostService _post;
        public PostController(IPostService post)
        {
            _post = post;
        }

        [HttpGet("getAllPost")]
        public IActionResult GetPosts()
        {
            var post = _post.GetPost();
            if (post.Count > 0)
            {
                return Ok(post);
            }
            return NotFound();
        }
        [HttpGet("/getPostDetail/{id}")]
        public IActionResult GetPostById(int id)
        {
            var post = _post.GetPostById(id);
            if (post != null)
            {
                return Ok(post);
            }
            return NotFound();
        }

        [HttpPost("createNewPost")]
        public IActionResult CreatePost([FromBody] RequestCreatePostDTO request)
        {
            if (request == null)
            {
                return BadRequest("The field not empty");
            }
            int by = request.CreatedBy ?? 0;
            bool checkExisted = _post.checkPostExistedBy(by);
            if (checkExisted != true)
            {
                RequestCreatePostDTO createPost = _post.CreatePost(request);
                return Ok(createPost);
            }
            return Conflict("The post is existed");
        }

        [HttpDelete("deletePost/{id}")]
        public IActionResult DeletePost(int id)
        {
            Post checkExisted = _post.checkPostExistedByID(id);
            if (checkExisted != null)
            {
                bool deletePost = _post.DeletePost(id);
                return Ok("Delete " + checkExisted.PostId + " successfully");
            }
            return NotFound("The post not found");
        }

        [HttpPut("updatePost/{id}")]
        public IActionResult UpdatePost(int id, [FromBody] RequestPostDTO request)
        {
            if (request == null)
            {
                return BadRequest("The request body is empty");
            }

            Post existedPost = _post.checkPostExistedByID(id);
            if (existedPost == null)
            {
                return NotFound("Post not found");
            }

            existedPost.Context = request.Context;
            existedPost.Title = request.Title;
            existedPost.UpdatedAt = DateTime.Now;
            existedPost.UpdatedBy = request.UpdatedBy;
            existedPost.Image = request.Image;

            Post updatedPost = _post.UpdatePost(existedPost);

            if (updatedPost != null)
            {
                return Ok("Post updated successfully");
            }
            else
            {
                return StatusCode(500, "Failed to update the post");
            }
        }


        [HttpGet("searchPost/{context}")]
        public IActionResult searchPost(string context)
        {
            List<Post> searchPost = _post.searchPost(context);
            return Ok(searchPost);
        }

        [HttpGet("GetAllPostByPartyHostId/{id}")]
        public IActionResult getAllPostByPartyHostId (int id)
        {
            List<Post> partyHostPosts = _post.getAllPostByPartyHostId(id);
            if (partyHostPosts.Count > 0)
            {
                return Ok(partyHostPosts);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
