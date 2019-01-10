using LHRLA.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LHRLA.LHRLA.DAL.DataAccessClasses
{
    public class CouncellingSessionsDataAccess
    {
        #region Insert
        public bool AddCouncellingSessions(tbl_Councelling_Sessions row)
        {

            try
            {
                using (var db = new vt_LHRLAEntities())
                {
                    db.tbl_Councelling_Sessions.Add(row);
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

        public bool UpdateCouncellingSessions(tbl_Councelling_Sessions row)
        {

            try
            {
                using (var db = new vt_LHRLAEntities())
                {
                    tbl_Councelling_Sessions val = new tbl_Councelling_Sessions();
                    val = db.tbl_Councelling_Sessions.Where(a => a.ID == row.ID).FirstOrDefault();
                    val.Case_ID = row.Case_ID;
                    val.Counceller_ID = row.Counceller_ID;
                    val.Session_Duration_In_Mins = row.Session_Duration_In_Mins;
                    val.Session_Datetime = row.Session_Datetime;
                    val.Session_Details = row.Session_Details;
                    val.Is_Submitted = row.Is_Submitted;
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
        public List<tbl_Councelling_Sessions> GetAllCouncellingSessions()
        {
            try
            {
                List<tbl_Councelling_Sessions> lst = new List<tbl_Councelling_Sessions>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Councelling_Sessions.ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public List<tbl_Councelling_Sessions> GetAllActiveCouncellingSessions()
        //{
        //    try
        //    {
        //        List<tbl_Councelling_Sessions> lst = new List<tbl_Councelling_Sessions>();
        //        using (var db = new vt_LHRLAEntities())
        //        {
        //            lst = db.tbl_Councelling_Sessions.ToList().Where(a => a.Is_Active == true).ToList();
        //        }
        //        return lst;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}



        public List<tbl_Councelling_Sessions> GetCaseCouncellingSessionsbyID(int ID)
        {
            try
            {
                List<tbl_Councelling_Sessions> lst = new List<tbl_Councelling_Sessions>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Councelling_Sessions.Where(e => e.ID == ID).ToList();
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