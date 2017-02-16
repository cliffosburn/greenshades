using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Greenshades

{
    public class ValidateInput
    {
        //For the purpose of validating input in the event Javascript is no enabled on the client browser
        public static Boolean ValidateEmployeeDetails(EmployeeDetails myEmployee, bool NewEntry)
        {

            Boolean Valid = true;

            if (!NewEntry)
            {
                if (myEmployee.ID <= 0)
                {
                    Valid = false;
                }
            }


            if (myEmployee.FirstName.Length == 0)
            {
                Valid = false;
            }

            if (myEmployee.LastName.Length == 0)
            {
                Valid = false;
            }

            if (!NewEntry)
            {
                if (myEmployee.ContactID == 0)
                {
                    Valid = false;
                }
            }

            if (myEmployee.ContactEmail.Length > 0)
            {

                var EAA = new EmailAddressAttribute();
                bool validemail = EAA.IsValid(myEmployee.ContactEmail);
                if (!validemail) { Valid = false; }

            }

            if (myEmployee.ContactHomePhone.Length > 0)
            {
                if (!IsPhoneNumber(myEmployee.ContactHomePhone.ToString()))
                {
                    Valid = false;
                }
            }

            if (myEmployee.ContactCellPhone.Length > 0)
            {
                if (!IsPhoneNumber(myEmployee.ContactCellPhone.ToString()))
                {
                    Valid = false;
                }
            }

            if (myEmployee.ContactFax.Length > 0)
            {
                if (!IsPhoneNumber(myEmployee.ContactFax.ToString()))
                {
                    Valid = false;
                }
            }

            if (!NewEntry)
            {
                if (myEmployee.Employee_AddressID == 0)
                {
                    Valid = false;
                }
            }

            if (myEmployee.Employee_AddressLine.Length == 0)
            {
                Valid = false;
            }

            if (myEmployee.Employee_AddressCity.Length == 0)
            {
                Valid = false;
            }

            if (myEmployee.Employee_Address_StateID == 0)
            {
                Valid = false;
            }

            if (myEmployee.Employee_AddressZip.Length == 0)
            {
                Valid = false;
            }

            return Valid;
        }

        public static bool IsPhoneNumber(string number)
        {
            var isPhoneNumber = Regex.IsMatch(number, "\\(\\d{3}\\)\\s\\d{3}-\\d{4}");
            return isPhoneNumber;
        }
    }
}