using DataAccessLayer;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public  class ColorBUS
    {
        ColorDAL colorDAL = new ColorDAL();
        public ColorModel getById(int id)
        {
            return colorDAL.getById(id);    
        }
        public List<ColorModel> getAll()
        {
            return colorDAL.GetAll();
        }
    }
}
