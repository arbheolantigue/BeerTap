using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IqmetrixBeerTap.Domain.Model
{
    public class Keg
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Container { get; set; }
        public int OfficeId { get; set; }
    }
}
