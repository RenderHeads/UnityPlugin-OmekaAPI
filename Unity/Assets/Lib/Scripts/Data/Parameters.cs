/// <summary>
/// This file contains definitions of search parameters for the api.
/// </summary>
using System;
namespace RenderHeads.UnityOmeka.Data
{
    [System.Serializable]
    public class ItemSearchParams : SearchParams
    {
        /// <summary>
        /// Get items assigned to this item set. The api technically supports an array, but this is left out for simplicity
        /// </summary>
        public int item_set_id = -1;
        /// <summary>
        /// site_id
        /// </summary>
        public int site_id = -1;
        /// <summary>
        /// site_attachments_only
        /// </summary>
        public bool? site_attachments_only = null;
    }
    [System.Serializable]
    public class MediaSearchParams : SearchParams
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
    [System.Serializable]
    public class ItemSetsSearchParams : SearchParams
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


    public class Parameters
    {
        [NonSerialized]
        public string key_identity = string.Empty;
        [NonSerialized]
        public string key_credential = string.Empty;
    }
    [System.Serializable]

    public class CommonParams : Parameters
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
    [System.Serializable]

    public class SearchParams : CommonParams
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
        public bool? is_public = null;
    }

    /*
     [System.Serializable]
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
     [System.Serializable]
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
     [System.Serializable]
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
     [System.Serializable]

     public class UserSearchParams:SearchParams
     {
         public string email = string.Empty;
         public string name = string.Empty;
         public string role = string.Empty;
         public bool? is_active = null;
         public int site_permission_site_id = -1;
     }*/
}