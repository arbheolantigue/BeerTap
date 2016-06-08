using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IqmetrixBeerTap.Model;
using IQ.Platform.Framework.Common.Mapping;

namespace IqmetrixBeerTap.ApiServices.Mappers
{
    public class KegMapper : IMapper<Domain.Model.Keg, Keg>
    {
        public Keg Map(Domain.Model.Keg source)
        {
            return new Keg()
            {
                Id = source.Id,
                Container = source.Container,
                KegState = GetKegState(source.Container),
                Name = source.Name,
                OfficeId = source.OfficeId
            };
        }
        
        public static KegState GetKegState(decimal currentAmount)
        {
            if (currentAmount <= 100 && currentAmount >= 71)
                return KegState.New;

            if (currentAmount <= 70 && currentAmount >= 31)
                return KegState.GoinDown;

            if (currentAmount <= 30 && currentAmount >= 10)
                return KegState.AlmostEmpty;

            return KegState.SheIsDryMate;
        }
    }
}
