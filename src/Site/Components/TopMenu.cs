using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Site.Components
{
	public class TopMenu : ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View();
		}
	}
}
