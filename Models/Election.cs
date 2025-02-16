namespace Online_voting.Models
{
    public class Election
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ICollection<Candidate> Candidates { get; set; } = new List<Candidate>();
    }
}
