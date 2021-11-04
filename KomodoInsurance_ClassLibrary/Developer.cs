using System;
namespace KomodoInsurance_ClassLibrary
{
    public class Developer
    {
        public string Names { get; set; }
        public int ID { get; set; }
        public bool HasAccess { get; set; }

        public Developer() { }

        public Developer(string names, int id, bool hasaccess)
        {
            Names = names;
            ID = id;
            HasAccess = hasaccess;

        }
    }
}
