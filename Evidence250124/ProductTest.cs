using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evidence250124
{

    internal class ProductTest
    {
        static void Main()
        {
            {
                Console.WriteLine();
            }
            List<Product> products = new List<Product>()
            {
                new Product{ ProductId = 1, ProductName = "I-Phone", ProductDescription = "phone Desc", ModelId = 2 },
                new Product{ ProductId = 2, ProductName = "I-Phone", ProductDescription = "phone Desc", ModelId = 3 },
                new Product{ ProductId = 3, ProductName = "Tecno", ProductDescription = "Tecno Desc", ModelId = 1 },
                new Product{ ProductId = 4, ProductName = "Laptop", ProductDescription = "Laptop Desc", ModelId = 4 },
                new Product{ ProductId = 5, ProductName = "Shirt", ProductDescription = "Shirt Desc", ModelId = 5 },
                new Product{ ProductId = 6, ProductName = "Tibbat-Powder", ProductDescription = "Powder Desc", ModelId = 6 }

            };
            List<ProductCatagory> pCatagory = new List<ProductCatagory>()
            {
                new ProductCatagory{ CatagoryId = 1,CatagoryName = "Android"},
                new ProductCatagory{ CatagoryId = 2,CatagoryName = "Apple"},
                new ProductCatagory{ CatagoryId = 3,CatagoryName = "Cloths"},
                new ProductCatagory{ CatagoryId= 4, CatagoryName = "Computer"},
                new ProductCatagory{ CatagoryId = 5, CatagoryName = "Beauty"}
            };
            List<ProductModel> pModel = new List<ProductModel>()
            {
                new ProductModel{ CatagoryId = 1,ModelId = 1,ModelName = "Spark 10"},
                new ProductModel{ CatagoryId = 2,ModelId = 2,ModelName = "i-phone 13"},
                new ProductModel{ CatagoryId = 2,ModelId = 3,ModelName = "i-phone 13 pro"},
                new ProductModel{ CatagoryId = 4,ModelId = 4,ModelName = "Laptop LT50"},
                new ProductModel{ CatagoryId = 3,ModelId = 5,ModelName = "Shirt S68"},
                new ProductModel{CatagoryId = 5, ModelId = 6, ModelName = " BB Lovely"}
            };
            // using LINQ
            var resultAll = from pCat in pCatagory
                            join pMod in pModel
               on pCat.CatagoryId equals pMod.CatagoryId // on
                            join p in products
                            on pMod.ModelId equals p.ModelId // on 

                            // where pCat.CatagoryName.ToLower().Equals("computer") // where condition
                            orderby p.ProductId
                            select new
                            {
                                ProductID = p.ProductId,
                                ProductNameeee = p.ProductName,
                                Description = p.ProductDescription,
                                Catagory = pCat.CatagoryName,
                                Model = pMod.ModelName
                            };

            foreach (var pro in resultAll)
            {
                Console.WriteLine($"Product ID: {pro.ProductID}, Name: {pro.ProductNameeee}, Description: {pro.Description}, Catagory: {pro.Catagory}, Model: {pro.Model}");
            }


            //using Lambda
            var xyz = products.Join(pModel, product => product.ModelId, model => model.ModelId, (product,model) => new 
                                                {
                                                    pro = product.ProductName, product.ProductDescription, product.ProductId,
                                                    mod = model.ModelId, model.ModelName
                                                }).ToList();
            foreach (var p in xyz)
            {
                Console.WriteLine($"Product Name: {p.pro}, Model: {p.ModelName}");
            }

            Console.ReadKey();
        }
    }
}
