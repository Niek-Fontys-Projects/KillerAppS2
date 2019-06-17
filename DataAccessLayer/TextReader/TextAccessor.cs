using ModelLayer.Structural_Interfaces;
using System.Collections.Generic;
using System.IO;

namespace DataAccessLayer.TextReader
{
    public class TextAccessor : ITextAccessor
    {
        public TextAccessor()
        {

        }

        public IEnumerable<string> GetLines(string _filePath)
        {
            return File.ReadAllLines(_filePath);
        }
    }
}
