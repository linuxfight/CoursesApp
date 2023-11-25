using CourcesApp.Models;

namespace CourcesApp.Data
{
	public static class DataCourses
	{
		public static List<Course> Courses { get; set; }

		static DataCourses()
		{
			Courses = new List<Course>()
			{ 
				new Course()
				{ 
					Title = "Voice of Time",
					Description = "One of many Lololoshka seasons",
					imagePath = "C:\\Users\\kiko1\\source\\repos\\CourcesApp\\CourcesApp\\wwwroot\\pictures\\116c24c3-4d9e-4bff-be3e-c1304e50ae13.jpg"
				}
			};
		}
	}
}
