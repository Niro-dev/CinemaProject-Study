using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using CinemaProject.Dtos;
using CinemaProject.Models;

namespace CinemaProject.App_Start
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            // Domain to Dto
            Mapper.CreateMap<Customer, CustomerDto>(); Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>(); Mapper.CreateMap<Movie, MovieDto>();


            // Dto to Domain
            Mapper.CreateMap<CustomerDto, Customer>()
                .ForMember(c => c.CustomerUserId, opt => opt.Ignore());

            Mapper.CreateMap<MovieDto, Movie>()
                .ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}