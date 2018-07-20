using System;
using System.Collections.Generic;
using System.Text;

namespace SocketCommonsLibrary.Payload
{
    public class SimplePayload : BasePayload<IPayload>
    {

        public string Data { get; set; }
        public SimplePayload(string data)
        {
            this.Data = data; 
        }
        public override IPayload ToObject(string objectString)
        {
            try
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<IPayload>(objectString);
            }
            catch (Exception ex)
            {
                //Throw exception so consuming application can handle errors 
                throw ex;
            }
        
        }

        public override string ToString<IPayload>()
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
