using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuiceShopEntities
{
  public  class JuicePurchased
    { 
        public int purchase_id { get; set; }
        public int juice_id { get; set; }
        public int quantity { get; set; }
        public int amount { get; set; }

      
    }
}
