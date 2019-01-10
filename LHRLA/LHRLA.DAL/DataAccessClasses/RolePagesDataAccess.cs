using LHRLA.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LHRLA.LHRLA.DAL.DataAccessClasses
{
    public class RolePagesDataAccess
    {
        #region Insert
        public bool AddRolePages(tbl_Role_Pages row)
        {

            try
            {
                using (var db = new vt_LHRLAEntities())
                {
                    db.tbl_Role_Pages.Add(row);
                    db.SaveChanges();

                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool AddMultipleRolePages(List<tbl_Role_Pages> rows)
        {

            try
            {
                using (var db = new vt_LHRLAEntities())
                {
                    db.tbl_Role_Pages.AddRange(rows);
                    db.SaveChanges();

                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool UserPermission(int RoleID, string PageURL)
        {
            try
            {
                using (var db = new vt_LHRLAEntities())
                {
                    var data = from p in db.tbl_Pages
                               join pp in db.tbl_Role_Pages on p.ID equals pp.Page_ID
                               where pp.Role_ID == RoleID && PageURL.Contains(p.URL)
                               select p;
                    if (data.Count() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion

        #region Update

        //public bool UpdateRolePages(tbl_Role_Pages row)
        //{

        //    try
        //    {
        //        using (var db = new vt_LHRLAEntities())
        //        {
        //            tbl_Role_Pages val = new tbl_Role_Pages();
        //            val = db.tbl_Role_Pages.Where(a => a.ID == row.ID).FirstOrDefault();
        //            val.Name = row.Name;
        //            val.Longitude = row.Longitude;
        //            val.Latitude = row.Latitude;
        //            val.Description = row.Description;
        //            val.Address = row.Address;
        //            val.Is_Active = row.Is_Active;

        //            db.SaveChanges();
        //        }
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}

        #endregion

        #region Delete
        public bool DeletePermissions(int RoleID)
        {

            try
            {
                using (var db = new vt_LHRLAEntities())
                {
                    List<tbl_Role_Pages> rows = new List<tbl_Role_Pages>();
                    rows = db.tbl_Role_Pages.Where(a => a.Role_ID == RoleID).ToList();
                    db.tbl_Role_Pages.RemoveRange(rows);
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

        #region Select
        public List<tbl_Role_Pages> GetAllRolePageses()
        {
            try
            {
                List<tbl_Role_Pages> lst = new List<tbl_Role_Pages>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Role_Pages.ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public List<tbl_Role_Pages> GetAllActiveRolePageses()
        //{
        //    try
        //    {
        //        List<tbl_Role_Pages> lst = new List<tbl_Role_Pages>();
        //        using (var db = new vt_LHRLAEntities())
        //        {
        //            lst = db.tbl_Role_Pages.ToList().Where(a => a.Is_Active == true).ToList();
        //        }
        //        return lst;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}



        public List<tbl_Role_Pages> GetRolePagesbyID(int ID)
        {
            try
            {
                List<tbl_Role_Pages> lst = new List<tbl_Role_Pages>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Role_Pages.Where(e => e.ID == ID).ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<tbl_Role_Pages> GetRolePagesbyRoleID(int RoleID)
        {
            try
            {
                List<tbl_Role_Pages> lst = new List<tbl_Role_Pages>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Role_Pages.Where(e => e.Role_ID==RoleID).ToList();
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