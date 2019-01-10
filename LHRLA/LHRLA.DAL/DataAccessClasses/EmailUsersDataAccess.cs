using LHRLA.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LHRLA.LHRLA.DAL.DataAccessClasses
{
    public class EmailUsersDataAccess
    {
        #region Insert
        public bool AddEmailUsers(tbl_Email_Users row)
        {

            try
            {
                using (var db = new vt_LHRLAEntities())
                {
                    db.tbl_Email_Users.Add(row);
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

        //#region Update

        //public bool UpdateEmailUsers(tbl_Email_Setup row)
        //{

        //    try
        //    {
        //        using (var db = new vt_LHRLAEntities())
        //        {
        //            tbl_Email_Setup val = new tbl_Email_Setup();
        //            val = db.tbl_Email_Setup.Where(a => a.ID == row.ID).FirstOrDefault();
        //            val.Name = row.Name;
        //            val.Description = row.Description;
        //            val.Email_Body = row.Email_Body;
        //            val.Is_Active = row.Is_Active;
        //            val.Email_Subject = row.Email_Subject;
        //            val.Email_CC = row.Email_CC;
        //            db.SaveChanges();
        //        }
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}

        //#endregion

        #region Delete

        #endregion

        #region Select
        public List<tbl_Email_Users> GetAllEmailUsers()
        {
            try
            {
                List<tbl_Email_Users> lst = new List<tbl_Email_Users>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Email_Users.ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public List<tbl_Email_Users> GetAllActiveEmailUsers()
        //{
        //    try
        //    {
        //        List<tbl_Email_Users> lst = new List<tbl_Email_Users>();
        //        using (var db = new vt_LHRLAEntities())
        //        {
        //            lst = db.tbl_Email_Users.ToList().Where(a => a.Is_Active == true).ToList();
        //        }
        //        return lst;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}



        public List<tbl_Email_Users> GetEmailUsersbyID(int ID)
        {
            try
            {
                List<tbl_Email_Users> lst = new List<tbl_Email_Users>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Email_Users.Where(e => e.ID == ID).ToList();
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