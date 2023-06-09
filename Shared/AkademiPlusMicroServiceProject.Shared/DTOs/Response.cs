﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AkademiPlusMicroServiceProject.Shared.DTOs
{
    public class Response<T>
    {
        public T Data { get; set; }
        [JsonIgnore]
        public int StatusCode { get; set; }
        [JsonIgnore]
        public bool IsSuccessful { get; set; }
        public List<string> Errors { get; set; }

        public static Response<T> Success(int statusCode)
        {
            return new Response<T> { StatusCode = statusCode, Data = default(T), IsSuccessful = true };
        }
        public static Response<T> Success(int statusCode, T data)
        {
            return new Response<T> { StatusCode = statusCode, Data = data, IsSuccessful = true };
        }
        public static Response<T> Fail(int statusCode, string error)
        {
            return new Response<T> { StatusCode = statusCode, Errors = new List<string> { error }, IsSuccessful = false };
        }
        public static Response<T> Fail(int statusCode, List<string> errors)
        {
            return new Response<T> { StatusCode = statusCode, Errors = errors, IsSuccessful = false };
        }
    }
}