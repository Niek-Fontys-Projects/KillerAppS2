using ModelLayer.Structural_Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLayer.Filter
{
    internal class WordFilter : IWordFilter
    {
        private readonly IEnumerable<string> blackList;

        internal WordFilter(IEnumerable<string> _blackList)
        {
            blackList = _blackList;
        }

        public string Filter(string _text)
        {
            string text = string.Empty;
            foreach (string word in blackList)
            {
                _text.Replace(word, "***");
            }
            return text;
        }
    }
}
