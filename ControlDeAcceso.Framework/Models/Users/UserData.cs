using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeAcceso.Framework.Models.Users
{
	public class UserData : UserBase
	{
		public string ID { get; set; }
		public string Nombre { get; set; }
		public string Apellidos { get; set; }
		public string RoleID { get; set; }
	}
}
