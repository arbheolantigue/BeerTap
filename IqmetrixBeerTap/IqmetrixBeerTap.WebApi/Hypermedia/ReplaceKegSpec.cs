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
    public class ReplaceKegSpec : SingleStateResourceSpec<ReplaceKeg, int>
    {
        public static ResourceUriTemplate Uri = ResourceUriTemplate.Create("Offices({OfficeId})/Kegs({Id})/ReplaceKeg");

        public override IResourceStateSpec<ReplaceKeg, NullState, int> StateSpec
        {
            get
            {
                return
                    new SingleStateSpec<ReplaceKeg, int>
                    {
                        Operations = new StateSpecOperationsSource<ReplaceKeg, int>
                        {
                            Post = ServiceOperations.Update
                        }
                    };
            }
        }
        protected override IEnumerable<ResourceLinkTemplate<ReplaceKeg>> Links()
        {
            yield return
                CreateLinkTemplate(CommonLinkRelations.Self, Uri, c => c.OfficeId,
                    c => c.Id);
        }
    }
}