using Socket_Commons_Library;
using System;
using System.Collections.Generic;
using System.Text;

namespace CySocket
{
    public class DynamicRequest : IRequest
    {
        #region interface implemented methods

        //byte[] IRequest.RawPayload { get; set; }


        //public DynamicRequest()
        //{

        //}
        //public DynamicRequest(byte[] rawPayload)
        //{
        //    RawPayload = rawPayload;
        //}
        //public Payload<T> GetPayload<T>()
        //{
        //    throw new NotImplementedException();
        //}
        //#endregion

        //private DynamicRequest Parse(byte[] requestBytes)
        //{
        //    return this.Parse(Encoding.ASCII.GetString(requestBytes));
        //}
        //private DynamicRequest Parse(string requestString)
        //{
        //    Payload<dynamic> payload = new Payload<dynamic>();
        //    payload = payload.ToObject<dynamic>(requestString);
        //    return this;
        //}

        //public string ToString()
        //{
        //    return Payload<dynamic>.ToString();
        //}
        //public byte[] ToBytes()
        //{

        //}

        //T IRequest<T>.GetPayload()
        //{
        //    throw new NotImplementedException();
        //}
        #endregion
        public Payload<T> GetPayload<T>()
        {
            throw new NotImplementedException();
        }
    }
}
