using System;
using System.Collections.Generic;
using System.Text;

namespace SocketCommonsLibrary.Payload
{
    public class SimplePayload : BasePayload, IPayload
    {

        //public override string Data { get; set; }
        public SimplePayload(string data)
        {
            this.Data = data; 
        }
        public override BasePayload ToObject(string objectString)
        {
            try
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<BasePayload>(objectString);
            }
            catch (Exception ex)
            {
                //Throw exception so consuming application can handle errors 
                throw ex;
            }
        }
        public SimplePayload ToThisObject(string objectString)
        {
            try
            {
                return (SimplePayload)ToObject(objectString); //Newtonsoft.Json.JsonConvert.DeserializeObject<SimplePayload>(objectString);
            }
            catch (Exception ex)
            {
                //Throw exception so consuming application can handle errors 
                throw ex;
            }
        }

        public override string ToString()
        {
            try
            {
                //object cast might be redundant
                return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
            }
            catch (Exception ex)
            {
                //Throw exception so consuming application can handle errors 
                throw ex;
            }
        }
    }
}
