using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using System.Reflection;
using RenderHeads.UnityOmeka.Data;
using RenderHeads.UnityOmeka.Data.Vocabularies;
using RenderHeads.UnityOmeka.Core.Interface;
using RenderHeads.UnityOmeka.Core.Extensions;
namespace RenderHeads.UnityOmeka.Core.Impl
{

    /// <summary>
    /// Implementation of the Omkey Client API
    /// </summary>
    /// <typeparam name="T">The type of vocabulary to use, so the api known what vocabulary to deserialize</typeparam>
    public class StandardApi<T> : IAPI<T> where T:Vocabulary,new()
    {
        /// <summary>
        /// Stores the api username / key
        /// </summary>
        private string _id = string.Empty;

        /// <summary>
        /// stores api password
        /// </summary>
        private string _key = string.Empty;

        /// <summary>
        ///  The endpoint to our API
        /// </summary>
        private Uri _endpoint = null;
        public async Task<SearchResponse> Search(ResourceType resourceType, SearchParams searchParams)
        {
            searchParams.key_credential = _key;
            searchParams.key_identity = _id;
            string queryString = GenerateParameters(searchParams);
            var request = UnityWebRequest.Get($"{_endpoint.ToString()}/{resourceType.ToString()}{queryString}");
            await request.SendWebRequest();
            SearchResponse r = new SearchResponse();
            r.ResponseCode = request.responseCode;
            r.RequestURL = request.url;
            if (r.ResponseCode == 200)
            {
                string message = request.downloadHandler.text;
                r.Message = JToken.Parse(message);
            }

            return r;
        }

        /// <summary>
        /// Using reflection we can turn our parameters into  a query string
        /// </summary>
        /// <param name="parameters">The parameters related to the query you want to filter by</param>
        /// <returns>A query string</returns>
        private string GenerateParameters(Parameters parameters)
        {
            FieldInfo[] fields = parameters.GetType().GetFields();
            string queryString = "?";
            foreach (var field in fields)
            {

                if (field.FieldType == typeof(string))
                {
                    string value =(string) field.GetValue(parameters);
                    if (!string.IsNullOrEmpty(value))
                    {
                        queryString += $"{field.Name}={UnityWebRequest.EscapeURL(value)}&";
                    }
                }

                if (field.FieldType == typeof(int))
                {
                    int value = (int)field.GetValue(parameters);
                    if (value >=0)
                    {
                        queryString += $"{field.Name}={value}&";
                    }
                }

                if (field.FieldType == typeof(bool?))
                {
                    bool? value = (bool?)field.GetValue(parameters);
                    if (value!=null)
                    {
                        queryString += $"{field.Name}={value}&";
                    }
                }
            }

            return queryString;
        }

        public void SetCredentials(string id, string key)
        {
            _id = id;
            _key = key;
        }

        public void SetRestEndPoint(string endpoint)
        {
            _endpoint = new Uri(new Uri(endpoint), "api"); ;
        }

        public async Task<ItemSetSearchResponse<T>> SearchItemSets(ItemSetsSearchParams searchparams)
        {
            var result = await Search(ResourceType.item_sets, searchparams);
            var response  = new ItemSetSearchResponse<T>() { ResponseCode = result.ResponseCode, RequestURL = result.RequestURL }; 
            if (result.ResponseCode == 200)
            {
                JArray array = (JArray)result.Message;
                List<ItemSet<T>> itemSets = new List<ItemSet<T>>();
                foreach (var  entry in array)
                {
                    ItemSet<T> r = ItemSet<T>.FromJObject((JObject)entry);
                    itemSets.Add(r);
                }

                response.ItemSets = itemSets;
            }
                return response;
        }

        public async Task<ItemSearchResponse<T>> SearchItems(ItemSearchParams searchparams)
        {
            var result = await Search(ResourceType.items, searchparams);
            var response = new ItemSearchResponse<T>() { ResponseCode = result.ResponseCode, RequestURL = result.RequestURL };
            if (result.ResponseCode == 200)
            {
                JArray array = (JArray)result.Message;
                List<Item<T>> itemSets = new List<Item<T>>();
                foreach (var entry in array)
                {
                    Item<T> r = Item<T>.FromJObject((JObject)entry);
                    itemSets.Add(r);
                }

                response.Items = itemSets;
            }
            return response;
        }

        public async Task<MediaSearchResponse<T>> SearchMedia(MediaSearchParams searchparams)
        {
            var result = await Search(ResourceType.media, searchparams);
            var response = new MediaSearchResponse<T>() { ResponseCode = result.ResponseCode, RequestURL = result.RequestURL };
            if (result.ResponseCode == 200)
            {
                JArray array = (JArray)result.Message;
                List<Media<T>> itemSets = new List<Media<T>>();
                foreach (var entry in array)
                {
                    Media<T> r = Media<T>.FromJObject((JObject)entry);
                    itemSets.Add(r);
                }

                response.Media = itemSets;
            }
            return response;
        }
    }
}
