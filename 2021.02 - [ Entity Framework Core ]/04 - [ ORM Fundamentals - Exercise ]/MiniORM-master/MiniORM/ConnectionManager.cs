namespace MiniORM
{
	using System;

	internal class ConnectionManager : IDisposable
	{
		private readonly DatabaseConnection connection;

		public ConnectionManager(DatabaseConnection connection)
		{
			this.connection = connection;

			this.connection.Open();
		}

		public void Dispose()
		{
			this.connection.Close();
		}
	}
}