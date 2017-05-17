using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestTask.Services;

namespace TestTask.Models
{
    public class UrlParser:IUrlParser
    {
        public SortedSet<string> AllUrls { get; set; }
        public SortedSet<string> LevelUrls { get; set; }
        public SortedSet<string> PageUrls { get; set; }
        public int Depth { get; set; }
        public string Domain { get; set; }
        public UrlParser()
        {
            AllUrls = new SortedSet<string>();
            LevelUrls = new SortedSet<string>();
            PageUrls = new SortedSet<string>();
        }
        public SortedSet<string> GetAllUrls()
        {
            for(int i=0;i<Depth;i++)
            {
                GetUrlsFromLevel();
                SaveUrlToLevel();
                SaveLevelUrlsToAll();
            }
            LevelUrls.Clear();
            PageUrls.Clear();
            return AllUrls;
        }
        private void GetUrlsFromLevel()
        {
            PageUrls.Clear();
            if(AllUrls.Count==0)
            {
                LevelUrls.Add(Domain);
            }
            foreach(string node in LevelUrls)
            {
                if(node.StartsWith("/"))
                {
                    ParseUrlFromPage(Domain + node);
                }
                else
                {
                    ParseUrlFromPage(node);
                }
            }
            LevelUrls.Clear();
        }
        private void SaveUrlToLevel()
        {
            LevelUrls.UnionWith(PageUrls);
        }
        private void SaveLevelUrlsToAll()
        {
            foreach(var node in LevelUrls)
            {
                AllUrls.Add(node);
            }
        }
        private void ParseUrlFromPage(string pageUrl)
        {
            var doc = new HtmlWeb().Load(pageUrl);
            foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//a[@href]"))
            {
                string hrefValue = link.GetAttributeValue("href", String.Empty);

                if ( hrefValue.StartsWith("/")||hrefValue.StartsWith(Domain) && !hrefValue.StartsWith("//"))
                {
                    if (hrefValue.Length > 1 && hrefValue.StartsWith("/"))
                    {
                        PageUrls.Add(Domain + hrefValue);
                    }
                    if(!hrefValue.StartsWith("/"))
                    {
                        PageUrls.Add(hrefValue);
                    }
                }

            }
        }
    }
}