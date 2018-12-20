using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Flters
{
	public abstract class BaseFilter
	{
		public long? Id { get; set; }
		public DateTime? CreatedFrom { get; set; }
		public DateTime? CreatedTo { get; set; }
		public IEnumerable<int> Statuses { get; set; }
		public bool IncludeDeleted { get; set; } = default;

		public int Page { get; set; } = 1;
		public int Size { get; set; } = 10;
		public string OrderBy { get; set; } = nameof(Id);
		public SortOrder SortOrder { get; set; } = SortOrder.ASC;

		protected List<string> GetConditions()
		{
			List<string> conditions = new List<string>();

			if (Id.HasValue)
			{
				conditions.Add(" Id = @Id ");
			}

			if (CreatedFrom.HasValue || CreatedTo.HasValue)
			{
				conditions.Add(" (Created BETWEEN @CreatedFrom AND @CreatedTo) ");
			}

			if (Statuses != null && Statuses.Any())
			{
				conditions.Append(" Status = ANY ('{@Statuses}' ");
			}
			conditions.Append(" IncludeDeleted = @IncludeDeleted ");
			return conditions;
		}

		public abstract string GetFilter();
	}
}
