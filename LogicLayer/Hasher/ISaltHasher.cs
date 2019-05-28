using ModelLayer.General_Interfaces;

namespace LogicLayer.Hasher
{
    public interface ISaltHasher
    {
        string Hash(string _passWord, string _salt);
        IObjectPair<string, string> HashNewSalt(string _passWord);
    }
}