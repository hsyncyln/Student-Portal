using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUSYS.Core.Services.Base
{
    public enum ServiceResultType
    {
        Success = 1,
        Fail = 0,
    }
    public class ServiceResult
    {
        public string Message { get; private set; }

        public ServiceResultType ResultType { get; private set; }
        public Exception Exception { get; private set; }

        public ServiceResult(ServiceResultType resultType)
        {
            ResultType = resultType;
        }
        public ServiceResult(ServiceResultType resultType, string message)
        {
            ResultType = resultType;
            Message = message;
        }
        public ServiceResult(ServiceResultType resultType, Exception exception, string message)
        {
            ResultType = resultType;
            Exception = exception;
            Message = message;
        }


    }
}
