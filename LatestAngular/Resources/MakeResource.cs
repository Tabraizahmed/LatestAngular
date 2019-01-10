using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace LatestAngular.Resources
{
    public class MakeResource
    {
        public MakeResource()
        {
            Models = new Collection<ModelResource>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ModelResource> Models { get; set; }
    }
}
