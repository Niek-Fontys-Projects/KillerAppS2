using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLayer
{
    public static class LogicLayer
    {
        public static void LogicLayerConfig(this IConfiguration configuration)
        {
            Factory.SMTPClient = configuration["LogicLayer:MailSettings:Client"];
            Factory.FromAddress = configuration["LogicLayer:MailSettings:FromMail"];
        }
    }
}
