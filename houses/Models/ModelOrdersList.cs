using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HousesModel.Entiti;

namespace houses.Models
{
    public class ModelOrdersList
    {
        public IEnumerable<orders> orders { get; set; }
    }
}