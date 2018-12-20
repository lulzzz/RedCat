using System;

namespace Core.Entities
{
	public abstract class BaseEntity
	{
		public long Id { get; set; }
		public DateTime Created { get; set; } = DateTime.UtcNow;
		public DateTime? LastUpdated { get; set; }
		public DateTime? Deleted { get; set; }
		public bool IsDeleted { get; set; }
	}
}
