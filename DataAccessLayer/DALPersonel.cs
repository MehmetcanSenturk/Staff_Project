using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using EntityLayer;
using System.Data.SqlClient;
using System.Data;
using System.Runtime.ConstrainedExecution;

namespace DataAccessLayer
{
    public class DALPersonel
    {
        public static List<EntityPersonel> PersonelListesi()
        {
            List<EntityPersonel> degerler = new List<EntityPersonel>();
             SqlCommand  cmd = new SqlCommand(
                 "Select * from Tbl_Bilgi"
                 ,Baglanti.bgl
                 );
            if (cmd.Connection.State != ConnectionState.Open)
            {
                cmd.Connection.Open();
            }
            SqlDataReader reader = cmd.ExecuteReader(); 
            while(reader.Read())
            {
                EntityPersonel entit = new EntityPersonel();    
                entit.Id =
                    int.Parse(reader["ID"].ToString()); 
                entit.Ad = 
                    reader["Ad"].ToString();
                entit.Soyad =
                    reader["Soyad"].ToString();
                entit.Gorev = 
                    reader["Gorev"].ToString();
                entit.Sehir =
                    reader["Sehir"].ToString();
                entit.Maas =
                    short.Parse(reader["Maas"].ToString());
                degerler.Add(entit);
            }
            reader.Close();
            return degerler;    
        }
        public static int Pers_Ekle(EntityPersonel per)
        {
            SqlCommand cmd2 = new SqlCommand("INSERT INTO Tbl_Bilgi (Ad,Soyad,Gorev,Sehir,Maas) VALUES (@P1,@P2,@P3,@P4,@P5)", Baglanti.bgl);
            if (cmd2.Connection.State != ConnectionState.Open)
            {
                cmd2.Connection.Open();
            }
            cmd2.Parameters.AddWithValue
                ("@P1", per.Ad);
            cmd2.Parameters.AddWithValue
                ("@P2", per.Soyad);
            cmd2.Parameters.AddWithValue
                ("@P3", per.Gorev);
            cmd2.Parameters.AddWithValue
                ("@P4", per.Sehir);
            cmd2.Parameters.AddWithValue
                ("@P5", per.Maas);
            return cmd2.ExecuteNonQuery();
        }
        public static bool Pers_Sil(int per)
        {
            SqlCommand cmd3 = new SqlCommand("DELETE FROM Tbl_Bilgi where Id=@P1", Baglanti.bgl);
            if(cmd3.Connection.State != ConnectionState.Open) 
            {
                cmd3.Connection.Open();
            }
            cmd3.Parameters.AddWithValue
                ("@P1", per);
            return cmd3.ExecuteNonQuery() > 0;
        }
        public static bool PersonelGuncelle(EntityPersonel ent)
        {
            SqlCommand cmd4 = new SqlCommand("Update Tbl_Bilgi set Ad=@P1,Soyad=@P2,Maas=@P3,Sehir=@P4,Gorev=@P5 Where Id=@P6", Baglanti.bgl);
            if (cmd4.Connection.State != ConnectionState.Open)
            {
                cmd4.Connection.Open();
            }
            cmd4.Parameters.AddWithValue
                        ("@P1", ent.Ad);
            cmd4.Parameters.AddWithValue
                        ("@P2", ent.Soyad);
            cmd4.Parameters.AddWithValue
                        ("@P3", ent.Maas);
            cmd4.Parameters.AddWithValue
                        ("@P4", ent.Sehir);
            cmd4.Parameters.AddWithValue
                        ("@P5", ent.Gorev);
            cmd4.Parameters.AddWithValue
                        ("@P6", ent.Id);
            return cmd4.ExecuteNonQuery() > 0;

        }
       
    }
}
