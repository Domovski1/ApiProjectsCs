using System;
using System.Runtime.Serialization;


namespace API_Projects.Classes.Placeholder
{
    [DataContract]
    public class PostsClass
    {
        [DataMember] public string title { get; set; }
        [DataMember] public string body { get; set; }
        [DataMember] public string userId { get; set; }
        [DataMember] public string id { get; set; }


    }
} 
