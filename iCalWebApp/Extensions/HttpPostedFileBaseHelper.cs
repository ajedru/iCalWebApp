using System;
using System.Web;

namespace iCalWebApp.Extensions
{
	public static class HttpPostedFileBaseHelper
	{
		public static bool HasFile(this HttpPostedFileBase file)
		{
			return (file != null && file.ContentLength > 0) ? true : false;
		}
	}
}