using Abp.Application.Services;
using Abp.Application.Services.Dto;
using LinXiDecorate.Persons.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LinXiDecorate.Persons
{
    public interface IPersonAppService : IAsyncCrudAppService<
        PersonDto,
        int,
        PagedResultRequestDto,
        CreatePersonDto,
        PersonDto
        >
    {

    }
}
