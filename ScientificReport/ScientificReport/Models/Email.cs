﻿using Microsoft.AspNetCore.Http;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using MailKit.Net.Smtp;
using System.Threading.Tasks;

namespace ScientificReport.Models
{
    public class Email
    {
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();
            //Change Email Address
            emailMessage.From.Add(new MailboxAddress("ScintificReport - AUTOZVIT", "andri.yovbak@gmail.com"));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };
            
            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.gmail.com", 465, true);
                await client.AuthenticateAsync("andri.yovbak@gmail.com", "nfvmpioukmgsphpq");
                await client.SendAsync(emailMessage);               
                await client.DisconnectAsync(true);
            }
        }
    }
}
