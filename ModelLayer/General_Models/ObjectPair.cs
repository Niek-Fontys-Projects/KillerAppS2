using ModelLayer.General_Interfaces;

namespace ModelLayer.General_Models
{
    public class ObjectPair<T1, T2> : IObjectPair<T1, T2>
    {
        private T1 object1;
        private T2 object2;

        public ObjectPair(T1 _object1, T2 _object2)
        {
            object1 = _object1;
            object2 = _object2;
        }
        public T1 Object1
        {
            get { return object1; }
        }

        public T2 Object2
        {
            get { return object2; }
        }
    }
}
