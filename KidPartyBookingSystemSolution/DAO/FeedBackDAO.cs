using AutoMapper;
using BusinessObjects;
using BusinessObjects.Request;
using BusinessObjects.Response;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class FeedBackDAO
    {
        private static FeedBackDAO instance = null;
        private readonly PHSContext dbContext = null;
        public FeedBackDAO()
        {
            if (dbContext == null)
            {
                dbContext = new PHSContext();
            }
        }

        public static FeedBackDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FeedBackDAO();
                }
                return instance;
            }
        }
        public async Task<ReponseFeedbackDTO> GetFeedbackById(int id)
        {
            try
            {
                var feedback = await dbContext.Feedbacks.SingleOrDefaultAsync(x => x.FeedbackId == id);


                if (feedback == null)
                {
                    throw new Exception("Post isn't exist");
                }

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<MappingProfile>();
                });
                IMapper mapper = config.CreateMapper();
                ReponseFeedbackDTO feedbackDTO = mapper.Map<ReponseFeedbackDTO>(feedback);
                return feedbackDTO;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }

        }

        public async Task<bool> CreateFeedback( RequestFeedbackDTO feedbackDTO)
        {
            try
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<MappingProfile>();
                });
                IMapper mapper = config.CreateMapper();
                Feedback feedback = mapper.Map<Feedback>(feedbackDTO);


                dbContext.Feedbacks.Add(feedback);

                if (await dbContext.SaveChangesAsync() > 0)
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }
    }
}
