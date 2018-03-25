using WinterWood.Entities;

namespace WinterWood.Repository.Contracts
{
    public class DbFactory : IDbFactory
    {
        WoodContext context;

        public WoodContext DbContext()
        {
            return context ?? (context = new WoodContext());
        }
    }
}
