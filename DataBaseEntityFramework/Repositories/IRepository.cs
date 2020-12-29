using System;
using System.Collections.Generic;
using System.Text;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Repositories
{
    interface IRepository<T>
    {
        //get all item
        List<T> GetAllItem(int take = 0, int skip = 0);
        //get item by id
        T GetItemById(int id);
        //get filtered item
        //create item
        void CreateItem(T item);
        //edit item
        void EditItem(T item);
        //delete item
        void DeleteItem(T item);
    }
}
