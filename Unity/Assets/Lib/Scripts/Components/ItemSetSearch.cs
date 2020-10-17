using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RenderHeads.UnityOmeka.Core;
using System.Threading.Tasks;

namespace RenderHeads.UnityOmeka.Components
{
    public class ItemSetSearch : MonoBehaviour
    {

        public ItemSearchParameters SearchParams;

        private SearchResponse _response;
        // Start is called before the first frame update
        async void Start()
        {
            await Run();
        }

        async Task Run()
        {
            if (OmekaClient.Instance == null)
            {
                throw new System.Exception("[ItemSetSearch] Omeka client not initialized yet.");
            }

           
        }


    }
}