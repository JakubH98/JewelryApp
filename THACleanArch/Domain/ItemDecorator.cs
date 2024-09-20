using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THACleanArch.Domain
{
    public abstract class ItemDecorator : Item
    {
        private Item _item;
        public override abstract double Price { get; }

        public ItemDecorator(Item item) : base(item.Id, item.Description, item.Price)
        {
            _item = item;
        }        

        public class GiftWrapping : ItemDecorator
        {
            public GiftWrapping(Item item) : base(item) { }

            public override double Price => _item.Price + 50; 
        }
        public class Shipment : ItemDecorator
        {
            public Shipment(Item item) : base(item) { }

            public override double Price => _item.Price + 80;
        }
    }
}
