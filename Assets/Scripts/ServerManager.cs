using UnityEngine;
using System.Collections;
using SimpleJSON;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ServerManager : MonoBehaviour
{
    public JSONNode logInData;

    public bool ServerLoggedIn = false;

    private static ServerManager instance;
    public static ServerManager Instance
    {
        get { return instance; }
    }
    void Awake()
    {
        instance = this;
    }

    public IEnumerator LogIn(string fbId, string name, string email, Texture myPic)
    {
        ServerLog("Logging.....");
        string logInString = "http://localhost/LeaderBoard/GameServices.php";

        WWWForm form = new WWWForm();
        form.AddField("fbId", name );
        form.AddField("name", name);
        form.AddField("email", email);

        UnityWebRequest www = UnityWebRequest.Post(logInString, form);
        www.chunkedTransfer = false;
        yield return www.SendWebRequest();

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
}
