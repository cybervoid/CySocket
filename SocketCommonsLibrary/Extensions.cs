using System;
using System.Collections.Generic;
using System.Text;

namespace SocketCommonsLibrary
{
    public static class Extensions
    {
        public static dynamic ToDynamic(string serializedString)
        {
            if (string.IsNullOrEmpty(serializedString) == true)
                return null;
            return Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(serializedString);
        }
    }
}
