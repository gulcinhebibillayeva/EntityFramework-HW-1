using ADO_NET_03_Homework;
using Azure.Identity;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Extensions.Configuration;
using System.ComponentModel.Design;
using System.Reflection;

var builder = new ConfigurationBuilder();
builder.SetBasePath(Directory.GetCurrentDirectory());
builder.AddJsonFile("appsettings.json");

var config = builder.Build();
string connectionString = config
                .GetConnectionString("MyJsonCS")!;


using (var db = new UserContext(connectionString))
{

    {

        while (true)
        {
            Console.WriteLine("Qeydiyyatdan kecin");
            Console.WriteLine("1.Sign in");
            Console.WriteLine("2.Sign Up");
            Console.WriteLine("3.Exit ");
            Console.WriteLine("Secim edin: ");
            if (!int.TryParse(Console.ReadLine(), out int num)) continue;
            else if (num == 1)
            {
                string username;
                while (true)
                {
                    Console.WriteLine("UserName daxil edin ");

                    username = Console.ReadLine();
                    var writtenUser = db.Users.FirstOrDefault(x => x.UserName == username);

                    if (writtenUser != null)
                    {
                        Console.WriteLine("This username is exist");
                    }
                    else if (username == null)
                    {
                        Console.WriteLine("Please enter username");
                    }
                    else break;
                }
                string password;
                while (true)
                {
                    Console.WriteLine("Password daxil edin");
                    password = Console.ReadLine();
                    if (password == null)
                    {
                        Console.WriteLine("You should enter password");
                    }
                    else break;
                }
                string firstName;
                while (true)
                {
                    Console.WriteLine("FirstName daxil edin");
                    firstName = Console.ReadLine();
                    if (firstName == null)
                    {
                        Console.WriteLine("You should enter firstname");
                    }
                    else break;
                }

                string lastName;
                while (true)
                {
                    Console.WriteLine("Enter lastname");
                    lastName = Console.ReadLine();
                    if (lastName == null)
                    {
                        Console.WriteLine("You should enter lastname");
                    }
                    else break;
                }

                int age;
                while (true)
                {
                    Console.WriteLine("Enter age");
                    if (int.TryParse(Console.ReadLine(), out age))
                    {
                        if (age > 0)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("incorrect age");
                        }
                        Console.WriteLine("Please enter number");
                    }

                }
                bool gender;
                while (true)
                {
                    Console.WriteLine("Enter gender (0 = qadın, 1 = kişi): ");
                    string genderInput = Console.ReadLine();
                    if (genderInput == "0")
                    {
                        gender = false;
                        break;
                    }
                    else if (genderInput == "1")
                    {
                        gender = true;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please enter correct value (0 or 1)");
                    }
                }


                var newUser = new User
                {
                    UserName = username,
                    Password = password,
                    FirstName = firstName,
                    LastName = lastName,
                    Age = age,
                    Gender = gender

                };
                db.Users.Add(newUser);
                db.SaveChanges();
            }

            else if (num == 2)
            {
                Console.WriteLine("Sign up");

                string username;
                while (true)
                {
                    Console.WriteLine("Enter username");
                    username = Console.ReadLine();
                    var writtenusername = db.Users.FirstOrDefault(u => u.UserName == username);
                    if (writtenusername == null)
                    {
                        Console.WriteLine("This username is not exist");
                    }
                    else break;
                }

                string password;
                while (true)
                {
                    Console.WriteLine("Enter password");
                    password = Console.ReadLine();
                    var truepassword = db.Users.FirstOrDefault(u => u.UserName == username && u.Password == password);
                    if (truepassword == null)
                    {
                        Console.WriteLine("password is not correct");
                    }
                    else break;
                }

                var user = db.Users.FirstOrDefault(u => u.UserName == username);
                if (user != null) {
                    Console.WriteLine(user);
                }
            }

                if (num == 3) {
                    break;
                }
            }

        }


    
}