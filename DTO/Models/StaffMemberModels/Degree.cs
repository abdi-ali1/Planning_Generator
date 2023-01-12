namespace DTO.Models.StaffMemberModels
{
    public class Degree
    {
        private int id;
        private string nameOfDegree;
        private int degreelevel;

        public int Id
        {
            get => id;
        }
        public string NameOfDegree
        {
            get => nameOfDegree;
        }
        public int Degreelevel
        {
            get => degreelevel;
        }

        public Degree(int id, string nameOfDegree, int degreelevel)
        {
            this.id = id;
            this.nameOfDegree = nameOfDegree;
            this.degreelevel = degreelevel;
        }
    }
}
