using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesAmerica.Application.Base
{
    public class ApiResponseStatus
    {
        public static int OK => 200;
        public static int BAD_REQUEST => 400;
        public static int ERROR => 500;
    }

    public class ApiResponse<T>
    {
        public int Status { get; private set; }
        public string Message { get; private set; }
        public T? Data { get; private set; }

        public ApiResponse(string message, T? data)
        {
            Status = ApiResponseStatus.OK;
            Message = message;
            Data = data;
        }

        public ApiResponse(int status, string message, T data)
        {
            Status = status;
            Message = message;
            Data = data;
        }

        public ApiResponse(string message)
        {
            Status = ApiResponseStatus.ERROR;
            Message = message;
            Data = default;
        }
    }

    public class ApiResponse
    {
        public int Status { get; private set; }
        public string Message { get; private set; }
        public object? Data { get; private set; }

        public ApiResponse(string message, object? data)
        {
            Status = ApiResponseStatus.OK;
            Message = message;
            Data = data;
        }

        public ApiResponse(int status, string message, object data)
        {
            Status = status;
            Message = message;
            Data = data;
        }

        public ApiResponse(string message)
        {
            Status = ApiResponseStatus.ERROR;
            Message = message;
            Data = default;
        }
    }
}
