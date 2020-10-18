using Newtonsoft.Json.Linq;
using RenderHeads.UnityOmeka.Data;
using RenderHeads.UnityOmeka.Data.Vocabularies;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;

namespace RenderHeads.UnityOmeka.Core.Interface
{
    /// <summary>
    /// Business logic interface for our API
    /// </summary>
    /// <typeparam name="T">A type of  Vocabulary (e.g. DublinCoreVocabulary)</typeparam>
    public interface IAPI<T> where T:Vocabulary,new()
    {

        /// <summary>
        /// Sets the rest endpoint to communicate with
        /// </summary>
        /// <param name="endpoint">The endpoint to communicate with</param>
        void SetRestEndPoint(string endpoint);
        /// <summary>
        /// Set the credentials for the API communication, if you need to access protected data
        /// </summary>
        /// <param name="id">The username</param>
        /// <param name="key">the api key associated with the user</param>
        void SetCredentials(string id, string key);

        /// <summary>
        /// Search the api for a given resource type
        /// </summary>
        /// <param name="resourceType">Supported resource types are item, item set and media</param>
        /// <param name="searchparams">The search paramters to filter the search (create an appropriate search param instance for your resource type)</param>
        /// <returns>A json object containing the data you need</returns>
        Task<SearchResponse> Search(ResourceType resourceType, SearchParams searchparams);

        /// <summary>
        /// Search the api for item sets
        /// </summary>
        /// <param name="searchparams">The search paramters to filter the search (create an appropriate search param instance for your resource type)</param>
        /// <returns>A json object containing the data you need</returns>
        Task<ItemSearchResponse<T>> SearchItems(ItemSearchParams searchparams) ;

        /// <summary>
        /// Search the api for item sets
        /// </summary>
        /// <param name="searchparams">The search paramters to filter the search (create an appropriate search param instance for your resource type)</param>
        /// <returns>A json object containing the data you need</returns>
        Task<ItemSetSearchResponse<T>> SearchItemSets(ItemSetsSearchParams searchparams);

        /// <summary>
        /// Search For Media
        /// </summary>
        /// <param name="searchparams">The media to search for</param>
        /// <returns>A json object containing the data you</returns>
        Task<MediaSearchResponse<T>> SearchMedia(MediaSearchParams searchparams);

    }
}