using AutoMapper;
using LinXiDecorate.Persons.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinXiDecorate.Persons
{
    public class PersonMapProfile : Profile
    {
        // Role and permission
        public PersonMapProfile()
        {
            CreateMap<CreatePersonDto, Person>();
            CreateMap<PersonDto, Person>();

            CreateMap<Person, PersonDto>();
            CreateMap<Person, CreatePersonDto>();
        }
    }
}
