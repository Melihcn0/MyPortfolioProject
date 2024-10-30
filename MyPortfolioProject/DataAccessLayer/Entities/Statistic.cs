namespace MyPortfolioProject.DataAccessLayer.Entities
{
    public class Statistic
    {
        public int StatisticID { get; set; }
        public int Project { get; set; }
        public int CompletedProject { get; set; }
        public int OngoingCourse { get; set; }
        public int Certificate { get; set; }

    }
}
