using _02_Mapping.Models.Entitites;

namespace _02_Mapping.Services;

internal class CustomerService : DataService<CustomerEntity>
{
    public override Task<CustomerEntity> CreateAsync(CustomerEntity entity)
    {
        return base.CreateAsync(entity);
    }

    public override async Task UpdateAsync(CustomerEntity entity)
    {
        var item = await GetAsync(x => x.Id == entity.Id);
        await base.UpdateAsync(item);
    }
}
