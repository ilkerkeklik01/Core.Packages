using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Serilog;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Core.Application.Pipelines.Logging;

public class LoggingBehavior<TRequest,TResponse>: IPipelineBehavior<TRequest,TResponse>
    where TRequest : IRequest<TResponse>, ILoggableRequest 
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly LoggerServiceBase _loggerServiceBase;

    public LoggingBehavior(IHttpContextAccessor httpContextAccessor, LoggerServiceBase loggerServiceBase)
    {
        _httpContextAccessor = httpContextAccessor;
        _loggerServiceBase = loggerServiceBase;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        List<LogParameter> logParameters =
            new()
            {
                new LogParameter(){Type= request.GetType().Name,Value=request } //Name ?
            };

        TResponse? response;

        LogDetail logDetail = new()
        {
            //FullName?
            MethodName = next.Method.Name,
            IsSuccessful = true,
            Parameters = logParameters,
            User = _httpContextAccessor.HttpContext.User.Identity?.Name??"?"
        };

        try
        {
            response = await next();
        }
        catch (Exception ex)
        {
            logDetail.IsSuccessful = false;
            _loggerServiceBase.Info(JsonSerializer.Serialize(logDetail));
            throw;
        }
        
        _loggerServiceBase.Info(JsonSerializer.Serialize(logDetail));

        return response;

    }
}
