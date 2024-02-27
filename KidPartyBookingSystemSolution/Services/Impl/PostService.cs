using Repository.Impl;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Impl
{
    public class PostService : IPostService
    {
        private IPostRepository postRepository;

        public PostService()
        {
            postRepository = new PostRepository();
        }
    }
}
