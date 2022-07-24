using Microsoft.EntityFrameworkCore;
using Model;
using Model.Enum;
using Repository.Context;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductRepository : IProductRepository
    {
        #region Variable
        private readonly ProductContext _productContext;

        #endregion

        #region ctor
        public ProductRepository(ProductContext productContext)
        {
            _productContext = productContext;
        }

        #endregion

        #region Methods
        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _productContext.Products.ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {
            return await _productContext.Products.FindAsync(id);
        }

        public async Task<int> Insert(Product product)
        {
            try
            {
                await _productContext.Products.AddAsync(product);
                if (await _productContext.SaveChangesAsync() > 0)
                {
                    return (int)ProcessStatus.Success;
                }
                else
                {
                    return (int)ProcessStatus.Failed;
                }
            }
            catch (Exception e)
            {
                return (int)ProcessStatus.Exception;
            }
        }

        public async Task<int>Update(Product product)
        {
            Product update = await _productContext.Products.FindAsync(product.Id);
            if (update == null)
            {
                return (int)ProcessStatus.NotFound;
            }
            else
            {
                update.Description = product.Description;
                update.Name = product.Name;
                try
                {
                    if (await _productContext.SaveChangesAsync() > 0)
                    {
                        return (int)ProcessStatus.Success;
                    }
                    else
                    {
                        return (int)ProcessStatus.Failed;
                    }
                }
                catch (Exception e)
                {
                    return (int)ProcessStatus.Exception;
                }
               
            }
        }

        public async Task<int>Delete(int id)
        {
            Product delete = await _productContext.Products.FindAsync(id);
            if (delete == null)
            {
                return (int)ProcessStatus.NotFound;
            }
            else
            {
                _productContext.Products.Remove(delete);
                try
                {
                    if (await _productContext.SaveChangesAsync() > 0)
                    {
                        return (int)ProcessStatus.Success;
                    }
                    else
                    {
                        return (int)ProcessStatus.Failed;
                    }
                }
                catch (Exception e)
                {
                    return (int)ProcessStatus.Exception;
                }
               
            }
        }

        #endregion

    }
}
