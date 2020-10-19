using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RenderHeads.UnityOmeka.Data
{
    /// <summary>
    /// Class for mapping the JsonLD ID to .net ID.
    /// </summary>
    public class IdObject
    {
        /// <summary>
        /// Maps to @ID
        /// </summary>
        public string Link;

        public int Id;
        public static IdObject FromJObject(JObject jobject)
        {
            if (jobject == null)
            {
                return null;
            }
            IdObject idObject = new IdObject();

            idObject.Link = jobject["@id"].ToString();
            idObject.Id = int.Parse(jobject["o:id"].ToString());
            return idObject;
        }

        public static IdObject[] FromJArray(JArray array)
        {
            if (array == null)
            {
                return null;
            }
            IdObject[] idObjects = new IdObject[array.Count];
            int n = 0;
            foreach (var entry in array)
            {
                idObjects[n] = IdObject.FromJObject((JObject)entry);
                n++;
            }
            return idObjects;
        }
    }
}