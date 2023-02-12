using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Services.CustomQueryServices
{
    public interface ICustomService<TDataModel> where TDataModel : class
    {
        Task<IEnumerable<TDataModel>> GetAll();
        Task<TDataModel> Get(object id);
        //Task<int> Insert(TDataModel model);
        //Task<int> Update(TDataModel model);
        //Task<int> Delete(TDataModel model);


    }
}
