using System;
using System.Globalization;
using System.Web.UI;

namespace iCalWebApp.Models
{
	/// <summary>
	/// Struct do przechowywania danych konfiguracyjnych kt�re nie b�da si� zmienia� po czasie kompilacji
	/// </summary>
	public struct Config
	{
		/// <summary>
		/// Domy�lny tytu� zdarzenia
		/// </summary>
		public static string DefaultEventTitle
		{
			get { return Translator.Instance.Get("DefaultEventTitle"); }
		}

		/// <summary>
		/// Domy�lny komentarz do zdarzenia
		/// </summary>
		public static string DefaultEventComment
		{
			get { return Translator.Instance.Get("DefaultEventComment"); }
		}

		/// <summary>
		/// Metoda zwracaj�ca domy�ln� warto�c dla translacji gdy nie znaleziono jej w plikach lokalizacji
		/// </summary>
		/// <param name="key">Klucz translacji kt�ry nie zosta� znaleziony</param>
		/// <returns></returns>
		public static string MissingTranslation(string key)
		{
			return string.Format("Error Missing Translation for '{0}'!", key);
		}

		/// <summary>
		/// Zagnie�d�ona klasa singleton helpera do wyci�gania zlokalizowanych translacji z plik�w lokalizacji, na wy��czne u�ycie struktury Config
		/// </summary>
		private class Translator : TemplateControl
		{
			public string Get(string key)
			{
				CultureInfo culture = CultureInfo.CurrentCulture;
				object translation = GetLocalResourceObject(key);

				if (translation == null)
				{
					return MissingTranslation(key);
				}

				return translation.ToString();
			}

			#region Singleton

			private static Translator instance;

			/// <summary>
			/// Konstruktor na potrzeby singletona
			/// </summary>
			private Translator()
			{}

			public static Translator Instance
			{
				get
				{
					if (instance == null)
					{
						instance = new Translator();
					}
					return instance;
				}
			}

			#endregion
		}
	}
}