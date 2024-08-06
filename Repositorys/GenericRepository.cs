using AssetTrackingEF.Data;
using AssetTrackingEF.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTrackingEF.Repositorys
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AssetContext _context = new AssetContext();
        public void Add(T entity)
        {
           _context.Set<T>().Add(entity);
            Save();
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            Save();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ee)
            {
                ConsoleHelper.ConsoleWrite($"Somethinq went wrong: {ee.InnerException}", false, ConsoleColor.Red);
            }
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            Save();
        }
    }
}
