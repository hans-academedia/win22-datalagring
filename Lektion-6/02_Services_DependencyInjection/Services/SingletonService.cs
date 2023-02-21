namespace _02_Services_DependencyInjection.Services
{
    public class SingletonService
    {
        private readonly Guid id = Guid.NewGuid();

        public Guid GetId()
        {
            return id;
        }
    }
}
