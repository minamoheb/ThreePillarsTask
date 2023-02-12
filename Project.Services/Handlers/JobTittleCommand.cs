using Project.Core.Data;
using Project.Core.Entities;
using Project.Services.CustomQueryServices;
using Project.Services.ModalServices;
using AutoMapper;
using RepositoryLayer.UnitOfWork;
using System.Threading.Tasks;

namespace Project.Services.Handler
{
    public class JobTittleCommand : CustomService<JobTittleModel, JobTittle>
    {

        public JobTittleCommand(IUnitOfWork<SystemDBContext> uow, IMapper mapper) : base(uow, mapper)
        {

        }

        public async Task<string> Insert(JobTittleModel model)
        {
            var mappedData = _mapper.Map<JobTittle>(model);
            var res = await Repository.Insert(mappedData);
            return "S" + res.Id;
        }
        public async Task<string> Update(JobTittleModel model)
        {
            var mappedData = _mapper.Map<JobTittle>(model);
            var res = await Repository.Update(mappedData);
            return "S" + res.Id;
        }
        public async Task<string> Delete(JobTittleModel model)
        {
            var mappedData = _mapper.Map<JobTittle>(model);
            var res = await Repository.Delete(mappedData);
            return "S" + res.Id;
        }




    }
}
