using PieShop.Data.DBContexts;
using PieShop.Data.Repository;
using PieShop.Entities.Orders;
using System;
using System.Collections.Generic;

namespace PieShop.Data.OrderRepository
{
    public class SqLServerOrderRepository : SQLServerRepository<Order>, IOrderRepository
    {
        public SqLServerOrderRepository(PieShopDbContext context) : base(context)
        {
        }

        public override Order Add(Order order)
        {
            order.OrderPlaced = DateTime.Now;

            _context.Orders.Add(order);

            _context.SaveChanges();

            return order;
        }
    }
}
