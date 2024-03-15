using BusinessObjects;
using BusinessObjects.Request;
using BusinessObjects.Response;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Impl
{
    public class FeedBackRepository : IFeedBackRepository
    {
        private FeedBackDAO feedBackDAO;
        public FeedBackRepository()
        {
            feedBackDAO = new FeedBackDAO();
        }

        public Task<bool> CreateFeedback(RequestFeedbackDTO feedback) => feedBackDAO.CreateFeedback(feedback);

        public Task<ReponseFeedbackDTO> GetFeedbackById(int feedback) => feedBackDAO.GetFeedbackById(feedback);

        public List<Feedback> listFeedBack() => feedBackDAO.listFeedBack();
    }
}
