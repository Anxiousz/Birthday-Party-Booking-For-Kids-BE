using Repository.Impl;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using BussinessObjects.Request;
using BusinessObjects.Request;

namespace Services.Impl
{
    public class PostService : IPostService
    {
        private IPostRepository postRepository;

        public PostService()
        {
            postRepository = new PostRepository();
        }
        public bool checkPostExistedBy(int by)
        {
            return postRepository.checkPostExistedBy(by);
        }

        public Post checkPostExistedByID(int id)
        {
            return postRepository.checkPostExistedByID(id);
        }

        public int CountPost()
        {
            return postRepository.CountPost();
        }

        public RequestCreatePostDTO CreatePost(RequestCreatePostDTO request)
        {
            return postRepository.CreatePost(request);
        }

        public bool DeletePost(int id)
        {
            return postRepository.DeletePost(id);
        }

        public List<Post> GetPost()
        {
            return postRepository.GetPost();
        }

        public Post GetPostById(int id)
        {
            return postRepository.GetPostById(id);
        }

        public List<Post> searchPost(string context)
        {
            return postRepository.searchPost(context);
        }

        public Post UpdatePost(Post request)
        {
            return postRepository.UpdatePost(request);
        }
    }
}
