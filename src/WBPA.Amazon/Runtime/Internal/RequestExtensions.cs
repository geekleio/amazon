using Amazon.Runtime.Internal;

namespace WBPA.Amazon.Runtime.Internal
{
    /// <summary>
    /// Extension methods for the <see cref="IRequest"/> interface.
    /// </summary>
    public static class RequestExtensions
    {
        /// <summary>
        /// Gets the approximate message size of the AWS HTTP <paramref name="request"/>.
        /// </summary>
        /// <param name="request">The AWS HTTP request object to parse.</param>
        /// <returns>An approximate message size of the data being transfered to AWS.</returns>
        public static int GetApproximateMessageSize(this IRequest request)
        {
            if (request == null) { return 0; }
            int size = 0;
            foreach (var item in request.Parameters)
            {
                size += item.Key.Length;
                size += item.Value.Length;
            }
            return size;
        }
    }
}