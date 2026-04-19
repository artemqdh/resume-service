namespace Domain.Entity
{
    public class Vacancy
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
    }
}
