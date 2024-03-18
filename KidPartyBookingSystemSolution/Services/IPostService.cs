using BusinessObjects;
using BusinessObjects.Request;
using BussinessObjects.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IPostService
    {
        public List<Post> GetPost();
        public Post GetPostById(int id);
        public RequestCreatePostDTO CreatePost(RequestCreatePostDTO request);
        public bool DeletePost(int id);
        public Post UpdatePost(Post request);
        public List<Post> searchPost(string context);
        public int CountPost();
        public bool checkPostExistedBy(int by);
        public Post checkPostExistedByID(int id);
    }
}
