using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Logging;

public class LogDetailWithException: LogDetail
{
    public string ExceptionMessage { get; set; }
    
    public LogDetailWithException()
    {
        ExceptionMessage = string.Empty;
        IsSuccessful = false;
    }

    public LogDetailWithException(string fullName, 
        string methodName, 
        string user, 
        List<LogParameter> parameters,
        string exceptionMessage) : base(fullName, methodName, user, parameters)
    {
        ExceptionMessage = exceptionMessage;
        IsSuccessful = false;
    }

}
