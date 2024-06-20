using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Helper;
using Model;
namespace DataAccessLayer
{
    public class OrderDAL
    {
        DataHelper helper = new DataHelper();
        List<OrderModel> orders;

        public List<OrderStatisticsModel> CountOrderYear()
        {
            try
            {
               DataTable tb = helper.ExcuteReader("Pro_GetTotalOrderByMonth");
                if (tb != null)
                {
                   List<OrderStatisticsModel> list = new List<OrderStatisticsModel>();
                    for (int i = 0; i < tb.Rows.Count; i++)
                    {
                        OrderStatisticsModel model = new OrderStatisticsModel();
                        model.totalOrder = int.Parse(tb.Rows[i]["totalOrder"].ToString());
                        model.month = int.Parse(tb.Rows[i]["month"].ToString());
                        list.Add(model);
                    }
                    return list;

                    
                }
                else return null;
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<Dictionary<string,int>> RevenueStatistics(int? fr_month,int? to_month )
        {
            try
            {
                DataTable tb = helper.ExcuteReader("Pro_Revenue_Statistics", "@fr_month", "@to_month", fr_month, to_month);
                if (tb != null)
                {
                    List<Dictionary<string, int>> list = new List<Dictionary<string, int>>();
                    for (int i = 0; i < tb.Rows.Count; i++)
                    {
                        Dictionary<string, int> reuslt = new Dictionary<string, int>();
                        int totalPrice = int.Parse(tb.Rows[i]["sum_revenue"].ToString());
                        int month = int.Parse(tb.Rows[i]["month"].ToString());
                        reuslt.Add("month", month);
                        reuslt.Add("totalPrice", totalPrice);
                        list.Add(reuslt);
                    }
                    return list;

                }
                else return null;
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public Dictionary<string,int> GetTotalOrderToday()
        {
            try
            {
                DataTable tb = helper.ExcuteReader("Pro_TotalOrderInDay");
                if (tb != null)
                {
                    int totalOrder = int.Parse(tb.Rows[0]["totalOrder"].ToString());
                    int totalPrice = tb.Rows[0]["totalMoney"] != DBNull.Value ? int.Parse(tb.Rows[0]["totalMoney"].ToString()):0;
                    Dictionary<string, int> reuslt = new Dictionary<string, int>();
                    reuslt.Add("totalOrder", totalOrder);
                    reuslt.Add("totalPrice", totalPrice);


                    return reuslt;

                }
                else return null;
            }catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Create(OrderModel order)
        {
            try
            {
                DataTable result = helper.ExcuteReader("Pro_CreateOrder", "@receiving_address", "@fullname", "@email", "@phone_number", "@money_total", 
                                                    "@status_id", "@shippingTypeId", "@paymentTypeId", "@list_json_orderdetail",
                                                    order.receiving_address, order.full_name, order.email, order.phone_number,order.money_total,
                                                    order.status_id,order.shippingType_id,order.paymentType_id
                                                    ,order.orderDetails != null ? MessageConvert.SerializeObject(order.orderDetails):null);
                return int.Parse(result.Rows[0]["orderId"].ToString());

            }catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Update(OrderModel order)
        {
            try
            {
                int result = helper.ExcuteNonQuery("Pro_UpdateOrder", "@id", "@receiving_address", "@fullname", "@email", "@phone_number","@money_total", "@order_date", "@shippingType_id", "@paymentType_id", "@status_id", "@list_orderdetail",
                                                     order.id, order.receiving_address, order.full_name, order.email, order.phone_number, order.money_total,order.order_date,order.shippingType_id,order.paymentType_id, order.status_id, order.orderDetails != null ? MessageConvert.SerializeObject(order.orderDetails) : null
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
                int reuslt = helper.ExcuteNonQuery("Pro_DeleteOrder","@id",id);
                return reuslt;
            }catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Cancel(int id)
        {
            try
            {
                int reuslt = helper.ExcuteNonQuery("Pro_CancelOrder", "@id", id);
                return reuslt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public OrderModel GetByIdAndPhoneOrEmail(int id , string option)
        {
            try
            {
                DataTable tb = helper.ExcuteReader("Pro_GetOrderByIdAndEmailOrPhone","@id","@input",id, option);
                if (tb != null)
                {
                    OrderModel order = new OrderModel();
                    order.orderDetails = new List<OrderDetailModel>();
                    order.id = int.Parse(tb.Rows[0]["id"].ToString());
                    order.receiving_address = tb.Rows[0]["receiving_address"].ToString();
                    order.phone_number = tb.Rows[0]["phone_number"].ToString();
                    order.money_total = int.Parse(tb.Rows[0]["money_total"].ToString());
                    order.order_date = tb.Rows[0]["order_date"] != DBNull.Value ? DateTime.Parse(tb.Rows[0]["order_date"].ToString()) : DateTime.MinValue;
                    order.update_at = tb.Rows[0]["update_at"] != DBNull.Value ? DateTime.Parse(tb.Rows[0]["update_at"].ToString()) : DateTime.MinValue;
                    order.status_id = int.Parse(tb.Rows[0]["status_id"].ToString());
                    order.email = tb.Rows[0]["email"].ToString();
                    order.full_name = tb.Rows[0]["full_name"].ToString();
                    order.paymentType_id = tb.Rows[0]["paymentType_id"] != DBNull.Value ? int.Parse(tb.Rows[0]["paymentType_id"].ToString()) : 0;
                    order.shippingType_id = tb.Rows[0]["shippingType_id"] != DBNull.Value ? int.Parse(tb.Rows[0]["shippingType_id"].ToString()) : 0;

                    for (int i = 0; i < tb.Rows.Count; i++)
                    {
                        OrderDetailModel orderDetail = new OrderDetailModel();
                        orderDetail.id = int.Parse(tb.Rows[i]["orderdetail_id"].ToString());
                        orderDetail.order_id = int.Parse(tb.Rows[0]["id"].ToString());
                        orderDetail.product_id = int.Parse(tb.Rows[0]["product_id"].ToString());
                        orderDetail.quantity = int.Parse(tb.Rows[i]["quantity"].ToString());
                        orderDetail.price = int.Parse(tb.Rows[i]["price"].ToString());
                        orderDetail.size_id = int.Parse(tb.Rows[i]["size_id"].ToString());
                        orderDetail.color_id = int.Parse(tb.Rows[i]["color_id"].ToString());
                        orderDetail.style_id = int.Parse(tb.Rows[i]["style_id"].ToString());
                        order.orderDetails.Add(orderDetail);

                    }
                    return order;
                }
                else return null;
            }catch(Exception ex)
            {
                throw ex;
            }

        }
        public List<OrderModel> GetListOrderWaitConfirmation(int?pageIndex,int ? pageSize,int status_id,out int total)
        {
            total = 0;
            try
            {

                DataTable tb = helper.ExcuteReader("Pro_GetListOrder","@pageIndex","@pageSize","@status_id",pageIndex,pageSize, status_id);
                if (tb != null)
                {
                    List<OrderModel> orderList = new List<OrderModel>();
                    total = int.Parse(tb.Rows[0]["RecordCount"].ToString());
                    for (int i = 0; i < tb.Rows.Count; i++)
                    {
                        OrderModel order = new OrderModel();
                        order.id = int.Parse(tb.Rows[i]["id"].ToString());
                        order.receiving_address = tb.Rows[i]["receiving_address"].ToString();
                        order.phone_number = tb.Rows[i]["phone_number"].ToString();
                        order.money_total = int.Parse(tb.Rows[i]["money_total"].ToString());
                        order.order_date = tb.Rows[i]["order_date"] != DBNull.Value ? DateTime.Parse(tb.Rows[i]["order_date"].ToString()) : DateTime.MinValue;
                        order.update_at = tb.Rows[i]["update_at"] != DBNull.Value ? DateTime.Parse(tb.Rows[i]["update_at"].ToString()) : DateTime.MinValue;
                        order.status_id = int.Parse(tb.Rows[i]["status_id"].ToString());
                        order.email = tb.Rows[i]["email"].ToString();
                        order.full_name = tb.Rows[i]["full_name"].ToString();
                        order.totalProduct = int.Parse(tb.Rows[i]["totalProduct"].ToString());
                        order.paymentType_id = tb.Rows[i]["paymentType_id"] != DBNull.Value ? int.Parse(tb.Rows[i]["paymentType_id"].ToString()) : 0;
                        order.shippingType_id = tb.Rows[i]["shippingType_id"] != DBNull.Value ? int.Parse(tb.Rows[i]["shippingType_id"].ToString()) : 0;
                        orderList.Add(order);

                    }
                    return orderList;
                }
                else return null;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public List<OrderModel> search(int? pageIndex, int? pageSize, string value, int status_id, out int total)
        {
            total = 0;
            try
            {

                DataTable tb = helper.ExcuteReader("Pro_SearchOrder", "@pageIndex", "@pageSize","@value", "@status_id", pageIndex, pageSize,value, status_id);
                if (tb != null)
                {
                    List<OrderModel> orderList = new List<OrderModel>();
                    total = int.Parse(tb.Rows[0]["RecordCount"].ToString());
                    for (int i = 0; i < tb.Rows.Count; i++)
                    {
                        OrderModel order = new OrderModel();
                        order.id = int.Parse(tb.Rows[i]["id"].ToString());
                        order.receiving_address = tb.Rows[i]["receiving_address"].ToString();
                        order.phone_number = tb.Rows[i]["phone_number"].ToString();
                        order.money_total = int.Parse(tb.Rows[i]["money_total"].ToString());
                        order.order_date = tb.Rows[i]["order_date"] != DBNull.Value ? DateTime.Parse(tb.Rows[i]["order_date"].ToString()) : DateTime.MinValue;
                        order.update_at = tb.Rows[i]["update_at"] != DBNull.Value ? DateTime.Parse(tb.Rows[i]["update_at"].ToString()) : DateTime.MinValue;
                        order.status_id = int.Parse(tb.Rows[i]["status_id"].ToString());
                        order.email = tb.Rows[i]["email"].ToString();
                        order.full_name = tb.Rows[i]["full_name"].ToString();
                        order.totalProduct = int.Parse(tb.Rows[i]["totalProduct"].ToString());
                        order.paymentType_id = tb.Rows[i]["paymentType_id"] != DBNull.Value ? int.Parse(tb.Rows[i]["paymentType_id"].ToString()) : 0;
                        order.shippingType_id = tb.Rows[i]["shippingType_id"] != DBNull.Value ? int.Parse(tb.Rows[i]["shippingType_id"].ToString()) : 0;
                        orderList.Add(order);

                    }
                    return orderList;
                }
                else return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public OrderModel GetById(int id)
        {
            try
            {
                DataTable tb = helper.ExcuteReader("Pro_GetOrderById","@id",id);
                if (tb != null)
                {
                    OrderModel order = new OrderModel();
                    order.orderDetails = new List<OrderDetailModel>();
                    order.id = int.Parse(tb.Rows[0]["id"].ToString());
                    order.receiving_address = tb.Rows[0]["receiving_address"].ToString();
                    order.phone_number = tb.Rows[0]["phone_number"].ToString();
                    order.money_total = int.Parse(tb.Rows[0]["money_total"].ToString());
                    order.order_date = tb.Rows[0]["order_date"] != DBNull.Value ? DateTime.Parse(tb.Rows[0]["order_date"].ToString()) : DateTime.MinValue;
                    order.update_at = tb.Rows[0]["update_at"] != DBNull.Value ? DateTime.Parse(tb.Rows[0]["update_at"].ToString()) : DateTime.MinValue;
                    order.status_id = int.Parse(tb.Rows[0]["status_id"].ToString());
                    order.email = tb.Rows[0]["email"].ToString();
                    order.full_name = tb.Rows[0]["full_name"].ToString();
                    order.shippingType_id = int.Parse(tb.Rows[0]["shippingType_id"].ToString());
                    order.paymentType_id = int.Parse(tb.Rows[0]["paymentType_id"].ToString());


                    for (int i = 0; i < tb.Rows.Count; i++)
                    {
                        OrderDetailModel orderDetail = new OrderDetailModel();
                        orderDetail.id = int.Parse(tb.Rows[i]["OrderDetail_id"].ToString());
                        orderDetail.order_id = int.Parse(tb.Rows[0]["id"].ToString());

                        orderDetail.product_id = int.Parse(tb.Rows[i]["product_id"].ToString());
                        orderDetail.quantity = int.Parse(tb.Rows[i]["quantity"].ToString());
                        orderDetail.price = int.Parse(tb.Rows[i]["price"].ToString());
                        orderDetail.size_id = int.Parse(tb.Rows[i]["size_id"].ToString());
                        orderDetail.color_id = int.Parse(tb.Rows[i]["color_id"].ToString());
                        orderDetail.style_id = int.Parse(tb.Rows[i]["style_id"].ToString());
                        order.orderDetails.Add(orderDetail);

                    }
                    return order;


                }
                else return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
