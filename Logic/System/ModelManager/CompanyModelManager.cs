using Logic.Companys;
using Logic.Enum;
using Logic.Interface;


namespace Logic.System.ModelManager
{
    public class CompanyModelManager: ICompanyModelManager
    {
        private List<Company> allCompanies;
        private IBinarayFileManager fileManager { get; set; }

        public IList<Company> AllCompanies { get { return allCompanies.AsReadOnly(); } }



        public CompanyModelManager(IBinarayFileManager fileManager)
        {
            this.fileManager = fileManager;
            this.allCompanies = (List<Company>?)this.fileManager.ReadFromBinaryFile<IList<Company>>(RepositoryType.Company);
        }

        /// <summary>
        /// Adds a new Company object to the list of all companies.
        /// </summary>
        /// <param name="company">The Company object to be added to the list.</param>
        /// <returns>
        /// A Result<string> object indicating the success or failure of the operation. If the operation is successful, 
        /// the Ok variant will contain a string message indicating that the Company object was added to the list. 
        /// If the operation fails, the Fail variant will contain an Exception object with more information about the error.
        /// </returns>
        public Result<string> AddNewCompany(Company company)
        {
            try
            {
                if (!allCompanies.Any(x => x.Equals(company)))
                {
                    allCompanies.Add(company);
                    return Result<string>.Ok("is added to list");
                }

                return Result<String>.Fail(new Exception("company already exist"));

            }
            catch (Exception e)
            {

                return Result<string>.Fail(e);
            }
            
        }

        /// <summary>
        /// Saves the list of all companies to a binary file.
        /// </summary>
        public void SafeProducts()
        {
            fileManager.WriteToBinaryFile<List<Company>>(allCompanies, RepositoryType.Company);
        }

    }
}
