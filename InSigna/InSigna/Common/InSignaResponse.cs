using InSigna.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InSigna.Common
{
    public class InSignaResponse
    {

        public InSignaResponse()
        {
            this.TypeOfResponse = TypeOfResponse.OK;
        }

        public InSignaResponse(TypeOfResponse typeOfResponse, string message = "")
        {
            this.TypeOfResponse = typeOfResponse;
            this.Message = message;
            this.Data = null;
        }


        public TypeOfResponse TypeOfResponse { get; set; }
        public string Message { get; set; } = string.Empty;
        public object? Data { get; set; }
    }
}
