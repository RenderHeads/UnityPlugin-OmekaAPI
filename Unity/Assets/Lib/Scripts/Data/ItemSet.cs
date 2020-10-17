using RenderHeads.UnityOmeka.Data.Vocabularies;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RenderHeads.UnityOmeka.Data
{
    public class ItemSet : DublinCoreProperties
    {
        public IdObject Id;
        public string[] Type;
        public bool? IsPublic;
        public IdObject Owner;
        public IdObject ResourceClass;
        public IdObject ResourceTemplate;
        public IdObject Thumbnail;
        public string? title;
        public DateTime? Created;
        public DateTime? Modified;
        public bool? IsOpen;

    }
}