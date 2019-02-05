using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phramd.Utility
{
    public class NewsData
    {
        public string headline { get; set; }
        public List<string> headlineList { get; set; }
        public List<string> headlines = new List<string>();
        public string published { get; set; }
        public List<string> publishedList { get; set; }
        public List<string> publishDates = new List<string>();
        public DateTime publishedDate { get; set; }

        // stop from skipping over
        public int pos = 0;

        public void AddHeadline(string headline)
        {
            headlines.Add(headline);
        }
        public string GetHeadline()
        {
            string curHeadline = "";
            curHeadline = headlines.ElementAt(pos);
            pos++;
            if (pos >= headlines.Count)
            {
                pos = 0;
            }
            return curHeadline;
        }

        public void AddPublished(string published)
        {
            publishDates.Add(published);
        }
        public string GetPublished()
        {
            string curPublished = "";
            curPublished = publishDates.ElementAt(pos);
            pos++;
            if (pos >= publishDates.Count)
            {
                pos = 0;
            }
            return curPublished;
        }

    } 
}
