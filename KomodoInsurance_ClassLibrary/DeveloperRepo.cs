using System;
using System.Collections.Generic;

namespace KomodoInsurance_ClassLibrary
{
    public class DeveloperRepo
    {
       
        private List<Developer> _listofDevs = new List<Developer>();


        //Create Developer
        public void AddDeveloperToList(Developer developers)
        {
            _listofDevs.Add(developers);
        }
        //Read List of Developers
        public List<Developer> GetDevelopersList()
        {
            return _listofDevs;
        }
        //Update Developer and Access
        public bool UpdateExistingDeveloper(int ID, Developer newDev)
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

        //Delete Developer
        public bool RemoveDeveloperFromList(int id)
        {
            Developer developer = GetDevelopersByID(id);

            if (developer == null)
            {
                return false;
            }

            int initialCount = _listofDevs.Count;
            _listofDevs.Remove(developer);

            if (initialCount == _listofDevs.Count +1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //Helper Method -- It's job is to help the other methods
        private Developer GetDevelopersByID(int id)
        {
            foreach (Developer developer in _listofDevs)
            {
                if (developer.ID == id)
                {
                    return developer;
                }
            }

            return null;
        }
    }
}
