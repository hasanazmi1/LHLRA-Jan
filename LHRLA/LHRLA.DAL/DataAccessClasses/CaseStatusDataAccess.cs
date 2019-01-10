using LHRLA.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LHRLA.LHRLA.DAL.DataAccessClasses
{
    public class CaseStatusDataAccess
    {
        vt_LHRLAEntities db = new vt_LHRLAEntities();
        #region Insert
        public bool AddCaseStatus(tbl_Case_Status row)
        {

            try
            {
               
               // {
                    db.tbl_Case_Status.Add(row) ;
                    db.SaveChanges();

               // }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        #endregion

        #region Update

        public bool UpdateCaseStatus(tbl_Case_Status row)
        {

            try
            {
                using (var db = new vt_LHRLAEntities())
                {
                    tbl_Case_Status val = new tbl_Case_Status();
                    val = db.tbl_Case_Status.Where(a => a.ID == row.ID).FirstOrDefault();
                    val.Code = row.Code;
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
        public List<tbl_Case_Status> GetAllCaseStatus()
        {
            try
            {
                List<tbl_Case_Status> lst = new List<tbl_Case_Status>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Case_Status.ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<tbl_Case_Status> GetAllActiveCaseStatus()
        {
            try
            {
                List<tbl_Case_Status> lst = new List<tbl_Case_Status>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Case_Status.ToList().Where(a => a.Is_Active == true).ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<tbl_Case_Status> CheckDuplicateData(string Code)
        {
            try
            {
                List<tbl_Case_Status> lst = new List<tbl_Case_Status>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Case_Status.ToList().Where(a => a.Code == Code).ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public List<tbl_Case_Status> GetCaseStatusbyID(int ID)
        {
            try
            {
                List<tbl_Case_Status> lst = new List<tbl_Case_Status>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Case_Status.Where(e => e.ID == ID).ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<tbl_Case_Status> GetCaseStatusbyIDOnUpdate(int ID,string Code )
        {
            try
            {
                List<tbl_Case_Status> lst = new List<tbl_Case_Status>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Case_Status.Where(e => e.ID != ID && e.Code == Code).ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<tbl_Case_Status> GetCaseStatusbyIDOfExistingData(int ID, string Code)
        {
            try
            {
                List<tbl_Case_Status> lst = new List<tbl_Case_Status>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Case_Status.Where(e => e.ID == ID && e.Code == Code).ToList();
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