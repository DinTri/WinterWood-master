using WinterWood.Entities;

namespace WinterWood.Repository.Contracts
{
    public interface IDbFactory
    {
        WoodContext DbContext();

    }
}
