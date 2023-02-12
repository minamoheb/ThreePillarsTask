using Project.Core.Data;
using Project.Core.Entities;
using Project.Services.CustomQueryServices;
using Project.Services.ModalServices;
using AutoMapper;
using RepositoryLayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Project.Services.Handler
{
    public class AddressBookCommand : CustomService<AddressBookModel, AddressBook>
    {

        public AddressBookCommand(IUnitOfWork<SystemDBContext> uow, IMapper mapper) : base(uow, mapper)
        {

        }

        public async Task<string> Insert(AddressBookModel model)
        {
            var mappedData = _mapper.Map<AddressBook>(model);
            var res = await Repository.Insert(mappedData);
            return "S" + res.Id;
        }
        public async Task<string> Update(AddressBookModel model)
        {
            var mappedData = _mapper.Map<AddressBook>(model);
            var res = await Repository.Update(mappedData);
            return "S" + res.Id;
        }
        public async Task<string> Delete(AddressBookModel model)
        {
            var mappedData = _mapper.Map<AddressBook>(model);
            var res = await Repository.Delete(mappedData);
            return "S" + res.Id;
        }

        public override async Task<IEnumerable<AddressBookModel>> GetAll()
        {

            var data = await Repository.GetList(null, orderBy: b => b.OrderBy(c => c.BirthDate), t => t?
                         .Include(c => c.JobTittle)
                          .Include(c => c.Department)
                , false);
            if (data.Count == 0)
                return null;

            var mappedData = _mapper.Map<IEnumerable<AddressBookModel>>(data);
            return mappedData;

        }
        public async Task<IEnumerable<AddressBookModel>> FilterData(int? jobid, int? depid, DateTime? fmdate, DateTime? todate, string name)
        {

            Expression<Func<AddressBook, bool>> predicate = null;
            predicate = c => (c.JobId == jobid || jobid == 0)
            && (c.DepId == depid || depid == 0)
            && (c.FullName == name || name == null)
            && ((c.BirthDate >= fmdate && c.BirthDate <= todate) || fmdate == null || todate == null);

            var data = await Repository.GetList(predicate, c => c.OrderByDescending(x => x.FullName), t => t?
                         .Include(c => c.JobTittle)
                         .Include(c => c.Department)
            , false);
            if (data.Count == 0)
                return null;
            var mappedData = _mapper.Map<IEnumerable<AddressBookModel>>(data);
            return mappedData;
        }


    }
}
