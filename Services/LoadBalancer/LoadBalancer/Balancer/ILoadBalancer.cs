namespace LoadBalancer.Balancer
{
    public interface ILoadBalancer
    {
        /// <summary>
        /// Returns the service, which should be the next service
        /// to receive an request.
        /// </summary>
        /// <returns></returns>
        IServiceOptions Next();
    }
}
