using Exercises.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exercises.Models.Data;
using Exercises.Models.ViewModels;

namespace Exercises.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            var model = StudentRepository.GetAll();

            return View(model);
        }

        [HttpGet]
        public ActionResult AddStudent()
        {
            var viewModel = new StudentVM();
            viewModel.SetStateItems(StateRepository.GetAll());
            viewModel.SetCourseItems(CourseRepository.GetAll());
            viewModel.SetMajorItems(MajorRepository.GetAll());
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult AddStudent(StudentVM studentVM)
        {
            studentVM.Student.Courses = new List<Course>();

            foreach (var id in studentVM.SelectedCourseIds)
                studentVM.Student.Courses.Add(CourseRepository.Get(id));
            studentVM.Student.Address.State = StateRepository.Get(studentVM.Student.Address.State.StateAbbreviation);
            studentVM.Student.Major = MajorRepository.Get(studentVM.Student.Major.MajorId);

            StudentRepository.Add(studentVM.Student);

            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult EditStudent(int studentId)
        {
            var viewModel = new StudentVM();
            viewModel.Student = StudentRepository.Get(studentId);
            viewModel.SetStateItems(StateRepository.GetAll());
            viewModel.SetCourseItems(CourseRepository.GetAll());
            viewModel.SetMajorItems(MajorRepository.GetAll());
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult EditStudent(Student student)
        {
            var viewModel = new StudentVM();
            viewModel.Student.Courses = new List<Course>();
            foreach (var id in viewModel.SelectedCourseIds)
            {
                viewModel.Student.Courses.Add(CourseRepository.Get(id));
            }
            student.Address.State = StateRepository.Get(student.Address.State.StateAbbreviation);
            student.Major = MajorRepository.Get(student.Major.MajorId);

            StudentRepository.Edit(student);
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult DeleteStudent(int studentId)
        {
            var student = StudentRepository.Get(studentId);
            return View(student);
        }

        [HttpPost]
        public ActionResult DeleteStudent(Student student)
        {
            StudentRepository.Delete(student.StudentId);
            return RedirectToAction("List");
        }
    }
}