using Airelax.Domain.Houses;

namespace Airelax
{
    public interface IManageHouseRepository
    {
        void Delete(House house);
        House Get(string id);
        void SaveChange();
        void Update(House house);
    }
}