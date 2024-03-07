using BusinessObjects.Request;
using BusinessObjects.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IFeedBackRepository
    {
        Task<ReponseFeedbackDTO> GetFeedbackById(int feedback);
        Task<bool> CreateFeedback(RequestFeedbackDTO feedback);
    }
}
