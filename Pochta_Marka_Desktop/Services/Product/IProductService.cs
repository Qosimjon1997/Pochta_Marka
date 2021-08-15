using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pochta_Marka_Desktop.Services.Product
{
    public interface IProductService
    {
        Task<IEnumerable<ProductModel>> GetAll();
        Task<ProductModel> Get(int id);
        Task<bool> Post(ProductModel model);
        Task<bool> Delete(int id);
        Task<bool> Update(int id, ProductModel model);

    }
}
