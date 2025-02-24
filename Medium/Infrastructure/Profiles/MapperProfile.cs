using AutoMapper;
using Domain.DTOs.ArticleDTOs;
using Domain.DTOs.AuthDTOS;
using Domain.DTOs.CommentDTOs;
using Domain.DTOs.ReactionDTOs;
using Domain.DTOs.SubscriptionDTOs;
using Domain.DTOs.UserDTOs;
using Domain.Entities;

namespace Infrastructore.Profiles;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<CreateArticleDTO,Article>();
        CreateMap<UpdateArticleDTO,Article>();
        CreateMap<Article,GetArticleDTO>();

        CreateMap<UpdateUserDTO,User>();
        CreateMap<User,GetUserDTO>();

        CreateMap<CreateCommentDTO,Comment>();
        CreateMap<UpdateCommentDTO,Comment>();
        CreateMap<Comment,GetCommentDTO>();

        CreateMap<CreateReactionDTO,Reaction>();
        CreateMap<UpdateReactionDTO,Reaction>();
        CreateMap<Reaction,GetReactionDTO>();

        CreateMap<CreateSubscriptionDTO,Subscription>();
        CreateMap<UpdateSubscriptionDTO,Subscription>();
        CreateMap<Subscription,GetSubscriptionDTO>();
    }
}
