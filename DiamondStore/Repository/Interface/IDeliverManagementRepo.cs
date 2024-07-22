﻿using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IDeliverManagementRepo
    {
         Task<List<User>> GetManagerList();

        Task<List<User>> GetShipperList();

        Task<IEnumerable<Delivery>> GetAllAsyncShipper(Guid shipperId);

        Task<List<Order>> GetOrderList();
       
    }
}
