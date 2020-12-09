using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace Puffix.BaseWcfExtensions
{
    public class BaseClientAndEnpointBehavior<InspectorT> : IEndpointBehavior, IBehavior<InspectorT>
           where InspectorT : IClientMessageInspector, IDispatchMessageInspector, IInspector, new()
    {
        public BaseClientAndEnpointBehavior()
        { }

        public virtual void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        { }

        public virtual void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            clientRuntime.ClientMessageInspectors.Add(BuildInspector());
        }

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
