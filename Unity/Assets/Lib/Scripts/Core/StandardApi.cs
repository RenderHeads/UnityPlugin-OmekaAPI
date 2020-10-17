using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using System.Reflection;
namespace RenderHeads.UnityOmeka.Core
{

    /// <summary>
    /// Allows for UnityWeb request to follow async / await pattern
    /// https://gist.github.com/mattyellen/d63f1f557d08f7254345bff77bfdc8b3
    /// </summary>
    public static class ExtensionMethods
    {
        public static TaskAwaiter GetAwaiter(this AsyncOperation asyncOp)
        {
            var tcs = new TaskCompletionSource<object>();
            asyncOp.completed += obj => { tcs.SetResult(null); };
            return ((Task)tcs.Task).GetAwaiter();
        }
    }
    public class StandardApi : IAPI
    {

        
        private string _id = string.Empty;
        private string _key = string.Empty;
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
        /// Using reflection we can tern our parameters into  a query string
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
    }
}