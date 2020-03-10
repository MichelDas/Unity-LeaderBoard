using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserCRUD : MonoBehaviour
{
    string url = "http://localhost/LeaderBoard/Select.php";
    public string[] userData;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        WWW users = new WWW(url);
        yield return users;
        string userDataString = users.text;
        Debug.Log(userDataString);
        userData = userDataString.Split(';');
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
