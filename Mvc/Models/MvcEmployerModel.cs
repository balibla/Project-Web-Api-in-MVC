using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc.Models
{
    public class MvcEmployerModel
    {
        public int EmployerId { get; set; }
        [Required(ErrorMessage = "Required Field")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Required Field")]

        public string Position { get; set; }
        [Required(ErrorMessage = "Required Field")]

        public Nullable<int> Age { get; set; }
        [Required(ErrorMessage = "Required Field")]

        public Nullable<int> Salary { get; set; }
    }
}