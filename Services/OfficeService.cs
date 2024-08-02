using AssetTrackingEF.Models;
using AssetTrackingEF.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTrackingEF.Services
{
    public class OfficeService : IOfficeService
    {
        //private Repository<Office> _repository = new Repository<Office>();

        public void AddOffice(Office office)
        {
            //_repository.Add(office);
        }
    }
}
