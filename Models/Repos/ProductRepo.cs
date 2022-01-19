using System.Collections.Generic;

namespace _18_1_22_Beginner_APIs.Models
{
    public interface IProductRepository
    {
        IEnumerable<ProductItem> Get();
        ProductItem Get(int id);
        void Create(ProductItem item);
        void Update(ProductItem item);
        ProductItem Delete(int id);
    }

    public class ProductRepository : IProductRepository
    {
        private ProductDBContext Context;
        public IEnumerable<ProductItem> Get()
        {
            return Context.ProductItems;
        }
        public ProductItem Get(int Id)
        {
            return Context.ProductItems.Find(Id);
        }
        public ProductRepository(ProductDBContext context)
        {
            Context = context;
        }
        public void Create(ProductItem item)
        {
            Context.ProductItems.Add(item);
            Context.SaveChanges();
        }
        public void Update(ProductItem updatedProductItem)
        {
            ProductItem currentItem = Get(updatedProductItem.ProductId);
            currentItem.ProductName = updatedProductItem.ProductName;
            currentItem.ProductPrice = updatedProductItem.ProductPrice;
            currentItem.ProductDescription = updatedProductItem.ProductDescription;

            Context.ProductItems.Update(currentItem);
            Context.SaveChanges();
        }

        public ProductItem Delete(int Id)
        {
            ProductItem Item = Get(Id);

            if (Item != null)
            {
                Context.ProductItems.Remove(Item);
                Context.SaveChanges();
            }

            return Item;
        }
    }

}
