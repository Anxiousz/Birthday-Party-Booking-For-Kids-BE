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
    }
}
