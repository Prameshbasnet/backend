using API.Email.Contracts;
using API.Email.Dtos;
using Common.Common.Response;
using Microsoft.AspNetCore.Mvc;

namespace API.Email
{
    [Route("api/email")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;
        
    }
}
