namespace _02_Services_DependencyInjection.Services
{
    public class WithoutService
    {
        private readonly Guid id = Guid.NewGuid();

        public Guid GetId()
        {
            return id;
        }
    }
}
