using LHRLA.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LHRLA.LHRLA.DAL.DataAccessClasses
{
    public class MeetingsDataAccess
    {
        #region Insert
        public bool AddMeetings(tbl_Meetings row)
        {

            try
            {
                using (var db = new vt_LHRLAEntities())
                {
                    db.tbl_Meetings.Add(row);
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

        public bool UpdateMeetings(tbl_Meetings row)
        {

            try
            {
                using (var db = new vt_LHRLAEntities())
                {
                    tbl_Meetings val = new tbl_Meetings();
                    val = db.tbl_Meetings.Where(a => a.ID == row.ID).FirstOrDefault();
                    val.Start_Datetime = row.Start_Datetime;
                    val.End_Datetime = row.End_Datetime;
                    val.Location_Descp = row.Location_Descp;
                    val.City_Id = row.City_Id;
                    val.Description = row.Description;
                    val.Followup_Notes = row.Followup_Notes;
                    val.Participants_Details = row.Participants_Details;
                    val.Case_ID = row.Case_ID;
                    val.Meeting_Initiated_By = row.Meeting_Initiated_By;
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
        public List<tbl_Meetings> GetAllMeetings()
        {
            try
            {
                List<tbl_Meetings> lst = new List<tbl_Meetings>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Meetings.ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public List<tbl_Meetings> GetAllActiveCaseTypes()
        //{
        //    try
        //    {
        //        List<tbl_Meetings> lst = new List<tbl_Meetings>();
        //        using (var db = new vt_LHRLAEntities())
        //        {
        //            lst = db.tbl_Meetings.ToList().Where(a => a.Is_Active == true).ToList();
        //        }
        //        return lst;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}



        public List<tbl_Meetings> GetMeetingsbyID(int ID)
        {
            try
            {
                List<tbl_Meetings> lst = new List<tbl_Meetings>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Meetings.Where(e => e.ID == ID).ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public tbl_Meetings GetMeetingsDetail(int ID)
        {
            try
            {
                tbl_Meetings lst = new tbl_Meetings();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Meetings.Where(e => e.ID == ID).FirstOrDefault();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<tbl_Meetings> GetMeetingsByDay(int Day, int Month, int Year,int UserId)
        {
            try
            {
                DateTime dt1 = new DateTime(Year, Month, Day);
                DateTime dt2 = dt1.AddDays(1);
                List<tbl_Meetings> lst = new List<tbl_Meetings>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Meetings.Where(e => e.Start_Datetime >= dt1 && e.Start_Datetime < dt2 && e.UserId==UserId).ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<int> GetMeetingsByMonth(int Month, int Year, int UserId)
        {
            try
            {
                DateTime dt1 = new DateTime(Year, Month, 1);
                DateTime dt2 = dt1.AddMonths(1);
                List<int> lstDays = new List<int>();
                List<tbl_Meetings> lst = new List<tbl_Meetings>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Meetings.Where(e => e.Start_Datetime >= dt1 && e.Start_Datetime < dt2 && e.UserId == UserId).ToList();
                }
                for (int i = 0; i < lst.Count; i++)
                {
                    lstDays.Add(DateTime.Parse(lst[i].Start_Datetime.ToString()).Day);
                }
                return lstDays;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion
    }
}