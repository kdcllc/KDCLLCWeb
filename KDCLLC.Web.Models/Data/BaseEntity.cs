using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDCLLC.Web.Models.Data
{
    public abstract class BaseEntity 
    {
        public BaseEntity()
        {
            CreatedAt = DateTime.Now;
        }

        [Key]
        public virtual int Id { get; set; }

        /// <summary>
        /// Default created date
        /// </summary>
        public virtual DateTime CreatedAt { get; set; }
    }
}
