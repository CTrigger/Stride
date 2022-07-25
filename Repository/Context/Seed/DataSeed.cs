using Model;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Repository.Context.Seed
{
    public class DataSeed
    {
        #region variables
        private const string SeedPath = @"..\Repository\Context\Seed\";

        #endregion


        #region Aux Methods
        public static string ReadInternalJson(string fileName)
        {
            string jsonData = string.Empty;
            string fullPath = Path.GetFullPath(SeedPath);
            if (Directory.Exists(fullPath))
            {
                using (StreamReader File = new StreamReader(string.Concat(fullPath, fileName, ".json")))
                {
                    jsonData = File.ReadToEnd();
                }
            }
            return jsonData;
        }
        #endregion

        public static void ProductSeed(ProductContext productcContext)
        {
            if (!productcContext.Products.Any())
            {
                string data = ReadInternalJson("ProductSeed");
                List<Product> seed = JsonSerializer.Deserialize<List<Product>>(data);
                
                productcContext.Products.AddRange(seed);
                productcContext.SaveChanges();
            }
        }

        public static void UserSeed(UserContext userContext)
        {
            if (!userContext.Users.Any())
            {
                string data = ReadInternalJson("UserSeed");
                List<User> seed = JsonSerializer.Deserialize<List<User>>(data);

                userContext.Users.AddRange(seed);
                userContext.SaveChanges();
            }
        }
    }
}
