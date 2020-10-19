<div align="center">
    <img src="http://renderheads.com/wp-content/themes/renderheads-theme/assets/media/logo.svg">
</div>
<p align="center">
  © <a href="http://www.renderheads.com">RenderHeads </a> 2020
</p>
<p align ="center"> Author / Maintainer: <a href="https://www.shanemarks.co.za">Shane Marks</a> </p>


# Omeka S API support for Unity3D

This repository contains an implementation of the Omeka API for Unity3D to retrieve content from an Omeka System and use it within unity.

## What is [Omeka](https://github.com/omeka/omeka-s)?
Omeka S is a web publication system for universities, galleries, libraries, archives, and museums. It consists of a local network of independently curated exhibits sharing a collaboratively built pool of items, media, and their metadata.

## Current Functionality
Read-only support. Currently, no plans for adding write support (maybe in the future if there is a demand for it).

Api search of *Item Sets, Items and Media*. I felt this subset of features gives the most coverage for typical usage in Unity.

Dublin Core Vocabulary. The API client is designed in such a way that you can extend support for other vocabularies easily.

## Dependencies
The implementation relies on [NewtonSoft Json.Net]() for deserialization of the Json-LD information returned from the API. We have included a vanilla build of the library, however there is a Unity specific version available on the [unity asset store](https://assetstore.unity.com/packages/tools/input-management/json-net-for-unity-11347) that you should use in your production project.

## Requirements
Unity 2018 LTS or greater

## Project Structure
Within the Unity project you will find the following folders:

[**Lib**](https://github.com/RenderHeads/lib-unity-omeka/tree/main/Unity/Assets/Lib): Contains the API implementation

[**3rdParty**](https://github.com/RenderHeads/lib-unity-omeka/tree/main/Unity/Assets/3rdParty): Contains the 3rd party dependencies

[**Sample**](https://github.com/RenderHeads/lib-unity-omeka/tree/main/Unity/Assets/Sample): Contains a test scene and example of how to work with the API

## Using the API
### Configure your settings
Configure the scriptableobject found in data/ClientSettings in order to set your endpoint and api keys (optional, for accessing private information).
The endpoint does not need to include /api/ at the end.

### Add Client component to your scene
Add the OmekaClient component to your scene. This will initialize an instance of the API on awake. We have not included a singleton pattern for the component, however such functionality is easy to extend.

### Use the API and make requests
Find a reference to the API component and call the relevant API endpoint with search parameters, for example:

`ItemSearchResponse<DublicCoreVocabulary> response = await _client.Api.SearchItems(new ItemSearchParams() { item_set_id = index.Id });`

## API pattern
The API needs to be informed of what Vocabulary to expect, you can specify a type of Vocabulary when instantiating the API.

The API uses Async/Await instead of coroutines, as it results in cleaner code. There is an extension method included to add support for this to UnityWebRequest

Each API endpoint takes in Parameter object, containing all possible parameters for a  search. If a parameter is set, then it will be included in the query.

Each API endpoint returns a response object, which include the URL that was requested, the HTTP response code, and a list of typed objects (based on the search type), assuming the request was successful.

## Custom Vocabulary
The implementation currently supports a Dublin Core Vocabulary, and will convert the dublin core meta data to a typed object. If you need to support a custom vocabulary or a different vocabulary, you can create a new class that inherits type Vocabulary, and implement the abstract method to parse the JSON data, as per the DublinCore implementation.


# Usage and Contribution
## Usage License
The project is licensed under a GPL-3.0 license, which means you can use it for commerical and non commercial use, but the project you use it in also needs to apply the GPL-3.0 license and be open-sourced. If this license is not suitable for you, please contact us at southafrica@renderheads.com and we can discuss an appropriate commerical license.

## Contributors License
If you wish to contribute to this project, you will need to agree to our contributors license terms so that we can ensure that the community is free to use your contributions.
The Contributors License Agreement is avaiable here for review.


