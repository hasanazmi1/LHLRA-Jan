using LHRLA.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LHRLA.LHRLA.DAL.DataAccessClasses
{
    public class CaseFieldsOptionsDataAccess
    {

        #region Insert
        public bool AddCaseFieldsOptions(tbl_Case_Fields_Options row)
        {

            try
            {
                using (var db = new vt_LHRLAEntities())
                {
                    row.Is_Active = true;
                    db.tbl_Case_Fields_Options.Add(row);
                    db.SaveChanges();

                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool AddCaseFieldsOptionsList(List<tbl_Case_Fields_Options> row)
        {

            try
            {
                using (var db = new vt_LHRLAEntities())
                {
                    //foreach (tbl_Case_Fields_Options tbl in row)
                    //{
                    //    db.tbl_Case_Fields_Options.Add(tbl);
                    //}
                    db.tbl_Case_Fields_Options.AddRange(row);
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

        public bool UpdateCaseFieldsOptions(tbl_Case_Fields_Options row)
        {

            try
            {
                using (var db = new vt_LHRLAEntities())
                {
                    tbl_Case_Fields_Options val = new tbl_Case_Fields_Options();
                    val = db.tbl_Case_Fields_Options.Where(a => a.ID == row.ID).FirstOrDefault();
                    val.Name = row.Name;
                    val.Case_Field_ID = row.Case_Field_ID;
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
        public bool DeleteCaseFieldsOptionsById(int id)
        {

            try
            {
                using (var db = new vt_LHRLAEntities())
                {
                    List<tbl_Case_Fields_Options> rows = new List<tbl_Case_Fields_Options>();
                    rows = db.tbl_Case_Fields_Options.Where(a => a.Case_Field_ID == id).ToList();
                    db.tbl_Case_Fields_Options.RemoveRange(rows);
                    db.SaveChanges();

                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool InActiveOptions(tbl_Case_Fields_Options row)
        {

            try
            {
                using (var db = new vt_LHRLAEntities())
                {
                    tbl_Case_Fields_Options val = new tbl_Case_Fields_Options();
                    val = db.tbl_Case_Fields_Options.Where(a => a.ID == row.ID).FirstOrDefault();                
                    val.Is_Active = false;
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
        public List<tbl_Case_Fields_Options> GetAllCaseFieldsOptions()
        {
            try
            {
                List<tbl_Case_Fields_Options> lst = new List<tbl_Case_Fields_Options>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Case_Fields_Options.ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<tbl_Case_Fields_Options> GetAllActiveCaseFieldsOptions()
        {
            try
            {
                List<tbl_Case_Fields_Options> lst = new List<tbl_Case_Fields_Options>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Case_Fields_Options.ToList().Where(a => a.Is_Active == true).ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public List<tbl_Case_Fields_Options> GetCaseFieldsOptionsbyID(int ID)
        {
            try
            {
                List<tbl_Case_Fields_Options> lst = new List<tbl_Case_Fields_Options>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Case_Fields_Options.Where(e => e.ID == ID).ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<tbl_Case_Fields_Options> GetCaseFieldsOptionsbyField(int FieldId)
        {
            try
            {
                List<tbl_Case_Fields_Options> lst = new List<tbl_Case_Fields_Options>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Case_Fields_Options.Where(e => e.Case_Field_ID==FieldId && e.Is_Active==true).ToList();
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