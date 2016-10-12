using AutoMapper;
using Marina.Data;
using Marina.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marina.Web.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<Person, PersonViewModel>();
        }
    }
}