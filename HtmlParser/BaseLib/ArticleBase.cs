using System;
using System.Collections.Generic;

namespace BaseLib
{
    /// <summary>
    /// Базовый класс для статьи, требует расширение под конкретный сайт
    /// Возможно динамическое подключение как плагина
    /// </summary>
    [Serializable]
    public abstract class ArticleBase
    {
//         Сначала не работал без создания mongoId, оставляю на случай потери работоспособности
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

        /// <summary>
        /// Метод для создания записи в базе данных.
        /// </summary>
        /// <returns> 
        /// Название поля с маленькой буквы - значение поля
        /// </returns>
        public abstract IDictionary<string, object> getFields();
    }
}
