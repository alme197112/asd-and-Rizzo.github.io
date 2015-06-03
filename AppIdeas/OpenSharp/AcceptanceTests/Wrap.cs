namespace AcceptanceTests.Helpers
{
    public class Wrap<T>
    {
        private readonly T _underlyingUnderlyingObject;

        public Wrap(T underlyingObject)
        {
            _underlyingUnderlyingObject = underlyingObject;
        }

        public T UnderlyingObject
        {
            get { return _underlyingUnderlyingObject; }
        }
    }
}