using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace API_Projects.Classes.Competition
{
    [DataContract]
    public class CompetitionClass
    {
        [DataMember] public string title { get; set; } 

        [DataMember] public string description { get; set; }

        [DataMember] public string image { get; set; }

    }
}
