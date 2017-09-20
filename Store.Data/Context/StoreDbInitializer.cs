using System;
using System.Data.Entity;
using System.Linq;
using Store.Model.POCO_Entities;
using Store.Model.POCO_Entities;

namespace Store.Data.Context
{
    public class StoreDbInitializer : IDatabaseInitializer<StoreDbContext>
    {
        public void InitializeDatabase(StoreDbContext context)
        {
            if (context.Database.Exists())
            {
                if (context.Customers.Count() == 0)
                {
                    Customer alex = new Customer
                    {
                        CustomerName = "Alex",
                        CustomerLastName = "Black",
                        CustomerEmail = "alex@gmail.com",
                        CustomerAddress = "main street, 12-222",
                        CustomerCity = "New York",
                        CustomerRegion = "New York",
                        CustomerCountry = "USA"
                    };

                    Customer alexEntity = context.Customers.Add(alex);

                    Customer ivan = new Customer
                    {
                        CustomerName = "Ivan",
                        CustomerLastName = "Petrov",
                        CustomerEmail = "ivan@mail.com",
                        CustomerAddress = "leninskaya street, 22-45",
                        CustomerCity = "Moscow",
                        CustomerRegion = "Moscow",
                        CustomerCountry = "Russia"
                    };

                    Customer ivanEntity = context.Customers.Add(ivan);

                    CustomerPhone ivanPhoneNumber = new CustomerPhone
                    {
                        Customer = ivanEntity,
                        CustomerId = ivanEntity.CustomerId,
                        CustomerPhoneNumber = "+375886167618"
                    };

                    CustomerPhone alexPhoneNumber = new CustomerPhone
                    {
                        Customer = alexEntity,
                        CustomerId = alexEntity.CustomerId,
                        CustomerPhoneNumber = "+375586543618"
                    };

                    context.CusomerPhones.AddRange(new[] { ivanPhoneNumber, alexPhoneNumber });
                    context.SaveChanges();
                }

                if (context.Products.Count() == 0)
                {
                    // Forced deletion if data exists
                    context.Database.ExecuteSqlCommand("DELETE FROM ProductBrand");
                    // Brands
                    ProductBrand hpBrand = new ProductBrand
                    {
                        ProductBrandName = "HP",
                        ProductBrandCountry = "USA"
                    };
                    
                    ProductBrand hpBrandEntity = context.ProductBrands.Add(hpBrand);

                    ProductBrand appleBrand = new ProductBrand
                    {
                        ProductBrandName = "Apple",
                        ProductBrandCountry = "USA"
                    };

                    ProductBrand appleBrandEntity = context.ProductBrands.Add(appleBrand);

                    // Forced deletion if data exists
                    context.Database.ExecuteSqlCommand("DELETE FROM ProductManufacturer");
                    // Manufacturers
                    ProductManufacturer productManufacturer = new ProductManufacturer
                    {
                        ProductManufacturerCountry = "USA"
                    };

                    ProductManufacturer productManufacturerEntity =
                        context.ProductManufacturers.Add(productManufacturer);

                    // Forced deletion if data exists
                    context.Database.ExecuteSqlCommand("DELETE FROM ProductCategory");
                    // Categories
                    ProductCategory computerEquipment = new ProductCategory
                    {
                        ProductCategoryName = "Computer equipment"
                    };

                    ProductCategory computerEquipmentEntity =
                        context.ProductCategories.Add(computerEquipment);

                    // Forced deletion if data exists
                    context.Database.ExecuteSqlCommand("DELETE FROM ProductSubCategory");
                    // SubCategories
                    ProductSubCategory subCategoryNotebooks = new ProductSubCategory
                    {
                        ProductCategory = computerEquipment,
                        ProductCategoryId = computerEquipment.ProductCategoryId,
                        ProductSubCategoryName = "Notebooks"
                    };

                    ProductSubCategory subCategoryNotebooksEntity =
                        context.ProductSubCategories.Add(subCategoryNotebooks);

                    #region Image as base64 string

                    byte[] imageHp6735s = Convert.FromBase64String(
                        @"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");

                    #endregion

                    Product productNotebookHp = new Product
                    {
                        ProductName = "hp6735s",
                        ProductBrand = hpBrandEntity,
                        ProductBrandId = hpBrandEntity.ProductBrandId,
                        ProductPrice = 615.72m,
                        ProductImage = imageHp6735s,
                        ProductDescription = "Good notebook.",
                        ProductQuanity = 15,
                        ProductCode = "6735s-HS82753-21",
                        ProductDiscount = null, //no discount
                        ProductManufacturer = productManufacturerEntity,
                        ProductManufacturerId = productManufacturerEntity.ProductManufacturerId,
                        ProductCategoryId = computerEquipmentEntity.ProductCategoryId,
                        ProductSubCategory = subCategoryNotebooksEntity,
                        ProductSubCategoryId = subCategoryNotebooksEntity.ProductSubCategoryId
                    };

                    #region Image as base64 string

                    byte[] imageMacBook = Convert.FromBase64String(@"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");

                    #endregion

                    Product productNotebookApple = new Product
                    {
                        ProductName = "macbook air",
                        ProductBrand = appleBrandEntity,
                        ProductBrandId = appleBrandEntity.ProductBrandId,
                        ProductPrice = 1618.00m,
                        ProductImage = imageMacBook,
                        ProductDescription = "Good notebook. Very good.",
                        ProductQuanity = 180,
                        ProductCode = "air-HOKJ853-20",
                        ProductDiscount = 20, // 20 percent discount
                        ProductManufacturer = productManufacturerEntity,
                        ProductManufacturerId = productManufacturerEntity.ProductManufacturerId,
                        ProductCategoryId = computerEquipmentEntity.ProductCategoryId,
                        ProductSubCategory = subCategoryNotebooksEntity,
                        ProductSubCategoryId = subCategoryNotebooksEntity.ProductSubCategoryId
                    };

                    context.Products.AddRange(new[] { productNotebookHp, productNotebookApple });
                    context.SaveChanges();
                }
            }
        }
    }
}
