using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RenderHeads.UnityOmeka.Core
{

    /// <summary>
    /// Settings for our Omeka Client
    /// </summary>
    [CreateAssetMenu(fileName = "ClientSettings", menuName = "RenderHeads/Omeka/ClientSettings")]
    public class ClientSettings : ScriptableObject
    {
        /// <summary>
        /// API access token ID (username)
        /// </summary>
        public string KeyIdentity;

        /// <summary>
        /// API  access token KEY
        /// </summary>
        public string KeyCredential;

        /// <summary>
        /// The website hosting the Omeka S Rest API.
        /// Do not include the /api.
        /// Example http://my-domain.com
        /// </summary>
        public string OmekaEndpoint;
    }
}