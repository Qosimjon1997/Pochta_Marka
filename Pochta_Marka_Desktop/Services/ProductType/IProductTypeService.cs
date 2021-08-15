using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pochta_Marka_Desktop.Services.ProductType
{
    public interface IProductTypeService
    {
        Task<IEnumerable<ProductTypeModel>> GetAll();
        Task<ProductTypeModel> Get(int id);
        Task<bool> Post(ProductTypeModel model);
        Task<bool> Delete(int id);
        Task<bool> Update(int id, ProductTypeModel model);
    }
}
