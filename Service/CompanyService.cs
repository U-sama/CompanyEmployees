﻿using AutoMapper;
using Contracts;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service
{
    internal sealed class CompanyService : ICompanyService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public CompanyService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _repository = repository;
        }

        public IEnumerable<CompanyDto> GetAllCompaines(bool trackChanges)
        {
            try
            {
                var companies = _repository.Company.GetAllCompanies(trackChanges);
                var companiesDto = _mapper.Map<IEnumerable<CompanyDto>>(companies);
                return companiesDto;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetAllCompaines)} service method {ex}");
                throw;
            }
        }

    }
}
