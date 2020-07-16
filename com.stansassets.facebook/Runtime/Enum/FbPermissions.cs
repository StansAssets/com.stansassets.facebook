namespace StansAssets.Facebook
{
    /// <summary>
    /// Contain list of facebook permissions
    /// https://developers.facebook.com/docs/facebook-login/permissions/v2.0
    /// </summary>
    public enum FbPermissions
    {
        // Instagram Platform

        /// <summary>
        /// The instagram_basic permission allows your app to read an Instagram account profile's info and media.
        /// Requires App Review.
        /// https://developers.facebook.com/docs/facebook-login/permissions/v2.0#reference-instagram_basic
        /// </summary>
        instagram_basic,

        /// <summary>
        /// Does not require App Review.
        /// The email permission allows your app to read an person's primary email address.
        /// </summary>
        email,

        /// <summary>
        /// Grants your app access to the default fields of the User object that are a subset of a person's public profile:
        /// * id
        /// * first_name
        /// * last_name
        /// * middle_name
        /// *  name
        /// *  name_format
        /// *  picture
        /// * short_name
        /// https://developers.facebook.com/docs/facebook-login/permissions/v2.0#reference-default
        /// </summary>
        public_profile,

        /// <summary>
        /// Requires App Review.
        /// The user_birthday permission allows your app to read a person's birthday as listed in their Facebook profile.
        /// https://developers.facebook.com/docs/facebook-login/permissions/v2.0#reference-user_birthday
        /// </summary>
        user_birthday,

        /// <summary>
        /// Requires App Review.
        /// The user_friends permission allows your app to get a list of a person's friends using that app.
        /// The allowed usage for this permission is to provide Facebook-related content to personalize a person's experience.
        /// You may also use this permission to request analytics insights to improve your app and for marketing or advertising purposes, through the use of aggregated and de-identified or anonymized information (provided such data cannot be re-identified).
        /// https://developers.facebook.com/docs/facebook-login/permissions/v2.0#reference-user_friends
        /// </summary>
        user_friends,

        /// <summary>
        /// Requires App Review.
        /// The user_hometown permission allows your app to read a person's hometown location from their Facebook profile.
        /// https://developers.facebook.com/docs/facebook-login/permissions/v2.0#reference-user_hometown
        /// </summary>
        user_hometown,

        /// <summary>
        /// Requires App Review.
        /// The user_location permission allows your app to read the city name as listed in the location field of a person's Facebook profile.
        /// https://developers.facebook.com/docs/facebook-login/permissions/v2.0#reference-user_location
        /// </summary>
        user_location,

        /// <summary>
        /// Requires App Review.
        /// The user_likes permission allows your app to read a list of all Facebook Pages that a user has Liked.
        /// The allowed usage for this permission is to provide a personalized experience by correlating or surfacing content related to the person's Likes.
        /// This includes curating content at scale to customize apps with large amounts of content, and enabling people to share their Likes with others,
        /// for example in dating and music apps. You may also use this permission to request analytics insights to improve your app and for marketing
        /// or advertising purposes, through the use of aggregated and de-identified or anonymized information (provided such data cannot be re-identified).
        /// https://developers.facebook.com/docs/facebook-login/permissions/v2.0#reference-user_likes
        /// </summary>
        user_likes,

        /// <summary>
        /// Requires App Review.
        /// The user_photos permission allows your app to read the photos a person has uploaded to Facebook.
        /// https://developers.facebook.com/docs/facebook-login/permissions/v2.0#reference-user_photos
        /// </summary>
        user_photos,

        /// <summary>
        /// Requires App Review.
        /// The **user_posts** permission allows your app to access the posts a person has made on their timeline, but not the comments on those posts.
        /// https://developers.facebook.com/docs/facebook-login/permissions/v2.0#reference-user_posts
        /// </summary>
        user_posts,

        /// <summary>
        ///Requires App Review.
        /// The user_videos permission allows your app to read a list of videos uploaded by a person.
        /// https://developers.facebook.com/docs/facebook-login/permissions/v2.0#reference-user_videos
        /// </summary>
        user_videos,

        /// <summary>
        /// Requires App Review.
        /// Grants an app permission to access a person's age range.
        /// https://developers.facebook.com/docs/facebook-login/permissions/v2.0#reference-user_age_range
        /// </summary>
        user_age_range,
    }
}
