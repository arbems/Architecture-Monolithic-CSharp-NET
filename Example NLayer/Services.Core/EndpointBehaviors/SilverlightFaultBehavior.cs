﻿using System;
using System.ServiceModel.Channels;
using System.ServiceModel.Configuration;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace Nlayer.Samples.NLayerApp.DistributedServices.Core.EndpointBehaviors
{

   /// <summary>
   ///    By default, WCF services return fault messages with an HTTP 500 response code.
   ///    Due to limitations in the browser networking stack, the bodies of these messages are inaccessible within
   ///    Silverlight,
   ///    and consequently the fault messages cannot be read by the client.
   ///    To send faults that will be accessible to a Silverlight client, a WCF service must modify the way it sends its fault
   ///    messages.
   ///    The key change needed is for WCF to return fault messages with an HTTP 200 response code instead of the HTTP 500
   ///    response code.
   ///    This change enables Silverlight to read the body of the message and also enables WCF clients of the same service to
   ///    continue
   ///    working using their normal fault-handling procedures.
   /// </summary>
   /// <remarks>
   ///    http://msdn.microsoft.com/en-us/library/ee844556%28VS.96%29.aspx
   /// </remarks>
   public class SilverlightFaultBehavior : BehaviorExtensionElement,
      IEndpointBehavior
   {

      public override Type BehaviorType
      {
         get
         {
            return typeof (SilverlightFaultBehavior);
         }
      }
      // The following methods are stubs and not relevant. 
      public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
      {
      }

      public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
      {
         var inspector = new SilverlightFaultMessageInspector();
         endpointDispatcher.DispatchRuntime.MessageInspectors.Add(inspector);
      }

      public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
      {
      }

      public void Validate(ServiceEndpoint endpoint)
      {
      }

      protected override object CreateBehavior()
      {
         return new SilverlightFaultBehavior();
      }

   }

}