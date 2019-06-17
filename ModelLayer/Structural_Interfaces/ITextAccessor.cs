using System.Collections.Generic;

namespace ModelLayer.Structural_Interfaces
{
    public interface ITextAccessor
    {
        IEnumerable<string> GetLines(string _filePath);
    }
}