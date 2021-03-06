﻿using RSS_Reader.XML_Parser;
using System;

namespace RSS_Reader.RSS_Classes
{
    /// <summary>
    /// Структура элемента Image в RSS
    /// </summary>
    public class Image : IXML
    {
        [XMLProperty("link")]
        public Uri Link { get; set; }

        [XMLProperty("url")]
        public Uri Url { get; set; }
    }
}
