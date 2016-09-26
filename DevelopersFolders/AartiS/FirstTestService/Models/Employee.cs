using System.Collections.Generic;

public class Employee

    {

        public int EmployeeId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }


        public static List<Employee> GetEmployees()

        {

            return new List<Employee>()

            {

                new Employee()

                {

                    EmployeeId=1,

                    FirstName="John",

                    LastName="Doe"

                },

                new Employee()

                {

                    EmployeeId=2,

                    FirstName="John",

                    LastName="Smith"

                },

                new Employee()

                {

                    EmployeeId=3,

                    FirstName="Jane",

                    LastName="Smith"

                }

            };

        }

    }