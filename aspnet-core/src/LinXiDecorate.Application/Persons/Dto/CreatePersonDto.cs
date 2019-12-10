using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LinXiDecorate.Persons.Dto
{
    public class CreatePersonDto
    {
        [StringLength(50)]
        public string Name { get; set; }

        public DateTime CreationTime { get; set; }
    }
}
