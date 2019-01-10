using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using LatestAngular.Models;

namespace LatestAngular.Resources
{
    public class VehicleResource
    {
        public int Id { get; set; }
        public Model Model { get; set; }
        public bool IsRegistered { get; set; }
       
        public DateTime LastUpdate { get; set; }

        public ContactResource Contact { get; set; }
        public ICollection<int> Features { get; set; }

        public VehicleResource()
        {
            Features = new Collection<int>();
        }
    }

    public class ContactResource
    {
        
        public string ContactName { get; set; }
       
        public string ContactEmail { get; set; }
       
        public string ContactPhone { get; set; }
    }
}
