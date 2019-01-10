using LHRLA.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LHRLA.LHRLA.DAL.DataAccessClasses
{
    public class UserBranchDataAccess
    {
        #region Insert
        public bool AddUserBranch(tbl_User_Branch row)
        {

            try
            {
                using (var db = new vt_LHRLAEntities())
                {
                    db.tbl_User_Branch.Add(row);
                    db.SaveChanges();

                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool AddMultipleUserBranch(List<tbl_User_Branch> rows,int UserId)
        {
            try
            {
                List<tbl_User_Branch> UserBranches = new List<tbl_User_Branch>();
                for (int i = 0; i < rows.Count; i++)
                {
                    tbl_User_Branch b = new tbl_User_Branch();
                    b.User_ID = UserId;
                    b.Branch_ID = rows[i].Branch_ID;
                    UserBranches.Add(b);
                }
                using (var db = new vt_LHRLAEntities())
                {
                    db.tbl_User_Branch.AddRange(UserBranches);
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

        public bool UpdateUserBranch(tbl_User_Branch row)
        {

            try
            {
                using (var db = new vt_LHRLAEntities())
                {
                    tbl_User_Branch val = new tbl_User_Branch();
                    val = db.tbl_User_Branch.Where(a => a.ID == row.ID).FirstOrDefault();
                    val.User_ID = row.User_ID;
                    val.Branch_ID = row.Branch_ID;
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
        public bool DeleteUserBranch(int UserID)
        {

            try
            {
                using (var db = new vt_LHRLAEntities())
                {
                    List<tbl_User_Branch> rows = new List<tbl_User_Branch>();
                    rows = db.tbl_User_Branch.Where(a => a.User_ID == UserID).ToList();
                    db.tbl_User_Branch.RemoveRange(rows);
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
        public List<tbl_User_Branch> GetAllUserBranches()
        {
            try
            {
                List<tbl_User_Branch> lst = new List<tbl_User_Branch>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_User_Branch.ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public List<tbl_User_Branch> GetAllActiveBranches()
        //{
        //    try
        //    {
        //        List<tbl_User_Branch> lst = new List<tbl_User_Branch>();
        //        using (var db = new vt_LHRLAEntities())
        //        {
        //            lst = db.tbl_User_Branch.ToList().Where(a => a.Is_Active == true).ToList();
        //        }
        //        return lst;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}



        public List<tbl_User_Branch> GetBranchbyID(int ID)
        {
            try
            {
                List<tbl_User_Branch> lst = new List<tbl_User_Branch>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_User_Branch.Where(e => e.ID == ID).ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<tbl_User_Branch> GetBranchbyUser(long UserID)
        {
            try
            {
                List<tbl_User_Branch> lst = new List<tbl_User_Branch>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_User_Branch.Where(e => e.User_ID==UserID).ToList();
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