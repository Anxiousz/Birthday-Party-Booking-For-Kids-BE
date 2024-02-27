using BusinessObjects;
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
    }
}
