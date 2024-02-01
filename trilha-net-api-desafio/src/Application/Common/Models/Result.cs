using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models
{
    public class Result<T>
    {
        public HttpStatusCode StatusCode { get; }

        public bool Sucess { get; }
        public string ErrorMessage { get; }
        public T Data { get; }

        public Result(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }

        private Result(bool success, string errorMessage, T data, HttpStatusCode statusCode)
        {
            Sucess = success;
            ErrorMessage = errorMessage;
            Data = data;
            StatusCode = statusCode;
        }


        public static Result<T> Success(T data)
        {

            return new Result<T>(true, string.Empty, data, HttpStatusCode.Created);
        }

        public static Result<T> Failure(string errorMessage)
        {
            return new Result<T>(false, errorMessage, default, HttpStatusCode.BadRequest);
        }
    }
}