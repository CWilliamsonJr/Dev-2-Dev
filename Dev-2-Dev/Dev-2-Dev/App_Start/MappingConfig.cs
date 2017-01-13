using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using AutoMapper;
using Dev_2_Dev.Models;
using Dev_2_Dev.ViewModels;

namespace Dev_2_Dev
{
    public class MappingConfig
    {
        public static void RegisterMaps()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<User, UserViewModel>().ReverseMap(); // maps users model to UserView Model and vise versa
            });
        }
    }
}