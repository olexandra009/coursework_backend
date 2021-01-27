namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework
{
    public static class Roles
    {
        /// <summary>User with this role can add other users and edit their roles</summary>
        public static readonly string MangerAdmin = "UserManger";
        /// <summary>User with this role can add news and events</summary>
        public static readonly string Admin = "NewsAndEvents";
        /// <summary>User with this role can edit news and events</summary>
        public static readonly string Moderator = "Moderator";
        /// <summary>User with this role can edit news and events</summary>
        public static readonly string ApplicationAdmin = "ApplicationAdmin";
        /// <summary>User with this role can create and vote petition</summary>
        public static readonly string SuperUser = "SuperUser";
        /// <summary>User with this role can create application</summary>
        public static readonly string User = "User";

    }
}
