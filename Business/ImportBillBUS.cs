using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DataAccessLayer;
namespace Businesss
{
    public class ImportBillBUS
    {
        ImportBillDAL impDAL = new ImportBillDAL();
        public int Create(ImportBillModel importBill)

        {
            return impDAL.Create(importBill);


        }
        public ImportBillModel GetById(int id)
        {
            return impDAL.GetById(id);
        }
        public int Update(ImportBillModel importBill)
        {
            return impDAL.Update(importBill);
        }
        public int Delete(int id)
        {
            return impDAL.Delete(id);
        }
    }
}
