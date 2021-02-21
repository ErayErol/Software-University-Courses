namespace MiniORM.App
{
	using System.Linq;
	using Data;
	using Data.Entities;

	public class StartUp
	{
		public static void Main(string[] args)
		{
			var connectionString = "Server=.;Database=MiniORM;Integrated Security=True";

			var context = new SoftUniDbContext(connectionString);

			context.Employees.Add(new Employee
			{
				FirstName = "Gosho",
				LastName = "Inserted",
				DepartmentId = context.Departments.First().Id,
				IsEmployed = true,
			});

			var employee = context.Employees.Last();
			employee.FirstName = "Modified";

			context.SaveChanges();
		}
	}
}