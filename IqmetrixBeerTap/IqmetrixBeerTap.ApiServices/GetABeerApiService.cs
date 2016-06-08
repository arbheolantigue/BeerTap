using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using IqmetrixBeerTap.Domain.Controller;
using IqmetrixBeerTap.Model;
using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi;

namespace IqmetrixBeerTap.ApiServices
{
    public class GetABeerApiService : IGetABeerApiService
    {
        private readonly IKegService _getABeer;

        public GetABeerApiService(IKegService getABeer)
        {
            _getABeer = getABeer;
        }
        public Task<GetABeer> UpdateAsync(GetABeer resource, IRequestContext context, CancellationToken cancellation)
        {
            var officeId = GetOfficeId(context);
            resource.Amount = _getABeer.GetBeer(resource.Id, resource.Amount, officeId);
            resource.OfficeId = officeId;
            return Task.FromResult(resource);
        }
        private int GetOfficeId(IRequestContext context)
        {
            var officeid = context.UriParameters.GetByName<int>("OfficeId").EnsureValue();
            var linkParameter = new KegLinkParameter(officeid);
            context.LinkParameters.Set(linkParameter);
            return officeid;
        }
    }
}
