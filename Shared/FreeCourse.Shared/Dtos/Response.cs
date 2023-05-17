using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FreeCourse.Shared.Dtos
{
    public class Response<T>
    {
        public T Data { get; private set; }
        public Error Error { get; set; }
        public int StatusCode { get; private set; }
        [JsonIgnore]
        public bool IsSuccessful { get; private set; }
        public static Response<T> Succes(T data, int statusCode)
        {
            return new Response<T> { Data = data, StatusCode = statusCode, IsSuccessful = true };
        }
        public static Response<T> Succes(int statusCode)
        {
            return new Response<T> { StatusCode = statusCode, IsSuccessful = true };
        }

        public static Response<T> Fail(Error errorDto, int statusCode)
        {
            return new Response<T> { Error = errorDto, StatusCode = statusCode, IsSuccessful = false };
        }

        public static Response<T> Fail(string error, int statusCode, bool isShow)
        {
            var errorDto = new Error(error, isShow);
            return new Response<T> { Error = errorDto, StatusCode = statusCode, IsSuccessful = false };
        }

    }
}
