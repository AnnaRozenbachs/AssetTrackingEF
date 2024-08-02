using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTrackingEF.Models
{
    public class Asset
    {
        public Asset(string brand, string model,decimal price, DateTime purchaseDate, int assetType, int officeId)
        {
            
            Brand = brand;
            Model = model;
            Price = price;
            PurchaseDate = purchaseDate;     
            AssetType = assetType;
            OfficeId = officeId;

        }

        public int Id { get; set; }

        public string Model { get; set; }

        public string Brand { get; set; }

        public int OfficeId { get; set; }

        public DateTime PurchaseDate { get; set; }

        public decimal Price { get; set; }

        public int AssetType { get; set; }

        public Office Office { get; set; }
    }
}
