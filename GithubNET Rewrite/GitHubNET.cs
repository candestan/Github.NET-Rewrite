using System.Text.Json;
using System.Net;
namespace GitHubNET_Rewrite
{
    public class GitHubNET
    {
        #region Data Types
        public class DataTypes
        {
            public class TwitterInfo
            {
                public string UserName { get; set; }
                public Uri Twitter_URL { get; set; }
            }
            public class GITHUB_API_OUTPUT
            {
                public class USER_OUTPUT
                {
                    public string? login { get; set; }
                    public int id { get; set; }
                    public string? node_id { get; set; }
                    public string? avatar_url { get; set; }
                    public string? gravatar_id { get; set; }
                    public string? url { get; set; }
                    public string? html_url { get; set; }
                    public string? followers_url { get; set; }
                    public string? following_url { get; set; }
                    public string? gists_url { get; set; }
                    public string? starred_url { get; set; }
                    public string? subscriptions_url { get; set; }
                    public string? organizations_url { get; set; }
                    public string? repos_url { get; set; }
                    public string? events_url { get; set; }
                    public string? received_events_url { get; set; }
                    public string? type { get; set; }
                    public bool site_admin { get; set; }
                    public string? name { get; set; }
                    public string? company { get; set; }
                    public string? blog { get; set; }
                    public string? location { get; set; }
                    public object? email { get; set; }
                    public object? hireable { get; set; }
                    public string? bio { get; set; }
                    public string? twitter_username { get; set; }
                    public int public_repos { get; set; }
                    public int public_gists { get; set; }
                    public int followers { get; set; }
                    public int following { get; set; }
                    public DateTime created_at { get; set; }
                    public DateTime updated_at { get; set; }
                }
            }
        }
        #endregion

        public class USER
        {
            public string UserName { get; set; }
            public int ID { get; set; }
            public Uri Avatar_URL { get; set; }
            public string Node_ID { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public string Bio { get; set; }
            public DataTypes.TwitterInfo Twitter { get; set; }
            public int Repo_Count { get; set; }
            public int Gist_Count { get; set; }
            public int Follower_Count { get; set; }
            public int Following_Count { get; set; }
            public Uri ProfileLink { get; set; }
            public Uri APILink { get; set; }

            public USER(string _Name)
            {
                UserName = _Name;
                ProfileLink = new Uri(string.Format("https://github.com/{0}/", UserName));
                APILink = new Uri(string.Format("https://api.github.com/users/{0}", UserName));
                string? _JSON;
#pragma warning disable SYSLIB0014
                using (var REQ  = new WebClient())
                    _JSON = REQ.DownloadString(APILink);
#pragma warning restore SYSLIB0014
                var SERIALIZED = JsonSerializer.Deserialize<DataTypes.GITHUB_API_OUTPUT.USER_OUTPUT>(_JSON);
                ID = SERIALIZED.id;
                Node_ID = SERIALIZED.node_id;
                Avatar_URL = new Uri(SERIALIZED.avatar_url);
                Name = SERIALIZED.name;
                Bio = SERIALIZED.bio;
                Twitter.UserName = SERIALIZED.twitter_username;
                Twitter.Twitter_URL = new Uri(string.Format("https://twitter.com/{0}",Twitter.UserName));
                Repo_Count = SERIALIZED.public_repos;
                Gist_Count = SERIALIZED.public_gists;
                Follower_Count = SERIALIZED.followers;
                Following_Count = SERIALIZED.following;
            }
            public USER() {  }
        }
        public class ORGANIZATION : USER
        {
            public ORGANIZATION(string _Name) : base(_Name)
            {
            }
        }
        public class Repostory
        {
            public int StarCount { get; set; }
            public string? Name { get; set; }
            public string? RepoLink { get; set; }
            public USER? Owner { get; set; }
        }
    }
}