using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWare.Cross_cutting.Common
{
    public class MessageResult<T>
    {
        public MessageResult(bool error, string responseMessage, List<T> items)
        {
            Items = items;
            ResponseMessage = responseMessage;
            Error = error;

        }

        public List<T> Items { get; set; } = null!;
        public string ResponseMessage { get; set; }

        public bool Error { get; set; }


    }
}
