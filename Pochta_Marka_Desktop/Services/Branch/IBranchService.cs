using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pochta_Marka_Desktop.Services.Branch
{
    public interface IBranchService
    {
        Task<IEnumerable<BranchModel>> GetAll();
        Task<BranchModel> Get(int id);
        Task<bool> Post(BranchModel model);
        Task<bool> Delete(int id);
        Task<bool> Update(int id,BranchModel model);

    }
}
