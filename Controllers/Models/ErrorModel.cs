using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrontendCore.Models
{
    public  class ErrorModel
    {
        public string Title { get; set; }

        public string Message { get; set; }

        public string Type { get; set; }

        public string Target { get; set; }
    }
}
