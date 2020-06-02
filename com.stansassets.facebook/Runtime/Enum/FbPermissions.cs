namespace SA.Facebook
{
    /// <summary>
    /// Contain list of facebook permissions
    /// https://developers.facebook.com/docs/facebook-login/permissions/v2.0
    /// </summary>
    public enum FbPermissions
    {
        //Read Permissions - User Attributes
        email,
        public_profile,
        read_custom_friendlists,
        user_about_me,
        user_birthday,
        user_education_history,
        user_friends,
        user_hometown,
        user_location,
        user_relationship_details,
        user_relationships,
        user_religion_politics,
        user_work_history,

        //Read Permissions - User Activity
        user_games_activity,
        user_likes,
        user_photos,
        user_posts,
        user_tagged_places,
        user_videos,
        user_website,

        //Read Permissions - User Events and Groups
        user_events,
        user_managed_groups,

        //Write Permissions
        publish_actions,
        rsvp_event
    }
}
