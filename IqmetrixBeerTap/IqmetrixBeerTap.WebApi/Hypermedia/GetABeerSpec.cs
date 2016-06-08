using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IqmetrixBeerTap.ApiServices;
using IqmetrixBeerTap.Model;
using IQ.Platform.Framework.WebApi.CacheControl;
using IQ.Platform.Framework.WebApi.Hypermedia;
using IQ.Platform.Framework.WebApi.Hypermedia.Specs;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace IqmetrixBeerTap.WebApi.Hypermedia
{
    public class GetABeerSpec : SingleStateResourceSpec<GetABeer,int>
    {
        public static ResourceUriTemplate Uri = ResourceUriTemplate.Create("Offices({OfficeId})/Kegs({Id})/GetBeer");

        public override IResourceStateSpec<GetABeer, NullState, int> StateSpec
        {
            get
            {
                return
                    new SingleStateSpec<GetABeer, int>
                    {
                        Operations = new StateSpecOperationsSource<GetABeer, int>
                        {
                            Post = ServiceOperations.Update
                        }
                    };
            }
        }
        protected override IEnumerable<ResourceLinkTemplate<GetABeer>> Links()
        {
            yield return
                CreateLinkTemplate(CommonLinkRelations.Self, Uri, c => c.OfficeId,
                    c => c.Id);
        }

    }
}