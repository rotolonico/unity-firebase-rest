using Firebase.Objects;
using UnityEngine;

namespace Firebase
{
    public class FirebaseInitializer : MonoBehaviour
    {
        public static FirebaseInfo FirebaseInfo;

        /// <summary>
        /// It will execute when the application starts
        /// It will store Firebase's projectId and apiKey onto the FirebaseInfo object
        /// </summary>
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void InitializeFirebase()
        {
            // TODO: Add projectId and apiKey for your project!
            FirebaseInfo = new FirebaseInfo(
                "project-id",
                "API_KEY");
        }
    }
}