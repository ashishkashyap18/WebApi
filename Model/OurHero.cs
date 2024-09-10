namespace WebApi.Model
{
    public class OurHero
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public string LastName { get; set; }

        public bool isActive { get; set; }
    }
}
