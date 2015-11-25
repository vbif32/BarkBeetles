using System;
using System.Collections.Generic;

namespace BaseLib
{
    [Serializable]
    public abstract class ArticleBase
    {
//         [NonSerialized]
//         [BsonId]
//         protected ObjectId _mongoId;
// 
//         protected ArticleBase()
//         {
//             _mongoId = ObjectId.GenerateNewId();
//         }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Link { get; set; }
        public abstract IDictionary<string, object> getFields();
    }
}
