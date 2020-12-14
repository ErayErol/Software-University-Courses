namespace Bakery.Core
{
    using Bakery.Models.BakedFoods.Contracts;
    using Bakery.Models.Drinks.Contracts;
    using Bakery.Models.Tables.Contracts;
    using Contracts;
    using Models.BakedFoods;
    using Models.Drinks;
    using Models.Tables;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Controller : IController
    {
        private decimal totalIncome = 0.0M;

        private readonly List<IBakedFood> foods;
        private readonly List<IDrink> drinks;
        private readonly List<ITable> tables;

        public Controller()
        {
            this.foods = new List<IBakedFood>();
            this.drinks = new List<IDrink>();
            this.tables = new List<ITable>();
        }

        public string AddFood(string type, string name, decimal price)
        {
            IBakedFood food = null;

            if (type == "Bread")
            {
                food = new Bread(name, price);
            }
            else if (type == "Cake")
            {
                food = new Cake(name, price);
            }

            this.foods.Add(food);
            return $"Added {name} ({type}) to the menu";
        }

        public string AddDrink(string type, string name, int portion, string brand)
        {
            IDrink drink = null;

            if (type == "Tea")
            {
                drink = new Tea(name, portion, brand);
            }
            else if (type == "Water")
            {
                drink = new Water(name, portion, brand);
            }

            this.drinks.Add(drink);
            return $"Added {name} ({brand}) to the drink menu";
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table = null;

            if (type == "InsideTable")
            {
                table = new InsideTable(tableNumber, capacity);
            }
            else if (type == "OutsideTable")
            {
                table = new OutsideTable(tableNumber, capacity);
            }

            this.tables.Add(table);
            return $"Added table number {tableNumber} in the bakery";
        }

        public string ReserveTable(int numberOfPeople)
        {
            foreach (ITable table in this.tables)
            {
                if (table.IsReserved == false && table.Capacity > numberOfPeople)
                {
                    table.Reserve(numberOfPeople);
                    return $"Table {table.TableNumber} has been reserved for {numberOfPeople} people";
                }
            }

            return $"No available table for {numberOfPeople} people";
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            var table = this.tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            if (table == null)
            {
                return $"Could not find table {tableNumber}";
            }

            var food = this.foods.FirstOrDefault(x => x.Name == foodName);
            if (food == null)
            {
                return $"No {foodName} in the menu";
            }

            table.OrderFood(food);
            return $"Table {tableNumber} ordered {foodName}";
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            var table = this.tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            if (table == null)
            {
                return $"Could not find table {tableNumber}";
            }

            var drink = this.drinks.FirstOrDefault(x => x.Name == drinkName && x.Brand == drinkBrand);
            if (drink == null)
            {
                return $"There is no {drinkName} {drinkBrand} available";
            }

            table.OrderDrink(drink);
            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
        }

        public string LeaveTable(int tableNumber)
        {
            var table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);

            var sb = new StringBuilder();

            if (table != null)
            {
                sb.AppendLine($"Table: {tableNumber}");
                sb.AppendLine($"Bill: {table.GetBill():f2}");
                totalIncome += table.GetBill();

                table.Clear();
            }

            return sb.ToString().Trim();
        }

        public string GetFreeTablesInfo()
        {
            var sb = new StringBuilder();

            foreach (ITable freeTable in this.tables.Where(t => t.IsReserved == false))
            {
                sb.AppendLine(freeTable.GetFreeTableInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string GetTotalIncome()
        {
            return $"Total totalIncome: {totalIncome:f2}lv";
        }
    }
}
