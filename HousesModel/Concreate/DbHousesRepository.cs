using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HousesModel.Entiti;
using HousesModel.Abstract;

namespace HousesModel.Concreate
{
    public class DbHousesRepository : IHouseReposetory
    {
        DbHousesContext context = new DbHousesContext();
        public IEnumerable<Houses> Houses
        {
            get { return context.Houses; }
        }
    }
}
