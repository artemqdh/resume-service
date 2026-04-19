namespace Domain.Entity
{
    public class Vacancy
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public string? NameCompany { get; set; }
        public string? DatePosted { get; set; }
        public string? Country { get; set; }
        public string? StreetAddress { get; set; }
        public string? WorkSchedule { get; set; }
       // public string? WorkSchedule { get; set; }
    }
}
