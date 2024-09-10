namespace WebApi.Model
{    
    public class AddUpdateOurHero
    {
        public required string FirstName { get; set; }
        public string LastName { get; set; }
        public bool isActive { get; set; }
    }
}
