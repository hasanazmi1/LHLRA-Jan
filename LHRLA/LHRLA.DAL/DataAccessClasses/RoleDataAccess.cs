using LHRLA.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LHRLA.LHRLA.DAL.DataAccessClasses
{
    public class RoleDataAccess
    {
        #region Insert
        public bool AddRole(tbl_Role row)
        {

            try
            {
                using (var db = new vt_LHRLAEntities())
                {
                    db.tbl_Role.Add(row);
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

        public bool UpdateRole(tbl_Role row)
        {

            try
            {
                using (var db = new vt_LHRLAEntities())
                {
                    tbl_Role val = new tbl_Role();
                    val = db.tbl_Role.Where(a => a.ID == row.ID).FirstOrDefault();
                    val.Name = row.Name;
                    val.Name = row.Name;
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
        public List<tbl_Role> GetAllRolees()
        {
            try
            {
                List<tbl_Role> lst = new List<tbl_Role>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Role.ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<tbl_Role> GetAllActiveRoles()
        {
            try
            {
                List<tbl_Role> lst = new List<tbl_Role>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Role.ToList().Where(a => a.Is_Active == true).ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<tbl_Role> CheckDuplicateData(string Name)
        {
            try
            {
                List<tbl_Role> lst = new List<tbl_Role>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Role.ToList().Where(a => a.Name == Name).ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public List<tbl_Role> GetRolebyID(int ID)
        {
            try
            {
                List<tbl_Role> lst = new List<tbl_Role>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Role.Where(e => e.ID == ID).ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<tbl_Role> GetRolebyIDOfExistingData(int ID,string name)
        {
            try
            {
                List<tbl_Role> lst = new List<tbl_Role>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Role.Where(e => e.ID == ID && e.Name == name).ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<tbl_Role> GetRolebyIDName(int ID, string name)
        {
            try
            {
                List<tbl_Role> lst = new List<tbl_Role>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Role.Where(e => e.ID != ID && e.Name == name).ToList();
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