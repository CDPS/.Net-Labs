using System;
using System.Collections.Generic;
using System.Text;

namespace DesingPatterns.Prototype.Models
{
    public class FoodOrder : Prototype
    {
        public string CustomerName { get; set; }
        public bool IsDelivery { get; set; }

        public string[] OrderContents { get; set; }

        public OrderInfo Info { get; set; }

        public override Prototype DeepClone()
        {
            FoodOrder clonedOrder = (FoodOrder) this.MemberwiseClone();
            clonedOrder.Info =  (OrderInfo) this.Info.DeepClone();
            return clonedOrder;
        }

        public override Prototype ShallowClone()
        {
            return (Prototype) this.MemberwiseClone();
        }
    }
}
