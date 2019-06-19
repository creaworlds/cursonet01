using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;

namespace ControlDeAcceso.Framework.Tools
{
	public class DataBase : IDisposable
	{
		internal MySqlConnection conn;

		public readonly MySqlCommand cmd;
		public string ConnectionName { get; set; } = "DATASERVER";

		public DataBase()
		{
			this.cmd = new MySqlCommand();
		}

		public bool Connecta()
		{
			var succcess = false;

			try
			{
				this.conn = new MySqlConnection(ConfigurationManager.ConnectionStrings[this.ConnectionName].ConnectionString);
				this.conn.Open();

				this.cmd.Connection = this.conn;
				this.cmd.CommandType = CommandType.StoredProcedure;

				succcess = (this.conn.State == System.Data.ConnectionState.Open);
			}
			catch (Exception ex)
			{

			}

			return succcess;
		}

		public DataSet GetDataSet(string sql)
		{
			var ds = new DataSet();

			if (this.Connecta())
			{
				using (var da = new MySqlDataAdapter(this.cmd))
				{
					da.Fill(ds);
				}
			}

			return ds;
		}

		public DataTable GetDataTable(string sql)
		{
			var dt = new DataTable();

			if (this.Connecta())
			{
				this.cmd.CommandText = sql;

				using (var da = new MySqlDataAdapter(this.cmd))
				{
					da.Fill(dt);
				}
			}

			return dt;
		}

		public void Dispose()
		{
			this.Finaliza();
		}

		public void Finaliza()
		{
			try
			{
				this.conn.Close();
			}
			catch (Exception ex)
			{

			}
		}

		~DataBase()
		{
			this.Finaliza();
		}
	}
}
