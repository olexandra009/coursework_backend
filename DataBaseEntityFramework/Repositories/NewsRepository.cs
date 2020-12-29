using System.Collections.Generic;
using System.Linq;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Repositories
{
    public class NewsRepository : IRepository<News>
    {
        private PlatformDbContext _context;

        public NewsRepository(PlatformDbContext context)
        {
            _context = context;
        }

        public List<News> GetAllItem(int take = 0, int skip = 0)
        {
            if (take == 0) return _context.Newses.ToList();
            return _context.Newses.Skip(skip).Take(take).ToList();
        }

        public News GetItemById(int id)
        {
            return _context.Newses.Include(news => news.Id == id).FirstOrDefault();
        }

        public void CreateItem(News item)
        {
            _context.Newses.Add(item);
            _context.SaveChanges();
        }

        public void EditItem(News item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteItem(News item)
        {
            _context.Newses.Attach(item);
            _context.Newses.Remove(item);
            _context.SaveChanges();
        }
    }
}
