using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace DNP.Data
{
    public interface IAdultData
    {
        Task<List<Adult>> GetAdults();

        Task<Adult> AddAdults(Adult adult);

        Task RemoveAdults(int adultId);

        Task<Adult> Update(Adult adult);

        Task<Adult>  Get(int id);
        
    }
}