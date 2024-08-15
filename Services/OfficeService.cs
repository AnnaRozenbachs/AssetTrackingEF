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
        private OfficeRepository _oRepository = new OfficeRepository();
        public void AddOfficeList()
        {
            _oRepository.AddOfficeList();
        }
    }
}
