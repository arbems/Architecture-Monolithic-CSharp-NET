//===================================================================================
// Microsoft Developer and Platform Evangelism
//=================================================================================== 
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
// OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//===================================================================================
// Copyright (c) Microsoft Corporation.  All Rights Reserved.
// This code is released under the terms of the MS-LPL license, 
// http://microsoftExampleNlayer.codeplex.com/license
//===================================================================================

namespace Microsoft.Samples.ExampleNlayer.Domain.MainBoundedContext.ERPModule.Aggregates.ProductAgg
{
    using Microsoft.Samples.ExampleNlayer.Domain.Seedwork;

    /// <summary>
    /// Base contract for product repository
    /// <see cref="Microsoft.Samples.ExampleNlayer.Domain.Seedwork.IRepository{Product}"/>
    /// </summary>
    public interface  IProductRepository
        :IRepository<Product>
    {
    }
}
