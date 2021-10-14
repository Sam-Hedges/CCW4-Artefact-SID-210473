using System;
using System.Collections.Generic;
using static System.Console;

namespace CCW4_Artefact_SID_210473
{
    enum Profession
    {
        Programmer,
        Designer,
        Artist,
        Audio
    }

    struct Member
    {
        public string name;
        public int age;
        public Profession profession;
        public bool workAvailability;
    }

    class Program
    {
        public const int MIN_TEAM_LIMIT = 3;
        public List<Member> devTeam = new List<Member>();
        public static Program program = new Program();

        static void Main(string[] args)
        {
            WriteLine("Welcome to the Development Team Program!\nPress enter to continue...");
            ReadLine();

            program.MemberInit();
        }

        void MemberInit()
        {
            Clear();
            bool temp = IsInfoCorrect("Would you like to add a new member to the team? (Y/N)");
            if (!temp && devTeam.Count < 3) 
            {
                Clear();
                WriteLine("You don't have at least 3 members for a team\nPlease create a new member\nPress enter to continue...");
                ReadLine();
                MemberInit(); 
            }

            Member tempMember = new Member();
            bool allInfoCorrect = false;
            do
            {

                tempMember.name = NameInit();
                tempMember.age = AgeInit();
                tempMember.profession = ProfessionInit();
                tempMember.workAvailability = WorkInit();

                Clear();
                allInfoCorrect = IsInfoCorrect($"Is this info correct?" +
                    $"\nName: {tempMember.name}" +
                    $"\nAge: {tempMember.age}" +
                    $"\nProfession: {tempMember.profession}" +
                    $"\nAvailablilty: {tempMember.workAvailability}" +
                    $"\n(Y/N)");

            } while (!allInfoCorrect);

            devTeam.Add(tempMember);

        }

        string NameInit()
        {

            bool validAnswer = false;
            string tempName = string.Empty;
            do
            {
                Clear();
                WriteLine("Please enter Members' name:");
                tempName = ReadLine();
                validAnswer = IsInfoCorrect($"Is the name ({tempName}) correct? (Y/N)");

            } while (!validAnswer);
            
            return tempName;
        }

        int AgeInit()
        {

            bool validAnswer = false;
            int tempAge = 0;
            do
            {
                Clear();
                WriteLine("Please enter Members' age: (Must be above 18!)");
                bool isInt = int.TryParse(ReadLine(), out tempAge);
                if (!isInt)
                {
                    AgeInit();
                }
                validAnswer = IsInfoCorrect($"Is the age ({tempAge}) correct? (Y/N)");

            } while (!validAnswer && tempAge < 18);

            return tempAge;
        }

        Profession ProfessionInit()
        {

            bool validAnswer = false;
            Profession tempProf = Profession.Artist;
            do
            {
                Clear();
                WriteLine("Please enter Members' profession: (Programmer, Designer, Artist, Audio)");
                bool isProf = Enum.TryParse(typeof(Profession), ReadLine(), true, out object parsedEnumVal);
                if (!isProf)
                {
                    ProfessionInit();
                } else
                {
                    tempProf = (Profession)parsedEnumVal;
                }
                validAnswer = IsInfoCorrect($"Is the profession ({tempProf}) correct? (Y/N)");

            } while (!validAnswer);

            return tempProf;
        }

        bool WorkInit()
        {

            bool validAnswer = false;
            bool tempWork = false;
            do
            {
                Clear();
                tempWork = IsInfoCorrect("Is Member available to work? (Y/N)");
                validAnswer = IsInfoCorrect($"Is the availablity ({tempWork}) correct? (Y/N)");

            } while (!validAnswer);

            return false;
        }

        bool IsInfoCorrect(string text)
        {
            bool hasInputValidAnswer = false;
            bool answer = false;

            do
            {
                Clear();
                WriteLine(text);
                string temp = ReadLine();
                switch (temp.ToLower())
                {
                    case "y":
                        hasInputValidAnswer = true;
                        answer = true;
                        break;
                    case "n":
                        hasInputValidAnswer = true;
                        answer = false;
                        break;
                    default:
                        hasInputValidAnswer = false;
                        Clear();
                        WriteLine("That is an invalid answer please try again\nPress enter to continue...");
                        ReadLine();
                        break;
                }

            } while (!hasInputValidAnswer);

            return answer;
        }
    }
}
