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


namespace Store.Data
{

    // CusomerPhone
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.32.0.0")]
    public class CusomerPhone
    {
        public int CustomerId { get; set; } // CustomerId (Primary key)
        public string CustomerPhoneNumber { get; set; } // CustomerPhoneNumber (length: 10)
        public int CustomerPhoneId { get; set; } // CustomerPhoneId (Primary key)

        // Foreign keys

        /// <summary>
        /// Parent Customer pointed by [CusomerPhone].([CustomerId]) (Customer_CustomerPhone)
        /// </summary>
        public virtual Customer Customer { get; set; } // Customer_CustomerPhone
    }

}
// </auto-generated>
