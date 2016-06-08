using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi.AspNet;
using IQ.Platform.Framework.WebApi.Services.Security;

namespace IqmetrixBeerTap.ApiServices.Security
{

    public class IqmetrixBeerTapApiUser : ApiUser<UserAuthData>
    {
        public IqmetrixBeerTapApiUser(string name, Option<UserAuthData> authData)
            : base(authData)
        {
            Name = name;
        }

        public string Name { get; private set; }

    }

    public class IqmetrixBeerTapUserFactory : ApiUserFactory<IqmetrixBeerTapApiUser, UserAuthData>
    {
        public IqmetrixBeerTapUserFactory() :
            base(new HttpRequestDataStore<UserAuthData>())
        {
        }

        protected override IqmetrixBeerTapApiUser CreateUser(Option<UserAuthData> auth)
        {
            return new IqmetrixBeerTapApiUser("IqmetrixBeerTap user", auth);
        }
    }

}
