using AutoMapper;
using Project.Core.Data;
using Project.Core.Entities;
using Project.Services.ModalServices;
using RepositoryLayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace Project.Services.Helper.ErrorHandler
{
    public class LogErrorHandler : ILogErrorHandler
    {
        private readonly IUnitOfWork<SystemDBContext> _uow;
        protected readonly IMapper _mapper;

        public LogErrorHandler(IUnitOfWork<SystemDBContext> uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }


        public SaveStatusModel SysError(LogErrorModel model)
        {
            var res = new SaveStatusModel {Status = SaveStatus.Failed};
            if (SysErrorInsert(model))
            {
                res = new SaveStatusModel {Status = SaveStatus.Success};
            }
            return res;
        }


        private bool SysErrorInsert(LogErrorModel model)
        {

            var mappedData = _mapper.Map<SysError>(model);
            var res = _uow.GetRepository<SysError>().Insert(mappedData);
            return true;
        }
          
         
    }
}
