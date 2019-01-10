using LHRLA.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LHRLA.LHRLA.DAL.DataAccessClasses
{
    public class UserLogDataAccess
    {
        #region Insert
        public bool AddUserLog(tbl_UserLog row)
        {

            try
            {
                using (var db = new vt_LHRLAEntities())
                {
                    db.tbl_UserLog.Add(row);
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

        public bool UpdateUserLog(tbl_UserLog row)
        {

            try
            {
                using (var db = new vt_LHRLAEntities())
                {
                    tbl_UserLog val = new tbl_UserLog();
                    val = db.tbl_UserLog.Where(a => a.ID == row.ID).FirstOrDefault();
                    val.Entity_Type = row.Entity_Type;
                    val.Entity_ID = row.Entity_ID;
                    val.Action_Timestamp = row.Action_Timestamp;
                    val.Description = row.Description;
                    val.Action_Name = row.Action_Name;
                    val.Action_User_ID = row.Action_User_ID;

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
        public List<tbl_UserLog> GetAllUserLogs()
        {
            try
            {
                List<tbl_UserLog> lst = new List<tbl_UserLog>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_UserLog.ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public List<tbl_Branch> GetAllActiveBranches()
        //{
        //    try
        //    {
        //        List<tbl_Branch> lst = new List<tbl_Branch>();
        //        using (var db = new vt_LHRLAEntities())
        //        {
        //            lst = db.tbl_UserLog.ToList().Where(a => a.Is_Active == true).ToList();
        //        }
        //        return lst;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}



        public List<tbl_UserLog> GetUserLogbyID(int ID)
        {
            try
            {
                List<tbl_UserLog> lst = new List<tbl_UserLog>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_UserLog.Where(e => e.ID == ID).ToList();
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