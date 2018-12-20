namespace Core.Entities
{
	public class Contact : BaseEntity
	{
		public string ContactPerson { get; set; }
		public string Phone { get; set; }
		public string Email { get; set; }
		public string Skype { get; set; }
		public string Viber { get; set; }
	}
}
