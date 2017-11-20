﻿using System.Runtime.Serialization;

namespace DistributedServices.Core.ErrorHandlers
{

   /// <summary>
   ///    Default ServiceError
   /// </summary>
   [DataContract(Name = "ServiceError", Namespace = "Microsoft.Samples.DistributedServices.Core")]
   public class ApplicationServiceError
   {

      /// <summary>
      ///    Error message that flow to client services
      /// </summary>
      [DataMember(Name = "ErrorMessage")]
      public string ErrorMessage { get; set; }

   }

}