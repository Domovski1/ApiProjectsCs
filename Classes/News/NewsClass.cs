using System;
using System.Collections.Generic;
using System.Runtime.Serialization;


namespace API_Projects.Classes.News
{
    [DataContract]
    public class NewsClass
    {

        /// <summary>
        /// Название новости
        /// </summary>
        [DataMember]
        public string title { get; set; }

        /// <summary>
        /// Фотография новости
        /// </summary>
        [DataMember]
        public string image { get; set; }

        /// <summary>
        /// Дата создания новости
        /// </summary>
        [DataMember]
        public string create_date { get; set; }

        /// <summary>
        /// Количество комментариев
        /// </summary>
        [DataMember]
        public string comments_count { get; set; }

        /// <summary>
        /// ID новости
        /// </summary>
        [DataMember]
        public string id { get; set; }

    }
}
