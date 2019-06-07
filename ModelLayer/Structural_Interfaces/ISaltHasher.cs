using ModelLayer.General_Interfaces;

namespace ModelLayer.Structural_Interfaces
{
    public interface ISaltHasher
    {
        string Hash(string _passWord, string _salt);
        IObjectPair<string, string> HashNewSalt(string _passWord);
    }
}