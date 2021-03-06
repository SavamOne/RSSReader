﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RSS_Reader.Utils
{
    /// <summary>
    /// Оптимизация HTML-кода в item->description.
    /// Форматирует HTML.
    /// Удаляет все IFrame, а так же убирает ссылки
    /// </summary>
    public static class DescriptionPrettifier
    {
        static Regex IFrameRE { get; }
        static Regex AOpenRE { get; } 
        static Regex ACloseRE { get; }

        static DescriptionPrettifier()
        {
            IFrameRE = new Regex("<iframe[^>]*><\\/iframe>");
            AOpenRE = new Regex("<a[^>]*>");
            ACloseRE = new Regex("<\\/a>");
        }

        public static string PrettifyDescription(this string description)
        {
            description = IFrameRE.Replace(description, string.Empty);
            description = AOpenRE.Replace(description, string.Empty);
            description = ACloseRE.Replace(description, string.Empty);
            description = 
            @"<html>
                <meta charset=utf-8>
                <style>
                body{
                    color: #333333;
                    font-family: Arial
                    padding: 10px;
                }
                html, body{
                    max-width: 100%;
                }
                img{
                    width: 90 %; 
                    height: auto;
                    margin: auto;
                }
                </style>
                <body>" 
            + "\n"+ description + "\n" +
            @"  </body>
            </html>";
            return description;
        }
        
        
    }
}
