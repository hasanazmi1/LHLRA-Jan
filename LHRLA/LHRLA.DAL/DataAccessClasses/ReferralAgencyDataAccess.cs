using LHRLA.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LHRLA.LHRLA.DAL.DataAccessClasses
{
    public class ReferralAgencyDataAccess
    {
        #region Insert
        public bool AddReferralAgency(tbl_Referral_Agency row)
        {

            try
            {
                using (var db = new vt_LHRLAEntities())
                {
                    db.tbl_Referral_Agency.Add(row);
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

        public bool UpdateReferralAgency(tbl_Referral_Agency row)
        {

            try
            {
                using (var db = new vt_LHRLAEntities())
                {
                    tbl_Referral_Agency val = new tbl_Referral_Agency();
                    val = db.tbl_Referral_Agency.Where(a => a.ID == row.ID).FirstOrDefault();
                    val.Name = row.Name;
                    val.Name = row.Name;
                    val.Description = row.Description;
                    val.Contact_Details = row.Contact_Details;
                    val.Address = row.Address;
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
        public List<tbl_Referral_Agency> GetAllReferralAgency()
        {
            try
            {
                List<tbl_Referral_Agency> lst = new List<tbl_Referral_Agency>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Referral_Agency.ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<tbl_Referral_Agency> CheckDuplicateData(string Name)
        {
            try
            {
                List<tbl_Referral_Agency> lst = new List<tbl_Referral_Agency>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Referral_Agency.Where(o=> o.Name == Name).ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public List<tbl_Referral_Agency> GetAllActiveBranches()
        //{
        //    try
        //    {
        //        List<tbl_Referral_Agency> lst = new List<tbl_Referral_Agency>();
        //        using (var db = new vt_LHRLAEntities())
        //        {
        //            lst = db.tbl_Referral_Agency.ToList().Where(a => a.Is_Active == true).ToList();
        //        }
        //        return lst;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}



        public List<tbl_Referral_Agency> GetReferralAgencybyID(int ID)
        {
            try
            {
                List<tbl_Referral_Agency> lst = new List<tbl_Referral_Agency>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Referral_Agency.Where(e => e.ID == ID).ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<tbl_Referral_Agency> GetReferralAgencybyIDOfExistingName(int ID,string name)
        {
            try
            {
                List<tbl_Referral_Agency> lst = new List<tbl_Referral_Agency>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Referral_Agency.Where(e => e.ID == ID && e.Name == name).ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<tbl_Referral_Agency> GetReferralAgencybyIDName(int ID, string name)
        {
            try
            {
                List<tbl_Referral_Agency> lst = new List<tbl_Referral_Agency>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Referral_Agency.Where(e => e.ID != ID && e.Name == name).ToList();
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