using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class PunchBag2 : MonoBehaviour {

	public int ScoreValue;
	private HandController handController;
	public AudioClip sound;

	void Start(){
		GameObject gameControllerObject = GameObject.FindWithTag ("HandControl");
		if (gameControllerObject != null) {
			handController = gameControllerObject.GetComponent <HandController>();
		}
	}

	public void OnCollisionEnter(Collision collision)
	{
		RigidHand leapObj = collision.gameObject.GetComponent<RigidHand>();
		
		/*if (leapObj)
		{
			Debug.Log(leapObj.maxVelocity.magnitude);
			rigidbody.AddForceAtPosition(leapObj.maxVelocity * 200, leapObj.transform.position);

		}*/
		audio.Play();
		ScoreManage2.scorre += ScoreValue;
		//sound.playOneShot ();
	}


	

}
