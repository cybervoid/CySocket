using System;
using System.Collections.Generic;
using System.Text;

namespace Socket_Commons_Library
{
    public class Payload<T>
    {
        T data;

        public Payload()
        {

        }
        public Payload(T dataObject)
        {
            this.data = dataObject;
        }
        public string ToString(T responseT)
        {
            try
            {
                //object cast might be redundant
                return Newtonsoft.Json.JsonConvert.SerializeObject((object)responseT, Newtonsoft.Json.Formatting.Indented);
            }
            catch (Exception ex)
            {
                //Throw exception so consuming application can handle errors 
                throw ex;
            }
        }

        public T ToObject<T>(string objectString)
        {
            try
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(objectString);
            }
            catch (Exception ex)
            {
                //Throw exception so consuming application can handle errors 
                throw ex;
            }
        }
    }
}
