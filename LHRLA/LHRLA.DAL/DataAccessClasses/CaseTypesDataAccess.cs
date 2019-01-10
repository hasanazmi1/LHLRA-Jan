using LHRLA.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LHRLA.LHRLA.DAL.DataAccessClasses
{
    public class CaseTypesDataAccess
    {
        #region Insert
        public bool AddCaseTypes(tbl_Case_Types row)
        {

            try
            {
                using (var db = new vt_LHRLAEntities())
                {
                    db.tbl_Case_Types.Add(row);
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

        public bool UpdateCaseTypes(tbl_Case_Types row)
        {

            try
            {
                using (var db = new vt_LHRLAEntities())
                {
                    tbl_Case_Types val = new tbl_Case_Types();
                    val = db.tbl_Case_Types.Where(a => a.ID == row.ID).FirstOrDefault();
                    val.Type = row.Type;
                    val.Case_Sub_Type_ID = row.Case_Sub_Type_ID;
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
        public List<tbl_Case_Sub_Types> GetAllCaseTypes()
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

        public List<tbl_Case_Types> GetAllMainCaseTypes()
        {
            try
            {
                List<tbl_Case_Types> lst = new List<tbl_Case_Types>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Case_Types.ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<tbl_Case_Types> GetAllActiveCaseTypes()
        {
            try
            {
                List<tbl_Case_Types> lst = new List<tbl_Case_Types>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Case_Types.ToList().Where(a => a.Is_Active == true).ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public List<tbl_Case_Types> GetCaseTypesbyID(int ID)
        {
            try
            {
                List<tbl_Case_Types> lst = new List<tbl_Case_Types>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Case_Types.Where(e => e.ID == ID).ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
        public List<tbl_Case_Types> GetCaseTypesbyCaseSubTypeID(int ID)
        {
            try
            {
                List<tbl_Case_Types> lst = new List<tbl_Case_Types>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Case_Types.OrderBy(x=> x.ID).Where(e => e.Case_Sub_Type_ID == ID).ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<tbl_Case_Sub_Types> GetCaseSubTypeValue(int ID)
        {
            try
            {
                List<tbl_Case_Sub_Types> lst = new List<tbl_Case_Sub_Types>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Case_Sub_Types.OrderBy(x => x.ID).Where(e => e.ID == ID).ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<tbl_Case_Sub_Types> GetCaseSubTypeID(int ID)
        {
            try
            {
                List<tbl_Case_Sub_Types> lst = new List<tbl_Case_Sub_Types>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Case_Sub_Types.OrderBy(x => x.ID).Where(e => e.ID == ID).ToList();
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