using LHRLA.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LHRLA.LHRLA.DAL
{
    public class CaseRegisterationTypesDataAccess
    {
        #region Insert
        public bool AddCaseRegisterationTypes(tbl_Case_Registeration_Types row)
        {

            try
            {
                using (var db = new vt_LHRLAEntities())
                {
                    db.tbl_Case_Registeration_Types.Add(row);
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

        public bool UpdateCaseRegisterationTypes(tbl_Case_Registeration_Types row)
        {

            try
            {
                using (var db = new vt_LHRLAEntities())
                {
                    tbl_Case_Registeration_Types val = new tbl_Case_Registeration_Types();
                    val = db.tbl_Case_Registeration_Types.Where(a => a.ID == row.ID).FirstOrDefault();
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
        public List<tbl_Case_Registeration_Types> GetAllCaseRegisterationTypes()
        {
            try
            {
                List<tbl_Case_Registeration_Types> lst = new List<tbl_Case_Registeration_Types>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Case_Registeration_Types.ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<tbl_Case_Registeration_Types> GetAllActiveCaseRegisterationTypes()
        {
            try
            {
                List<tbl_Case_Registeration_Types> lst = new List<tbl_Case_Registeration_Types>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Case_Registeration_Types.ToList().Where(a => a.Is_Active == true).ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<tbl_Case_Registeration_Types> CheckDuplicateData(string Type)
        {
            try
            {
                List<tbl_Case_Registeration_Types> lst = new List<tbl_Case_Registeration_Types>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Case_Registeration_Types.ToList().Where(a => a.Type == Type).ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public List<tbl_Case_Registeration_Types> GetCaseRegisterationTypesbyID(int ID)
        {
            try
            {
                List<tbl_Case_Registeration_Types> lst = new List<tbl_Case_Registeration_Types>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Case_Registeration_Types.Where(e => e.ID == ID).ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<tbl_Case_Registeration_Types> GetCaseRegisterationTypesbyIDOnUpdate(int ID,string type)
        {
            try
            {
                List<tbl_Case_Registeration_Types> lst = new List<tbl_Case_Registeration_Types>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Case_Registeration_Types.Where(e => e.ID != ID && e.Type == type).ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<tbl_Case_Registeration_Types> GetCaseRegisterationTypesOfExistingData(int ID, string type)
        {
            try
            {
                List<tbl_Case_Registeration_Types> lst = new List<tbl_Case_Registeration_Types>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Case_Registeration_Types.Where(e => e.ID == ID && e.Type == type).ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<tbl_Case_Registeration_Types> GetActiveCaseRegisterationTypesbyID(int ID)
        {
            try
            {
                List<tbl_Case_Registeration_Types> lst = new List<tbl_Case_Registeration_Types>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Case_Registeration_Types.Where(e => e.ID == ID && e.Is_Active == true).ToList();
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