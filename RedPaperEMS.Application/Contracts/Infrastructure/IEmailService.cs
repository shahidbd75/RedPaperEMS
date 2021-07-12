using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RedPaperEMS.Application.Models.Mail;

namespace RedPaperEMS.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendMail(Email email);
    }
}
