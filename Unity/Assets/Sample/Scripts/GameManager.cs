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
namespace RenderHeads.UnityOmeka.Example
{
    public class GameManager : MonoBehaviour
    {

        [SerializeField] private Button ButtonPrefab = null;

        [SerializeField] private Transform _buttonRoot = null;

        [SerializeField] private OmekaClient _client = null;

        [SerializeField] private RawImage _mediaDisplay =null;

        private Texture2D _mediaDisplayTexture;


        void Start()
        {

        }

        public async void SearchItemSets()
        {
            var response = await _client.Api.SearchItemSets(new ItemSetsSearchParams());

            GenerateItemSetButtons(response);
        }

        private void GenerateItemSetButtons(ItemSetSearchResponse<DublicCoreVocabulary> response)
        {
            ClearChildren(_buttonRoot);

            for (int i=0; i< response.ItemSets.Count;i++)
            {
                Button b = GameObject.Instantiate<Button>(ButtonPrefab);
                b.GetComponentInChildren<Text>().text = response.ItemSets[i].Title;
                IdObject idObject = response.ItemSets[i].Id;
                b.onClick.AddListener(() => { SearchItemSet(idObject); });
                b.gameObject.transform.SetParent(_buttonRoot);
            }
        }

        private void GenerateItemButtons(ItemSearchResponse<DublicCoreVocabulary> response)
        {
            ClearChildren(_buttonRoot);

            for (int i = 0; i < response.Items.Count; i++)
            {
                Button b = GameObject.Instantiate<Button>(ButtonPrefab);
                b.GetComponentInChildren<Text>().text = response.Items[i].Title;
                IdObject idObject = response.Items[i].Id;
                b.onClick.AddListener(() => { SearchMedia(idObject); });
                b.gameObject.transform.SetParent(_buttonRoot);
            }
        }


        private void GenerateMediaButtons(MediaSearchResponse<DublicCoreVocabulary> response)
        {
            ClearChildren(_buttonRoot);

            for (int i = 0; i < response.Media.Count; i++)
            {
                Button b = GameObject.Instantiate<Button>(ButtonPrefab);
                b.GetComponentInChildren<Text>().text = response.Media[i].Title;
                string url  = response.Media[i].OriginalUrl;
                b.onClick.AddListener(() => { ShowMedia(url); });
                b.gameObject.transform.SetParent(_buttonRoot);
            }
        }

        private async void ShowMedia(string url)
        {
            var request = UnityWebRequestTexture.GetTexture(url);

            await request.SendWebRequest();

            if (!request.isNetworkError && !request.isHttpError)
            {
                if (_mediaDisplayTexture !=null)
                {
                    GameObject.Destroy(_mediaDisplayTexture);
                }
                _mediaDisplayTexture = DownloadHandlerTexture.GetContent(request);
                _mediaDisplay.texture = _mediaDisplayTexture;
                _mediaDisplay.SetNativeSize();
            }
        }

     

        public async void SearchItemSet(IdObject index)
        {
            var response = await _client.Api.SearchItems(new ItemSearchParams() { item_set_id = index.Id });
            GenerateItemButtons(response);
        }

        public async void SearchMedia(IdObject index)
        {
            var response = await _client.Api.SearchMedia(new MediaSearchParams() { item_id = index.Id });
            GenerateMediaButtons(response);
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
