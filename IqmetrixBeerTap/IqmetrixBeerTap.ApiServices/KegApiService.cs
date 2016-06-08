using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using IqmetrixBeerTap.Domain.Controller;
using IqmetrixBeerTap.Model;
using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.Common.Mapping;
using IQ.Platform.Framework.WebApi;
using IQ.Platform.Framework.WebApi.Services.Mapping;

namespace IqmetrixBeerTap.ApiServices
{
    public class KegApiService : IKegApiService
    {
        private readonly IKegService _kegService;
        private readonly IMapper<Domain.Model.Keg, Keg> _toResourceMapper;
        private readonly IMapper<Keg, Domain.Model.Keg> _toEntityMapper;
        public KegApiService(IKegService kegService,
            IMapper<Domain.Model.Keg, Keg> toResourceMapper,
            IMapperFactory mapper)
        {
            _kegService = kegService;
            _toResourceMapper = toResourceMapper;
            _toEntityMapper = mapper.Create<Keg, Domain.Model.Keg>();
        }
        public Task<Keg> GetAsync(int id, IRequestContext context, CancellationToken cancellation)
        {
            var officeId = GetOfficeId(context);
            var keg = _kegService.GetByKegId(id, officeId);
            return Task.FromResult(_toResourceMapper.Map(keg));
        }

        public Task<IEnumerable<Keg>> GetManyAsync(IRequestContext context, CancellationToken cancellation)
        {
            var officeId = GetOfficeId(context);
            return Task.FromResult(_kegService.GetAllByOffice(officeId).Select(k => _toResourceMapper.Map(k)));
        }

        public Task<ResourceCreationResult<Keg, int>> CreateAsync(Keg resource, IRequestContext context, CancellationToken cancellation)
        {
            var officeId = GetOfficeId(context);
            var keg =_kegService.AddKeg(officeId, _toEntityMapper.Map(resource));
            return Task.FromResult(new ResourceCreationResult<Keg, int>(_toResourceMapper.Map(keg)));
        }

        public Task<Keg> UpdateAsync(Keg resource, IRequestContext context, CancellationToken cancellation)
        {
            var newKeg = _kegService.Update(_toEntityMapper.Map(resource));
            return Task.FromResult(_toResourceMapper.Map(newKeg));
        }

        public Task DeleteAsync(ResourceOrIdentifier<Keg, int> input, IRequestContext context, CancellationToken cancellation)
        {
            GetOfficeId(context);
            _kegService.Delete(input.Id);
            return TaskHelper.GetCompleted();
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
