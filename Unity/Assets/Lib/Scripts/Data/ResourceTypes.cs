using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RenderHeads.UnityOmeka.Core
{
    /// <summary>
    /// Definition of currently supports resource types for api searching.
    /// </summary>
    public enum ResourceType
    {
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
        item_sets
        /*
    /// <summary>
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
    api_resources*/

    }
}