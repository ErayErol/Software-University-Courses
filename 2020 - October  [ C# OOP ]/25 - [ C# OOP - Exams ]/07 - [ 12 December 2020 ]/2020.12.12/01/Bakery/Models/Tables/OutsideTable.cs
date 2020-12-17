namespace Bakery.Models.Tables
{
    public class OutsideTable : Table
    {
        public OutsideTable(int tableNumber, int capacity) 
            : base(tableNumber, capacity, 3.5M)
        {
        }
    }
}
