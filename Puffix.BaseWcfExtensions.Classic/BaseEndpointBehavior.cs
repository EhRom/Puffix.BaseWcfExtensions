using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace Puffix.BaseWcfExtensions
{
    public abstract class BaseEndpointBehavior<InspectorT> : IEndpointBehavior, IBehavior<InspectorT>
            where InspectorT : IDispatchMessageInspector, IInspector, new()
    {
        public BaseEndpointBehavior()
        { }

        public virtual void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        { }

        public virtual void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        { }

        public virtual void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            endpointDispatcher.DispatchRuntime.MessageInspectors.Add(BuildInspector());
        }

        public virtual void Validate(ServiceEndpoint endpoint)
        { }

        protected virtual InspectorT BuildInspector()
        {
            return new InspectorT();
        }
    }
}
