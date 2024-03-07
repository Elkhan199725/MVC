using MVCStudentApp.Models;

namespace MVCStudentApp.ViewModels;

public class HomeIndexViewModel
{
    public List<Student> Students = new List<Student>();
    public List<Teacher> Teachers = new List<Teacher>();
}
