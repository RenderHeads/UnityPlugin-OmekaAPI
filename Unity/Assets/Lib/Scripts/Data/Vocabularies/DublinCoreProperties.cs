using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RenderHeads.UnityOmeka.Data.Vocabularies
{

    public class Property
    {
        public string Type;
        public int PropertyId;
        public string PropertyLabel;
        public bool IsPublic;
        public string Value;
        public string Language;

    }

    public class DublinCoreProperties
    {
        public Property[]  DCTermsAbstract;
        public Property[] DCTermsAccessRight;
        public Property[] DCTermsAccrualMethod;
        public Property[] DCTermsAccrualPeriodicity;
        public Property[] DCTermsAccraulPolicy;
        public Property[] DCTermsAlternative;
        public Property[] DCTermsAudience;
        public Property[] DCTermsEducationLevel;
        public Property[] DCTermsBibliographicCitation;
        public Property[] DCTermsConformsTo;
        public Property[] DCTermsContributor;
        public Property[] DCTermsCoverage;
        public Property[] DCTermsCreator;
        public Property[] DCTermsDate;
        public Property[] DCTermsDateAccepted;
        public Property[] DCTermsAvailable;
        public Property[] DCTermsDateCopyrighted;
        public Property[] DCTermsCreated;
        public Property[] DCTermsIssued;
        public Property[] DCTermsModified;
        public Property[] DCTermsDateSubmitted;
        public Property[] DCTermsValid;
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
        public Property[] DCTermsRights;
        public Property[] DCTermsRightsHolder;
        public Property[] DCTermsSource;
        public Property[] DCTermsSpacial;
        public Property[] DCTermsSubject;
        public Property[] DCTermsTableOfContents;
        public Property[] DCTermsTemporal;
        public Property[] DCTermsTitle;
        public Property[] DCTermsType;

    }
}