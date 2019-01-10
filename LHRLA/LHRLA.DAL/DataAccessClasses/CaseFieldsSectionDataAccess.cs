using LHRLA.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LHRLA.LHRLA.DAL.DataAccessClasses
{
    public class CaseFieldsSectionDataAccess
    {
        #region Insert
        public bool AddCaseFiledsSection(tbl_Case_Fields_Section row)
        {

            try
            {
                using (var db = new vt_LHRLAEntities())
                {
                    db.tbl_Case_Fields_Section.Add(row);
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

        public bool UpdateCaseFiledsSection(tbl_Case_Fields_Section row)
        {

            try
            {
                using (var db = new vt_LHRLAEntities())
                {
                    tbl_Case_Fields_Section val = new tbl_Case_Fields_Section();
                    val = db.tbl_Case_Fields_Section.Where(a => a.ID == row.ID).FirstOrDefault();
                    val.Name = row.Name;
                    val.Sequence_No = row.Sequence_No;
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
        public List<tbl_Case_Fields_Section> GetAllCaseFiledsSections()
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

        public List<tbl_Case_Fields_Section> GetAllActiveCaseFiledsSections()
        {
            try
            {
                List<tbl_Case_Fields_Section> lst = new List<tbl_Case_Fields_Section>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Case_Fields_Section.ToList().Where(a => a.Is_Active == true).ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public List<tbl_Case_Fields_Section> GetCaseFiledsSectionbyID(int ID)
        {
            try
            {
                List<tbl_Case_Fields_Section> lst = new List<tbl_Case_Fields_Section>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Case_Fields_Section.Where(e => e.ID == ID).ToList();
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