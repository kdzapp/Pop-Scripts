using UnityEngine;
using UnityEngine.Advertisements;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class GameController : MonoBehaviour {

	public Vector3 spawnVal;
	public float rand;
	public float randx;
	public static bool birdR = false;
	public int waveCount;
	public float startWait;
	public float waveWait;
	public int countR = 1;
	public static int adCount;
	
	void Start ()
	{
		if(Advertisement.isSupported) //Advertisements
		{
			Advertisement.allowPrecache = true;
			Advertisement.Initialize("30182", false);
		}
		PopBalloon.gameOn = false;
		if(PlayerPrefs.GetInt("ad") > 4) // Show Ad after 5 games
		{
			adCount = 0;
			Advertisement.Show(null, new ShowOptions
			{
				pause = true
			});
		}
		PlayerPrefs.SetInt("ad", adCount); //Ad count*/
		waitStart();
		StartCoroutine (spawnBirds());
	}
	
	void waitStart()
	{
		if(countR == 0)
		{
			Time.timeScale = 0;
			countR++;
		}
		if(PopBalloon.gameOn == false)
		{
			countR = 0;
		}
	}
	
	IEnumerator spawnBirds () //Bird Spawning
	{
			yield return new WaitForSeconds (startWait);
			for(int i = 0; i < waveCount; i++)
			{
				if(PopBalloon.gameOn == true)
				{
					randx = Random.Range(0f,2f);
					rand = Random.Range(-4.5f, 4.5f);
					if(randx < 1f) // Birds Coming from Left
					{
						Vector3 spawnPos = new Vector3 (-4.5f, rand, spawnVal.z);
						if(Scorer.score < 1990)
						{
							Quaternion spawnRot = Quaternion.identity;
							Instantiate(Resources.Load("BirdSequence") as GameObject, spawnPos, spawnRot);
						}
						else
						{
							Quaternion spawnRot = Quaternion.identity;
							Instantiate(Resources.Load("Astroid") as GameObject, spawnPos, spawnRot);
						}
						birdR = false;
					}
					else //Birds Coming from Right
					{
						Vector3 spawnPos = new Vector3 (4.5f, rand, spawnVal.z);
						if(Scorer.score < 1990)
						{
							var rotation = Quaternion.identity;
							rotation.eulerAngles = new Vector3 (0,180,0);
							Quaternion spawnRot = rotation;
							Instantiate(Resources.Load("BirdSequenceR") as GameObject, spawnPos, spawnRot);
						}
						else
						{
							Quaternion spawnRot = Quaternion.identity;
							Instantiate(Resources.Load("AstroidR") as GameObject, spawnPos, spawnRot);
						}
						birdR = true;
					}
					yield return new WaitForSeconds (waveWait);
				}
			}
	}
}