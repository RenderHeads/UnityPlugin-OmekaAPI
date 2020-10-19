using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RenderHeads.UnityOmeka.Core;
using RenderHeads.UnityOmeka.Data.Vocabularies;
using RenderHeads.UnityOmeka.Core.Interface;
using RenderHeads.UnityOmeka.Core.Impl;

namespace RenderHeads.UnityOmeka.Components
{

    /// <summary>
    /// Main component that initializes our API
    /// </summary>
    public class OmekaClient : MonoBehaviour
    {
        /// <summary>
        /// Reference to our api business logic
        /// </summary>
        public IAPI<DublicCoreVocabulary> Api { get; private set; }

        /// <summary>
        /// Reference to client settings containing api endpoint and user details
        /// </summary>
        [SerializeField] private ClientSettings _clientSettings = null;
        void Awake()
        {
            if (_clientSettings == null)
            {
                throw new System.Exception("[OmekaClient] Init failed, client settings is null");
            }
            if (Api == null)
            {
                IAPI<DublicCoreVocabulary> api = new StandardApi<DublicCoreVocabulary>();
                Api = api;
                api.SetRestEndPoint(_clientSettings.OmekaEndpoint);
                api.SetCredentials(_clientSettings.KeyIdentity, _clientSettings.KeyCredential);
                Debug.Log("[OmekaClient] Successfully Initialized");
            }
        } 
       
    }
}