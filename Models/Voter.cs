namespace Online_voting.Models
{
    public class Voter
    {
        public int Id { get; set; }
        public string UserId { get; set; } // Link to ASP.NET Identity User
        public ICollection<Vote> Votes { get; set; } = new List<Vote>();
    }
}
