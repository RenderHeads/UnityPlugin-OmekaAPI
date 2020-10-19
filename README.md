© RenderHeads 2020
# Omeka S API support for Unity3D

This repo contains an implementation of the Omeka API for Unity3D to retrieve content from an Omeka System and use it within unity.

## What is [Omeka](https://github.com/omeka/omeka-s)?
Omeka S is a web publication system for universities, galleries, libraries, archives, and museums. It consists of a local network of independently curated exhibits sharing a collaboratively built pool of items, media, and their metadata.

## Current Functionality
- Read-only support 
- Api search of *Item Sets, Items and Media*
- Dublin Core Vocabulary

## Dependencies
- The implementation relies of NewtonSoft Json.Net as deserialization of the Json-LD information

## Project Structure
Within the Unity project you will find the following folders:

### Lib
Contains the API implementation
### 3rdParty
Contains the 3rd party dependencies
### Sample
Contains a test scene and example of how to work with the API

## Using the API
### Configure your settings
In the inspector editor data/ClientSettings and configure your endpoint and api keys (optional, for accessing private information).
The endpoint does not need to include /api/ at the end

### Add Client component to your scene
Add the OmekaClient component to your scene. This will initialize an instance of the API on awake.

### Use the API and make requests
Call the relevant API endpoint with search parameters, for example:

`ItemSearchResponse<DublicCoreVocabulary> response = await _client.Api.SearchItems(new ItemSearchParams() { item_set_id = index.Id });`

## API pattern
- The API uses Async/Await instead of coroutines, as it results in cleaner code. There is an extension method included to add support for this to UnityWebRequest
- Each API endpoint takes in Parameter object, containing all possible parameters for a  search. If a parameter is set, then it will be included in the query.
- Each API endpoint returns a response object, which include the URL that was requested, the HTTP response code, and a list of typed objects (based on the search type), assuming the request was successful.



 
