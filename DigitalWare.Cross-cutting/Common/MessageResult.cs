using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWare.Cross_cutting.Common
{
    public class MessageResult<T>
    {

        public MessageResult(bool error, List<T>? items = null, string? responseMessage = null)
        {
            ResponseMessage = responseMessage;
            Error = error;
            Items = items ?? new List<T>();
        }

        public List<T> Items { get; set; }
        public string? ResponseMessage { get; set; }

        public bool Error { get; set; }


    }
}
