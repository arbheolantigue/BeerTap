using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IqmetrixBeerTap.Model;
using IQ.Platform.Framework.WebApi;

namespace IqmetrixBeerTap.ApiServices
{
    public interface IGetABeerApiService : IUpdateAResourceAsync<GetABeer, int>
    {
    }
}
