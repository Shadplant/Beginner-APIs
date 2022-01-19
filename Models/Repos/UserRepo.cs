using System.Collections.Generic;

namespace _18_1_22_Beginner_APIs.Models
{
    public interface IUserRepository
    {
        IEnumerable<UserItem> Get();
        UserItem Get(int id);
        void Create(UserItem item);
        void Update(UserItem item);
        UserItem Delete(int id);
    }

    public class UserRepository : IUserRepository
    {
        private UserDBContext Context;
        public IEnumerable<UserItem> Get()
        {
            return Context.UserItems;
        }
        public UserItem Get(int Id)
        {
            return Context.UserItems.Find(Id);
        }
        public UserRepository(UserDBContext context)
        {
            Context = context;
        }
        public void Create(UserItem item)
        {
            Context.UserItems.Add(item);
            Context.SaveChanges();
        }
        public void Update(UserItem updatedUserItem)
        {
            UserItem currentItem = Get(updatedUserItem.UserId);
            currentItem.FullName = updatedUserItem.FullName;
            currentItem.DOB = updatedUserItem.DOB;

            Context.UserItems.Update(currentItem);
            Context.SaveChanges();
        }

        public UserItem Delete(int Id)
        {
            UserItem Item = Get(Id);

            if (Item != null)
            {
                Context.UserItems.Remove(Item);
                Context.SaveChanges();
            }

            return Item;
        }
    }
}
