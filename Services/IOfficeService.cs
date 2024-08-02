using AssetTrackingEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTrackingEF.Services
{
    public interface IOfficeService
    {
        void AddOffice(Office office);
    }
}
