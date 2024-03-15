using Repository.Impl;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects.Request;
using BusinessObjects.Response;
using BusinessObjects;

namespace Services.Impl
{
    public class FeedBackService : IFeedBackService
    {
        private IFeedBackRepository feedBackRepository;

        public FeedBackService()
        {
            feedBackRepository = new FeedBackRepository();
        }

        public Task<bool> CreateFeedback(RequestFeedbackDTO feedback) => feedBackRepository.CreateFeedback(feedback);

        public Task<ReponseFeedbackDTO> GetFeedbackById(int feedback) => feedBackRepository.GetFeedbackById(feedback);

        public List<Feedback> listFeedBack() => feedBackRepository.listFeedBack();
    }
}
