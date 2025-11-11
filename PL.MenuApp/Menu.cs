using System;
using PL.ModelsForPL;
using BLL.ModelsForBLL;
using BLL.EntityServices;
using PL.MappersForPL;

namespace PL
{
    public class Menu
    {
        private string options =
            "1. Add student\n" +
            "2. Add joiner\n" +
            "3. Add photographer\n" +
            "4. Show all students\n" +
            "5. Show all joiners\n" +
            "6. Show all photographers\n" +
            "7. Delete student\n" +
            "8. Delete joiner\n" +
            "9. Delete photographer\n" +
            "10. Check the task\n" +
            "11. Exit";
        private bool isRunning = true;
        private StudentService studentService = new StudentService();
        private JoinerService joinerService = new JoinerService();
        private PhotographerService photographerService = new PhotographerService();

        public void Start()
        {
            while (isRunning)
            {
                Console.WriteLine(options);
                Console.Write("Select an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Surname: ");
                        string sSurname = Console.ReadLine();
                        Console.Write("Name: ");
                        string sName = Console.ReadLine();
                        Console.Write("Course: ");
                        int sCourse = int.Parse(Console.ReadLine());
                        Console.Write("Student ID: ");
                        string sId = Console.ReadLine();
                        Console.Write("Gender: ");
                        string sGender = Console.ReadLine();
                        Console.Write("Address: ");
                        string sAddress = Console.ReadLine();
                        Console.Write("Record Book Number: ");
                        string sRecordBook = Console.ReadLine();
                        Console.Write("Provider type: ");
                        string sType = Console.ReadLine();
                        Console.Write("Path: ");
                        string sPath = Console.ReadLine();
                        StudentModelPL student = new StudentModelPL(sSurname, sName, sCourse, sId,
                            sGender, sAddress, sRecordBook);
                        try
                        {
                            studentService.AddStudent(student.ToBLL(), sType, sPath);
                            Console.Clear();
                            Console.WriteLine("Student has been added successfully");
                            break;
                        }
                        catch (Exception e)
                        {
                            Console.Clear();
                            Console.WriteLine(e.Message);
                            break;
                        }

                    case "2":
                        Console.Write("Surname: ");
                        string jSurname = Console.ReadLine();
                        Console.Write("Name: ");
                        string jName = Console.ReadLine();
                        Console.Write("Expirience years: ");
                        int jExpYears = int.Parse(Console.ReadLine());
                        Console.Write("Workshop: ");
                        string jWorkshop = Console.ReadLine();
                        Console.Write("Provider type: ");
                        string jType = Console.ReadLine();
                        Console.Write("Path: ");
                        string jPath = Console.ReadLine();
                        JoinerModelPL joiner = new JoinerModelPL(jSurname, jName, jExpYears, jWorkshop);
                        try
                        {
                            joinerService.AddJoiner(joiner.ToBLL(), jType, jPath);
                            Console.Clear();
                            Console.WriteLine("Joiner has been added successfully");
                            break;
                        }
                        catch (Exception e)
                        {
                            Console.Clear();
                            Console.WriteLine(e.Message);
                            break;
                        }
                    case "3":
                        Console.Write("Surname: ");
                        string pSurname = Console.ReadLine();
                        Console.Write("Name: ");
                        string pName = Console.ReadLine();
                        Console.Write("Camera model: ");
                        string pCameraModel = Console.ReadLine();
                        Console.Write("Specialty: ");
                        string pSpecialty = Console.ReadLine();
                        Console.Write("Provider type: ");
                        string pType = Console.ReadLine();
                        Console.Write("Path: ");
                        string pPath = Console.ReadLine();
                        PhotographerModelPL photographer = new PhotographerModelPL(pSurname, pName, pCameraModel, pSpecialty);
                        try
                        {
                            photographerService.AddPhotographer(photographer.ToBLL(), pType, pPath);
                            Console.Clear();
                            Console.WriteLine("Photographer has been added successfully");
                            break;
                        }
                        catch (Exception e)
                        {
                            Console.Clear();
                            Console.WriteLine(e.Message);
                            break;
                        }
                    case "4":
                        Console.Write("Provider type: ");
                        string sTypeAll = Console.ReadLine();
                        Console.Write("Path: ");
                        string sPathAll = Console.ReadLine();
                        List<StudentModelBLL> sModels = studentService.GetStudents(sTypeAll, sPathAll);
                        if (sModels != null || sModels.Count != 0)
                        {
                            foreach (StudentModelBLL sModel in sModels)
                            {
                                Console.WriteLine(sModel.ToPL().ToString());
                            }

                            break;
                        }
                        Console.WriteLine("No students found");
                        break;
                    case "5":
                        Console.Write("Provider type: ");
                        string jTypeAll = Console.ReadLine();
                        Console.Write("Path: ");
                        string jPathAll = Console.ReadLine();
                        List<JoinerModelBLL> jModels = joinerService.GetJoiners(jTypeAll, jPathAll);
                        if (jModels != null || jModels.Count != 0)
                        {
                            foreach (JoinerModelBLL jModel in jModels)
                            {
                                Console.WriteLine(jModel.ToPL().ToString());
                            }

                            break;
                        }
                        Console.WriteLine("No joiners found");
                        break;
                    case "6":
                        Console.Write("Provider type: ");
                        string pTypeAll = Console.ReadLine();
                        Console.Write("Path: ");
                        string pPathAll = Console.ReadLine();
                        List<PhotographerModelBLL> pModels = photographerService.GetPhotographers(pTypeAll, pPathAll);
                        if (pModels != null || pModels.Count != 0)
                        {
                            foreach (PhotographerModelBLL pModel in pModels)
                            {
                                Console.WriteLine(pModel.ToPL().ToString());
                            }
                            break;
                        }
                        Console.WriteLine("No photographers found");
                        break;
                    case "7":
                        Console.Write("Provider type: ");
                        string sTypeDel = Console.ReadLine();
                        Console.Write("Path: ");
                        string sPathDel = Console.ReadLine();
                        Console.Write("Student ID to delete: ");
                        string sIdDel = Console.ReadLine();
                        try
                        {
                            studentService.DeleteStudent(sIdDel, sTypeDel, sPathDel);
                            Console.Clear();
                            Console.WriteLine("Student has been deleted successfully");
                            break;
                        }
                        catch (Exception e)
                        {
                            Console.Clear();
                            Console.WriteLine(e.Message);
                            break;
                        }
                    case "8":
                        Console.Write("Provider type: ");
                        string jTypeDel = Console.ReadLine();
                        Console.Write("Path: ");
                        string jPathDel = Console.ReadLine();
                        Console.Write("Joiner surname to delete: ");
                        string jSurnameDel = Console.ReadLine();
                        try
                        {
                            joinerService.DeleteJoiner(jSurnameDel, jTypeDel, jPathDel);
                            Console.Clear();
                            Console.WriteLine("Joiner has been deleted successfully");
                            break;
                        }
                        catch (Exception e)
                        {
                            Console.Clear();
                            Console.WriteLine(e.Message);
                            break;
                        }
                    case "9":
                        Console.Write("Provider type: ");
                        string pTypeDel = Console.ReadLine();
                        Console.Write("Path: ");
                        string pPathDel = Console.ReadLine();
                        Console.Write("Photographer surname to delete: ");
                        string pSurnameDel = Console.ReadLine();
                        try
                        {
                            photographerService.DeletePhotographer(pSurnameDel, pTypeDel, pPathDel);
                            Console.Clear();
                            Console.WriteLine("Photographer has been deleted successfully");
                            break;
                        }
                        catch (Exception e)
                        {
                            Console.Clear();
                            Console.WriteLine(e.Message);
                            break;
                        }
                    case "10":
                        Console.Write("Provider type: ");
                        string sTypeTask = Console.ReadLine();
                        Console.Write("Path: ");
                        string sPathTask = Console.ReadLine();
                        var students = studentService.Task(sTypeTask, sPathTask);
                        if (students != null && students.Count != 0)
                        {
                            foreach (StudentModelBLL s in students)
                            {
                                Console.WriteLine(s.ToPL().ToString());
                            }

                            break;
                        }
                        Console.WriteLine("No students found for the task");
                        break;
                    case "11":
                        isRunning = false;
                        break;
                }
            }
        }
    }
}
