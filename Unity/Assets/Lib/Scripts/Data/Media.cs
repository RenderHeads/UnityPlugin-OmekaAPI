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
    /// Definition of a Thumbnail URL object.
    /// </summary>
    [System.Serializable]
    public class ThumbnailUrl
    {
        public string Large;
        public string Medium;
        public string Square;
        public static ThumbnailUrl FromJObject(JObject jobject)
        {
            if (jobject == null)
            {
                return null;
            }

            ThumbnailUrl t = new ThumbnailUrl()
            {
              

            };
            t.Large = jobject["large"]?.ToString();
            t.Medium = jobject["medium"]?.ToString();
            t.Square = jobject["square"]?.ToString();

            return t;
        }
    }

    /// <summary>
    /// Definition of a Media object as returned by api/media
    /// </summary>
    /// <typeparam name="T">The type of vocabulary the media supports</typeparam>
    [System.Serializable]
    public class Media<T> where T : Vocabulary, new()
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
        public T Vocabulary;

        public IdObject Item;
        public string Ingester;
        public string Renderer;
        public string Source;
        public string MediaType;
        public string SHA256;
        public long? Size;
        public string Filename;
        public string OriginalUrl;
        public ThumbnailUrl ThumbnailUrl;




        public static Media<T> FromJObject(JObject jobject)
        {
            Media<T> media = new Media<T>();
            media.Id = IdObject.FromJObject(jobject);
            //the "@type" can come in as both a string and a string array, so we need to handle that
            var type = jobject["@type"].ToObject<object>();
            if (type.GetType() == typeof(string))
            {
                media.Type = new string[] { type.ToString() };
            }
            else
            {
                media.Type = jobject["@type"].ToObject<string[]>();
            }
            media.IsPublic = Helpers.TryGet<JToken>(jobject, "o:is_public")?.ToObject<bool?>();
            media.Owner = IdObject.FromJObject(Helpers.TryGet<JObject>(jobject, "o:owner"));
            media.ResourceClass = IdObject.FromJObject(Helpers.TryGet<JObject>(jobject, "o:resource_class"));
            media.ResourceTemplate = IdObject.FromJObject(Helpers.TryGet<JObject>(jobject, "o:resource_template"));
            media.Thumbnail = IdObject.FromJObject(Helpers.TryGet<JObject>(jobject, "o:thumbnail"));
            media.Title = Helpers.TryGet<JToken>(jobject, "o:title")?.ToString();
            media.Created = Helpers.DateTimeFromJObject(Helpers.TryGet<JObject>(jobject, "o:created"));
            media.Modified = Helpers.DateTimeFromJObject(Helpers.TryGet<JObject>(jobject, "o:modified"));
            media.Vocabulary = new T();
            media.Vocabulary.ApplyVocabulary(jobject);

            media.Item = IdObject.FromJObject(Helpers.TryGet<JObject>(jobject, "o:item"));
            media.Ingester = Helpers.TryGet<JToken>(jobject, "o:ingester")?.ToObject<string>();
            media.Renderer = Helpers.TryGet<JToken>(jobject, "o:renderer")?.ToObject<string>();
            media.Source = Helpers.TryGet<JToken>(jobject, "o:source")?.ToObject<string>();
            media.MediaType = Helpers.TryGet<JToken>(jobject, "o:media_type")?.ToObject<string>();
            media.SHA256 = Helpers.TryGet<JToken>(jobject, "o:sha256")?.ToObject<string>();
            media.Size = Helpers.TryGet<JToken>(jobject, "o:size")?.ToObject<long?>();
            media.Filename = Helpers.TryGet<JToken>(jobject, "o:filename")?.ToObject<string>();
            media.OriginalUrl = Helpers.TryGet<JToken>(jobject, "o:original_url")?.ToObject<string>();
            media.ThumbnailUrl = ThumbnailUrl.FromJObject(Helpers.TryGet<JObject>(jobject, "o:thumbnail_urls"));

            return media;
        }


    }


}