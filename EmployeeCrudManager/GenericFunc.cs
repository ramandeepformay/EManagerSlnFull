using System;
using System.Text.RegularExpressions;
namespace EmployeeCrudManager
{
    public class GenericFunc
    {
    // validation checker for sting input
        public static string regexChecker(string nameSearchInput){
            var regEx = new Regex(@"^([a-zA-z\s]{2,32})$");
            if(regEx.IsMatch(nameSearchInput)){
                return nameSearchInput.ToLower(); 
            }
            else{
                return null;
            }
        }

    // validation checker for int input
        public static int intChecker(string age){
            int number;
            bool success =Int32.TryParse(age, out number);
            if(success){
                return number;
            }
            else{
                return 0;
            }
        }
    }
}
    
