using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pochta_Marka_Desktop.Services.Employee
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeModel>> GetAll();
        Task<EmployeeModel> Get(int id);
        Task<EmployeeModel> GetByLoginPass(string login,string passw);
        Task<bool> Post(EmployeeModel employee);
        Task<EmployeeModel> GetByPass(string passw);
        Task<bool> Delete(int id);
        Task<bool> Update(int id, EmployeeModel employee);
    }
}
