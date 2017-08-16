using System;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;
using Cuemon;

namespace WBPA.Amazon.Runtime
{
    /// <summary>
    /// Extension methods for the <see cref="AmazonWebServiceRequest"/> object.
    /// </summary>
    public static class AmazonWebServiceRequestExtensions
    {
        /// <summary>
        /// Converts the specified <paramref name="request"/> to its equivalent AWS <see cref="IRequest"/>.
        /// </summary>
        /// <typeparam name="TMarshaller">The type of the AWS marshaller.</typeparam>
        /// <param name="request">The <see cref="AmazonWebServiceRequest"/> to convert.</param>
        /// <param name="marshaller">The marshaller that will convert the <paramref name="request"/> object to an AWS HTTP request.</param>
        /// <returns>An object implementing the <see cref="IRequest"/> interface.</returns>
        public static IRequest Marshall<TMarshaller>(this AmazonWebServiceRequest request, TMarshaller marshaller = null) where TMarshaller : class, IMarshaller<IRequest, AmazonWebServiceRequest>
        {
            Validator.ThrowIfNull(request, nameof(request));
            if (marshaller == null) { marshaller = Activator.CreateInstance<TMarshaller>(); }
            return marshaller.Marshall(request);
        }
    }
}