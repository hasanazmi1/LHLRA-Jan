using LHRLA.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LHRLA.LHRLA.DAL.DataAccessClasses
{
    public class CaseDataDataAccess
    {
        #region Insert
        public bool AddCaseData(tbl_Case_Data row)
        {

            try
            {
                using (var db = new vt_LHRLAEntities())
                {
                    db.tbl_Case_Data.Add(row);
                    db.SaveChanges();

                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool AddAllCaseData(List<tbl_Case_Data> rows)
        {

            try
            {
                using (var db = new vt_LHRLAEntities())
                { 
                    db.tbl_Case_Data.AddRange(rows);
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

        public bool UpdateCaseData(tbl_Case_Data row)
        {

            try
            {
                using (var db = new vt_LHRLAEntities())
                {
                    tbl_Case_Data val = new tbl_Case_Data();
                    val = db.tbl_Case_Data.Where(a => a.ID == row.ID).FirstOrDefault();
                    val.Case_ID = row.Case_ID;
                    val.Field_Value = row.Field_Value;
                    val.Description = row.Description;

                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateCaseDataOnApproval(int CaseId,int LogId)
        {

            try
            {
                using (var db = new vt_LHRLAEntities())
                {
                    List<tbl_Case_Data> lstOldData= new List<tbl_Case_Data>();
                    List<tbl_Case_Data_temp> lstNewData = new List<tbl_Case_Data_temp>();
                    lstOldData = db.tbl_Case_Data.Where(a => a.Case_ID == CaseId).ToList();
                    lstNewData = db.tbl_Case_Data_temp.Where(a => a.Case_ID == CaseId && a.CaseHistoryLogID==LogId).ToList();
                    for (int i = 0; i < lstNewData.Count; i++)
                    {
                        tbl_Case_Data val = new tbl_Case_Data();
                        val=lstOldData.Where(a => a.Case_ID == lstNewData[i].Case_ID && a.Case_Field_ID == lstNewData[i].Case_Field_ID).FirstOrDefault();
                        
                        if (val != null)
                        {
                            val.Field_Value = lstNewData[i].Field_Value;
                            val.Description = lstNewData[i].Description;
                            db.SaveChanges();
                        }
                        else //if data didn't exist in old data
                        {
                            tbl_Case_Data val2 = new tbl_Case_Data();
                            val2.Field_Value = lstNewData[i].Field_Value;
                            val2.Description = lstNewData[i].Description;
                            val2.Case_ID = lstNewData[i].Case_ID;
                            val2.Case_Field_ID = lstNewData[i].Case_Field_ID;
                            AddCaseData(val2);
                        }
                    }
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
        public List<tbl_Case_Data> GetAllCaseData()
        {
            try
            {
                List<tbl_Case_Data> lst = new List<tbl_Case_Data>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Case_Data.ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public List<tbl_Branch> GetAllActiveBranches()
        //{
        //    try
        //    {
        //        List<tbl_Branch> lst = new List<tbl_Branch>();
        //        using (var db = new vt_LHRLAEntities())
        //        {
        //            lst = db.tbl_Branch.ToList().Where(a => a.Is_Active == true).ToList();
        //        }
        //        return lst;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}



        public List<tbl_Case_Data> GetCaseDatabyID(int ID)
        {
            try
            {
                List<tbl_Case_Data> lst = new List<tbl_Case_Data>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Case_Data.Where(e => e.Case_Field_ID == ID).ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<tbl_Case_Data> GetCaseDatabyCaseId(int CaseId)
        {
            try
            {
                List<tbl_Case_Data> lst = new List<tbl_Case_Data>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Case_Data.Where(e => e.Case_ID==CaseId).ToList();
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