using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DataAccessLayer.Helper;
using System.Data;
namespace DataAccessLayer
{
    public class ImportBillDAL
    {
        DataHelper helper = new DataHelper();

        public ImportBillModel GetById(int id)
        {
            try
            {
                DataTable tb = helper.ExcuteReader("Pro_GetImportBillById", "@id",id);
                if (tb != null)
                {
                    ImportBillModel imp = new ImportBillModel();
                    imp.id = int.Parse(tb.Rows[0]["id"].ToString());
                    imp.import_date = DateTime.Parse(tb.Rows[0]["import_date"].ToString());
                    imp.provider_id = int.Parse(tb.Rows[0]["provider_id"].ToString());
                    imp.user_id = int.Parse(tb.Rows[0]["user_id"].ToString());
                    imp.money_total = int.Parse(tb.Rows[0]["money_total"].ToString());
                    imp.importBills = new List<ImportBillDetailModel>();
                    for (int i = 0; i < tb.Rows.Count; i++)
                    {
                        ImportBillDetailModel impd = new ImportBillDetailModel();
                        impd.id = int.Parse(tb.Rows[i]["importBillDetail_id"].ToString());
                        impd.importbill_id = int.Parse(tb.Rows[i]["importbill_id"].ToString());

                        impd.pro_id = int.Parse(tb.Rows[i]["pro_id"].ToString());
                        impd.price = int.Parse(tb.Rows[i]["price"].ToString());
                        impd.color_id = int.Parse(tb.Rows[i]["color_id"].ToString());
                        impd.size_id = int.Parse(tb.Rows[i]["size_id"].ToString());
                        impd.quantity = int.Parse(tb.Rows[i]["quantity"].ToString());
                        imp.importBills.Add(impd);
                    }
                 
                    return imp;

                }
                else return null;

            }catch(Exception ex) {
                throw ex;
            }
        }

        public int Create(ImportBillModel importBill)
        {
            try
            {
                 int result = helper.ExcuteNonQuery("Pro_CreateImportBill", "@import_date", "@provider_id", "@user_id", "@total_money", "@list_json_importbilldetail",
                                                    importBill.import_date, importBill.provider_id, importBill.user_id, importBill.money_total, 
                                                    importBill.importBills != null ? MessageConvert.SerializeObject(importBill.importBills) : null
                    );

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Update(ImportBillModel importBill)
        {
            try
            {
                int result = helper.ExcuteNonQuery("Pro_UpdateImportBill", "@importbill_id", "@import_date", "@provider_id", "@user_id", "@total_money", "@list_json_importbilldetail",
                                                    importBill.id, importBill.import_date, importBill.provider_id, importBill.user_id, importBill.money_total, 
                                                    importBill.importBills != null ? MessageConvert.SerializeObject(importBill.importBills) : null
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
                int result = helper.ExcuteNonQuery("Pro_DeleteImportBill", "@importbill_id", id);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
