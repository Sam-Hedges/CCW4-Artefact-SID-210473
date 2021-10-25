using System;
using System.Collections.Generic;
using static System.Console;

namespace CCW4_Artefact_SID_210473
{

    /// <summary>
    /// Enumerator of available professions for Member Struct
    /// </summary>
    enum Profession 
    {
        Programmer,
        Designer,
        Artist,
        Audio
    }

    /// <summary>
    /// Structure of Member related Information
    /// </summary>
    struct Member 
    {
        public string name;
        public int age;
        public Profession profession; // Used enum within structure to store profession of member
        public bool workAvailability;
    }

    class Program
    {
        public const int MIN_TEAM_LIMIT = 3; // Const of the minimum amount of members to be stored in the list
        public List<Member> devTeam = new List<Member>(); // List to store all the members

        static void Main(string[] args) // Main method gets automatically run first
        {

            WriteLine("Welcome to the Development Team Program!\nPress enter to continue..."); ReadLine();

            Program program = new Program(); // Initilize a new version of the class to call the MemberInit() method
            program.MemberInit();

        }

        /// <summary>
        /// Initilizes members and adds them to the list
        /// </summary>
        void MemberInit()
        {
            while (true)
            {
                Clear(); bool addNewMember = IsInfoCorrect("Would you like to add a new member to the team? (Y/N)");
                if (!addNewMember && devTeam.Count < MIN_TEAM_LIMIT) // If the user doesn't want to add a new member and the number 
                                                                     // of members in the list is less than the min team limit
                {

                    Clear(); WriteLine("You need at least 3 members for a team\nPlease create a new member\nPress enter to continue...\n");
                    WriteLine("Current Members:");

                    foreach (Member member in devTeam) // Prints all of the members' details 
                    {
                        WriteLine(PrintMembers(member));
                    }

                    ReadLine();
                    continue; // Starts the while loop from the beginning

                } else if (!addNewMember && devTeam.Count >= MIN_TEAM_LIMIT) { break; } // Breaks out of the member creation while loop

                Member tempMember = new Member(); // Initilizes a new temporary member to be populated with new member information 
                while (true)
                {
                    // Populating the temporary member
                    tempMember.name = NameInit();
                    tempMember.age = AgeInit();
                    tempMember.profession = ProfessionInit();
                    tempMember.workAvailability = WorkInit();

                    // If the displayed member info is correct then break the while loop to add the member to the list
                    Clear(); bool allInfoCorrect = IsInfoCorrect($"{PrintMembers(tempMember)}\n(Y/N)");
                    if (allInfoCorrect) { break; }

                }

                // Add the temporary member to the list
                devTeam.Add(tempMember);

            }
            
            // Displays all the members' information
            Clear(); WriteLine("The final team is:\n");
            for (int i = 0; i < devTeam.Count; i++)
            {
                WriteLine(PrintMembers(devTeam[i]));
            }

            ReadLine();

        }

        /// <summary>
        /// Takes a Member and returns all of its' information as a String
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        string PrintMembers(Member member)
        {            

            return ($@"
Name: {member.name}
Age: {member.age}
Profession: {member.profession}
Availablilty: {member.workAvailability}");   
            
        }

        /// <summary>
        /// Returns a Name as a String
        /// </summary>
        /// <returns></returns>
        string NameInit()
        {
            while (true)
            {
                Clear(); WriteLine("Please enter Members' name:");
                string tempName = ReadLine();

                if (IsInfoCorrect($"Is the name ({tempName}) correct? (Y/N)")) { return tempName; }
            }
        }

        /// <summary>
        /// Returns an Age as an Integer
        /// </summary>
        /// <returns></returns>
        int AgeInit()
        {
            while (true)
            {
                Clear(); WriteLine("Please enter Members' age: (Must be above 18!)");

                bool isInt = int.TryParse(ReadLine(), out int tempAge);
                if (!isInt || tempAge < 18) { continue; }

                if (IsInfoCorrect($"Is the age ({tempAge}) correct? (Y/N)")) { return tempAge; }
            }
        }

        /// <summary>
        /// Returns a Profession of the Enum Profession
        /// </summary>
        /// <returns></returns>
        Profession ProfessionInit()
        {
            while (true)
            {
                Clear(); WriteLine("Please enter Members' profession: (Programmer, Designer, Artist, Audio)");

                bool isProf = Enum.TryParse(ReadLine(), true, out Profession parsedEnumVal);
                if (!isProf) { continue; }

                if (IsInfoCorrect($"Is the profession ({parsedEnumVal}) correct? (Y/N)")) { return parsedEnumVal; }
            } 
        }

        /// <summary>
        /// Returns whether a Member is available to work as a Bool
        /// </summary>
        /// <returns></returns>
        bool WorkInit()
        {
            while (true)
            {
                Clear(); bool tempWork = IsInfoCorrect("Is Member available to work? (Y/N)");
                if (IsInfoCorrect($"Is the availablity ({tempWork}) correct? (Y/N)")) { return tempWork; }
            } 
        }

        /// <summary>
        /// Takes a string to be displayed and returns a true or false answer as a Bool
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        bool IsInfoCorrect(string text)
        {
            while (true)
            {

                Clear(); WriteLine(text);
                switch (ReadLine().ToLower())
                {
                    case "y":
                        return true;
                    case "n":
                        return false;
                    default:
                        Clear(); WriteLine("That is an invalid answer please try again\nPress enter to continue...");
                        ReadLine();
                        continue;
                }

            }
        }
    }
}