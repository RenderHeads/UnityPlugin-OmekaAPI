using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RenderHeads.UnityOmeka.Core;
namespace RenderHeads.UnityOmeka.Components
{

    public class OmekaClient : MonoBehaviour
    {

        private static IAPI _apiInstance;
        public static IAPI Instance
        {
            get
            {          
                return _apiInstance;
            }
        }
        [SerializeField] private ClientSettings _clientSettings;
        void Awake()
        {
            if (_clientSettings == null)
            {
                throw new System.Exception("[OmekaClient] Init failed, client settings is null");
            }
            if (_apiInstance == null)
            {
                IAPI api = new StandardApi();
                _apiInstance = api;
                api.SetRestEndPoint(_clientSettings.OmekaEndpoint);
                api.SetCredentials(_clientSettings.KeyIdentity, _clientSettings.KeyCredential);
            }
        } 
       
    }
}