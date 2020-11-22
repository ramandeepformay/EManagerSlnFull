// using System;
// using System.Collections.Generic;
// using EmployeeCrudManager.Models;
// namespace EmployeeCrudManager {
//     public class EmpUserInput {
//         public static void Input (EmpMgtSys eManager) {

//             while (true) {

//                 var strDetails = "What would you like to do today?\n" +
//                     "Enter -s- for Search\n" +
//                     "Enter -a- for Add\n" +
//                     "Enter -d- for Delete\n" +
//                     "Enter -p- for Print\n" +
//                     "Enter -r- for Promotion or Demotion\n" +
//                     "Enter -q- for Quit\n";

//                 // console interaction
//                 System.Console.WriteLine (strDetails);

//                 var userInput = System.Console.ReadLine ().ToLower ();

//                 try {

//                     // employee search input func 
//                     if (userInput == "s") {
//                         Console.WriteLine ("Enter the first name of employee to complete your search\n");

//                         var inputSearch = Console.ReadLine ();
//                         var inputValidator = GenericFunc.regexChecker (inputSearch);

//                         //  input validation
//                         if (inputValidator != null) {
//                             var result = eManager.Search (inputValidator);

//                             if (result != null) {
//                                 System.Console.WriteLine ($"\n{result.Display()}");
//                             } else {
//                                 System.Console.WriteLine ($"{inputValidator} doesn't exist in our directory");
//                             }
//                         } else {
//                             System.Console.WriteLine ("Please enter the valid type\n");
//                         }
//                     }

//                     // employee add input func
//                     if (userInput == "a") {
//                         System.Console.WriteLine ("Let's start adding an employee\n");

//                         System.Console.WriteLine ("Enter the First name of an employee.");
//                         var first = Console.ReadLine ();
//                         var firstValidator = GenericFunc.regexChecker (first);

//                         System.Console.WriteLine ("\nEnter the Last name of an employee.");
//                         var last = Console.ReadLine ();
//                         var lastValidator = GenericFunc.regexChecker (last);

//                         System.Console.WriteLine ("\nEnter the Age of an employee.");
//                         var age = Console.ReadLine ();
//                         var ageValidator = GenericFunc.intChecker (age);

//                         System.Console.WriteLine ("\nEnter the Designation of an employee.");
//                         var designation = Console.ReadLine ();
//                         var designationValidator = GenericFunc.regexChecker (designation);

//                         System.Console.WriteLine ("\nEnter the Salary of an employee.");
//                         var salary = Console.ReadLine ();
//                         var salaryValidator = GenericFunc.intChecker (salary);

//                         // capturing all the inputs and sending it to mgtsys to add an employee and retrive all the lists 
//                         if (firstValidator != null && lastValidator != null && ageValidator != 0 && designationValidator != null &&
//                             salaryValidator != 0) {
//                             // var newEmp= eManager.Create(firstValidator,lastValidator,ageValidator, designationValidator,salaryValidator);

//                             // displaying detail of the employee which has been added to our directory
//                             foreach (var emp in newEmp) {
//                                 if (firstValidator == emp.FirstName) {
//                                     System.Console.WriteLine ($"\n{firstValidator} has been added in our directory\n");
//                                     System.Console.WriteLine ($"\n{emp.Display()}");
//                                 }
//                             }
//                         } else {
//                             throw new Exception ("Please enter valid type!");
//                         }
//                     }

//                     // delete input func
//                     if (userInput == "d") {

//                         System.Console.WriteLine ("\nEnter the first name of an employee which you don't want in the Directory");

//                         var inputDel = Console.ReadLine ();
//                         var inputDelValidator = GenericFunc.regexChecker (inputDel);

//                         if (inputDelValidator != null) {
//                             var delResult = eManager.DeleteEmp (inputDelValidator);
//                             if (delResult == null) {
//                                 throw new Exception ($"{inputDelValidator} doesn't exist in our directory");
//                             }
//                             System.Console.WriteLine ($"{delResult.FullName} has been deleted from our directory.");
//                         } else {
//                             throw new Exception ("please enter valid type");
//                         }

//                     }

//                     // print all the employees
//                     if (userInput == "p") {

//                         Console.WriteLine ("Below are the details of all the following employees of our company\n");

//                         var results = eManager.Print ();
//                         foreach (var emp in results) {
//                             System.Console.WriteLine ($"\n{emp.Display()}");
//                         }

//                     }

//                     // promotion or demotion func
//                     if (userInput == "r") {
//                         //getting inputs to promote an employee
//                         System.Console.WriteLine ("Would you like to promote or demote an employee?\n. Enter 'pr' to promote or 'de' to demote");
//                         var userLevelInput = Console.ReadLine ();
//                         var userInputValidator = GenericFunc.regexChecker (userLevelInput);

//                         System.Console.WriteLine ("Enter the name of an employee");
//                         var empName = Console.ReadLine ();
//                         var empNameValidator = GenericFunc.regexChecker (empName);

//                         // getting prev employee 
//                         var prevEmpPos = eManager.Search (empNameValidator);

//                         if (prevEmpPos == null || empNameValidator == null) {
//                             throw new Exception ($"{empNameValidator} doesn't exist  in our directory");
//                         }
//                         // getting prev employee rating
//                         var prevEmpPosRating = prevEmpPos.Rating;

//                         // promotion 
//                         if (userInputValidator == "pr") {
//                             // getting employee rating
//                             var newEmpPos = eManager.Rank (empNameValidator, userInputValidator);
//                             if (newEmpPos.Rating > prevEmpPosRating) {
//                                 System.Console.WriteLine ("Employee has been Promoted");
//                             }
//                             // dont promote employee thrice in a row
//                             if (newEmpPos.Rating > 3) {
//                                 System.Console.WriteLine ("Cannot promote it again");
//                             }

//                         }

//                         // demotion
//                         if (userInputValidator == "de") {
//                             // setting counter
//                             var count = 0;
//                             // checking if employee rating is zero then don't do anything
//                             if (prevEmpPosRating == 0) {
//                                 System.Console.WriteLine ("Employee cannot be demoted");
//                             }

//                             if (prevEmpPosRating > 0) {
//                                 var newEmpPos = eManager.Rank (empNameValidator, userInputValidator);
//                                 System.Console.WriteLine ("Employee has been demoted");
//                                 count++;
//                             }
//                             // dont demote employe thrice in a row
//                             if (count == 2) {
//                                 System.Console.WriteLine ("Cannot be demoted");
//                             }

//                         }

//                     }

//                     //quit 
//                     if (userInput == "q") {
//                         break;
//                     }
//                 } catch (Exception e) {
//                     Console.WriteLine ($"Error Message:{e.Message}");
//                 }
//             }
//         }
//     }
// }