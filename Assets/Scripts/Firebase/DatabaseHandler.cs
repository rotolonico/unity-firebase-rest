using Proyecto26;
using UnityEngine;

namespace Firebase
{
    public static class DatabaseHandler
    {
        public delegate void OnDatabaseSuccess(string responseJson);

        /// <summary>
        /// Deploys JSON on the Firebase Database at the given path
        /// </summary>
        /// <param name="json">JSON to deploy to the database</param>
        /// <param name="path">Database path</param>
        /// <param name="authenticate">Whether or not the request should be authenticated with the user's idToken</param>
        /// <param name="callback">Executes after the request was successfully completed, passes the json deployed to the database</param>
        public static void Put(string json, string path, bool authenticate, OnDatabaseSuccess callback)
        {
            var authHeader = authenticate ? $"auth={AuthHandler.idToken}" : "";
            RestClient.Put(
                    $"https://{FirebaseInitializer.FirebaseInfo.projectId}.firebaseio.com/{path}.json?{authHeader}",
                    json)
                .Then(
                    response => { callback(response.Text); }).Catch(Debug.Log);
        }

        /// <summary>
        /// Gets JSON from the Firebase Database from the given path
        /// </summary>
        /// <param name="path">Database path</param>
        /// <param name="authenticate">Whether or not the request should be authenticated with the user's idToken</param>
        /// <param name="callback">Executes after the request was successfully completed, passes the json retrieved from the database</param>
        public static void Get(string path, bool authenticate, OnDatabaseSuccess callback)
        {
            var authHeader = authenticate ? $"auth={AuthHandler.idToken}" : "";
            RestClient.Get(
                $"https://{FirebaseInitializer.FirebaseInfo.projectId}.firebaseio.com/{path}.json?{authHeader}").Then(
                response => { callback(response.Text); }).Catch(Debug.Log);
        }
    }
}