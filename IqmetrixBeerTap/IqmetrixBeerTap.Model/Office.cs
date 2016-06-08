using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace IqmetrixBeerTap.Model
{
    /// <summary>
    /// A Sample Resource, used as a placeholder. To be removed after real-world API resources have been added.
    /// </summary>
    public class Office : IStatelessResource, IIdentifiable<int>
    {
        /// <summary>
        /// Unique Identifier for the Office
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name for the Office
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description for the Office
        /// </summary>
        public string Description { get; set; }
        
    }
}
