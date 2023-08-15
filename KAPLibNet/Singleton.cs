
namespace KAPLibNet
{
    public interface ISingletonLike<T> where T : class,new()
    {
        private static T _Instance { get; set; } = null;

        public static T Instance {
            get {
                if (_Instance == null) {
                    _Instance = new T();
                }
                return _Instance;
            }
        }
    }
}
