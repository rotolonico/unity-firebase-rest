using System;

namespace Firebase.Objects
{
    [Serializable]
    public class FirebaseInfo
    {
        public string projectId;
        public string apiKey;

        public FirebaseInfo(string projectId, string apiKey)
        {
            this.projectId = projectId;
            this.apiKey = apiKey;
        }
    }
}