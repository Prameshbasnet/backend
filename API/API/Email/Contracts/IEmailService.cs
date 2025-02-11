using API.Email.Dtos;
using Microsoft.AspNetCore.Mvc;
using Common.Common.Response;

namespace API.Email.Contracts
{
    public interface IEmailService
    {
        Task SendConfirmationEmail(string userName, string applicationType, string email);
    }
}
