using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace API_Projects.Classes.News
{
    [DataContract]
    public class User
    {
        [DataMember] public string login { get; set;}

        [DataMember] public string name { get; set; }

        [DataMember] public string image { get; set; }


    }
}
