﻿using AutoMapper;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidley.Dtos;
using Vidley.Models;

namespace Vidley.App_Start //the automapper must be initialized in the console using install-package automapper -version 4.1
{
    public class MapingProfile : Profile //uses the Profile interface from teh AutoMapper namespace
    {
        public MapingProfile() //the construtor method for the mapping profile
        {
            Mapper.CreateMap<Customer, CustomerDto>(); //the generic method for maping subjects to target. The first object in the <> is the source, while the second object is the target that is being mapped to from the source
            Mapper.CreateMap<CustomerDto, Customer>().ForMember(c => c.Id, opt => opt.Ignore()); ; //vice versa
            Mapper.CreateMap<MovieDto, Movie>().ForMember(m => m.Id, opt => opt.Ignore());
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<MembershipTypeDto, MembershipType>().ForMember(m => m.Id, opt => opt.Ignore());
            Mapper.CreateMap<Genre, GenreDto>();
            Mapper.CreateMap<GenreDto, Genre>().ForMember(m => m.Id, opt => opt.Ignore());
        } //auto mapper uses the property names of the objects to map them 
    }
}
// This mapping profile is initialized in the Global.asax folder as  Mapper.Initialize(c => c.AddProfile<MapingProfile>())