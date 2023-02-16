using HousesModel.Entiti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HousesModel.Abstract
{
    public interface IHouseReposetory
    {
        IEnumerable<Houses> Houses { get; }
    }
}
