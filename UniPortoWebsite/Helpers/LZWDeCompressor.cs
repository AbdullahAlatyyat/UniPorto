using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniPortoWebsite.Helpers
{
    public class LZWDeCompressor
    {
        public string Decompressor(
            Dictionary<int, string> dictionary, List<int> indices)
        {
            string s = string.Empty;

            foreach (int index in indices)
            {
                foreach (KeyValuePair<int, string> kvp in dictionary)
                {
                    if (kvp.Key == index)
                    {
                        s += kvp.Value;
                        break;
                    }
                }
            }

            return s;
        }
    }
}