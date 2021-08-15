using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pochta_Marka_Desktop.Services.Sale
{
    public interface ISaleService
    {
        Task<IEnumerable<SaleModel>> GetAll();
        Task<SaleModel> Get(int id);
        Task<bool> Post(IEnumerable<SaleModel> model);
        Task<bool> Delete(int id);
        Task<bool> Update(int id, SaleModel model);
    }
}
