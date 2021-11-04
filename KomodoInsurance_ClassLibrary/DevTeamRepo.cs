using System;
using System.Collections.Generic;

namespace KomodoInsurance_ClassLibrary
{
    public class DevTeamRepo
    {
        private List<DevTeam> _listofDevTeam = new List<DevTeam>();


        //Create Team
        public void AddDeveloperToTeam(DevTeam dev)
        {

            _listofDevTeam.Add(dev);
        }
        //Read List of Developers
        public List<DevTeam> GetDevTeamList()
        {
            return _listofDevTeam;
        }
        //Update Developer and Access
        public bool UpdateExistingDeveloper(string ID, Developer newDev)
        {
            //Find the Developer
            Developer oldDev = GetDevelopersByID(ID);

            //Update the Developer
            if (oldDev != null)
            {
                oldDev.Names = newDev.Names;
                oldDev.ID = newDev.ID;
                oldDev.HasAccess = newDev.HasAccess;

                return true;
            }
            else
            {
                return false;
            }
        }

        //Delete Developer from team
        public bool RemoveDeveloperFromList(int ID)
        {
            DevTeam dev = Convert.ToString(GetDevelopersByID(ID));

            if (ID == null)
            {
                return false;
            }

            int initialCount = _listofDevTeam.Count;
            _listofDevTeam.Remove(dev);

            if (initialCount > _listofDevTeam +1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //Helper Method -- It's job is to help the other methods
        public DevTeam GetDeveloperByID(string id)
        {
           foreach (DevTeam team in _listofDevTeam)
           {
                if (team.TeamName.ToLower() == id.ToLower())
                {  
                    return team;
                }
           } 
        }
    }
}
