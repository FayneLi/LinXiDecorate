using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LinXiDecorate.Persons.Dto
{
    public class PersonDto : EntityDto<int>
    {
        [StringLength(50)]
        public string Name { get; set; }

        public DateTime CreationTime { get; set; }
    }
}
