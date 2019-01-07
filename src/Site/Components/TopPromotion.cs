using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Site.Components
{
	public class TopPromotion : ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View();
		}
	}
}
