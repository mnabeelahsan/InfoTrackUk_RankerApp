﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

namespace InfoTrackUkApp.Services
{
    public class HtmlProcessService
    {
        public string GetRanks(string htmlContent, string url)
        {
            string pattern = @"<cite[^>]*>(.*?)<\/cite>";
            MatchCollection matches = Regex.Matches(htmlContent, pattern, RegexOptions.Singleline);

            List<string> rankList = new List<string>();
            int matchCount = matches.Count;

            if (matchCount > 0)
            {
                foreach (Match match in matches)
                {
                    string citeTagContent = match.Groups[1].Value;
                    // Remove any HTML tags from the content
                    string textContent = Regex.Replace(citeTagContent, @"<.*?>", string.Empty);
                    if (textContent.Contains(url) == true)
                    {
                        rankList.Add(match.Index.ToString());
                    }
                    
                }
                return string.Join(",", rankList);
            }
            else
            {
                return "0";
            }
            
        }
    }
}
