using WebApi.Model;

namespace WebApi.Services
{
    public class OurHeroService:IOurHeroService
    {
        private readonly List<OurHero> _ourHerosList;
        public OurHeroService()
        {
            _ourHerosList = new List<OurHero>()
            {
                new OurHero(){
                Id = 1,
                FirstName = "Test",
                LastName = "",
                isActive = true,
                }
            };
        }

        public List<OurHero> GetAllHeros(bool? isActive)
        {
            return isActive == null ? _ourHerosList : _ourHerosList.Where(hero => hero.isActive == isActive).ToList();
        }
        public OurHero? GetOurHeroById(int id)
        {
            return _ourHerosList.FirstOrDefault(hero => hero.Id == id); 
        }
        public OurHero AddOurHero(AddUpdateOurHero obj)
        {
            var addHero = new OurHero()
            {
                Id = _ourHerosList.Max(hero => hero.Id)+1,
                FirstName = obj.FirstName,
                LastName = obj.LastName,
                isActive = obj.isActive
            };
            _ourHerosList.Add(addHero);
            return addHero;
        }

        public OurHero? UpdateOurHero(int id, AddUpdateOurHero obj)
        {
            var ourHero = _ourHerosList.FindIndex(index => index.Id == id);
            if(ourHero > 0)
            {
                var hero = _ourHerosList[ourHero];
                hero.FirstName = obj.FirstName;
                hero.LastName = obj.LastName;
                hero.isActive = obj.isActive;

                _ourHerosList[ourHero] = hero;
                return hero;
            }
            else
            {
                return null;
            }
        }
        public bool DeleteOurHeroById(int id)
        {
           var ourHeroIndex = _ourHerosList.FindIndex(Index =>  Index.Id == id);
            if(ourHeroIndex>= 0)
            {
                _ourHerosList.RemoveAt(ourHeroIndex);
            }
            return ourHeroIndex >= 0;
        }
    }
}
