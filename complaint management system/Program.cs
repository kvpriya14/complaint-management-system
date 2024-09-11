using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT
{
    internal class Program
    {

        public class Complaint
        {
            public int Id { get; private set; }
            public string StudentName { get; set; }
            public string Description { get; set; }
            public DateTime Date { get; private set; }
            public bool IsResolved { get; set; }


            public Complaint(int id, string studentName, string description)
            {
                Id = id;
                StudentName = studentName;
                Description = description;
                Date = DateTime.Now;
                IsResolved = false;
            }


            public void MarkAsResolved()
            {
                IsResolved = true;
            }
        }


        public class ComplaintManager
        {
            private List<Complaint> complaints;

            public ComplaintManager()
            {
                complaints = new List<Complaint>();
            }


            public void AddComplaint(string studentName, string description)
            {
                int newId = complaints.Count + 1;
                Complaint newComplaint = new Complaint(newId, studentName, description);
                complaints.Add(newComplaint);
                Console.WriteLine("Complaint registered successfully.");
            }


            public void DisplayComplaints()
            {
                foreach (var complaint in complaints)
                {
                    Console.WriteLine($"ID: {complaint.Id}, Student: {complaint.StudentName}, Description: {complaint.Description}, Date: {complaint.Date}, Resolved: {complaint.IsResolved}");
                }
            }


            public Complaint GetComplaintById(int id)
            {
                return complaints.Find(c => c.Id == id);
            }


            public void UpdateComplaint(int id, string studentName, string description)
            {
                Complaint complaint = GetComplaintById(id);
                if (complaint != null)
                {
                    complaint.StudentName = studentName;
                    complaint.Description = description;
                    Console.WriteLine("Complaint updated successfully.");
                }
                else
                {
                    Console.WriteLine("Complaint not found.");
                }
            }


            public void DeleteComplaint(int id)
            {
                Complaint complaint = GetComplaintById(id);
                if (complaint != null)
                {
                    complaints.Remove(complaint);
                    Console.WriteLine("Complaint deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Complaint not found.");
                }
            }
        }



        static void Main(string[] args)
        {
            ComplaintManager complaintManager = new ComplaintManager();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("            CIET COMPLAINT MAAGEMENT SYSTEM              ");
                Console.WriteLine("1.Student");
                Console.WriteLine("2.Faculty");
                int a;
                a = Convert.ToInt32(Console.ReadLine());
                if (a == 1)
                {
                    Console.WriteLine("Student loged in");
                }
                else
                {
                    Console.WriteLine("Faculty loged in");
                }
                Console.WriteLine("\n1. Register Complaint");
                Console.WriteLine("2. Display Complaints");
                Console.WriteLine("3. Update Complaint");
                Console.WriteLine("4. Delete Complaint");
                Console.WriteLine("5. Resolve Complaint");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter student name: ");
                        string studentName = Console.ReadLine();
                        Console.Write("Enter complaint description: ");
                        string description = Console.ReadLine();
                        complaintManager.AddComplaint(studentName, description);
                        break;
                    case 2:
                        complaintManager.DisplayComplaints();
                        break;
                    case 3:
                        Console.Write("Enter complaint ID to update: ");
                        int updateId = int.Parse(Console.ReadLine());
                        Console.Write("Enter new student name: ");
                        string newStudentName = Console.ReadLine();
                        Console.Write("Enter new complaint description: ");
                        string newDescription = Console.ReadLine();
                        complaintManager.UpdateComplaint(updateId, newStudentName, newDescription);
                        break;
                    case 4:
                        Console.Write("Enter complaint ID to delete: ");
                        int deleteId = int.Parse(Console.ReadLine());
                        complaintManager.DeleteComplaint(deleteId);
                        break;
                    case 5:
                        Console.Write("Enter complaint ID to resolve: ");
                        int resolveId = int.Parse(Console.ReadLine());
                        Complaint resolveComplaint = complaintManager.GetComplaintById(resolveId);
                        if (resolveComplaint != null)
                        {
                            resolveComplaint.MarkAsResolved();
                            Console.WriteLine("Complaint resolved successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Complaint not found.");
                        }
                        break;
                    case 6:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}
