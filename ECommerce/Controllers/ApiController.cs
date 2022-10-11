using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.Results;
using ECommerce.Application.Interfaces;
using ECommerce.Application.Notifications;

namespace ECommerce.Services.Api.Controllers
{
    [ApiController]
    public abstract class ApiController : ControllerBase
    {
        private readonly INotifier _notifier;
        protected ApiController(INotifier notifier) 
            => _notifier = notifier;
        

        protected ActionResult CustomResponse(object result = null)
        {
            if (IsOperationValid())
            {
                return Ok(result);
            }

            return BadRequest(new
            {
                errors = _notifier.GetNotifications().Select(n => n.Message)
            });
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            var errors = modelState.Values.SelectMany(e => e.Errors);
            foreach (var error in errors)
            {
                AddError(error.ErrorMessage);
            }

            return CustomResponse();
        }

        protected ActionResult CustomResponse(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                AddError(error.ErrorMessage);
            }

            return CustomResponse();
        }

        protected bool IsOperationValid()
        {
            return !_notifier.HasNotification();
        }

        protected void AddError(string erro)
        {
            _notifier.Handle(new Notification(erro));
        }

    }
}
