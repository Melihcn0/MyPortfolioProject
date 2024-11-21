namespace MyPortfolioProject.DataAccessLayer.Entities
{
    public class Admin
    {
        public int AdminID {get;set;}
        public string AdminMail {get;set;}
        public string AdminPassword {get;set;}
        public string AdminNameSurname { get; set; }
        public string AdminRole {get;set;}
    }
}
