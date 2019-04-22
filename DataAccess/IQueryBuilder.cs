namespace DataAccess
{
    public interface IQueryBuilder
    {
        void ClearQuery();
        void Insert(IAnnouncement _object);
        void Insert(IUserWithPassWord _object);
        void Insert(IRating _object);
        void Insert(IMessage _object);
    }
}