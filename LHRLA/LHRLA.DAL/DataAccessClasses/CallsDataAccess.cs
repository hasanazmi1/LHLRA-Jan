using LHRLA.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LHRLA.LHRLA.DAL.DataAccessClasses
{
    public class CallsDataAccess
    {
        #region Insert
        public bool AddCall(tbl_Calls row)
        {

            try
            {
                using (var db = new vt_LHRLAEntities())
                {
                    db.tbl_Calls.Add(row);
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

        public bool UpdateCall(tbl_Calls row)
        {

            try
            {
                using (var db = new vt_LHRLAEntities())
                {
                    tbl_Calls val = new tbl_Calls();
                    val = db.tbl_Calls.Where(a => a.ID == row.ID).FirstOrDefault();
                    val.Caller_Number = row.Caller_Number;
                    val.Caller_Name = row.Caller_Name;
                    val.Operator_ID = row.Operator_ID;
                    val.Call_Start_DateTime = row.Call_Start_DateTime;
                    val.Call_End_DateTime = row.Call_End_DateTime;
                    val.Call_Duration_In_Mins = row.Call_Duration_In_Mins;
                    val.Caller_Longitude = row.Caller_Longitude;
                    val.Caller_Latitude = row.Caller_Latitude;
                    val.City_ID = row.City_ID;
                    val.Is_Received = row.Is_Received;
                    val.Operator_Descp = row.Operator_Descp;

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
        public List<tbl_Call_Operators> GetAllCallOperators()
        {
            try
            {
                List<tbl_Call_Operators> lst = new List<tbl_Call_Operators>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Call_Operators.ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<tbl_Call_Operators> GetAllActiveCallOperators()
        {
            try
            {
                List<tbl_Call_Operators> lst = new List<tbl_Call_Operators>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Call_Operators.ToList().Where(a => a.Is_Active == true).ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public List<tbl_Call_Operators> GetCallOperatorsbyID(int ID)
        {
            try
            {
                List<tbl_Call_Operators> lst = new List<tbl_Call_Operators>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Call_Operators.Where(e => e.ID == ID).ToList();
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