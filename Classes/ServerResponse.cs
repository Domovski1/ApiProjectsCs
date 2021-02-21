using System;
using System.Collections.Generic;
using System.Runtime.Serialization;



namespace API_Projects.Classes
{
    [DataContract]
    public class ServerResponse <T>
    {
        [DataMember]
        public List<T> data { get; set; }

        [DataMember]
        public Boolean success { get; set; }

    }
}
