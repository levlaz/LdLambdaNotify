# LdLambdaNotify
Process LaunchDarkly webhooks with AWS Lambda

## Overview

This project allows you to process webhooks from LaunchDarkly using AWS Lambda.
It uses the following AWS products:

* [AWS API Gateway](https://aws.amazon.com/api-gateway/) -- this serves as 
the endpoint that webhooks in LaunchDarkly will get sent to. In addition 
this serves as the trigger for the Lambda function.
* [AWS Lambda](https://aws.amazon.com/lambda/) -- this is where the code in 
this repository runs. The Lambda function processes the incoming webhook and 
uses the AWS SDK to send an email. 
* [AWS SES](https://aws.amazon.com/ses/) -- this is used for sending email.

