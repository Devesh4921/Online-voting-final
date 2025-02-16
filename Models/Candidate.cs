namespace Online_voting.Models
{
    public class Candidate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ElectionId { get; set; }
        public Election Election { get; set; }
    }
}
