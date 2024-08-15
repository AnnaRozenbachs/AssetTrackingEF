using AssetTrackingEF.Data;
using AssetTrackingEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTrackingEF.Repositorys
{
    public class OfficeRepository : GenericRepository<Office>, IOfficeRepository
    {
        public void AddOfficeList()
        {
            var offices = GetAll();
            if (offices.Count == 0)

            {
                AddRange(Office.OfficeList());
            }
        }
    }
}
