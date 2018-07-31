using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using CommonMark;

using Newtonsoft.Json.Linq;

using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace LdLambdaNotify
{
    public class Function
    {
        /// <summary>
        /// Main Lambda Handler
        /// </summary>
        /// <param name="apigProxyEvent"></param>
        /// <returns>APIGatewayResponse</returns>
        public APIGatewayProxyResponse Handler(APIGatewayProxyRequest apigProxyEvent)
        {
            dynamic json = JValue.Parse(apigProxyEvent.Body);
            string title = json.title;
            Console.WriteLine(title);

            string htmlBody = CommonMarkConverter.Convert(title);
            Mailer mail = new Mailer("New LD Change", title, htmlBody);
            mail.Send().Wait();
            
            return new APIGatewayProxyResponse
            {
                Body = title,
                StatusCode = 200,
            };

        }
    }
}
