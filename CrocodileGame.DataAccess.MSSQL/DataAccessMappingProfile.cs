using AutoMapper;
using CrocodileGame.Domain.Models;
using System.Linq;

namespace CrocodileGame.DataAccess.PostgreSQL
{
    public class DataAccessMappingProfile : Profile
    {
        public DataAccessMappingProfile()
        {
            CreateMap<Card, Entities.Card>();
            CreateMap<Entities.Card, Card>()
                .ForMember(c => c.Topics, opt => opt.MapFrom(cardEnt => cardEnt.CardTopics.Select(ct => ct.Topic).ToList()));

            CreateMap<Topic, Entities.Topic>();
            CreateMap<Entities.Topic, Topic>()
                .ForMember(t => t.Cards, opt => opt.MapFrom(topEnt => topEnt.CardTopics.Select(ct => ct.Card).ToList()));
        }
    }
}
