using System.Collections.Generic;

namespace _18_1_22_Beginner_APIs.Models
{
    public interface ICategoryRepository
    {
        IEnumerable<CategoryItem> Get();
        CategoryItem Get(int id);
        void Create(CategoryItem item);
        void Update(CategoryItem item);
        CategoryItem Delete(int id);
    }

    public class CategoryRepository : ICategoryRepository
    {
        private CategoryDBContext Context;
        public IEnumerable<CategoryItem> Get()
        {
            return Context.CategoryItems;
        }
        public CategoryItem Get(int Id)
        {
            return Context.CategoryItems.Find(Id);
        }
        public CategoryRepository(CategoryDBContext context)
        {
            Context = context;
        }
        public void Create(CategoryItem item)
        {
            Context.CategoryItems.Add(item);
            Context.SaveChanges();
        }
        public void Update(CategoryItem updatedCategoryItem)
        {
            CategoryItem currentItem = Get(updatedCategoryItem.CategoryId);
            currentItem.CategoryName = updatedCategoryItem.CategoryName;

            Context.CategoryItems.Update(currentItem);
            Context.SaveChanges();
        }

        public CategoryItem Delete(int Id)
        {
            CategoryItem Item = Get(Id);

            if (Item != null)
            {
                Context.CategoryItems.Remove(Item);
                Context.SaveChanges();
            }

            return Item;
        }
    }
}
