using Common.Common.Response;
using FluentValidation.Results;
using System.Net;


namespace Common.Common.Handlers
{
    public static class ResponseHandler
    {
        public static APIResponse GetValidationErrorResponse(ValidationResult validationResult)
        {
            IDictionary<string, string> errors = new Dictionary<string, string>();

            foreach (var error in validationResult.Errors)
            {
                errors[error.PropertyName] = error.ErrorMessage;
            }

            return new APIResponse(false, HttpStatusCode.BadRequest, errors, Message.ERROR);
        }
        public static APIResponse GetValidationErrorResponse(List<ValidationResult> validationResults)
        {
            var errors = validationResults.SelectMany(vr => vr.Errors).ToList();
            return new APIResponse(false, HttpStatusCode.BadRequest, errors, Message.ERROR);
        }
        public static APIResponse GetBadRequestResponse(string message)
        {
            return new APIResponse(false, HttpStatusCode.BadRequest, message, Message.ERROR);
        }

        public static APIResponse GetBadRequestResponse(dynamic data)
        {
            return new APIResponse(false, HttpStatusCode.BadRequest, data, Message.ERROR);
        }

        public static APIResponse GetSuccessResponse(dynamic data, string message)
        {
            return new APIResponse(true, HttpStatusCode.OK, data, message);
        }

        public static APIResponse GetSuccessResponse(dynamic data)
        {
            return new APIResponse(true, HttpStatusCode.OK, data, Message.OK);
        }

        public static APIResponse GetFailureResponse(dynamic data)
        {
            return new APIResponse(false, HttpStatusCode.NotAcceptable, data, Message.ERROR);
        }

        public static APIResponse GetUnAuthorizeResponse()
        {
            return new APIResponse(false, HttpStatusCode.Unauthorized, "Invalid username or password");
        }

        public static APIResponse GetUnAuthorizeResponse(dynamic data, string message)
        {
            return new APIResponse(true, HttpStatusCode.Unauthorized, data, message);
        }

        public static APIResponse GetUnprocessableResponse(dynamic data, string message)
        {
            return new APIResponse(true, HttpStatusCode.UnprocessableContent, data, message);
        }
    }
}
