using Contracts;
using Service.Contracts;

namespace Service
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IEmployeeService> _employeeService;
        private readonly Lazy<ICompanyService> _companyService;

        public ServiceManager(IRepositoryManager repository, ILoggerManager logger)
        {
            _employeeService = new Lazy<IEmployeeService>(() => new EmployeeService(repository, logger));
            _companyService = new Lazy<ICompanyService>(() => new CompanyService(repository, logger));
        }

        public IEmployeeService EmployeeService => _employeeService.Value;
        public ICompanyService CompanyService => _companyService.Value;
    }
}
