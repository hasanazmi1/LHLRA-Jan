using LHRLA.DAL;
using LHRLA.LHRLA.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LHRLA.LHRLA.DAL.DataAccessClasses
{
   public class BranchDataAccess
    {
        #region Insert
        public bool AddBranch(tbl_Branch row)
        {

            try
            {
                using (var db = new vt_LHRLAEntities())
                {
                    db.tbl_Branch.Add(row);
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

        public bool UpdateBranch(tbl_Branch row)
        {

            try
            {
                using (var db = new vt_LHRLAEntities())
                {
                    tbl_Branch val = new tbl_Branch();
                    val = db.tbl_Branch.Where(a => a.ID == row.ID).FirstOrDefault();
                    val.Name = row.Name;
                    val.Longitude = row.Longitude;
                    val.Latitude = row.Latitude;
                    val.Description = row.Description;
                    val.Address = row.Address;
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
        public List<tbl_Branch> GetAllBranches()
        {
            try
            {
                List<tbl_Branch> lst = new List<tbl_Branch>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Branch.ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<tbl_Branch> CheckDuplicateData(string name)
        {
            try
            {
                List<tbl_Branch> lst = new List<tbl_Branch>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Branch.Where(o=> o.Name == name).ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<tbl_Branch> GetAllActiveBranches()
        {
            try
            {
                List<tbl_Branch> lst = new List<tbl_Branch>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Branch.ToList().Where(a=>a.Is_Active==true).ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public List<tbl_Branch> GetBranchbyID(int ID)
        {
            try
            {
                List<tbl_Branch> lst = new List<tbl_Branch>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Branch.Where(e => e.ID==ID).ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<tbl_Branch> GetBranchbyNameID(int ID,string name)
        {
            try
            {
                List<tbl_Branch> lst = new List<tbl_Branch>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Branch.Where(e => e.ID == ID && e.Name == name).ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<tbl_Branch> GetBranchbyIDOnUpdate(int ID,string name)
        {
            try
            {
                List<tbl_Branch> lst = new List<tbl_Branch>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Branch.Where(e => e.ID != ID && e.Name == name ).ToList();
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
