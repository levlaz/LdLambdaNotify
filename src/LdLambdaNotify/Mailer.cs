using System;
using Amazon;

using System.Net;
using System.Collections.Generic;
using System.Threading.Tasks;

using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;

namespace LdLambdaNotify
{
    class Mailer
    {
        //static readonly string senderAddress = Environment.GetEnvironmentVariable("LD_EMAIL_SENDER");
        static readonly string senderAddress = "lev@levlaz.org";
        //static readonly string receiverAddress = Environment.GetEnvironmentVariable("LD_EMAIL_RECEIVER");
        static readonly string receiverAddress = "lev@levlaz.org";
        static readonly string configSet = "LdLambdaNotify";
        private string subject, textBody, htmlBody;

        public Mailer (string subject, string textBody, string htmlBody)
        {
            this.subject = subject;
            this.textBody = textBody;
            this.htmlBody = htmlBody;
        }
        
        public async Task<bool> Send()
        {
            using (var client = new AmazonSimpleEmailServiceClient(RegionEndpoint.USWest2))
            {
                var sendRequest = new SendEmailRequest
                {
                    Source = senderAddress,
                    Destination = new Destination
                    {
                        ToAddresses = 
                        new List<string> { receiverAddress }
                    },
                    Message = new Message
                    {
                        Subject = new Content(subject),
                        Body = new Body
                        {
                            Html = new Content
                            {
                                Charset = "UTF-8",
                                Data = htmlBody
                            },
                            Text = new Content
                            {
                                Charset = "UTF-8",
                                Data = textBody
                            }
                        }
                    },
                    ConfigurationSetName = configSet
                };
                try
                {
                    Console.WriteLine("Sending email using Amazon SES...");
                    var response = await client.SendEmailAsync(sendRequest);
                    Console.WriteLine("Email was sent.");
                    return response.HttpStatusCode == HttpStatusCode.OK;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Email was not sent.");
                    Console.WriteLine("Error message: " + ex.Message);
                    return false;
                }
            }
        }
    }
}