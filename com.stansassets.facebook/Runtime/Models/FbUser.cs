using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using StansAssets.Foundation;
using UnityEngine.Assertions;

namespace SA.Facebook
{
    /// <summary>
    /// Represents a Facebook user.
    /// Contains parsed user fields from a Facebook API response,
    /// and additional methods to retrieve mode data based on current model state
    /// like for example generate user avatar url, etc
    /// </summary>
    public class FbUser
    {
        /// <summary>
        /// The ID of this person's user account. This ID is unique to each app and cannot be used across different apps.
        /// </summary>
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// The person's birthday.
        /// </summary>
        public DateTime Birthday { get; set; }

        /// <summary>
        /// Used for test accounts only. Name for this account
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The person's first name.
        /// </summary>
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// The person's last name.
        /// </summary>
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// A link to the person's Timeline.
        /// The link will only resolve if the person clicking the link is logged into Facebook and is a friend of the person whose profile is being viewed.
        /// </summary>
        public string ProfileUrl { get; set; } = string.Empty;

        /// <summary>
        /// The User's primary email address listed on their profile.
        /// This field value is <see cref="string.Empty"/> if no valid email address is available.
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// The person's current location as entered by them on their profile. This field requires the `user_location` permission.
        /// </summary>
        public string Location { get; set; } = string.Empty;

        /// <summary>
        /// The gender selected by this person, <see cref="FbGender.Male"/> or <see cref="FbGender.Female"/>.
        /// If the gender is set to a custom value, this value will be based off of the preferred pronoun;
        /// it will be omitted if the preferred pronoun is neutral.
        /// Use <see cref="RawGenderString"/> if you need more details.
        /// </summary>
        public FbGender Gender { get; set; } = FbGender.Male;

        /// <summary>
        /// Raw gender string value.
        /// </summary>
        public string RawGenderString { get; set; } = string.Empty;

        /// <summary>
        /// The age segment for this person expressed as a minimum and maximum age. For example, more than 18, less than 21.
        /// </summary>
        public string AgeRange { get; set; } = string.Empty;

        /// <summary>
        /// The profile picture URL of the Messenger user. The URL will expire.
        /// </summary>
        public string PictureUrl { get; set; } = string.Empty;

        readonly Dictionary<FbProfileImageSize, string> m_PicturesUrls = new Dictionary<FbProfileImageSize, string>();

        internal FbUser(IDictionary json)
        {
            ParseData(json);
        }

        /// <summary>
        /// Generates user profile image URL
        /// </summary>
        /// <param name="size">Requested profile image size.</param>
        /// <param name="callback">Request callback.</param>
        public void GetProfileUrl(FbProfileImageSize size, Action<string> callback)
        {
            if (m_PicturesUrls.ContainsKey(size))
            {
                callback.Invoke(m_PicturesUrls[size]);
                return;
            }

            FB.FbGraphApi.ResolveProfileImageUrl(Id, size, (url) =>
            {
                m_PicturesUrls.Add(size, url);
                callback.Invoke(url);
            });
        }

        /// <summary>
        /// Download user profile image of a given size
        /// </summary>
        /// <param name="size">Requested profile image size</param>
        /// <param name="callback">Callback with user Texture2D profile image</param>
        public void GetProfileImage(FbProfileImageSize size, Action<Texture2D> callback)
        {
            GetProfileUrl(size, url => { CachedWebRequest.GetTexture2D(url, callback); });
        }

        void ParseData(IDictionary json)
        {
            if (json.Contains("id")) Id = Convert.ToString(json["id"]);

            if (json.Contains("birthday"))
            {
                var birthday = string.Empty;
                try
                {
                    birthday = Convert.ToString(json["birthday"]);
                    Birthday = DateTime.Parse(birthday);
                }
                catch (Exception ex)
                {
                    Debug.LogWarning("Failed to Parse birthday:" + birthday + " with error:" + ex.Message);
                }
            }

            if (json.Contains("name")) Name = Convert.ToString(json["name"]);
            if (json.Contains("first_name")) FirstName = Convert.ToString(json["first_name"]);
            if (json.Contains("last_name")) LastName = Convert.ToString(json["last_name"]);
            if (json.Contains("link")) ProfileUrl = Convert.ToString(json["link"]);
            if (json.Contains("email")) Email = Convert.ToString(json["email"]);

            if (json.Contains("location"))
            {
                if (json["location"] is IDictionary loc) Location = Convert.ToString(loc["name"]);
            }

            if (json.Contains("gender"))
            {
                var g = Convert.ToString(json["gender"]);
                RawGenderString = g;
                if (g.Equals("male"))
                    Gender = FbGender.Male;
                else if (g.Equals("female"))
                    Gender = FbGender.Female;
                else
                    Gender = FbGender.Custom;
            }

            if (json.Contains("age_range"))
            {
                var age = json["age_range"] as IDictionary;
                Assert.IsNotNull(age);
                AgeRange = age.Contains("min") ? age["min"].ToString() : "0";
                AgeRange += "-";
                AgeRange += age.Contains("max") ? age["max"].ToString() : "1000";
            }

            if (json.Contains("picture"))
                if (json["picture"] is IDictionary picDict && picDict.Contains("data"))
                    if (picDict["data"] is IDictionary data && data.Contains("url"))
                        PictureUrl = Convert.ToString(data["url"]);
        }
    }
}
