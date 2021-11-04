using System;
using System.Collections.Generic;

namespace KomodoInsurance_ClassLibrary
{
    public class DevTeam
    {
        public string TeamName { get; set; }
        public int TeamID { get; set; }
        public List<Developer> TeamMembers { get; set; }

        public DevTeam() { }

        public DevTeam(string teamname, int teamid)
        {
            TeamName = teamname;
            TeamID = teamid;
        }
    }
}
