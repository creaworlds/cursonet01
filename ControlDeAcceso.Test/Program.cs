using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace ControlDeAcceso.Test
{
	class Program
	{
		static void Main(string[] args)
		{
			using (var db = new ControlDeAcceso.Framework.Tools.DataBase())
			{
				db.cmd.Parameters.Add("nombre", MySqlDbType.VarChar).Value = "Anthony";
				db.cmd.Parameters.Add("apellidos", MySqlDbType.VarChar).Value = "Acuña";
				db.cmd.Parameters.Add("username", MySqlDbType.VarChar).Value = "aacuna";
				db.cmd.Parameters.Add("pwd", MySqlDbType.VarChar).Value = "r3dc0d3$";
				db.cmd.Parameters.Add("activo", MySqlDbType.Bit).Value = true;
				db.cmd.Parameters.Add("done", MySqlDbType.Bit).Direction = ParameterDirection.Output;

				using (var dt = db.GetDataTable("SP_USUARIO_INSERTA"))
				{
					if (Convert.ToBoolean(db.cmd.Parameters["done"].Value))
					{
						foreach (DataRow obj in dt.Rows)
						{
							Console.WriteLine(obj["ID"]);
						}
					}
				}
			}

			Console.ReadLine();
		}
	}
}
