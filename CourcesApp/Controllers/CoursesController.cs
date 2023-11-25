using CourcesApp.Data;
using CourcesApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CourcesApp.Controllers
{
	public class CoursesController : Controller
	{
		private IWebHostEnvironment webHostEnvironment;

		public CoursesController(IWebHostEnvironment webHostEnvironment)
		{
			this.webHostEnvironment = webHostEnvironment;
		}

		public IActionResult Index()
		{
			return View(DataCourses.Courses);
		}

		public IActionResult IndexAdmin()
		{
			return View(DataCourses.Courses);
		}

		public IActionResult AddCourse()
		{
			var course = new Course();
			return View(course);
		}

		public IActionResult AddToList(Course course, IFormFile file) 
		{
			if (file != null && file.Length > 0)
			{
				var extension = Path.GetExtension(file.FileName);
				var fileName = Guid.NewGuid().ToString() + extension;
				var uploadFolder = Path.Combine(webHostEnvironment.WebRootPath, "pictures");
				var path = Path.Combine(uploadFolder, fileName);
				var stream = new FileStream(path, FileMode.Create);
				file.CopyTo(stream);
				stream.Close();
				course.imagePath = fileName;
			}

			DataCourses.Courses.Add(course);
			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult EditCourse(int id)
		{
			var course = DataCourses.Courses.FirstOrDefault(c => c.Id == id);
			return View(course);
		}

		[HttpPost]
		public IActionResult EditCourse(Course course, IFormFile file)
		{
			var courseToUpdate = DataCourses.Courses.FirstOrDefault(c => c.Id == course.Id);
			if (courseToUpdate != null)
			{
				courseToUpdate.Title = course.Title;
				courseToUpdate.Description = course.Description;
			}
			var path = "";
			if (file != null && file.Length > 0)
			{
				var extension = Path.GetExtension(file.FileName);
				var fileName = Guid.NewGuid().ToString() + extension;
				var uploadFolder = Path.Combine(webHostEnvironment.WebRootPath, "pictures");
				path = Path.Combine(uploadFolder, fileName);
				var stream = new FileStream(path, FileMode.Create);
				file.CopyTo(stream);
				stream.Close();
				if (courseToUpdate != null)
					courseToUpdate.imagePath = fileName;
			}
			return View(course);
		}

		public IActionResult DeleteCourse(int id)
		{
			var course = DataCourses.Courses.FirstOrDefault(c => c.Id == id);
			if (course != null)
			{
				DataCourses.Courses.Remove(course);
			}
			return RedirectToAction("IndexAdmin");
		}
	}
}
