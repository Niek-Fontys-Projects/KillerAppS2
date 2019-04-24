namespace ModelLayer.General_Interfaces
{
    public interface IObjectPair<T1, T2>
    {
        T1 Object1 { get; }
        T2 Object2 { get; }
    }
}
