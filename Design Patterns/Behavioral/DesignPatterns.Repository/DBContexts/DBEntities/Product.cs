using System;

namespace DesignPatterns.Repository.DBContexts.DBEntities
{
    public  class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime DueDate { get; set; }
    }
}
