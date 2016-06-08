using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi.Model;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace IqmetrixBeerTap.Model
{
    public class GetABeer : IStatelessResource , IIdentifiable<int>
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public int OfficeId { get; set; }

        
    }
}
