using Bo.ToDoAppNTİer.Common.İnterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bo.ToDoAppNTİer.Common.ResponseObjects
{
    public class Response : IResponse
    {
        public Response(ResponseType responseType)
        {
                ResponseType = responseType;
        }
        public Response(ResponseType ResponseType,string message) : this(ResponseType) 
        {
            Message = message;
        }
        public string Message { get; set; }
        public ResponseType ResponseType { get; set; }
    }



    public enum ResponseType
    {
        Success,ValidationError,NotFound
    }
}
