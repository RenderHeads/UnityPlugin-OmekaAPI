/// <summary>
/// Contains definitions of search responses for from api requests.
/// </summary>

using Newtonsoft.Json.Linq;
using RenderHeads.UnityOmeka.Data.Vocabularies;
using System.Collections.Generic;

namespace RenderHeads.UnityOmeka.Data
{
    [System.Serializable]
    public class SearchResponse
    {
        public JToken Message;
        public long ResponseCode;
        public string RequestURL;
    }

    [System.Serializable]
    public class ItemSetSearchResponse<T> where T : Vocabulary, new()
    {
        public List<ItemSet<T>> ItemSets;
        public long ResponseCode;
        public string RequestURL;
    }

    [System.Serializable]
    public class MediaSearchResponse<T> where T : Vocabulary, new()
    {
        public List<Media<T>> Media;
        public long ResponseCode;
        public string RequestURL;
    }

    [System.Serializable]
    public class ItemSearchResponse<T> where T : Vocabulary, new()
    {
        public List<Item<T>> Items;
        public long ResponseCode;
        public string RequestURL;
    }
}