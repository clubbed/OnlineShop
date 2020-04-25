using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Application.Response
{
    public class OkResponse<T> : IResponse where T : class
    {
        public OkResponse()
        {

        }

        public OkResponse(T data)
        {
            Data = data;
        }

        public T Data { get; }
    }
}
