using Newtonsoft.Json.Linq;
using RenderHeads.UnityOmeka.Data.Vocabularies;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RenderHeads.UnityOmeka.Data
{
    /// <summary>
    /// Definition of an item object, as returned by the  api/items endpoint
    /// </summary>
    /// <typeparam name="T">The vocabulary the Item has</typeparam>
    [System.Serializable]
    public class Item<T> where T : Vocabulary, new()
    {
        public IdObject Id;
        public string[] Type;
        public bool? IsPublic;
        public IdObject Owner;
        public IdObject ResourceClass;
        public IdObject ResourceTemplate;
        public IdObject Thumbnail;
        public IdObject[] Media;
        public IdObject[] ItemSet;
        public string Title;
        public DateTime? Created;
        public DateTime? Modified;
        public T Vocabulary;
        public static Item<T> FromJObject(JObject jobject)
        {
            Item<T> item = new Item<T>();
            item.Id = IdObject.FromJObject(jobject);
            //the "@type" can come in as both a string and a string array, so we need to handle that
            var type = jobject["@type"].ToObject<object>();
            if (type.GetType() == typeof(string))
            {
                item.Type = new string[] { type.ToString() };
            }
            else
            {
                item.Type = jobject["@type"].ToObject<string[]>();
            }
            item.IsPublic = Helpers.TryGet<JToken>(jobject, "o:is_public")?.ToObject<bool?>();
            item.Owner = IdObject.FromJObject(Helpers.TryGet<JObject>(jobject, "o:owner"));
            item.ResourceClass = IdObject.FromJObject(Helpers.TryGet<JObject>(jobject, "o:resource_class"));
            item.ResourceTemplate = IdObject.FromJObject(Helpers.TryGet<JObject>(jobject, "o:resource_template"));
            item.Thumbnail = IdObject.FromJObject(Helpers.TryGet<JObject>(jobject, "o:thumbnail"));
            item.Title = Helpers.TryGet<JToken>(jobject, "o:title")?.ToString();
            item.Created = Helpers.DateTimeFromJObject(Helpers.TryGet<JObject>(jobject, "o:created"));
            item.Modified = Helpers.DateTimeFromJObject(Helpers.TryGet<JObject>(jobject, "o:modified"));
            item.Media = IdObject.FromJArray(Helpers.TryGet<JArray>(jobject, "o:media"));
            item.ItemSet = IdObject.FromJArray(Helpers.TryGet<JArray>(jobject, "o:item_set"));
            item.Vocabulary = new T();
            item.Vocabulary.ApplyVocabulary(jobject);
            return item;
        }
    }
}