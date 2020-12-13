using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.TeamworkProjects
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfTeams = int.Parse(Console.ReadLine());

            List<RegisterTeam> registerTeams = new List<RegisterTeam>();

            for (int i = 0; i < countOfTeams; i++)
            {
                string[] registedTeamInfo = Console.ReadLine().Split('-');

                string userCreator = registedTeamInfo[0];
                string teamName = registedTeamInfo[1];

                RegisterTeam currentRegisterTeam = new RegisterTeam(userCreator, teamName);

                currentRegisterTeam.PrintMessages(currentRegisterTeam, registerTeams);
            }

            List<Join> joins = new List<Join>();

            while (true)
            {
                string[] joinInfo = Console.ReadLine().Split("->");

                if (joinInfo[0] == "end of assignment")
                {
                    break;
                }

                string userToJoin = joinInfo[0];
                string teamJoin = joinInfo[1];

                Join currentJoin = new Join(userToJoin, teamJoin);

                currentJoin.PrintMessages(currentJoin, registerTeams, joins);
            }

            PrintResult(registerTeams, joins);
        }

        private static void PrintResult(List<RegisterTeam> registerTeams, List<Join> joins)
        {
            var result = new Dictionary<string, List<string>>();

            foreach (var team in registerTeams)
            {
                foreach (var join in joins)
                {
                    if (team.TeamName == join.TeamJoin)
                    {
                        if (!result.ContainsKey(team.TeamName))
                        {
                            result.Add(team.TeamName, new List<string>());
                        }

                        result[team.TeamName].Add(join.UserToJoin);
                    }
                }
            }

            List<string> disbandTeams = new List<string>();

            foreach (var join in result.OrderByDescending(j => j.Value.Count).OrderBy(j => j.Key))
            {
                string teamName = join.Key;
                List<string> members = join.Value;


                Console.WriteLine(teamName);

                foreach (var team in registerTeams)
                {
                    if (team.TeamName == teamName)
                    {
                        Console.WriteLine($"- {team.UserCreator}");

                        foreach (var member in joins.OrderBy(m => m.UserToJoin))
                        {
                            if (team.TeamName == member.TeamJoin)
                            {
                                Console.WriteLine($"-- {member.UserToJoin}");
                            }
                        }
                    }

                    if (!result.ContainsKey(team.TeamName))
                    {
                        disbandTeams.Add(team.TeamName);
                    }
                }
            }

            Console.WriteLine("Teams to disband:");

            foreach (var disband in disbandTeams.OrderBy(t => t))
            {
                Console.WriteLine(disband);
            }
        }
    }

    class Join
    {
        public string UserToJoin { get; set; }

        public string TeamJoin { get; set; }

        public Join(string userToJoin, string teamJoin)
        {
            UserToJoin = userToJoin;
            TeamJoin = teamJoin;
        }

        public void PrintMessages(Join currentJoin, List<RegisterTeam> registerTeams, List<Join> joins)
        {
            bool anotherTeam = false;
            bool isValid = false;
            bool userTryToJoin = false;

            foreach (var registerTeam in registerTeams)
            {
                anotherTeam = false;
                isValid = false;
                userTryToJoin = false;

                if (registerTeam.TeamName.Contains(currentJoin.TeamJoin))
                {
                    if (registerTeam.UserCreator.Contains(currentJoin.UserToJoin))
                    {
                        // Member of a team cannot join another team - message should be thrown:

                        anotherTeam = true;
                    }
                    else
                    {
                        // if everything is OK

                        isValid = true;

                        break;
                    }
                }

                if (!registerTeam.UserCreator.Contains(currentJoin.UserToJoin))
                {
                    if (!registerTeam.TeamName.Contains(currentJoin.TeamJoin))
                    {
                        // If user tries to join currently non-existing team a message should be displayed: 

                        userTryToJoin = true;
                    }
                    else
                    {
                        // if everything is OK

                        isValid = true;

                        break;
                    }
                }
            }

            if (isValid)
            {
                joins.Add(currentJoin);
            }
            else if (userTryToJoin)
            {
                Console.WriteLine($"Team {TeamJoin} does not exist!");
            }
            else if (anotherTeam)
            {
                Console.WriteLine($"Member {UserToJoin} cannot join team {TeamJoin}!");
            }
        }
    }

    class RegisterTeam
    {
        public string UserCreator { get; set; }

        public string TeamName { get; set; }

        public RegisterTeam(string userCreator, string teamName)
        {
            this.UserCreator = userCreator;
            this.TeamName = teamName;
        }

        public void PrintMessages(RegisterTeam currentRegisterTeam, List<RegisterTeam> registerTeams)
        {
            bool isValid = true;

            foreach (var registerTeam in registerTeams)
            {
                if (registerTeam.TeamName == currentRegisterTeam.TeamName)
                {
                    isValid = false;

                    // If user tries to create a team more than once a message should be displayed: 

                    Console.WriteLine($"Team {TeamName} was already created!");
                }

                if (registerTeam.UserCreator == currentRegisterTeam.UserCreator)
                {
                    isValid = false;

                    // Creator of a team cannot create another team - message should be thrown: 

                    Console.WriteLine($"{UserCreator} cannot create another team!");
                }
            }

            // if everything is OK

            if (isValid)
            {
                Console.WriteLine($"Team {TeamName} has been created by {UserCreator}!");

                registerTeams.Add(currentRegisterTeam);
            }
        }
    }
}