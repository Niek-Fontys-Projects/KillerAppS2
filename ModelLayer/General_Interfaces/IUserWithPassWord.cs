namespace ModelLayer.General_Interfaces
{
    public interface IUserWithPassWord : IUser
    {
        string PassWord { get; }
        string PassWordHash { get; }
    }
}
