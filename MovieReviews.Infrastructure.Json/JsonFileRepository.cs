using MovieReviewsCompulsory.Domain.IRepositories;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace MovieReviews.Infrastructure.JsonRepository
{
    public abstract class JsonFileRepository<T> : IRepository<T>
    {
        public T[] Items { get; private set; }

        private TextReader jsonReader;
        public JsonFileRepository(TextReader reader)
        {
            jsonReader = reader;
            Items = JsonConvert.DeserializeObject<T[]>(jsonReader.ReadToEnd());
            //Items = GetAllItems();
        }

        public T[] GetAllItems()
        {
            return Items ??= LoadAllItems();
        }

        private T[] LoadAllItems()
        {
            List<T> itemsList = new List<T>();
            using (JsonTextReader reader = new JsonTextReader(jsonReader))
            {
                JsonSerializer serializer = new JsonSerializer();
                while (reader.Read())
                {
                    if (reader.TokenType == JsonToken.StartObject)
                    {
                        T item = ReadOneItem(reader);
                        itemsList.Add(item);
                    }
                }
            }
            return itemsList.ToArray();
        }

        public abstract T ReadOneItem(JsonTextReader reader);
    }
}