using LHRLA.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LHRLA.LHRLA.DAL.DataAccessClasses
{
    public class CaseFieldsDataAccesscs
    {
        #region Insert
        public bool AddCaseFields(tbl_Case_Fields row)
        {

            try
            {
                using (var db = new vt_LHRLAEntities())
                {
                    db.tbl_Case_Fields.Add(row);
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

        public bool UpdateCaseFields(tbl_Case_Fields row)
        {

            try
            {
                using (var db = new vt_LHRLAEntities())
                {
                    tbl_Case_Fields val = new tbl_Case_Fields();
                    val = db.tbl_Case_Fields.Where(a => a.ID == row.ID).FirstOrDefault();
                    val.Name = row.Name;
                    val.Field_Type = row.Field_Type;
                    val.Is_Active = row.Is_Active;
                    val.Sequence_No = row.Sequence_No;
                    val.Is_Mandatory = row.Is_Mandatory;
                    val.Is_Visible_On_App = row.Is_Visible_On_App;
                    val.Case_Field_Section_ID = row.Case_Field_Section_ID;
                    val.Is_Encrypted = row.Is_Encrypted;
                    val.Is_Hidden = row.Is_Hidden;
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
        public List<tbl_Case_Fields> GetAllCaseFields()
        {
            try
            {
                List<tbl_Case_Fields> lst = new List<tbl_Case_Fields>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Case_Fields.ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<tbl_Case_Fields_Section> GetAllCaseFieldsSections()
        {
            try
            {
                List<tbl_Case_Fields_Section> lst = new List<tbl_Case_Fields_Section>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Case_Fields_Section.ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<tbl_Case_Fields_Section> GetAllCaseFieldsBySectionID(int id)
        {
            try
            {
                List<tbl_Case_Fields_Section> lst = new List<tbl_Case_Fields_Section>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Case_Fields_Section.Where(o=> o.ID == id).ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<tbl_Case_Fields> GetAllActiveCaseFields()
        {
            try
            {
                List<tbl_Case_Fields> lst = new List<tbl_Case_Fields>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Case_Fields.ToList().Where(a => a.Is_Active == true).ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public List<tbl_Case_Fields> GetCaseFieldsbyID(int ID)
        {
            try
            {
                List<tbl_Case_Fields> lst = new List<tbl_Case_Fields>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Case_Fields.Where(e => e.ID == ID).ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<tbl_Case_Fields> GetAppCaseFields()
        {		
	            try		
	            {		
                List<tbl_Case_Fields> lst = new List<tbl_Case_Fields>();		
                using (var db = new vt_LHRLAEntities())		
	                {		
	                    lst = db.tbl_Case_Fields.Where(e => e.Is_Active==true && e.Is_Visible_On_App==true).ToList();		
	                }		
	                return lst;		
            }		
	            catch (Exception ex)		
	            {		
	                throw ex;		
	            }		
	        }

        public List<tbl_Case_Fields> GetCaseFieldlbySectionID(int ID)
        {
            try
            {
                List<tbl_Case_Fields> lst = new List<tbl_Case_Fields>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Case_Fields.OrderBy(x => x.ID).Where(e => e.Case_Field_Section_ID == ID).ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<tbl_Case_Fields> GetCaseSequencebySectionID(int ID)
        {
            try
            {
                List<tbl_Case_Fields> lst = new List<tbl_Case_Fields>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Case_Fields.OrderBy(x => x.ID).Where(e => e.ID == ID).ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<tbl_Case_Fields_Options> GetOptionsByFieldID(int ID)
        {
            try
            {
                List<tbl_Case_Fields_Options> lst = new List<tbl_Case_Fields_Options>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Case_Fields_Options.OrderBy(x => x.ID).Where(e => e.Case_Field_ID == ID && e.Is_Active == true).ToList();
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