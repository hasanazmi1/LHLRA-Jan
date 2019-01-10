using LHRLA.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LHRLA.LHRLA.DAL.DataAccessClasses
{
    public class UserDataAccess
    {
        #region Insert
        public bool AddUser(tbl_User row)
        {

            try
            {
                using (var db = new vt_LHRLAEntities())
                {
                    db.tbl_User.Add(row);
                    db.SaveChanges();

                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public long CreateUser(tbl_User row)
        {

            try
            {
                using (var db = new vt_LHRLAEntities())
                {
                    db.tbl_User.Add(row);
                    db.SaveChanges();
                }
                return row.ID;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        #endregion

        #region Update

        public bool UpdateUser(tbl_User row)
        {

            try
            {
                using (var db = new vt_LHRLAEntities())
                {
                    tbl_User val = new tbl_User();
                    val = db.tbl_User.Where(a => a.ID == row.ID).FirstOrDefault();
                    val.User_Name = row.User_Name;
                    val.User_Password = row.User_Password;
                    val.Email = row.Email;
                    val.Name = row.Name;
                    val.Role_ID = row.Role_ID;
                    val.Contact = row.Contact;
                    val.Address = row.Address;
                    val.City_ID = row.City_ID;
                    val.Is_Active = row.Is_Active;
                    val.Supervisor_ID = row.Supervisor_ID;
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
        public List<tbl_User> GetAllUsers()
        {
            try
            {
                List<tbl_User> lst = new List<tbl_User>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_User.ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<tbl_User> GetAllActiveUsers()
        {
            try
            {
                List<tbl_User> lst = new List<tbl_User>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_User.ToList().Where(a => a.Is_Active == true).ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public List<tbl_User> GetUserbyID(long ID)
        {
            try
            {
                
                List<tbl_User> lst = new List<tbl_User>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_User.Where(e => e.ID == ID).ToList();
                  
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<tbl_User> GetUserbyIDOnUpdate(long ID,string email)
        {
            try
            {

                List<tbl_User> lst = new List<tbl_User>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_User.Where(e => e.ID != ID && e.Email == email).ToList();

                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<tbl_User> GetUserbyIDName(long ID, string email)
        {
            try
            {

                List<tbl_User> lst = new List<tbl_User>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_User.Where(e => e.ID == ID && e.Email == email).ToList();

                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        

        public List<tbl_User> CheckUser(string email, string password)
        {
            try
            {
                List<tbl_User> lst = new List<tbl_User>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_User.Where(o => o.Email.ToLower() == email.ToLower() && o.User_Password == password).ToList();
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<tbl_User> CheckUserEmail(string email)
        {
            try
            {
                List<tbl_User> lst = new List<tbl_User>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_User.Where(o => o.Email.ToLower().Equals(email.ToLower())).ToList();
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<tbl_User> UserLoginApp(string email, string password, bool IsAdmin)
        {
            try
            {
                List<tbl_User> lst = new List<tbl_User>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_User.Where(o => o.Email.ToLower() == email.ToLower() && o.User_Password == password).ToList();
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool IsSupervisor(int UserId,int SupervisorId)
        {
            try
            {
                bool IsSupervisor = false;
                List<tbl_User> lst = new List<tbl_User>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_User.Where(a=>a.ID==UserId && a.Supervisor_ID==SupervisorId).ToList();
                    if (lst.Count>0)
                    {
                        IsSupervisor = true;
                    }
                }
                return IsSupervisor;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion
    }

}