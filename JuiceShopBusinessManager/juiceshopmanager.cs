using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JuiceShopDAL;
using JuiceShopEntities;
namespace JuiceShopBusinessManager
{
    public class juiceshopmanager
    {
        public List<juice> GetJuiceFlavors()
        {

        juiceshopDAL dal = new juiceshopDAL();
            List<juice> lst = dal.GetJuiceFlavors();

            return lst;
        }
        
        public void choicejuices(int juice_id,int quantity)
        {
            juiceshopDAL dal = new juiceshopDAL();
            dal.juicepurchase(juice_id, quantity);
        }
        public List<JuicePurchased> Alljuicepurchased()
        {
            juiceshopDAL dal = new juiceshopDAL();

            List<JuicePurchased> lst = dal.Alljuicepurchased();
            return lst;


        }
        public void removeolddata()
        {
            juiceshopDAL d = new juiceshopDAL();
            d.cleardata();
        }
    }
}
