namespace DesingPatterns.Prototype.Models
{
    public class OrderInfo : Prototype
    {
        public int Id { get; set; }
        public string Details { get; set; }

        public override Prototype DeepClone()
        {
           return (OrderInfo) this.MemberwiseClone();
        }

        public override Prototype ShallowClone()
        {
            return (OrderInfo) this.MemberwiseClone();
        }
    }
}