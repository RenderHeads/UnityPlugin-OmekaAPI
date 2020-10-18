using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RenderHeads.UnityOmeka.Data
{
    public static class Helpers
    {
        public static T TryGet<T>(JObject root, string key, bool supressError=false) where T:JToken
        {
            JToken token;
            if (root.TryGetValue(key, out token))
            {
                //it is possible for a token to be found but its value to be null,
                if (IsNullOrEmpty(token))
                {
                    return null;
                }
                try
                {
                    T result = (T)token;
                    return result;
                }
                catch
                {
                    Debug.LogWarning($"[TryGetJobject] Found {key} in root object but could not cast value to JObject,  value is: {token}");
                    return null;
                }
            }
            else
            {
                if (!supressError)
                {
                    Debug.LogError($"[TryGetJobject] Could not find {key} in root object");
                }
                return null;
            }
        }

        public static DateTime? DateTimeFromJObject(JObject jobject)
        {
            if (jobject == null)
            {
                return null;
            }

            return DateTime.Parse(jobject["@value"].ToString());
        }

        //https://stackoverflow.com/questions/24066400/checking-for-empty-or-null-jtoken-in-a-jobject
        public static bool IsNullOrEmpty(JToken token)
        {
            return (token == null) ||
                   (token.Type == JTokenType.Array && !token.HasValues) ||
                   (token.Type == JTokenType.Object && !token.HasValues) ||
                   (token.Type == JTokenType.String && token.ToString() == String.Empty) ||
                   (token.Type == JTokenType.Null);
        }

    }
}