using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIShower : MonoBehaviour
{
    public static UIShower instance;

    private void Awake()
    {
        instance = this;
    }

    [SerializeField] private Image profilePicture;
    [SerializeField] private Text profileName;

    public void SetUIElements(string profileName)
    {
        this.profileName.text = profileName;
    }

    public void SetUIProfilePicture(Texture profilepic)
    {
     //   if (profilepic != null)
       //     Debug.Log("profile picture should be shown");
        profilePicture.sprite = Sprite.Create(profilepic as Texture2D, new Rect(0, 0, 128, 128), new Vector2());

    }

}
