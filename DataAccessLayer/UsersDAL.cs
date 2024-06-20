using DataAccessLayer.Helper;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class UsersDAL
    {
        DataHelper helper = new DataHelper();
        public int GetTotalUser()
        {
            try
            {
                DataTable tb = helper.ExcuteReader("Pro_TotalUser");
                if (tb != null)
                {
                    int result = int.Parse(tb.Rows[0]["totalUser"].ToString());
                    return result;
                }
                else return 0;

            }catch (Exception ex)
            {
                throw ex;
            }
        }

        public UsersModel getById(int id)
        {
            try
            {
                DataTable tb = helper.ExcuteReader("Pro_GetUserById","@id",id);
                if (tb != null)
                {
                    UsersModel us = new UsersModel();
                    us.id = int.Parse(tb.Rows[0]["id"].ToString());
                    us.password = tb.Rows[0]["password"].ToString();
                    us.us_name = tb.Rows[0]["us_name"].ToString();
                    us.updated_at = tb.Rows[0]["updated_at"] != DBNull.Value ? DateTime.Parse(tb.Rows[0]["updated_at"].ToString()) : DateTime.MinValue;
                    us.created_at = tb.Rows[0]["created_at"] != DBNull.Value ? DateTime.Parse(tb.Rows[0]["created_at"].ToString()) : DateTime.MinValue;
                    us.role_id = int.Parse(tb.Rows[0]["role"].ToString());
                    us.province = tb.Rows[0]["province"].ToString();
                    us.district = tb.Rows[0]["district"].ToString();
                    us.ward = tb.Rows[0]["ward"].ToString();
                    us.email = tb.Rows[0]["email"].ToString();
                    us.active = bool.Parse(tb.Rows[0]["active"].ToString());
                    us.phone_number = tb.Rows[0]["phonenumber"].ToString();
                    us.birthday = tb.Rows[0]["birthday"] != DBNull.Value ? DateTime.Parse(tb.Rows[0]["birthday"].ToString()) : DateTime.MinValue;
                    return us;

                }
                else return null;
         
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<UsersModel> searchUser(int? pageIndex, int? pageSize,string value , out int total)
        {
            total = 0;
            try
            {
                DataTable tb = helper.ExcuteReader("Pro_SearchUser", "@pageIndex", "@pageSize", "@value", pageIndex, pageSize, value);
                if (tb != null)
                {
                    List<UsersModel> list = new List<UsersModel>();
                    total = int.Parse(tb.Rows[0]["RecordCount"].ToString());
                    for (int i = 0; i < tb.Rows.Count; i++)
                    {
                        UsersModel us = new UsersModel();
                        us.id = int.Parse(tb.Rows[i]["id"].ToString());
                        us.password = tb.Rows[i]["password"].ToString();
                        us.us_name = tb.Rows[i]["us_name"].ToString();
                        us.updated_at = tb.Rows[i]["updated_at"] != DBNull.Value ? DateTime.Parse(tb.Rows[i]["updated_at"].ToString()) : DateTime.MinValue;
                        us.created_at = tb.Rows[i]["created_at"] != DBNull.Value ? DateTime.Parse(tb.Rows[i]["created_at"].ToString()) : DateTime.MinValue;
                        us.role_id = int.Parse(tb.Rows[i]["role"].ToString());
                        us.province = tb.Rows[i]["province"].ToString();
                        us.district = tb.Rows[i]["district"].ToString();
                        us.ward = tb.Rows[i]["ward"].ToString();
                        us.email = tb.Rows[i]["email"].ToString();
                        us.active = bool.Parse(tb.Rows[i]["active"].ToString());
                        us.phone_number = tb.Rows[i]["phonenumber"].ToString();
                        us.birthday = tb.Rows[i]["birthday"] != DBNull.Value ? DateTime.Parse(tb.Rows[i]["birthday"].ToString()) : DateTime.MinValue;
                        list.Add(us);
                    }
                    return list;
                }
                else return null;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public List<UsersModel> searchCustomer(int? pageIndex, int? pageSize, string value, out int total)
        {
            total = 0;
            try
            {
                DataTable tb = helper.ExcuteReader("Pro_SearchCustomer", "@pageIndex", "@pageSize", "@value", pageIndex, pageSize, value);
                if (tb != null)
                {
                    List<UsersModel> list = new List<UsersModel>();
                    total = int.Parse(tb.Rows[0]["RecordCount"].ToString());
                    for (int i = 0; i < tb.Rows.Count; i++)
                    {
                        UsersModel us = new UsersModel();
                        us.id = int.Parse(tb.Rows[i]["id"].ToString());
                        us.password = tb.Rows[i]["password"].ToString();
                        us.us_name = tb.Rows[i]["us_name"].ToString();
                        us.updated_at = tb.Rows[i]["updated_at"] != DBNull.Value ? DateTime.Parse(tb.Rows[i]["updated_at"].ToString()) : DateTime.MinValue;
                        us.created_at = tb.Rows[i]["created_at"] != DBNull.Value ? DateTime.Parse(tb.Rows[i]["created_at"].ToString()) : DateTime.MinValue;
                        us.role_id = int.Parse(tb.Rows[i]["role"].ToString());
                        us.province = tb.Rows[i]["province"].ToString();
                        us.district = tb.Rows[i]["district"].ToString();
                        us.ward = tb.Rows[i]["ward"].ToString();
                        us.email = tb.Rows[i]["email"].ToString();
                        us.active = bool.Parse(tb.Rows[i]["active"].ToString());
                        us.phone_number = tb.Rows[i]["phonenumber"].ToString();
                        us.birthday = tb.Rows[i]["birthday"] != DBNull.Value ? DateTime.Parse(tb.Rows[i]["birthday"].ToString()) : DateTime.MinValue;
                        list.Add(us);
                    }
                    return list;
                }
                else return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<UsersModel> getList (int? pageIndex, int? pageSize,int role_id,out int total)
        {
            total = 0;
            try
            {
                DataTable tb = helper.ExcuteReader("Pro_GetListUsers","@pageIndex","@pageSize","@role_id",pageIndex,pageSize,role_id);
                if (tb != null)
                {
                    List<UsersModel> list = new List<UsersModel>();
                    total = int.Parse(tb.Rows[0]["RecordCount"].ToString());
                    for (int i = 0; i < tb.Rows.Count; i++)
                    {
                        UsersModel us = new UsersModel();
                        us.id = int.Parse(tb.Rows[i]["id"].ToString());
                        us.password = tb.Rows[i]["password"].ToString();
                        us.us_name = tb.Rows[i]["us_name"].ToString();
                        us.updated_at = tb.Rows[i]["updated_at"] != DBNull.Value ? DateTime.Parse(tb.Rows[i]["updated_at"].ToString()) : DateTime.MinValue;
                        us.created_at = tb.Rows[i]["created_at"] != DBNull.Value ? DateTime.Parse(tb.Rows[i]["created_at"].ToString()) : DateTime.MinValue;
                        us.role_id = int.Parse(tb.Rows[i]["role"].ToString());
                        us.province = tb.Rows[i]["province"].ToString();
                        us.district = tb.Rows[i]["district"].ToString();
                        us.ward = tb.Rows[i]["ward"].ToString();
                        us.email = tb.Rows[i]["email"].ToString();
                        us.active = bool.Parse(tb.Rows[i]["active"].ToString());
                        us.phone_number = tb.Rows[i]["phonenumber"].ToString();
                        us.birthday = tb.Rows[i]["birthday"] != DBNull.Value ? DateTime.Parse(tb.Rows[i]["birthday"].ToString()) : DateTime.MinValue;
                        list.Add(us);
                    }
                    return list;
                }
                else return null;

            }catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Create(UsersModel user)
        {
            try
            {
                int result = helper.ExcuteNonQuery("Pro_CreateUsers", "@password","@us_name","@email","@phoneNumber","@birthday","@province","@district","@ward","@role_id",
                                                    user.password,user.us_name,user.email,user.phone_number,user.birthday,user.province,user.district,user.ward,user.role_id
                    );
                return result;

            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public int Update(UsersModel user)
        {
            try
            {
                int result = helper.ExcuteNonQuery("Pro_UpdateUsers", "@password", "@us_name", "@email", "@phoneNumber", "@birthday", "@province", "@district", "@ward","@created_at","@id",
                                                    user.password, user.us_name, user.email, user.phone_number, user.birthday, user.province, user.district, user.ward,user.created_at,user.id
                    );
                return result;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Delete(int id)
        {
            try
            {
                int result = helper.ExcuteNonQuery("Pro_DeleteUsers", "@id",id);
                return result;
            }catch(Exception ex)
            {
                throw ex;
            }
        }


        public UsersModel Login(string value,string passWord)
        {
            try
            {
                DataTable tb = helper.ExcuteReader("Pro_Login","@value","@passWord",value,passWord);
                if (tb != null && tb.Rows.Count > 0)
                {
                    UsersModel us = new UsersModel();
                    us.id = int.Parse(tb.Rows[0]["id"].ToString());
                    us.password = tb.Rows[0]["password"].ToString();
                    us.us_name = tb.Rows[0]["us_name"].ToString();
                    us.updated_at = tb.Rows[0]["updated_at"] != DBNull.Value ? DateTime.Parse(tb.Rows[0]["updated_at"].ToString()) : DateTime.MinValue;
                    us.updated_at = tb.Rows[0]["created_at"] != DBNull.Value ? DateTime.Parse(tb.Rows[0]["created_at"].ToString()) : DateTime.MinValue;
                    us.role_id = int.Parse(tb.Rows[0]["role"].ToString());
                    us.province = tb.Rows[0]["province"].ToString();
                    us.district = tb.Rows[0]["district"].ToString();
                    us.ward = tb.Rows[0]["ward"].ToString();
                    us.email = tb.Rows[0]["email"].ToString();
                    us.active = bool.Parse(tb.Rows[0]["active"].ToString());
                    us.phone_number = tb.Rows[0]["phonenumber"].ToString();
                    us.birthday = tb.Rows[0]["birthday"] != DBNull.Value ? DateTime.Parse(tb.Rows[0]["birthday"].ToString()) : DateTime.MinValue;
                    return us;

                }
                else return null;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
