﻿using AssetTrackingEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTrackingEF.Repositorys
{
    public interface IAssetRepository : IGenericRepository<Asset>
    {
        List<Asset> Get();
    }
}