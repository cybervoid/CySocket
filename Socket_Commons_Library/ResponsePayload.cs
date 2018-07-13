using System;
using System.Collections.Generic;
using System.Text;

namespace Socket_Commons_Library
{
    public class ResponsePayload<T> 
    {
        T Response;
        public ResponsePayload(T response)
        {
            this.Response = response;
        }
        public string GetResponse<T>(T responseT)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(responseT, Newtonsoft.Json.Formatting.Indented);
        }

        public T ToResponse<T>(string responseString)
        {
            try
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(responseString);
            }
            catch(Exception ex)
            {
                //Throw exception so client or server can handle
                throw ex;
            }
        }
    }
    /// <summary>
    /// As dynamic data type
    /// </summary>
    public class ResponsePayload
    {

    }
}
