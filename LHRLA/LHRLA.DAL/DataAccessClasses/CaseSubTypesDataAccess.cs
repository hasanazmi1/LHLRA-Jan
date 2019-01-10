using LHRLA.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LHRLA.LHRLA.DAL.DataAccessClasses
{
    public class CaseSubTypesDataAccess
    {
        #region Insert
        public bool AddCaseSubTypes(tbl_Case_Sub_Types row)
        {

            try
            {
                using (var db = new vt_LHRLAEntities())
                {
                    db.tbl_Case_Sub_Types.Add(row);
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

        public bool UpdateCaseSubTypes(tbl_Case_Sub_Types row)
        {

            try
            {
                using (var db = new vt_LHRLAEntities())
                {
                    tbl_Case_Sub_Types val = new tbl_Case_Sub_Types();
                    val = db.tbl_Case_Sub_Types.Where(a => a.ID == row.ID).FirstOrDefault();
                    val.Type = row.Type;
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
        public List<tbl_Case_Sub_Types> GetAllCaseSubTypes()
        {
            try
            {
                List<tbl_Case_Sub_Types> lst = new List<tbl_Case_Sub_Types>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Case_Sub_Types.ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<tbl_Case_Sub_Types> GetAllActiveCaseSubTypes()
        {
            try
            {
                List<tbl_Case_Sub_Types> lst = new List<tbl_Case_Sub_Types>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Case_Sub_Types.ToList().Where(a => a.Is_Active == true).ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public List<tbl_Case_Sub_Types> GetCaseSubTypesbyID(int ID)
        {
            try
            {
                List<tbl_Case_Sub_Types> lst = new List<tbl_Case_Sub_Types>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Case_Sub_Types.Where(e => e.ID == ID).ToList();
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