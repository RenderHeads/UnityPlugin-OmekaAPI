using Newtonsoft.Json.Linq;
using RenderHeads.UnityOmeka.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;

namespace RenderHeads.UnityOmeka.Core
{


    public class SearchResponse
    {
        public JToken Message;
        public long ResponseCode;
        public string RequestURL;
    }

    public class ItemSetSearchResponse
    {
        public List<ItemSet> ItemSets;
        public long ResponseCode;
        public string RequestURL;
    }

    public class Parameters
    {
        [NonSerialized]
        public string key_identity = string.Empty;
        [NonSerialized]
        public string key_credential = string.Empty;
    }
    public class CommonParams:Parameters
    {
        /// <summary>
        /// Sort the result set by this field
        /// </summary>
        public string sort_by = "created";
        /// <summary>
        /// Sort the result set in this order, ascending ("asc") or descending ("desc")
        /// </summary>
        public string sort_order = "desc";
        /// <summary>
        /// The page number of the result set to return
        /// </summary>
        public int page = 1;
        /// <summary>
        /// The number of results per page
        /// </summary>
        public int per_page = 100;
        /// <summary>
        /// The number of results to return
        /// </summary>
        public int limit = 0;
        /// <summary>
        /// The number offset of results to return
        /// </summary>
        public int offset = 0;
    }

    public class SearchParams:CommonParams
    {
        /// <summary>
        /// Get RDF resources where there's a match in the fulltext index
        /// </summary>
        public string fulltext_search = "";
        /// <summary>
        /// Get RDF resources where there's an exact match in a value	
        /// </summary>
        public string search = "";
        /// <summary>
        /// Get the RDF resource that has this unique identifier
        /// </summary>
        public int id = -1;
        /// <summary>
        /// Get RDF resources that belong to this owner
        /// </summary>
        public int owner_id = -1;
        /// <summary>
        /// Get RDF resources with a class that has this unique label
        /// </summary>
        public string resource_class_label = string.Empty;
        /// <summary>
        /// Get RDF resources with a class that has this unique identifier
        /// </summary>
        public string resource_class_id = string.Empty;
        /// <summary>
        /// Get RDF resources with a template that has this unique identifier	
        /// </summary>
        public string resource_template_id = string.Empty;
        /// <summary>
        /// Get RDF resources that are public OR private
        /// </summary>
        public bool? is_public =null;
    }

    public class ItemSearchParameters:SearchParams
     {
        /// <summary>
         /// Get items assigned to this item set. The api technically supports an array, but this is left out for simplicity
         /// </summary>
        public int item_set_id =-1;
        /// <summary>
        /// site_id
        /// </summary>
        public int site_id = -1;
        /// <summary>
        /// site_attachments_only
        /// </summary>
        public bool? site_attachments_only = null;
    }

    public class MediaSearchParams:SearchParams
    {
        /// <summary>
        /// Get media assigned to this item
        /// </summary>
        public int item_id = -1;
        /// <summary>
        /// Get media of this media type
        /// </summary>
        public string media_type = string.Empty;
        /// <summary>
        /// Get media in this site's item pool AND are attached to a block
        /// </summary>
        public int site_id = -1;
    }

    public  class ItemSetsSearchParams:SearchParams
    {
        /// <summary>
        /// Get item sets that are open or closed	
        /// </summary>
        public bool? is_open = null;

        /// <summary>
        /// Get item sets in this site's item set pool
        /// </summary>
        public int site_id = -1;
    }

    public class VocabulariesSearchParams:SearchParams
    {
        /// <summary>
        /// Get a vocabulary that has this unique namespace URI (e.g. "http://purl.org/dc/terms/")
        /// </summary>
        public string namespace_uri = string.Empty;

        /// <summary>
        /// Get a vocabulary that has this unique namespace prefix (e.g. "dcterms")
        /// </summary>
        public string prefix = string.Empty;

    }

