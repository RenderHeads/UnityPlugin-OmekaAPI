using RenderHeads.UnityOmeka.Components;
using RenderHeads.UnityOmeka.Core;
using RenderHeads.UnityOmeka.Data;
using RenderHeads.UnityOmeka.Data.Vocabularies;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using RenderHeads.UnityOmeka.Core.Extensions;
using UnityEngine.Events;

namespace RenderHeads.UnityOmeka.Example
{
    /// <summary>
    /// An example script that lets us drill down from an item_set and display a piece of media
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        /// <summary>
        /// Reference to our UI search button, so we can attach callback
        /// </summary>
        [SerializeField] private Button _searchButton = null;

        /// <summary>
        /// Reference to button that is instaniated after the API returns its response
        /// </summary>
        [SerializeField] private Button _buttonPrefab = null;

        /// <summary>
        /// Our instantiate buttons are parented here
        /// </summary>
        [SerializeField] private Transform _buttonRoot = null;

        /// <summary>
        /// Reference to the API client
        /// </summary>
        [SerializeField] private OmekaClient _client = null;

        /// <summary>
        /// Reference to a UI element to display our media after its downloaded
        /// </summary>
        [SerializeField] private RawImage _mediaDisplay = null;

        /// <summary>
        /// Texture reference that will store our media after its downloaded
        /// </summary>
        private Texture2D _mediaDisplayTexture;


        private void Start()
        {
            //attach our callback to our button
            _searchButton.onClick.AddListener(SearchItemSets);
        }

        /// <summary>
        /// Callback that searchs for item sets
        /// </summary>
        public async void SearchItemSets()
        {
            var response = await _client.Api.SearchItemSets(new ItemSetsSearchParams());
            GenerateItemSetButtons(response);
        }


        /// <summary>
        /// Search a specific item set and returns all its items
        /// </summary>
        /// <param name="index">The ID of the item set to search</param>
        public async void SearchItemSet(IdObject index)
        {
            var response = await _client.Api.SearchItems(new ItemSearchParams() { item_set_id = index.Id });
            GenerateItemButtons(response);
        }

        /// <summary>
        /// Searched an Item for for media
        /// </summary>
        /// <param name="index">The ID of the item to search</param>
        public async void SearchMedia(IdObject index)
        {
            var response = await _client.Api.SearchMedia(new MediaSearchParams() { item_id = index.Id });
            GenerateMediaButtons(response);
        }
        /// <summary>
        /// Downloads a specific piece of media from a URL and displays it
        /// </summary>
        /// <param name="url">The path to the file</param>
        private async void ShowMedia(string url)
        {
            var request = UnityWebRequestTexture.GetTexture(url);

            await request.SendWebRequest();

            if (!request.isNetworkError && !request.isHttpError)
            {
                if (_mediaDisplayTexture != null)
                {
                    GameObject.Destroy(_mediaDisplayTexture);
                }
                _mediaDisplayTexture = DownloadHandlerTexture.GetContent(request);
                _mediaDisplay.texture = _mediaDisplayTexture;
                _mediaDisplay.SetNativeSize();
            }
        }


        private void GenerateItemSetButtons(ItemSetSearchResponse<DublicCoreVocabulary> response)
        {
            ClearChildren(_buttonRoot);
            for (int i = 0; i < response.ItemSets.Count; i++)
            {
                IdObject idObject = response.ItemSets[i].Id;
                GenerateButton(response.ItemSets[i].Title, () => { SearchItemSet(idObject); });
            }
        }
        private void GenerateItemButtons(ItemSearchResponse<DublicCoreVocabulary> response)
        {
            ClearChildren(_buttonRoot);
            for (int i = 0; i < response.Items.Count; i++)
            {
                IdObject idObject = response.Items[i].Id;
                GenerateButton(response.Items[i].Title, () => { SearchMedia(idObject); });
            }
        }

        private void GenerateMediaButtons(MediaSearchResponse<DublicCoreVocabulary> response)
        {
            ClearChildren(_buttonRoot);
            for (int i = 0; i < response.Media.Count; i++)
            {
                int n = i;
                GenerateButton(response.Media[n].Title, () => { ShowMedia(response.Media[n].OriginalUrl); });
            }
        }

        private Button GenerateButton(string buttonName, UnityAction callback)
        {
            Button b = GameObject.Instantiate<Button>(_buttonPrefab);
            b.GetComponentInChildren<Text>().text = buttonName;
            b.onClick.AddListener(callback);

            b.gameObject.transform.SetParent(_buttonRoot);

            return b;

        }
        private void ClearChildren(Transform T)
        {
            for (int i = 0; i < T.childCount; i++)
            {
                GameObject.Destroy(T.GetChild(i).gameObject);
            }
        }
    }
}
