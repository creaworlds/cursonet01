using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeAcceso.Framework.Tools
{
	internal class DataBase : IDisposable
	{
		private MySqlConnection conn;

		public DataBase()
		{
			var connStr = ConfigurationManager.ConnectionStrings["DATASERVER"].ConnectionString;
			this.conn = new MySqlConnection(connStr);
		}

		public void Connecta()
		{
			try
			{
				this.conn.Open();
			}
			catch (Exception ex)
			{
				
			}
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
	}
}
