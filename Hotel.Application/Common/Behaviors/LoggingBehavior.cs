using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Serilog;

namespace Hotel.Application.Common.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse> where TRequest 
        : IRequest<TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationtoken, RequestHandlerDelegate<TResponse> next)
        {
            var requestName = typeof(TRequest).Name;

            Log.Information("Hotel Request: {Name} {@Request}", requestName, request);
            var response = await next();
            return response;
        }
    }
}
