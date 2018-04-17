﻿using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace UploadDownload.Classes
{
    public class CustomExceptionWebApiFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            var exceptionMessage =  actionExecutedContext.Exception.Message;
            //We can log this exception message to the file or database.
            var response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent(exceptionMessage),
                ReasonPhrase = actionExecutedContext.Exception.Message.Replace(Environment.NewLine, " ")
            };
            actionExecutedContext.Response = response;
        }
    }
}