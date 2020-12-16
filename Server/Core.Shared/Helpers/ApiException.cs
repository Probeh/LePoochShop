using System;
using System.Runtime.InteropServices;
using Core.Shared.Models.Enums;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Core.Shared.Helpers
{
    public class ApiException : Exception
    {
        public HttpCode Code { get; set; }
        // ======================================= //
        public ApiException() { }
        public ApiException(string message) : base(message) { }
        public ApiException(string message, Exception innerException) : base(message, innerException) { }
        public ApiException(HttpCode code, [Optional] string message) : base(message) { this.Code = code; }
        // ======================================= //
    }
    public class ModelStateException : ApiException
    {
        // ======================================= //
        public ModelStateException() { }
        public ModelStateException(string message) : base(message) { }
        public ModelStateException(string message, Exception innerException) : base(message, innerException) { }
        public ModelStateException(ModelStateDictionary modelState) { }
        // ======================================= //
    }
}