using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using IqmetrixBeerTap.ApiServices.Mappers;
using IqmetrixBeerTap.Domain.Controller;
using IqmetrixBeerTap.Model;
using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi;

namespace IqmetrixBeerTap.ApiServices
{
    public class ReplaceKegApiService : IReplaceKegApiServices
    {
        private readonly IKegService _replacekeg;

        public ReplaceKegApiService(IKegService replacekeg)
        {
            _replacekeg = replacekeg;
        }
        public Task<ReplaceKeg> UpdateAsync(ReplaceKeg resource, IRequestContext context, CancellationToken cancellation)
        {
            var officeId = GetOfficeId(context);
            var id = context.UriParameters.GetByName<int>("Id").EnsureValue();
            var newResource = _replacekeg.ReplaceKeg(id, officeId);
            resource = resource ?? new ReplaceKeg();
            resource.Id = newResource.Id;
            resource.Amount = newResource.Container;
            resource.OfficeId = newResource.OfficeId;
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