    public class ResourceClassSearchParams :SearchParams
    {
        /// <summary>
        /// Get classes that belong to a vocabulary that has this unique identifier
        /// </summary>
        public int vocabulary_id = -1;

        /// <summary>
        /// Get classes that belong to a vocabulary that has this unique namespace URI (e.g. "http://purl.org/dc/dcmitype/")
        /// </summary>
        public string vocabulary_namespace_uri = string.Empty;

        /// <summary>
        /// Get classes that belong to a vocabulary that has this unique namespace prefix (e.g. "dcmitype")
        /// </summary>
        public string vocabulary_prefix = string.Empty;

        /// <summary>
        /// Get classes with this local name (e.g. "Image")
        /// </summary>
        public string local_name = string.Empty;

        /// <summary>
        /// Get a class with this unique term (e.g. "dcmitype:Image")	string
        /// </summary>
        public string term = string.Empty;

    }

    public class PropertiesSearchParams:SearchParams
    {
        /// <summary>
        /// Get classes that belong to a vocabulary that has this unique identifier
        /// </summary>
        public int vocabulary_id = -1;

        /// <summary>
        /// Get classes that belong to a vocabulary that has this unique namespace URI (e.g. "http://purl.org/dc/dcmitype/")
        /// </summary>
        public string vocabulary_namespace_uri = string.Empty;

        /// <summary>
        /// Get classes that belong to a vocabulary that has this unique namespace prefix (e.g. "dcmitype")
        /// </summary>
        public string vocabulary_prefix = string.Empty;

        /// <summary>
        /// Get classes with this local name (e.g. "Image")
        /// </summary>
        public string local_name = string.Empty;

        /// <summary>
        /// Get a class with this unique term (e.g. "dcmitype:Image")	string
        /// </summary>
        public string term = string.Empty;

    }

    public class UserSearchParams:SearchParams
    {
        public string email = string.Empty;
        public string name = string.Empty;
        public string role = string.Empty;
        public bool? is_active = null;
        public int site_permission_site_id = -1;
    }
    public enum ResourceType
    {/// <summary>
     /// Users who have login credentials
     /// </summary>
        users,
        /// <summary>
        /// RDF vocabularies imported into Omeka
        /// </summary>
        vocabularies,
        /// <summary>
        /// RDF classes that belong to vocabularies
        /// </summary>
        resource_classes,
        /// <summary>
        /// RDF properties that belong to vocabularies
        /// </summary>
        properties,
        /// <summary>
        /// Item RDF resources, the building blocks of Omeka
        /// </summary>
        items,
        /// <summary>
        /// Media RDF resources that belong to items
        /// </summary>
        media,
        /// <summary>
        /// Item set RDF resources, inclusive set of items
        /// </summary>
        item_sets,
        /// <summary>
        /// Templates that define how to describe RDF resources
        /// </summary>
        resource_templates,
        /// <summary>
        /// Omeka sites, the public components of Omeka
        /// </summary>
        sites,
        /// <summary>
        /// Pages within sites
        /// </summary>
        site_pages,
        /// <summary>
        /// Modules that extend Omeka fuctionality (search and read access only)
        /// </summary>
        modules,
        /// <summary>
        ///API resources available on this install (search and read access only) 
        /// </summary>
        api_resources

    }
    public interface IAPI
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
        /// <param name="resourceType">The search paramters to filter the search (create an appropriate search param instance for your resource type)</param>
        /// <returns>A json object containing the data you need</returns>
        Task<SearchResponse> Search(ResourceType resourceType, SearchParams searchparams);


        /// <summary>
        /// Search the api for a given resource type
        /// </summary>
        /// <param name="resourceType">Supported resource types are item, item set and media</param>
        /// <param name="resourceType">The search paramters to filter the search (create an appropriate search param instance for your resource type)</param>
        /// <returns>A json object containing the data you need</returns>
        Task<ItemSetSearchResponse> SearchItemSets(ItemSetsSearchParams searchparams);

    }
}