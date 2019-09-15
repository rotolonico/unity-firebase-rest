using System;
using UnityEngine;

namespace Demo.Scripts.Objects
{
    [Serializable]
    public class DemoUser
    {
        public string name;
        public string surname;

        public DemoUser(string name, string surname)
        {
            this.name = name;
            this.surname = surname;
        }
    }
}
