using LHRLA.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LHRLA.LHRLA.DAL.DataAccessClasses
{
    public class CallOperatorsDataAccess
    {
        #region Insert
        public bool AddCallOperators(tbl_Call_Operators row)
        {

            try
            {
                using (var db = new vt_LHRLAEntities())
                {
                    db.tbl_Call_Operators.Add(row);
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

        public bool UpdateCallOperators(tbl_Call_Operators row)
        {

            try
            {
                using (var db = new vt_LHRLAEntities())
                {
                    tbl_Call_Operators val = new tbl_Call_Operators();
                    val = db.tbl_Call_Operators.Where(a => a.ID == row.ID ).FirstOrDefault();
                    val.Name = row.Name;
                    val.Description = row.Description;
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