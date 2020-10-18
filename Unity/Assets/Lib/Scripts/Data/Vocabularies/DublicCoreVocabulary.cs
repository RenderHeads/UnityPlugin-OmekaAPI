using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RenderHeads.UnityOmeka.Data.Vocabularies
{

    public class Property
    {
        public string Type;
        public int? PropertyId;
        public string PropertyLabel;
        public bool? IsPublic;
        public string Value;
        public string Language;

        public static Property[] FromRoot(JObject root, string term)
        {
            JArray array;

            array = Helpers.TryGet<JArray>(root, term, supressError:true);

            if (array == null)
            {
                return null;
            }
            else
            {
                Property[] p = new Property[array.Count];
                int i = 0;
                foreach (var entry in array)
                {
                    p[i] = FromJObject((JObject)entry);
                    i++;
                }
                return p;
            }
        }

        public static Property FromJObject(JObject jObject)
        {
            Property p = new Property()
            {
                Type = jObject["type"]?.ToString(),
                PropertyId = jObject["property_id"]?.ToObject<int?>(),
                PropertyLabel = jObject["property_label"]?.ToString(),
                IsPublic = jObject["is_public"]?.ToObject<bool?>(),
                Value = jObject["@value"]?.ToString(),
                Language = jObject["@language"]?.ToString(),



            };

            return p;
        }




    }

    public abstract class Vocabulary
    {
        /// <summary>
        /// Apply the incoming json object and set the vocabulary.
        /// </summary>
        /// <param name="rootObject"></param>
        public abstract void ApplyVocabulary(JObject rootObject);
    }
    [System.Serializable]
    public class DublicCoreVocabulary : Vocabulary
    {
        public Property[] DCTermsAbstract;
        public Property[] DCTermsAccessRight;
        public Property[] DCTermsAccrualMethod;
        public Property[] DCTermsAccrualPeriodicity;
        public Property[] DCTermsAccraulPolicy;
        public Property[] DCTermsAlternativeTitle;
        public Property[] DCTermsAudience;
        public Property[] DCTermsEducationLevel;
        public Property[] DCTermsBibliographicCitation;
        public Property[] DCTermsConformsTo;
        public Property[] DCTermsContributor;
        public Property[] DCTermsCoverage;
        public Property[] DCTermsCreator;
        public Property[] DCTermsDate;
        public Property[] DCTermsDateAccepted;
        public Property[] DCTermsDateAvailable;
        public Property[] DCTermsDateCopyrighted;
        public Property[] DCTermsDateCreated;
        public Property[] DCTermsDateIssued;
        public Property[] DCTermsDateModified;
        public Property[] DCTermsDateSubmitted;
        public Property[] DCTermsDateValid;
        public Property[] DCTermsDescription;
        public Property[] DCTermsExtent;
        public Property[] DCTermsFormat;
        public Property[] DCTermsHasFormat;
        public Property[] DCTermsHasPart;
        public Property[] DCTermsHasVersion;
        public Property[] DCTermsIdentifier;
        public Property[] DCTermsInstructionalMethod;
        public Property[] DCTermsIsFormatOf;
        public Property[] DCTermsIsPartOf;
        public Property[] DCTermsIsReferencedBy;
        public Property[] DCTermsIsReplacedBy;
        public Property[] DCTermsIsRequiredBy;
        public Property[] DCTermsIsVersionOf;
        public Property[] DCTermsLanguage;
        public Property[] DCTermsLicense;
        public Property[] DCTermsMediator;
        public Property[] DCTermsMedium;
        public Property[] DCTermsProvenance;
        public Property[] DCTermsPublisher;
        public Property[] DCTermsReferences;
        public Property[] DCTermsRelation;
        public Property[] DCTermsReplaces;
        public Property[] DCTermRequires;
        public Property[] DCTermsRights;
        public Property[] DCTermsRightsHolder;
        public Property[] DCTermsSource;
        public Property[] DCTermsSpatialCoverage;
        public Property[] DCTermsSubject;
        public Property[] DCTermsTableOfContents;
        public Property[] DCTermsTemporal;
        public Property[] DCTermsTitle;
        public Property[] DCTermsType;

        public override void ApplyVocabulary(JObject rootObject)
        {
            DCTermsAbstract = Property.FromRoot(rootObject, "dcterms:abstract");
            DCTermsAccessRight = Property.FromRoot(rootObject, "dcterms:accessRights");
            DCTermsAccrualMethod = Property.FromRoot(rootObject, "dcterms:accrualMethod");
            DCTermsAccrualPeriodicity = Property.FromRoot(rootObject, "dcterms:accrualPeriodicity");
            DCTermsAlternativeTitle = Property.FromRoot(rootObject, "dcterms:alternative");
            DCTermsAudience = Property.FromRoot(rootObject, "dcterms:audience");
            DCTermsEducationLevel = Property.FromRoot(rootObject, "dcterms:educationLevel");
            DCTermsBibliographicCitation = Property.FromRoot(rootObject, "dcterms:bibliographicCitation");
            DCTermsConformsTo = Property.FromRoot(rootObject, "dcterms:conformsTo");
            DCTermsContributor = Property.FromRoot(rootObject, "dcterms:contributor");
            DCTermsCoverage = Property.FromRoot(rootObject, "dcterms:coverage");
            DCTermsCreator = Property.FromRoot(rootObject, "dcterms:creator");
            DCTermsDate = Property.FromRoot(rootObject, "dcterms:date");
            DCTermsDateAccepted = Property.FromRoot(rootObject, "dcterms:dateAccepted");
            DCTermsDateAvailable = Property.FromRoot(rootObject, "dcterms:available");
            DCTermsDateCopyrighted = Property.FromRoot(rootObject, "dcterms:dateCopyrighted");
            DCTermsDateCreated = Property.FromRoot(rootObject, "dcterms:created");
            DCTermsDateIssued = Property.FromRoot(rootObject, "dcterms:issued");
            DCTermsDateModified = Property.FromRoot(rootObject, "dcterms:modified");
            DCTermsDateSubmitted = Property.FromRoot(rootObject, "dcterms:dateSubmitted");
            DCTermsDateValid = Property.FromRoot(rootObject, "dcterms:valid");
            DCTermsDescription = Property.FromRoot(rootObject, "dcterms:description");
            DCTermsExtent = Property.FromRoot(rootObject, "dcterms:extent");
            DCTermsFormat = Property.FromRoot(rootObject, "dcterms:format");
            DCTermsHasFormat = Property.FromRoot(rootObject, "dcterms:hasFormat");
            DCTermsHasPart = Property.FromRoot(rootObject, "dcterms:hasPart");
            DCTermsHasVersion = Property.FromRoot(rootObject, "dcterms:hasVersions");
            DCTermsIdentifier= Property.FromRoot(rootObject, "dcterms:identifier");
            DCTermsInstructionalMethod = Property.FromRoot(rootObject, "dcterms:instructionalMethod");
            DCTermsIsFormatOf = Property.FromRoot(rootObject, "dcterms:isFormatOf");
            DCTermsIsPartOf = Property.FromRoot(rootObject, "dcterms:isPartOf");
            DCTermsIsReferencedBy = Property.FromRoot(rootObject, "dcterms:isReferencedBy");
            DCTermsIsReplacedBy = Property.FromRoot(rootObject, "dcterms:isReplacedBy");
            DCTermsIsRequiredBy = Property.FromRoot(rootObject, "dcterms:isRequiredBy");
            DCTermsIsVersionOf = Property.FromRoot(rootObject, "dcterms:isVersionOf");
            DCTermsLanguage = Property.FromRoot(rootObject, "dcterms:language");
            DCTermsLicense = Property.FromRoot(rootObject, "dcterms:license");
            DCTermsMediator = Property.FromRoot(rootObject, "dcterms:mediator");
            DCTermsMedium = Property.FromRoot(rootObject, "dcterms:medium");
            DCTermsProvenance = Property.FromRoot(rootObject, "dcterms:provenance");
            DCTermsPublisher = Property.FromRoot(rootObject, "dcterms:publisher");
            DCTermsReferences = Property.FromRoot(rootObject, "dcterms:references");
            DCTermsRelation = Property.FromRoot(rootObject, "dcterms:relation");
            DCTermsReplaces = Property.FromRoot(rootObject, "dcterms:replaces");
            DCTermRequires = Property.FromRoot(rootObject, "dcterms:requires");
            DCTermsRights = Property.FromRoot(rootObject, "dcterms:rights");
            DCTermsRightsHolder = Property.FromRoot(rootObject, "dcterms:rightsHolder");
            DCTermsSource = Property.FromRoot(rootObject, "dcterms:source");
            DCTermsSpatialCoverage = Property.FromRoot(rootObject, "dcterms:spatial");
            DCTermsSubject = Property.FromRoot(rootObject, "dcterms:subject");
            DCTermsTableOfContents = Property.FromRoot(rootObject, "dcterms:tableOfContents");
            DCTermsTemporal = Property.FromRoot(rootObject, "dcterms:temporal");
            DCTermsTitle = Property.FromRoot(rootObject, "dcterms:title");
            DCTermsType = Property.FromRoot(rootObject, "dcterms:type");

        }
    }
}