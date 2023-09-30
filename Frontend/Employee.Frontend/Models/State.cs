namespace Employee.Frontend.Models
{
    public class State
    {
        public int Id { get; set; }
        public string? StateName { get; set; }
        public int CountryId { get; set; }
        public Country? Country { get; set; }

        public ICollection<Employees> Employee { get; set; } = new HashSet<Employees>();
    }
}
