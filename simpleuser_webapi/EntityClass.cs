using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDAL
{
        public class User
        {
            [Key]
            public int Uid { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }

        }   
}
