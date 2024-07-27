using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Clinc.ReponseModel
{
    public class ResponseModel
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        //public int TotalCount { get; set; }

        public object Data { get; set; }
        public ResponseModel()
        {
            this.IsSuccess = false;
            Message = "Something wrong !";
        }
        public ResponseModel(string message, bool isSuccess =false,object Data = null)
        {
            this.IsSuccess = isSuccess;
            this.Data = Data;
            if (message is null)
            {
                this.Message = isSuccess ? "Successfully Done" : "Un Successfully";
            }
            else { this.Message = message; }
        }
    }
}
