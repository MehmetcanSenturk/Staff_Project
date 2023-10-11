using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using EntityLayer;
using System.Data.SqlClient;
using System.Data;
using DataAccessLayer;



namespace LogicLayer
{
    public class LogicPersonel
    {
        public static List<EntityPersonel> lgcPersonelListesi()
        {
            return DALPersonel.PersonelListesi();
        } 
        public static int Pers_Ekle(EntityPersonel pers)
        {
            if(pers.Ad !="" && pers.Soyad !="" && pers.Maas>=3500 && pers.Ad.Length >= 3)
            {
                return DALPersonel.Pers_Ekle(pers);
            }
            else
            {
                return -1;
            }
        }
        public static bool LPer_Sil(int pers)
        {
            if (pers >= 1)
            {
                return DALPersonel.Pers_Sil(pers);
            }
            else { return false; }
        }
        public static bool LPersonelGuncelle(EntityPersonel entity)
        {
            if(entity.Ad.Length >=3 && entity.Ad!="" && entity.Maas>= 4500)
            {
                return DALPersonel.PersonelGuncelle(entity);
            }
            else
            {
                return false;
            }
        }
    }
}
