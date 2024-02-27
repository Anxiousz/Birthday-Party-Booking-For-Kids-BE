using Repository.Impl;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Impl
{
    public class FeedBackService : IFeedBackService
    {
        private IFeedBackRepository feedBackRepository;

        public FeedBackService()
        {
            feedBackRepository = new FeedBackRepository();
        }
    }
}
