using UnityEngine;
using System.Collections;
//using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class Menu : MonoBehaviour {

	//public static bool playB = true; //Android Play Services
	public AudioClip PopA;

	void Start ()
	{
		Social.localUser.Authenticate (success => {
			if (success) {
				Debug.Log ("Authentication successful");
				string userInfo = "Username: " + Social.localUser.userName;
				Debug.Log (userInfo);
			}
			else
				Debug.Log ("Authentication failed");
		});
		/*if (playB) 
		{
			PlayGamesPlatform.Activate (); //Activate Game Center
			// if user authenticate fails don't ask to authenticate again (until game is initilized again 
			// authenticate user:
			Social.localUser.Authenticate ((bool success) => {
			});
		}
		playB = false;*/
	}

	public void Achieve ()
	{
		Social.ShowAchievementsUI ();
	}
	public void Leader ()
	{
		Social.ShowLeaderboardUI ();
	}
	public void Play()
	{
		Application.LoadLevel(1);
	}
	public void Pop()
	{
		AudioSource.PlayClipAtPoint (PopA, new Vector3 (0, 0, 0));
	}
}
