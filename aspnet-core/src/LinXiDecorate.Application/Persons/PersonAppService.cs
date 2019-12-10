using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.IdentityFramework;
using Abp.Linq.Extensions;
using LinXiDecorate.Authorization;
using LinXiDecorate.Authorization.Roles;
using LinXiDecorate.Authorization.Users;
using LinXiDecorate.Persons.Dto;
using LinXiDecorate.Roles.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LinXiDecorate.Persons
{
    public class PersonAppService : AsyncCrudAppService<Person, PersonDto, int, PagedResultRequestDto,
        CreatePersonDto, PersonDto>, IPersonAppService
    {


        public PersonAppService(IRepository<Person,int> repository):base(repository)
        {

        }

        public override async Task<PersonDto> CreateAsync(CreatePersonDto input)
        {
            //var person = ObjectMapper.Map<Person>(input);
            try
            {
                PersonDto person = await base.CreateAsync(input);
                return person;

            }
            catch (System.Exception ex)
            {

                throw ex;
            }


            //var sin = updateDto;
            //return base.CreateAsync(sin);
        }

        public override async Task<PersonDto> UpdateAsync(PersonDto input)
        {


            return await base.UpdateAsync(input);
        }
    }
}
