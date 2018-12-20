using System;

namespace Core.Errors
{
	public static class ErrorsHelper
	{
		public static string Format(this ApplicationErrors error, string parameter)
		{
			return String.Format(ErrorMessages.Error(ApplicationErrors.CREATE_ERROR), parameter);
		}
	}
}
