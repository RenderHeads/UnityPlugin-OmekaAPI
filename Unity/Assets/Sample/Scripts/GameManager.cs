using RenderHeads.UnityOmeka.Components;
using RenderHeads.UnityOmeka.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RenderHeads.UnityOmeka.Example
{
    public class GameManager : MonoBehaviour
    {
        private IAPI _api;
       async void Start()
        {
            _api = OmekaClient.Instance;

            var result = await _api.Search(ResourceType.media, new MediaSearchParams() { item_id = 6 });
            Debug.Log(result.ResponseCode);
        }

      

        
    }
}