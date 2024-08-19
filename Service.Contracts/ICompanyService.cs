using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface ICompanyService
    {
        IEnumerable<CompanyDto> GetAllCompaines(bool trackChanges);
        CompanyDto GetCompany(Guid companyId, bool trackChanges);
    }
}
