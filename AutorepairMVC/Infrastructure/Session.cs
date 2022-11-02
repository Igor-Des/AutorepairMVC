using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace lab4Controller.Infrastructure
{
    // Методы расширения для ISession для работы с произвольными объектами
    public static class Session
    {
        //Запись произвольного объекта  в сессию
        public static void SetList<T>(this ISession session, string key, IEnumerable<T> value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
        //Считывание произвольного объекта из сессии
        public static T Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
