﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IqmetrixBeerTap.Model;
using IQ.Platform.Framework.WebApi;

namespace IqmetrixBeerTap.ApiServices
{
    public interface IKegApiService :
          IGetAResourceAsync<Keg, int>,
        IGetManyOfAResourceAsync<Keg, int>,
        ICreateAResourceAsync<Keg, int>,
        IUpdateAResourceAsync<Keg, int>,
        IDeleteResourceAsync<Keg, int>
    {
    }
}
