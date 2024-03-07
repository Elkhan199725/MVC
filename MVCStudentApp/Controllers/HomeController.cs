using Microsoft.AspNetCore.Mvc;
using MVCStudentApp.Models;
using MVCStudentApp.ViewModels;

namespace MVCStudentApp.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        #region Students
        Student std1 = new Student()
        {
            Id = 1,
            FullName = "Elkhan Mammadli",
            Age = 26,
            Grade = 77
        };
        Student std2 = new Student()
        {
            Id = 2,
            FullName = "Noor Aliyev",
            Age = 25,
            Grade = 60
        };
        Student std3 = new Student()
        {
            Id = 3,
            FullName = "Seymour Aliyev",
            Age = 27,
            Grade = 69
        };
        Student std4 = new Student()
        {
            Id = 4,
            FullName = "Farhad Aliyev",
            Age = 35,
            Grade = 55
        };
        #endregion
        List<Student> students = new List<Student>() { std1, std2, std3, std4 };
        #region Teachers
        Teacher tch1 = new Teacher()
        {
            Id = 1,
            FullName = "Kamran J.",
            Age = 33,
            Salary = 15000
        };
        Teacher tch2 = new Teacher()
        {
            Id = 2,
            FullName = "Yusuf A.",
            Age = 26,
            Salary = 10000
        };
        #endregion
        List<Teacher> teachers = new List<Teacher>() { tch1, tch2 };

        //ViewBag.Teachers = teachers;

        HomeIndexViewModel viewModel = new HomeIndexViewModel()
        {
            Students = students,
            Teachers = teachers
        };
        return View(viewModel);
    }
}
