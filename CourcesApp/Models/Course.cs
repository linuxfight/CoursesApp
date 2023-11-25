namespace CourcesApp.Models
{
	public class Course
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string imagePath { get; set; }
		private static int _id;

		public Course() 
		{
			_id++;
			Id = _id;
		}
	}
}
