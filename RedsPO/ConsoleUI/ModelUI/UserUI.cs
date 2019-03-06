using System;
using Business;
using static System.Console;
using static UI.ConsoleUI;

namespace UI
{
    public static class UserUI
    {
        /// <summary>
        /// Logins the User into his Account.
        /// </summary>
        public static void Login()
        {
            try
            {
                Clear();

                WriteLine(new string('-', 40));
                WriteLine(new string(' ', 17) + "LOGIN" + new string(' ', 18));
                WriteLine(new string('-', 40));

                WriteLine("Enter Username:");
                string username = ReadLine();

                WriteLine("Enter Password:");
                string passwordHash = UserBusiness.HashPassword(ReadPassword());

                CurrentUser = UBusiness.FetchUser(username, passwordHash);

                if (CurrentUser == null)
                {
                    throw new InvalidOperationException("Unknown Username or Password!");
                }
                else
                {
                    ShowMenu();
                    TakeInput();
                }
            }
            catch (Exception currentException)
            {
                WriteLine("An unexpected ERROR occured! Please try again later.");
                WriteLine($"[{currentException.Message}]");
                Environment.Exit(1);
            }
        }

        /// <summary>
        ///   Registers the User.
        /// </summary>
        public static void Register()
        {
            try
            {
                Clear();

                WriteLine(new string('-', 40));
                WriteLine(new string(' ', 16) + "REGISTER" + new string(' ', 16));
                WriteLine(new string('-', 40));

                User user = new User();

                WriteLine("Enter Username: ");
                user.UserName = ReadLine();

                WriteLine("Enter Password:");
                user.PasswordHash = UserBusiness.HashPassword(ReadPassword());

                WriteLine("First Name: ");
                user.FirstName = ReadLine();

                WriteLine("Last Name: ");
                user.LastName = ReadLine();

                UBusiness.Register(user);

                Login();
            }
            catch
            {
                WriteLine("An unexpected ERROR occured! Please try again later.");
                Environment.Exit(1);
            }
        }

        /// <summary>
        /// Reads the password, hiding the input.
        /// </summary>
        public static string ReadPassword()
        {
            string inputPassword = "";
            ConsoleKeyInfo keyInfo = ReadKey(true);

            while (keyInfo.Key != ConsoleKey.Enter)
            {
                if (keyInfo.Key != ConsoleKey.Backspace)
                {
                    Write("*");
                    inputPassword += keyInfo.KeyChar;
                }
                else if (keyInfo.Key == ConsoleKey.Backspace)
                {
                    if (!string.IsNullOrEmpty(inputPassword))
                    {
                        // Remove one character from the list of password characters
                        inputPassword = inputPassword.Substring(0, inputPassword.Length - 1);
                        // Get the location of the cursor
                        int cursorPosition = CursorLeft;
                        // Move the cursor to the left by one character
                        SetCursorPosition(cursorPosition - 1, CursorTop);
                        // Replace it with space
                        Write(" ");
                        // Move the cursor to the left by one character again
                        SetCursorPosition(cursorPosition - 1, CursorTop);
                    }
                }

                keyInfo = ReadKey(true);
            }

            WriteLine();

            return inputPassword;
        }
    }
}
