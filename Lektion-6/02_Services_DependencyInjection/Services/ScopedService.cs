namespace _02_Services_DependencyInjection.Services
{
    public class ScopedService
    {
        private readonly Guid id = Guid.NewGuid();

        public Guid GetId()
        {
            return id;
        }
    }
}
