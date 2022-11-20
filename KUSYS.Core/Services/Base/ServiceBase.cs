using KUSYS.Core.Dto;
using KUSYS.Domain.DBContext;

namespace KUSYS.Core.Services.Base
{
    public abstract class ServiceBase : IServiceBase
    {
        public ServiceBase(KUSYSDbContext dbContext)
        {
            KUSYSDB = dbContext;
        }

        /// <summary>
        /// DB Connection 
        /// </summary>
        public KUSYSDbContext KUSYSDB
        {
            get; private set;
        }
    }
 
}
