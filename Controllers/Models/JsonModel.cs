using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrontendCore.Models
{
    public class JsonModel
    {
        public ReturnStatusEnum Status { get; set; }
        public string Message { get; set; }

        public string Data { get; set; }
    }

    public enum ReturnStatusEnum
    {
        Success,
        Fail
    }
}
