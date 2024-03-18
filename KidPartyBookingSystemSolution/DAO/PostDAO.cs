using AutoMapper;
using BusinessObjects;
using BusinessObjects.Request;
using BussinessObjects.Request;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class PostDAO
    {
        private static PostDAO instance = null;
        private readonly PHSContext dbContext = null;
        public PostDAO()
        {
            if (dbContext == null)
            {
                dbContext = new PHSContext();
            }
        }

        public static PostDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PostDAO();
                }
                return instance;
            }
        }

        public bool checkPostExistedBy(int by)
        {
            bool isExisted = false;
            Post checkAccount = dbContext.Posts.FirstOrDefault(x => x.CreatedBy == by);
            if (checkAccount != null)
            {
                isExisted = true;
            }
            return isExisted;
        }

        public Post checkPostExistedByID(int id)
        {
            return dbContext.Posts.FirstOrDefault(x => x.PostId == id);
        }

        // Get All Post
        public List<Post> GetPosts()
        {
            List<Post> post = dbContext.Posts.ToList();
            return post;
        }

        // Get All Post By PartyHostID
        public List<Post> getAllPostByPartyHostId(int id)
        {
            try
            {
                return dbContext.Posts
                    .Include(p => p.Feedbacks)
                    .Where(p => p.CreatedBy == id).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        // Get Post By Id
        public Post GetPostById(int id)
        {
            var post = dbContext.Posts
                 .Include(p => p.Feedbacks)
                 .SingleOrDefault(p => p.PostId == id);
            return post;
        }


        public RequestCreatePostDTO CreatePost(RequestCreatePostDTO request)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            IMapper mapper = config.CreateMapper();
            Post post = mapper.Map<Post>(request);
            post.CreatedAt = DateTime.Now;
            dbContext.Posts.Add(post);
            dbContext.SaveChanges();
            return request;
        }

        public bool DeletePost(int id)
        {
            Post checkExisted = checkPostExistedByID(id);
            bool isDeleted = false;
            if (checkExisted != null)
            {
                var relatedFeedbacks = dbContext.Feedbacks.Where(x => x.PostId == id);
                dbContext.Feedbacks.RemoveRange(relatedFeedbacks);
                dbContext.Posts.Remove(checkExisted);
                dbContext.SaveChanges();
                isDeleted = true;
            }
            return isDeleted;
        }

        public Post UpdatePost(Post request)
        {
            Post checkExisted = checkPostExistedByID(request.PostId);
            if (checkExisted != null)
            {
                dbContext.Entry(checkExisted).CurrentValues.SetValues(request);
                dbContext.Entry(checkExisted).State = EntityState.Modified;
                dbContext.SaveChanges();
            }
            return request;
        }

        public int CountPost()
        {
            return dbContext.Posts.Count();
        }

        public List<Post> searchPost(string context)
        {
            List<Post> searchAccounts = dbContext.Posts
                .Where(x =>
                    x.Context.ToUpper().Contains(context.ToUpper().Trim()) ||
                    x.Title.ToUpper().Contains(context.ToUpper().Trim()))
                .ToList();
            return searchAccounts;
        }
    }
}
