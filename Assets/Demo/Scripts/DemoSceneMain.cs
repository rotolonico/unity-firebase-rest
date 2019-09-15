using System;
using Demo.Scripts.Objects;
using Firebase;
using Serialization;
using UnityEngine;

namespace Demo.Scripts
{
    public class DemoSceneMain : MonoBehaviour
    {
        /// <summary>
        /// It will run when the DemoScene is loaded.
        /// It shows off all of the functionalities in the package:
        /// 1) It will create a new user with email test@test.com and password 1234567
        /// 2) It will sign in as the user with email test@test.com and password 1234567
        /// 3) It will post in users/userId some generic user info on the Database
        /// 4) it will retrieve in users/userId the user info from the Database and print it
        /// </summary>
        private void Start()
        {
            AuthHandler.SignUp("test@test.com", "1234567", signUpInfo =>
            {
                AuthHandler.SignIn("test@test.com", "1234567", signInInfo =>
                {
                    var newUser = new DemoUser("Name", "Surname");
                    var newUserJson = SerializationHandler.FromObjectToJSON(newUser, false);

                    DatabaseHandler.Put(newUserJson, $"users/{AuthHandler.userId}", true, putInfo =>
                    {
                        DatabaseHandler.Get($"users/{AuthHandler.userId}", true, getInfo =>
                        {
                            DemoUser user;
                            SerializationHandler.FromJSONToObject(getInfo, out user);
                            Debug.Log($"The user is named: {user.name} {user.surname}");
                        });
                    });
                });
            });
        }
    }
}