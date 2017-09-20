// <auto-generated>
// ReSharper disable ConvertPropertyToExpressionBody
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable InconsistentNaming
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable RedundantNameQualifier
// ReSharper disable RedundantOverridenMember
// ReSharper disable UseNameofExpression
// TargetFrameworkVersion = 4.6



#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning


namespace Store.Model.POCO_Entities
{

    // OrderProduct
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.32.0.0")]
    public class OrderProduct
    {
        public long OrderProductId { get; set; } // OrderProductId (Primary key)
        public long OrderProductNumber { get; set; } // OrderProductNumber
        public System.DateTime OrderProductDate { get; set; } // OrderProductDate
        public decimal OrderProductTotalQuantity { get; set; } // OrderProductTotalQuantity
        public decimal OrderProductTotalPrice { get; set; } // OrderProductTotalPrice
        public int CustomerId { get; set; } // CustomerId

        // Reverse navigation

        /// <summary>
        /// Child OrderDetails where [OrderDetails].[OrderProductId] point to this entity (OrderProduct_OrderDetails)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<OrderDetail> OrderDetails { get; set; } // OrderDetails.OrderProduct_OrderDetails

        // Foreign keys

        /// <summary>
        /// Parent Customer pointed by [OrderProduct].([CustomerId]) (Customer_OrderProduct)
        /// </summary>
        public virtual Customer Customer { get; set; } // Customer_OrderProduct

        public OrderProduct()
        {
            OrderDetails = new System.Collections.Generic.List<OrderDetail>();
        }
    }

}
// </auto-generated>