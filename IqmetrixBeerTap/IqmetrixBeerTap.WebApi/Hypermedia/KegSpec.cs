using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IqmetrixBeerTap.ApiServices;
using IqmetrixBeerTap.Model;
using IQ.Platform.Framework.WebApi.Hypermedia;
using IQ.Platform.Framework.WebApi.Hypermedia.Specs;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace IqmetrixBeerTap.WebApi.Hypermedia
{
    public class KegSpec : ResourceSpec<Keg, KegState, int>
    {
        public static ResourceUriTemplate Uri = ResourceUriTemplate.Create("Offices({OfficeId})/Kegs({Id})");

        protected override IEnumerable<ResourceLinkTemplate<Keg>> Links()
        {
            yield return CreateLinkTemplate<KegLinkParameter>(CommonLinkRelations.Self, Uri, c => c.Parameters.OfficeId, c => c.Resource.Id);
        }
        protected override IEnumerable<IResourceStateSpec<Keg, KegState, int>> GetStateSpecs()
        {
            yield return new ResourceStateSpec<Keg, KegState, int>(KegState.New)
            {
                Links =
                {
                    CreateLinkTemplate<KegLinkParameter>(LinkRelations.Kegs.getABeer, GetABeerSpec.Uri, c => c.Parameters.OfficeId, c => c.Resource.Id)
                },
                Operations = 
                {
                    Get = ServiceOperations.Get,
                    InitialPost = ServiceOperations.Create,
                    Post = ServiceOperations.Update,
                    Put = ServiceOperations.Update,
                    Delete = ServiceOperations.Delete
                }
            };
            yield return new ResourceStateSpec<Keg, KegState, int>(KegState.GoinDown)
            {
                Links =
                {
                    CreateLinkTemplate<KegLinkParameter>(LinkRelations.Kegs.getABeer, GetABeerSpec.Uri, c => c.Parameters.OfficeId, c => c.Resource.Id)
                },
                Operations = 
                {
                    Get = ServiceOperations.Get,
                    InitialPost = ServiceOperations.Create,
                    Post = ServiceOperations.Update,
                    Put = ServiceOperations.Update,
                    Delete = ServiceOperations.Delete
                }
            };
            yield return new ResourceStateSpec<Keg, KegState, int>(KegState.AlmostEmpty)
            {
                Links =
                {
                    CreateLinkTemplate<KegLinkParameter>(LinkRelations.Kegs.replaceKeg, ReplaceKegSpec.Uri, c => c.Parameters.OfficeId, c => c.Resource.Id),
                    CreateLinkTemplate<KegLinkParameter>(LinkRelations.Kegs.getABeer, GetABeerSpec.Uri, c => c.Parameters.OfficeId, c => c.Resource.Id)
                },
                Operations = new StateSpecOperationsSource<Keg, int>()
                {
                    Get = ServiceOperations.Get,
                    InitialPost = ServiceOperations.Create,
                    Post = ServiceOperations.Update,
                    Put = ServiceOperations.Update,
                    Delete = ServiceOperations.Delete
                }
            };
            yield return new ResourceStateSpec<Keg, KegState, int>(KegState.SheIsDryMate)
            {
                Links =
                {
                    CreateLinkTemplate<KegLinkParameter>(LinkRelations.Kegs.replaceKeg, ReplaceKegSpec.Uri, c => c.Parameters.OfficeId, c => c.Resource.Id)
                },
                Operations = new StateSpecOperationsSource<Keg, int>()
                {
                    Get = ServiceOperations.Get,
                    InitialPost = ServiceOperations.Create,
                    Post = ServiceOperations.Update,
                    Put = ServiceOperations.Update,
                    Delete = ServiceOperations.Delete
                }
            };
        }


    }
}