using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Xunit;
using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.TestUtilities;

using LdLambdaNotify;

namespace LdLambdaNotify.Tests
{
    public class FunctionTest
    {
        [Fact]
        public void TestToUpperFunction()
        {

            // Invoke the lambda function and confirm the string was upper cased.
            var function = new Function();
            var context = new TestLambdaContext();
            // var upperCase = function.Handler(context);

            // Assert.Equal("HELLO WORLD", upperCase);
        }
    }
}
