using WebApi.Model;

namespace WebApi.Services
{
    public interface IOurHeroService
    {
        List<OurHero> GetAllHeros(bool? isActive);
        OurHero? GetOurHeroById(int id);
        OurHero AddOurHero(AddUpdateOurHero obj);
        OurHero? UpdateOurHero(int id,AddUpdateOurHero obj);
        bool DeleteOurHeroById(int id);
    }
}
