using System.Collections.Generic;
using Proyecto26;
using Serialization;
using UnityEngine;

namespace Firebase
{
    public static class AuthHandler
    {
        public delegate void OnAuthSuccess(Dictionary<string, string> userInfo);

        public static string userId;
        public static string idToken;

        /// <summary>
        /// Signs up a new user to Firebase
        /// </summary>
        /// <param name="email">User's email</param>
        /// <param name="password">User's password</param>
        /// <param name="callback">Executes if the user was created successfully, passes info on the newly created user</param>
        public static void SignUp(string email, string password, OnAuthSuccess callback)
        {
            var payload = $"{{\"email\":\"{email}\",\"password\":\"{password}\",\"returnSecureToken\":true}}";
            RestClient.Post(
                $"https://identitytoolkit.googleapis.com/v1/accounts:signUp?key={FirebaseInitializer.FirebaseInfo.apiKey}",
                payload).Then(
                response =>
                {
                    var userInfo = new Dictionary<string, string>();
                    SerializationHandler.FromJSONToObject(response.Text, out userInfo);
                    callback(userInfo);
                }).Catch(Debug.Log);
        }

        /// <summary>
        /// Signs in a user to Firebase
        /// Stores the userId and the idToken of the user in the class
        /// </summary>
        /// <param name="email">User's email</param>
        /// <param name="password">User's password</param>
        /// <param name="callback">Executes if the user signed in successfully, passes info on the user</param>
        public static void SignIn(string email, string password, OnAuthSuccess callback)
        {
            var payload = $"{{\"email\":\"{email}\",\"password\":\"{password}\",\"returnSecureToken\":true}}";
            RestClient.Post(
                $"https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key={FirebaseInitializer.FirebaseInfo.apiKey}",
                payload).Then(
                response =>
                {
                    Dictionary<string, string> userInfo;
                    SerializationHandler.FromJSONToObject(response.Text, out userInfo);

                    userId = userInfo["localId"];
                    idToken = userInfo["idToken"];

                    callback(userInfo);
                }).Catch(Debug.Log);
        }
    }
}