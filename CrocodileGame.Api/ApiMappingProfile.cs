using AutoMapper;
using CrocodileGame.Api.Models;
using CrocodileGame.Api.ResourceModels;
using CrocodileGame.DataAccess.PostgreSQL.Migrations;
using CrocodileGame.Domain.Models;
using System.Linq;

namespace CrocodileGame.Api
{
    public class ApiMappingProfile : Profile
    {
        public ApiMappingProfile()
        {
            CreateMap<CardRequest, Card>();
            CreateMap<TopicRequest, Topic>();
            CreateMap<Card, CardInfoDto>();
            CreateMap<Topic, TopicInfoDto>();
            CreateMap<Card, CardDto>();
            CreateMap<Topic, TopicDto>();
        }
    }
}