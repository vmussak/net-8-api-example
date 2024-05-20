using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.Application
{
    public class DefaultResponse<T>
    {
        public DefaultResponse(IEnumerable<string> messages)
        {
            Messages = messages;
            Success = false;
            Data = default(T);
        }

        public DefaultResponse(string message)
        {
            Messages = new List<string> { message };
            Success = false;
            Data = default(T);
        }

        public DefaultResponse(T data)
        {
            Data = data;
            Success = true;
            Messages = null;
        }

        public bool Success { get; set; }
        public IEnumerable<string>? Messages { get; set; }
        public T? Data { get; set; }
    }
}
