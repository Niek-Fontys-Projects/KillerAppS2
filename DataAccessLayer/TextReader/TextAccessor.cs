using ModelLayer.Structural_Interfaces;
using System.Collections.Generic;
using System.IO;

namespace DataAccessLayer.TextReader
{
    internal class TextAccessor : ITextAccessor
    {
        internal TextAccessor()
        {

        }

        public IEnumerable<string> GetLines(string _filePath)
        {
            return File.ReadAllLines(_filePath);
        }
    }
}
