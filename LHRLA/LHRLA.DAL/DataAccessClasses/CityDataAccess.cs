using LHRLA.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LHRLA.LHRLA.DAL.DataAccessClasses
{
    public class CityDataAccess
    {
        #region Insert
        public bool AddCity(tbl_City row)
        {

            try
            {
                using (var db = new vt_LHRLAEntities())
                {
                    db.tbl_City.Add(row);
                    db.SaveChanges();

                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        #endregion

        #region Update

        public bool UpdateCity(tbl_City row)
        {

            try
            {
                using (var db = new vt_LHRLAEntities())
                {
                    tbl_City val = new tbl_City();
                    val = db.tbl_City.Where(a => a.ID == row.ID).FirstOrDefault();
                    val.Name = row.Name;
                    val.Description = row.Description;
                    val.Longitude = row.Longitude;
                    val.Latitude = row.Latitude;
                    val.Short_Code = row.Short_Code;
                    val.Is_Active = row.Is_Active;
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion

        #region Delete

        #endregion

        #region Select
        public List<tbl_City> GetAllCity()
        {
            try
            {
                List<tbl_City> lst = new List<tbl_City>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_City.ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<tbl_City> CheckDuplicateData(String Name)
        {
            try
            {
                List<tbl_City> lst = new List<tbl_City>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_City.Where(o=> o.Name == Name).ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        //public List<tbl_City> GetAllActiveCaseTypes()
        //{
        //    try
        //    {
        //        List<tbl_City> lst = new List<tbl_City>();
        //        using (var db = new vt_LHRLAEntities())
        //        {
        //            lst = db.tbl_City.ToList().Where(a => a.Is_Active == true).ToList();
        //        }
        //        return lst;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}



        public List<tbl_City> GetCitybyID(int ID)
        {
            try
            {
                List<tbl_City> lst = new List<tbl_City>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_City.Where(e => e.ID == ID).ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<tbl_City> GetCitybyIDOfExistingName(int ID,string name)
        {
            try
            {
                List<tbl_City> lst = new List<tbl_City>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_City.Where(e => e.ID == ID && e.Name == name).ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<tbl_City> GetCitybyIDName(int ID, string name)
        {
            try
            {
                List<tbl_City> lst = new List<tbl_City>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_City.Where(e => e.ID != ID && e.Name == name).ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<tbl_City> GetCitybyIDOfExistingShortCode(int ID, string code)
        {
            try
            {
                List<tbl_City> lst = new List<tbl_City>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_City.Where(e => e.ID == ID && e.Short_Code == code).ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<tbl_City> GetCitybyIDShortCode(int ID, string code)
        {
            try
            {
                List<tbl_City> lst = new List<tbl_City>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_City.Where(e => e.ID != ID && e.Short_Code == code).ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        #endregion
    }
}