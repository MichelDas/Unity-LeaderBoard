using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SimpleJSON;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ServerManager : MonoBehaviour
{
    public JSONNode logInData;

    public bool ServerLoggedIn = false;

    public List<string> FriendIds;
    public string[] friendsData;

    

    private static ServerManager instance;
    public static ServerManager Instance
    {
        get { return instance; }
    }
    void Awake()
    {
        instance = this;
        FriendIds = new List<string>();
    }

    public IEnumerator LogIn(string fbId, string name, string email, Texture myPic)
    {
        ServerLog("Logging.....");
        string logInString = "http://localhost/LeaderBoard/login.php";

        WWWForm form = new WWWForm();
        form.AddField("fbId", fbId );
        form.AddField("name", name);
        form.AddField("email", email);

        UnityWebRequest www = UnityWebRequest.Post(logInString, form);
        www.chunkedTransfer = false;
        yield return www.SendWebRequest();


        string userDataString = www.downloadHandler.text;
        Debug.Log(userDataString);

        if (www.error == null)
        {
            // you can place code here for handle a succesful post

        }
        else
        {
            // what to do on error
        }

    }

    public IEnumerator UpdateToSever(string fbId, int score)
    {
        ServerLog("Updating to Server .....");
        Debug.Log(fbId);
        Debug.Log(score);
        string updateString = "http://yourhostaddress.com/GameServices.php/GameServices.php?action=updateScore&fbId=" + fbId + "&gameId=" + Application.identifier + "&Score=" + score.ToString();
        WWW updateCall = new WWW(updateString);

        yield return updateCall;

        ServerLog("Progress Updated on Server");
        ServerLog(score.ToString() + " Has been posted to Server!");
    }

    public void ServerLog(string msg)
    {
        Debug.Log("<Server> " + msg);
    }

    public void SaveFriends(List<string> fdList)
    {
        FriendIds = new List<string>();
        FriendIds = fdList;
    }

    public void friendsFromSErver()
    {
        StartCoroutine("GetFriendsPlayingThisGameFromServer");
    }

    private IEnumerator GetFriendsPlayingThisGameFromServer()
    {
        ServerLog("Getting Friends Scores .....");


        //WWW users = new WWW(url);

        WWWForm form = new WWWForm();
        form.AddField("action", "login");
        string getScoreURL = "http://localhost/LeaderBoard/getScore.php";
        UnityWebRequest www = UnityWebRequest.Post(getScoreURL, form);
        www.chunkedTransfer = false;
        yield return www.SendWebRequest();
        string userDataString = www.downloadHandler.text;
        Debug.Log(userDataString);
        friendsData = userDataString.Split(';');

    }
}
