using System;

namespace DataGenerator.Model
{
    public class Order
    {
        public int ID { get; set; }
        public int Client_id { get; set; }
        public int Car_id { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
