using UnityEngine;
using UnityEngine.UI;
using SA.Facebook;

public class SA_FB_UseExample : MonoBehaviour
{
    [Header("User Info")]
    [SerializeField]
    Text m_UserName = null;
    [SerializeField]
    Text m_UserMail = null;
    [SerializeField]
    RawImage m_UserAvatar = null;

    [Header("Buttons")]
    [SerializeField]
    Button m_Connect = null;

    static FbUser s_CurrentUser;

    //Make sure that this method will be called only once per app session
    void Start()
    {
        //This can be done via editor menu
        FbSettings.SetAppId("1605471223039154");

        //This can also be done via the settings
        //We need email scope to be able to get user email
        if (!FbSettings.Scopes.Contains("email")) FbSettings.Scopes.Add("email");

        if (!FbSettings.Scopes.Contains("user_gender")) FbSettings.Scopes.Add("user_gender");

        if (!FbSettings.Scopes.Contains("user_location")) FbSettings.Scopes.Add("user_location");

        if (!FbSettings.Scopes.Contains("user_age_range")) FbSettings.Scopes.Add("user_age_range");

        m_Connect.interactable = false;
        FB.Init(() =>
        {
            Debug.Log("Init Completed");
            m_Connect.interactable = true;
            UpdateAccountUI();
        });

        //let's define button action based on user state
        m_Connect.onClick.AddListener(() =>
        {
            if (!FB.IsLoggedIn)
                SignInFlow();
            else
                SignOutFlow();
        });
    }

    void SignInFlow()
    {
        FB.Login((result) =>
        {
            if (result.IsSucceeded)
            {
                Debug.Log("Login Succeeded");
                UpdateAccountUI();
            }
            else
            {
                Debug.Log("Failed to login: " + result.Error);
            }
        });
    }

    void SignOutFlow()
    {
        FB.LogOut();
        UpdateAccountUI();
    }

    void UpdateAccountUI()
    {
        if (FB.IsLoggedIn)
        {
            if (s_CurrentUser != null)
                SetUserInfoUI(s_CurrentUser);
            else
                FB.GetLoggedInUserInfo((result) =>
                {
                    if (result.IsSucceeded)
                    {
                        SetUserInfoUI(result.User);

                        Debug.Log("result.User.Id: " + result.User.Id);
                        Debug.Log("result.User.Name: " + result.User.Name);
                        Debug.Log("result.User.FirstName: " + result.User.FirstName);
                        Debug.Log("result.User.LastName: " + result.User.LastName);

                        Debug.Log("result.User.Location: " + result.User.Location);
                        Debug.Log("result.User.PictureUrl: " + result.User.PictureUrl);
                        Debug.Log("result.User.ProfileUrl: " + result.User.ProfileUrl);
                        Debug.Log("result.User.AgeRange: " + result.User.AgeRange);
                        Debug.Log("result.User.Birthday: " + result.User.Birthday);
                        Debug.Log("result.User.Gender: " + result.User.Gender);
                        Debug.Log("result.User.AgeRange: " + result.User.AgeRange);
                        Debug.Log("result.RawResult: " + result.RawResult);

                        s_CurrentUser = result.User;
                    }
                    else
                    {
                        Debug.Log("Failed to load user Info: " + result.Error);
                    }
                });
        }
        else
        {
            m_Connect.GetComponentInChildren<Text>().text = "Sing in";
            m_UserName.text = "Signed out";
            m_UserMail.text = "Signed out";

            m_UserAvatar.texture = null;
        }
    }

    void SetUserInfoUI(FbUser user)
    {
        m_Connect.GetComponentInChildren<Text>().text = "Sing out";
        m_UserName.text = user.Name;
        m_UserMail.text = user.Email;

        user.GetProfileImage(FbProfileImageSize.Large, (texture) =>
        {
            m_UserAvatar.texture = texture;
        });
    }
}
