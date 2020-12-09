using System;
using System.ServiceModel.Configuration;

namespace Puffix.BaseWcfExtensions
{
    public abstract class BaseExtensionElement<BehaviorT, InspectorT> : BehaviorExtensionElement
            where BehaviorT : IBehavior<InspectorT>, new()
            where InspectorT : IInspector, new()
    {
        public override Type BehaviorType
        {
            get { return typeof(BehaviorT); }
        }

        public BaseExtensionElement()
        { }

        protected override object CreateBehavior()
        {
            return new BehaviorT();
        }
    }
}
