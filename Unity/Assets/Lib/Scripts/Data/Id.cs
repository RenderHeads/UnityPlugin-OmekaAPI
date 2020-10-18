using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RenderHeads.UnityOmeka.Data
{
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
    }
}