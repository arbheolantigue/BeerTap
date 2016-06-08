using IQ.Platform.Framework.WebApi.AspNet;
using IQ.Platform.Framework.WebApi.AspNet.Handlers;
using IQ.Platform.Framework.WebApi.Services.Security;
using IqmetrixBeerTap.ApiServices.Security;

namespace IqmetrixBeerTap.WebApi.Handlers
{
    public class PutYourApiSafeNameUserContextProvidingHandler
            : ApiSecurityContextProvidingHandler<IqmetrixBeerTapApiUser, NullUserContext>
    {

        public PutYourApiSafeNameUserContextProvidingHandler(
            IStoreDataInHttpRequest<IqmetrixBeerTapApiUser> apiUserInRequestStore)
            : base(new IqmetrixBeerTapUserFactory(), CreateContextProvider(), apiUserInRequestStore)
        {
        }

        static ApiUserContextProvider<IqmetrixBeerTapApiUser, NullUserContext> CreateContextProvider()
        {
            return
                new ApiUserContextProvider<IqmetrixBeerTapApiUser, NullUserContext>(_ => new NullUserContext());
        }
    }
}