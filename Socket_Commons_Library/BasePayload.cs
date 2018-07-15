using System;
using System.Collections.Generic;
using System.Text;

namespace Socket_Commons_Library
{
    public abstract class BasePayload<T> : IPayload where T : IPayload
    {
        //public abstract string ToString();
        public abstract BasePayload<T> ToObject(string objectString);
        //{
        //    try
        //    {
        //        //object cast might be redundant
        //        return Newtonsoft.Json.JsonConvert.SerializeObject((object)responseT, Newtonsoft.Json.Formatting.Indented);
        //    }
        //    catch (Exception ex)
        //    {
        //        //Throw exception so consuming application can handle errors 
        //        throw ex;
        //    }
        //}

        //public abstract BasePayload ToObject(string objectString)
        //{
        //    try
        //    {
        //        return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(objectString);
        //    }
        //    catch (Exception ex)
        //    {
        //        //Throw exception so consuming application can handle errors 
        //        throw ex;
        //    }
        //}
    }
}
