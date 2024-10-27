using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
	public class AppRole
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public List<AppUser> AppUsers { get; set; }
    }
}
