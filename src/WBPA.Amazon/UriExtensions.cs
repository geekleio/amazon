using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Amazon;
using Cuemon;

namespace WBPA.Amazon
{
    /// <summary>
    /// Extension methods for the <see cref="Uri"/> object.
    /// </summary>
    public static class UriExtensions
    {
        private static readonly Lazy<IEnumerable<RegionEndpoint>> LazyRegions = new Lazy<IEnumerable<RegionEndpoint>>(() =>
        {
            var fields = typeof(RegionEndpoint).GetFields(BindingFlags.Public | BindingFlags.Static).Where(fi => fi.FieldType == typeof(RegionEndpoint));
            return new List<RegionEndpoint>(fields.Select(fi => fi.GetValue(null) as RegionEndpoint));
        });


        /// <summary>
        /// Converts the specified <paramref name="endpoint"/> to its equivalent <see cref="RegionEndpoint"/>.
        /// </summary>
        /// <param name="endpoint">The <see cref="Uri"/> to convert.</param>
        /// <returns>A <see cref="RegionEndpoint"/> that is equivalent to the specified <paramref name="endpoint"/>; otherwise <c>null</c>.</returns>
        public static RegionEndpoint ToRegionEndpoint(this Uri endpoint)
        {
            return ToRegionEndpoint(endpoint, uri =>
            {
                return LazyRegions.Value.FirstOrDefault(re => endpoint.Host.ContainsAll(StringComparison.OrdinalIgnoreCase, re.SystemName));
            });
        }

        /// <summary>
        /// Converts the specified <paramref name="endpoint"/> to its equivalent <see cref="RegionEndpoint"/> representation.
        /// </summary>
        /// <param name="endpoint">The <see cref="Uri"/> to convert.</param>
        /// <param name="parser">The function delegate that will convert an <see cref="Uri"/> to its equivalent <see cref="RegionEndpoint"/>.</param>
        /// <returns>A <see cref="RegionEndpoint"/> that is equivalent to the specified <paramref name="endpoint"/>; otherwise <c>null</c>.</returns>
        public static RegionEndpoint ToRegionEndpoint(this Uri endpoint, Func<Uri, RegionEndpoint> parser)
        {
            Validator.ThrowIfNull(endpoint, nameof(endpoint));
            Validator.ThrowIfNull(parser, nameof(parser));
            return parser(endpoint);
        }
    }
}