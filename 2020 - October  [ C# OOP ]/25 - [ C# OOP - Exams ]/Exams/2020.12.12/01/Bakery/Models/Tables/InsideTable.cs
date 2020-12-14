namespace Bakery.Models.Tables
{
    public class InsideTable : Table
    {
        public InsideTable(int tableNumber, int capacity) 
            : base(tableNumber, capacity, 2.5M)
        {
        }
    }
}
