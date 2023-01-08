using Logic.Companys;
using Logic.Enum;
using Logic.Interface;

namespace Logic.System.ModelManager
{
    public class CompanyModelManager : ICompanyModelManager
    {
        private List<Company> companies;
        private IBinaryFileManager binaryFileManager { get; set; }

        public IList<Company> Companies { get { return companies.AsReadOnly(); } }

        public CompanyModelManager(IBinaryFileManager binaryFileManager)
        {
            this.binaryFileManager = binaryFileManager;
            companies = (List<Company>)binaryFileManager.ReadFromBinaryFile<IList<Company>>(RepositoryType.Company);
        }

        /// <summary>
        /// Adds a new company to the list of companies.
        /// </summary>
        /// <param name="company">The company to add.</param>
        /// <returns>A result object containing either a success message or an exception if there was an error.</returns>
        public Result<string> AddNewCompany(Company company)
        {
            try
            {
                if (!companies.Any(x => x.Equals(company)))
                {
                    companies.Add(company);
                    return Result<string>.Ok("Company added successfully!");
                }

                return Result<string>.Fail(new Exception("company already exists"));
            }
            catch (Exception e)
            {
                return Result<string>.Fail(e);
            }
        }

        /// <summary>
        /// Updates a specific company in the list.
        /// </summary>
        /// <param name="company">The company to update.</param>
        public void SaveCompany(Company company)
        {
         
            int index = companies.FindIndex(x => x.Name == company.Name);
            if (index != -1)
            {
                companies[index] = company;
            }
        }

        /// <summary>
        /// Saves the list of companies to a binary file.
        /// </summary>
        public void SafeProducts()
        {
            binaryFileManager.WriteToBinaryFile<List<Company>>(companies, RepositoryType.Company);
        }
    }
}
