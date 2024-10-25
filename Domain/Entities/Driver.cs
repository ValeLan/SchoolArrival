namespace Domain.Entities
{
    public class Driver : User
    {
        public List<Travel> Travels { get; set; } = new List<Travel>();
    }
}
