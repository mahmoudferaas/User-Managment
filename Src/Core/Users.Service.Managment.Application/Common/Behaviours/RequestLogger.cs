using System.Threading;
using System.Threading.Tasks;
using BaseClasses.Loggers.Utilities;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using Users.Service.Managment.Application.Common.Interfaces;

namespace Users.Service.Managment.Application.Common.Behaviours
{
    public class RequestLogger<TRequest> : IRequestPreProcessor<TRequest>
    {
        private readonly ILogger _logger;

        public RequestLogger(ILogger<TRequest> logger)
        {
            _logger = logger; 

        }

        public Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var name = typeof(TRequest).Name;

            _logger.LogInformation(" Request: {Name} {@UserId} {@Request}", name, request);

            return Task.CompletedTask;
        }

    }


    //public class RequestLogger<TRequest, TResponse> : IRequestPostProcessor<TRequest, TResponse>
    //{
    //    private readonly ILogger _logger;
    //    private readonly ICurrentUserService _currentUserService;
    //    private readonly ILogger _loggerCloud;
    //    private readonly IUserInformation _userInformation;

    //    public Task Process(TRequest request, TResponse response, CancellationToken cancellationToken)
    //    {
    //        var name = typeof(TRequest).Name;

    //        //_loggerCloud.LogInformation(_userInformation.BuildLoggingEntry(, "", _userInformation.CreateLoggerObject(request, response)));

    //        _logger.LogInformation(" Request: {Name} {@UserId} {@Request}",
    //            name, _currentUserService.GetUserId(), request);

    //        return Task.CompletedTask;
    //    }
    //}


}
