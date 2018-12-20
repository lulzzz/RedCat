using System.Collections.Generic;

namespace Core.Errors
{
	public static class ErrorMessages
	{
		private static Dictionary<ApplicationErrors, string> _errors = new Dictionary<ApplicationErrors, string>()
		{
			[ApplicationErrors.UNKNOWN_ERROR] = "Unknown error",
			[ApplicationErrors.CREATE_ERROR] = "Can't create {0}"
		};

		public static string Error(ApplicationErrors error)
		{
			return _errors.ContainsKey(error) ? _errors[error] : _errors[ApplicationErrors.UNKNOWN_ERROR];
		}
	}
}
