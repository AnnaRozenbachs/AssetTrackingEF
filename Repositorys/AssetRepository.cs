using AssetTrackingEF.Data;
using AssetTrackingEF.Helpers;
using AssetTrackingEF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTrackingEF.Repositorys
{
    public class AssetRepository : IRepository<Asset>
    {
        private readonly AssetContext _context = new AssetContext();
        public void Add(Asset asset)
        {
           _context.Assets.Add(asset);
            Save();
        }

        public void Delete(Asset asset)
        {
            _context.Assets.Remove(asset);
            Save();
        }

        public List<Asset> Get()
        {
            var assetList = _context.Assets
               .Include(x=>x.Office)
               .OrderBy(a=>a.Office.Country)
               .ThenByDescending(a=>a.PurchaseDate);

            return assetList.ToList();
        }

        public Asset GetById(int id)
        {
            return _context.Assets.Find(id);
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

        public void Update(Asset asset)
        {
            _context.Assets.Update(asset);
            Save();
        }
    }
}
