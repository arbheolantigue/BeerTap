using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using IQ.Platform.Framework.WebApi;
using IqmetrixBeerTap.Domain.Controller;
using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.Common.Mapping;
using myOffice = IqmetrixBeerTap.Domain.Model.Office;
using Office = IqmetrixBeerTap.Model.Office;

namespace IqmetrixBeerTap.ApiServices
{
    public class OfficeApiService : IOfficeApiService
    {
        private readonly IOfficeService _officeService;
        private readonly IMapper<myOffice, Office> _toResourceMapper;
        private readonly IMapper<Office, myOffice> _toEntityMapper;
      
        public OfficeApiService(
            IOfficeService officeService,
            IMapper<myOffice, Office> toResourceMapper
            ,IMapper<Office, myOffice> toEntityMapper)
        {
            _officeService = officeService;
            _toResourceMapper = toResourceMapper;
            _toEntityMapper = toEntityMapper;
        }

        public Task<IEnumerable<Office>> GetManyAsync(IRequestContext context, CancellationToken cancellation)
        {
            return Task.FromResult(_officeService.GetAll().Select(o => _toResourceMapper.Map(o)));
        }

        public Task<ResourceCreationResult<Office, int>> CreateAsync(Office resource, IRequestContext context, CancellationToken cancellation)
        {
            var newOffice =_officeService.Insert(_toEntityMapper.Map(resource));
            resource.Id = newOffice.Id;
            return Task.FromResult(new ResourceCreationResult<Office, int>(resource));
        }

        public Task<Office> UpdateAsync(Office resource, IRequestContext context, CancellationToken cancellation)
        {
             _officeService.Update(_toEntityMapper.Map(resource));
            return Task.FromResult(resource);
        }

        public Task DeleteAsync(ResourceOrIdentifier<Office, int> input, IRequestContext context, CancellationToken cancellation)
        {
            _officeService.Delete(input.Id);
            return TaskHelper.GetCompleted();
        }

        public Task<Office> GetAsync(int id, IRequestContext context, CancellationToken cancellation)
        {
            var office = _officeService.GetById(id);
            return Task.FromResult(_toResourceMapper.Map(office));
        }
    }
}
