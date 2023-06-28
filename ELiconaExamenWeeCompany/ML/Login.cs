namespace ML
{
	public class Login
	{
		public List<object> Objects;

		public int IdLogin { set; get; }
		public string Nombre { set; get; }
		public string Telefono { set; get; }
		public string Correo { set; get; }
		public string Empresa { set; get; }
		public byte[] Password { set; get; }
		public List<object> Logins { get; set; }

	}
}