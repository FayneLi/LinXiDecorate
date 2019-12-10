using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LinXiDecorate.Persons
{
    public class Person: Entity<int>, IHasCreationTime
    {
        public Person()
        {
            this.Name = string.Empty;
            CreationTime = DateTime.Now;
        }

        [StringLength(50)]
        public virtual string Name { get; set; }

        public virtual DateTime CreationTime { get; set; }


    }
}
