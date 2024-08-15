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
    public class AssetRepository : GenericRepository<Asset>, IAssetRepository
    {
        private readonly AssetContext _context = new AssetContext();    
        public List<Asset> Get()
        {
            var assetList = _context.Assets
               .Include(x=>x.Office)
               .OrderBy(a=>a.Office.Country)
               .ThenByDescending(a=>a.PurchaseDate);

            return assetList.ToList();
        }

    }
}
