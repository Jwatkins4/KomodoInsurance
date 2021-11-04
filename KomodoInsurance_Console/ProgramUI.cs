using System;
namespace KomodoInsurance_Console
{
    class ProgramUI
    {
        private DevTeamRepo _devTeamRepo = new DevTeamRepo();
        
        //Method that runs/starts the application
        public void Run()
        {
            SeedContentList();
            Menu();
        }

        //Menu
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                //Display options to user
                Console.WriteLine("Select a menu option:\n" +
                    "1. Create New Team\n" +
                    "2. View All Developers " +
                    "3. View All Teams\n" +
                    "4. Update Existing Team\n" +
                    "5. Delete Existing Team\n" +
                    "6. Exit ");

                //Get the user's input
                string input = Console.ReadLine();

                //Evaluate users input and act accordingly
                switch (input)
                {
                    case "1":
                        //Create New Team
                        CreateNewTeam();
                        break;
                    case "2:":
                        //View All Developers
                        DisplayAllDevelopers();
                        break;
                    case "3":
                        //View All Teams
                        DisplayAllTeams();
                        break;
                    case "4":
                        //Update Existing Team
                        UpdateExistingTeam();
                        break;
                    case "5":
                        //Delete Existing Team
                        DeleteExistingTeam();
                        break;
                    case "6":
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }
                Console.WriteLine("Please press any key to continue....");
                Console.ReadKey();
                Console.Clear();
            }
        }


        private void CreateNewTeam()
        {
            DevTeam newTeam = new DevTeam();

            //Team Name
            Console.WriteLine("Enter the name of your team");
            newTeam.Name = Console.ReadLine();

            //Team ID
            Console.WriteLine("Enter the Team ID (Number)");
            string idAsAString = Console.ReadLine();
            newTeam.ID = int.Parse(idAsAString);

            _devTeamRepo.AddTeamToList(newTeam);

        }

        private void DisplayAllDevelopers()
        {
            List<Developer> listofdevelopers = _devTeamRepo.GetDeveloperList();

            foreach(Developer developer in listofdevelopers)
            {
                Console.WriteLine($"Developer: {developer.Name}\n" +
                    $"ID: {developer.ID}");
            }
        }

        private void DisplayDeveloperbyName()
        {
            Console.WriteLine("Enter the Name of the developer you'd like to see ");

            //Developers Name
            string name = Console.ReadLine();

            //Find the developer by Name
            Developer developer = _developerRepo.GetDeveloperByName(name);

            if (developer != null)
            {
                Console.WriteLine($"Developer: {developer.Name}\n" +
                    $"ID: {developer.ID}" +
                    $"Access: {developer.HasAccess}");
            }
            else
            {
                Console.WriteLine("No developer by that title.");
            }

        }

        private void DeleteDeveloper()
        {
            DisplayAllDevelopers();


            Console.WriteLine("\n Enter the developer you want to remove:");

            string input = Console.ReadLine();

            bool wasDeleted = _devTeamRepo.RemoveFromList(input);

            if (wasDeleted)
            {
                Console.WriteLine("The developer was successfully deleted.");
            }
            else
            {
                Console.WriteLine("Developer could not be deleted.");
            }
        }

        private void UpdateDeveloper()
        {

        }

        private void DisplayAllTeams()
        {
            //DevTeam has string TeamName, int TeamID, list of developers
            List<DevTeam> listofdevteams = _devTeamRepo.GetDevTeamList();

            foreach (DevTeam devteam in listofdevteams)
            {
                Console.WriteLine($"Team Name: {devteam.TeamName}\n" +
                    $"Team ID: {devteam.TeamID}" +
                    $"Members: {devteam.TeamMembers}");
            }

        }

        private void UpdateExistingTeam()
        {
            DisplayAllTeams();

            string oldTeam = Console.ReadLine();

            boolWasUpdate = _devTeamRepo.UpdateExistingTeam(oldTeam, newTeam);


            if (wasUpdated)
            {
                Console.WriteLine("Team was updated");
            }
            else
            {
                Console.WriteLine("Could not update");
            }

        }

        private void DeleteExistingTeam()
        {
            DisplayAllTeams();

            
            Console.WriteLine("\n Enter the Team you want to remove:");

            string input = Console.ReadLine();

            bool wasDeleted = _devTeamRepo.RemoveContentFromList(input);

            if (wasDeleted)
            {
                Console.WriteLine("The team was successfully deleted.");
            }
            else
            {
                Console.WriteLine("Team could not be deleted.");
            }
            
        }

        private void SeedContentList()
        {
            Console.Clear();
            //Developer = string name, int ID, bool HasAccess (true or false)
            Developer Tom = new Developer("Tom", 23, true);
            Developer Sarah = new Developer("Sarah", 10, false);
            Developer Jamar = new Developer("Jamar", 4, true);

            _devTeamRepo.AddDeveloperToList(Tom);
            _devTeamRepo.AddDeveloperToList(Sarah);
            _devTeamRepo.AddDeveloperToList(Jamar);
        }

    }
}
