using System;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using Store.Model.POCO_Entities;

namespace Store.Data.Context
{
    public class StoreDbInitializer : IDatabaseInitializer<StoreDbContext>
    {
        public void InitializeDatabase(StoreDbContext context)
        {
            //string imageOriginalPath = ConfigurationManager.AppSettings["ImageOriginalPath"];
            //string imageCroppedPath = ConfigurationManager.AppSettings["ImageCroppedPath"];

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
                    context.Database.ExecuteSqlCommand("DELETE FROM ProductSubCategory");
                    // Forced deletion if data exists
                    context.Database.ExecuteSqlCommand("DELETE FROM ProductCategory");

                    // Categories
                    ProductCategory computerEquipment = new ProductCategory
                    {
                        ProductCategoryName = "Computer equipment"
                    };

                    ProductCategory computerEquipmentEntity =
                        context.ProductCategories.Add(computerEquipment);

                    // SubCategories
                    ProductSubCategory subCategoryNotebooks = new ProductSubCategory
                    {
                        ProductCategory = computerEquipment,
                        ProductCategoryId = computerEquipment.ProductCategoryId,
                        ProductSubCategoryName = "Notebooks"
                    };

                    ProductSubCategory subCategoryNotebooksEntity =
                        context.ProductSubCategories.Add(subCategoryNotebooks);

                    Product productNotebookHp6735S = new Product
                    {
                        ProductName = "hp6735s",
                        ProductBrand = hpBrandEntity,
                        ProductBrandId = hpBrandEntity.ProductBrandId,
                        ProductPrice = 615.72m,
                        ProductImageName = "hp6735s",
                        ProductImageMimeType = "image/jpeg",
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

                    Product productNotebookAppleMacBookPro15TouchBar2016 = new Product
                    {
                        ProductName = "Macbook Air Pro 15'' TouchBar (2016 year)",
                        ProductBrand = appleBrandEntity,
                        ProductBrandId = appleBrandEntity.ProductBrandId,
                        ProductPrice = 1618.00m,
                        ProductImageName = "AppleMacBookPro15TouchBar2016",
                        ProductImageMimeType = "image/jpeg",
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

                    Product productNotebookHpPavilionDv6 = new Product
                    {
                        ProductName = "HP Pavilion dv6",
                        ProductBrand = hpBrandEntity,
                        ProductBrandId = hpBrandEntity.ProductBrandId,
                        ProductPrice = 895m,
                        ProductImageName = "PavilionDv6-6b53er",
                        ProductImageMimeType = "image/jpeg",
                        ProductDescription = "Good Pavilion notebook.",
                        ProductQuanity = 25,
                        ProductCode = "Pavilion-dv6-HS32751-51",
                        ProductDiscount = 15, // 15 percent discount
                        ProductManufacturer = productManufacturerEntity,
                        ProductManufacturerId = productManufacturerEntity.ProductManufacturerId,
                        ProductCategoryId = computerEquipmentEntity.ProductCategoryId,
                        ProductSubCategory = subCategoryNotebooksEntity,
                        ProductSubCategoryId = subCategoryNotebooksEntity.ProductSubCategoryId
                    };

                    Product productNotebookHpEnvy = new Product
                    {
                        ProductName = "Hp Envy 13 AD011UR",
                        ProductBrand = hpBrandEntity,
                        ProductBrandId = hpBrandEntity.ProductBrandId,
                        ProductPrice = 950.54m,
                        ProductImageName = "HpENVY13-ad011ur",
                        ProductImageMimeType = "image/png",
                        ProductDescription = "Good HP ENVY is a good notebook.",
                        ProductQuanity = 59,
                        ProductCode = "Envy-13-ad011ur-1WS57EA-71",
                        ProductDiscount = 5, // 5 percent discount
                        ProductManufacturer = productManufacturerEntity,
                        ProductManufacturerId = productManufacturerEntity.ProductManufacturerId,
                        ProductCategoryId = computerEquipmentEntity.ProductCategoryId,
                        ProductSubCategory = subCategoryNotebooksEntity,
                        ProductSubCategoryId = subCategoryNotebooksEntity.ProductSubCategoryId
                    };

                    Product productNotebookHpProBook440G4 = new Product
                    {
                        ProductName = "HP ProBook 440 G4",
                        ProductBrand = hpBrandEntity,
                        ProductBrandId = hpBrandEntity.ProductBrandId,
                        ProductPrice = 1250.14m,
                        ProductImageName = "HpProBook440G4",
                        ProductImageMimeType = "image/png",
                        ProductDescription = "Good HP ProBook 440 G4 notebook.",
                        ProductQuanity = 180,
                        ProductCode = "HP-ProBook440-G4-Z3A12ES-21",
                        ProductDiscount = 5, // 5 percent discount
                        ProductManufacturer = productManufacturerEntity,
                        ProductManufacturerId = productManufacturerEntity.ProductManufacturerId,
                        ProductCategoryId = computerEquipmentEntity.ProductCategoryId,
                        ProductSubCategory = subCategoryNotebooksEntity,
                        ProductSubCategoryId = subCategoryNotebooksEntity.ProductSubCategoryId
                    };

                    Product productNotebookAppleMacBookPro15Retina = new Product
                    {
                        ProductName = "Apple MacBook Pro 15'' Retina (2015 year)",
                        ProductBrand = appleBrandEntity,
                        ProductBrandId = appleBrandEntity.ProductBrandId,
                        ProductPrice = 1250.14m,
                        ProductImageName = "AppleMacBookPro15Retina2015",
                        ProductImageMimeType = "image/jpeg",
                        ProductDescription = "Good Apple MacBook Pro 15'' Retina notebook.",
                        ProductQuanity = 255,
                        ProductCode = "Apple-MacBook-Pro15G4-MJLQ2-09",
                        ProductDiscount = 5, // 5 percent discount
                        ProductManufacturer = productManufacturerEntity,
                        ProductManufacturerId = productManufacturerEntity.ProductManufacturerId,
                        ProductCategoryId = computerEquipmentEntity.ProductCategoryId,
                        ProductSubCategory = subCategoryNotebooksEntity,
                        ProductSubCategoryId = subCategoryNotebooksEntity.ProductSubCategoryId
                    };

                    Product productNotebookAppleMacBookPro15TouchBar = new Product
                    {
                        ProductName = "Apple MacBook Pro 15'' Touch Bar (2017 year)",
                        ProductBrand = appleBrandEntity,
                        ProductBrandId = appleBrandEntity.ProductBrandId,
                        ProductPrice = 1470m,
                        ProductImageName = "AppleMacBookPro15TouchBar2017",
                        ProductImageMimeType = "image/jpeg",
                        ProductDescription = "Good Apple MacBook Pro 15'' Touch Bar notebook.",
                        ProductQuanity = 105,
                        ProductCode = "Apple-MacBook-Pro15G4-MPTV2-09",
                        ProductDiscount = null, // no discount
                        ProductManufacturer = productManufacturerEntity,
                        ProductManufacturerId = productManufacturerEntity.ProductManufacturerId,
                        ProductCategoryId = computerEquipmentEntity.ProductCategoryId,
                        ProductSubCategory = subCategoryNotebooksEntity,
                        ProductSubCategoryId = subCategoryNotebooksEntity.ProductSubCategoryId
                    };

                    Product productNotebookAppleMacBookPro13 = new Product
                    {
                        ProductName = "Apple MacBook Pro 13'' Touch Bar (2016 year)",
                        ProductBrand = appleBrandEntity,
                        ProductBrandId = appleBrandEntity.ProductBrandId,
                        ProductPrice = 749.5m,
                        ProductImageName = "AppleMacBookPro13TouchBar2016",
                        ProductImageMimeType = "image/jpeg",
                        ProductDescription = "Good Apple MacBook Pro 15'' Touch Bar notebook.",
                        ProductQuanity = 80,
                        ProductCode = "Apple-MacBook-Pro13-MLL42-09",
                        ProductDiscount = null, // no discount
                        ProductManufacturer = productManufacturerEntity,
                        ProductManufacturerId = productManufacturerEntity.ProductManufacturerId,
                        ProductCategoryId = computerEquipmentEntity.ProductCategoryId,
                        ProductSubCategory = subCategoryNotebooksEntity,
                        ProductSubCategoryId = subCategoryNotebooksEntity.ProductSubCategoryId
                    };

                    context.Products.AddRange(new[] {
                        productNotebookHp6735S, productNotebookAppleMacBookPro15TouchBar2016,
                        productNotebookHpPavilionDv6, productNotebookHpEnvy,
                        productNotebookHpProBook440G4, productNotebookAppleMacBookPro15Retina,
                        productNotebookAppleMacBookPro15TouchBar, productNotebookAppleMacBookPro13
                    });

                    context.SaveChanges();
                }
            }
        }
    }
}
