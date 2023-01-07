using Logic.Companys;

namespace Logic.Interface
{
    public interface ICompanyModelManager
    {
        public IList<Company> Companies { get; }
        public Result<string> AddNewCompany(Company company);
        public void SafeProducts();
    }
}
