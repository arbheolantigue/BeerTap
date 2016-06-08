using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IqmetrixBeerTap.Model;
using IQ.Platform.Framework.Common.Mapping;

namespace IqmetrixBeerTap.ApiServices.Mappers
{
    public class OfficeMapper: IMapper<Office, Domain.Model.Office>, IMapper<Domain.Model.Office, Office>
    {
        public Domain.Model.Office Map(Office source)
        {
            return new Domain.Model.Office
            {
                Id = source.Id,
                Name = source.Name,
                Description = source.Description
            };
        }

        public Office Map(Domain.Model.Office source)
        {
            return new Office
            {
                Id = source.Id,
                Name = source.Name,
                Description = source.Description
            };
        }
    }
}
