using Newtonsoft.Json.Linq;
using RenderHeads.UnityOmeka.Data.Vocabularies;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RenderHeads.UnityOmeka.Data
{

    [System.Serializable]
    public class ItemSet<T> where T : Vocabulary, new()
    {
        public IdObject Id;
        public string[] Type;
        public bool? IsPublic;
        public IdObject Owner;
        public IdObject ResourceClass;
        public IdObject ResourceTemplate;
        public IdObject Thumbnail;
        public string Title;
        public DateTime? Created;
        public DateTime? Modified;
        public bool? IsOpen;
        public T Vocabulary;

        public static ItemSet<T> FromJObject(JObject jobject)
        {
            ItemSet<T> item = new ItemSet<T>();
            item.Id = IdObject.FromJObject(jobject);
            item.Type = jobject["@type"].ToObject<string[]>();          
            item.IsPublic = Helpers.TryGet<JObject>(jobject,"o:is_public")?.ToObject<bool?>();
            item.Owner = IdObject.FromJObject(Helpers.TryGet<JObject>(jobject,"o:owner"));
            item.ResourceClass = IdObject.FromJObject(Helpers.TryGet<JObject>(jobject, "o:resource_class"));
            item.ResourceTemplate = IdObject.FromJObject(Helpers.TryGet<JObject>(jobject, "o:resource_template"));
            item.Thumbnail = IdObject.FromJObject(Helpers.TryGet<JObject>(jobject, "o:thumbnail"));
            item.Title = Helpers.TryGet<JObject>(jobject, "o:title")?.ToString();
            item.Created = Helpers.DateTimeFromJObject(Helpers.TryGet<JObject>(jobject, "o:created"));
            item.Modified = Helpers.DateTimeFromJObject(Helpers.TryGet<JObject>(jobject, "o:modified"));
            item.IsOpen = Helpers.TryGet<JObject>(jobject, "o:is_open")?.ToObject<bool?>();
            item.Vocabulary = new T();
            item.Vocabulary.ApplyVocabulary(jobject);
            return item;
        }

      
    }


}