using System;
using System.Collections.Generic;
using Core.Shared.Models.Enums;

namespace Core.Shared.Helpers.Exceptions
{
    public class ApiException : Exception
    {
        // ======================================= //
        public DateTime Created { get; set; }
        public HttpCode ErrorCode { get; set; }
        public string Target { get; set; }
        public string Reason { get; set; }
        public string Method { get; set; }
        public string Summary { get; set; }
        public Dictionary<string, IConvertible> Parameters { get; set; }
        // ======================================= //
        public ApiException(HttpCode error, params KeyValuePair<string, IConvertible>[] parameters)
        {
            this.Created = DateTime.Now;
            this.ErrorCode = error;
            this.Method = base.TargetSite.Name;
            this.Target = base.TargetSite.DeclaringType.Name;
            this.Reason = base.Message;
            this.Parameters = new Dictionary<string, IConvertible>(parameters);
        }
    }
}