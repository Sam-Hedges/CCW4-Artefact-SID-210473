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

        static void Main(string[] args)
        {
            WriteLine("Welcome to the Development Team Program!\nPress enter to continue..."); 
            ReadLine();
            Program program = new Program();
            program.MemberInit();
        }
        void MemberInit()
        {
            while (true)
            {
                Clear();
                bool addNewMember = IsInfoCorrect("Would you like to add a new member to the team? (Y/N)");
                if (!addNewMember && devTeam.Count < MIN_TEAM_LIMIT) 
                {
                    Clear();
                    WriteLine("You need at least 3 members for a team\nPlease create a new member\nPress enter to continue...\n");
                    WriteLine("Current Members:");
                    for (int i = 0; i < devTeam.Count; i++)
                    {
                        WriteLine(PrintMembers(devTeam[i]));
                    }
                    ReadLine();
                    continue; 
                } else if (!addNewMember && devTeam.Count >= MIN_TEAM_LIMIT)
                {
                    break;
                }

                Member tempMember = new Member();
                while (true)
                {
                    tempMember.name = NameInit();
                    tempMember.age = AgeInit();
                    tempMember.profession = ProfessionInit();
                    tempMember.workAvailability = WorkInit();

                    Clear();
                    bool allInfoCorrect = IsInfoCorrect($"{PrintMembers(tempMember)}\n(Y/N)");
                    if (allInfoCorrect) { break; }
                }
                devTeam.Add(tempMember);
            }

            Clear();
            WriteLine("The final team is:\n");
            for (int i = 0; i < devTeam.Count; i++)
            {
                WriteLine(PrintMembers(devTeam[i]));
            }
            ReadLine();
        }
        string PrintMembers(Member member)
        {            
            return ($@"
Name: {member.name}
Age: {member.age}
Profession: {member.profession}
Availablilty: {member.workAvailability}");          
        }
        string NameInit()
        {
            while (true)
            {
                Clear();
                WriteLine("Please enter Members' name:");
                string tempName = ReadLine();
                bool validAnswer = IsInfoCorrect($"Is the name ({tempName}) correct? (Y/N)");
                if (validAnswer) { return tempName; }
            }
        }
        int AgeInit()
        {
            while (true)
            {
                Clear();
                WriteLine("Please enter Members' age: (Must be above 18!)");
                bool isInt = int.TryParse(ReadLine(), out int tempAge);
                if (!isInt || tempAge < 18) { continue; }
                bool validAnswer = IsInfoCorrect($"Is the age ({tempAge}) correct? (Y/N)");
                if (validAnswer) { return tempAge; }
            }
        }
        Profession ProfessionInit()
        {
            while (true)
            {
                Clear();
                WriteLine("Please enter Members' profession: (Programmer, Designer, Artist, Audio)");
                bool isProf = Enum.TryParse(typeof(Profession), ReadLine(), true, out object parsedEnumVal);
                if (!isProf) { continue; }
                bool validAnswer = IsInfoCorrect($"Is the profession ({(Profession)parsedEnumVal}) correct? (Y/N)");
                if (validAnswer) { return (Profession)parsedEnumVal; }
            } 
        }
        bool WorkInit()
        {
            while (true)
            {
                Clear();
                bool tempWork = IsInfoCorrect("Is Member available to work? (Y/N)");
                bool validAnswer = IsInfoCorrect($"Is the availablity ({tempWork}) correct? (Y/N)");
                if (validAnswer) { return tempWork; }
            } 
        }
        bool IsInfoCorrect(string text)
        {
            while (true)
            {
                Clear();
                WriteLine(text);
                switch (ReadLine().ToLower())
                {
                    case "y":
                        return true;
                    case "n":
                        return false;
                    default:
                        Clear();
                        WriteLine("That is an invalid answer please try again\nPress enter to continue...");
                        ReadLine();
                        continue;
                }
            }
        }
    }
}
