using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace API_Projects.Classes.News
{
    [DataContract]
    public class Comments
    {
        [DataMember] public string text { get; set; }

        [DataMember] public string create_date { get; set; }

        [DataMember] public User user { get; set; }
    }
}
