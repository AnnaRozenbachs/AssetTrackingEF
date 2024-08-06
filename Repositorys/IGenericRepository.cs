using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTrackingEF.Repositorys
{
    public interface IGenericRepository<T> where T : class
    {
        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        T GetById(int id);

        void Save();

    }
}
