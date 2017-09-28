using System;

namespace Store.DomainModel.DTOs.ProductDescription
{
    /// <summary>
    /// Present base product description for a XML (serialize/deserialize)
    /// </summary>
    public abstract class ProductDescriptionBaseDto
    {
        public int ProductId { get; set; }
        public DateTime DateOfEntry { get; set; }
        public string Type { get; set; }
        public string CaseColor { get; set; }
        public decimal Width { get; set; }
        public decimal Depth { get; set; }
        public decimal Thickness { get; set; }
        public decimal Weight { get; set; }
        public string[] Functions { get; set; }
        public string[] Functionality { get; set; }
        public string[] Options { get; set; }
    }
}
