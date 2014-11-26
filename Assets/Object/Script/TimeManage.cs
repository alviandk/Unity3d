using UnityEngine;
using System.Collections;

public class TimeManage : MonoBehaviour {
	
	public TextMesh waktu;
	public TextMesh lose;

	public float timer = 60.0f;

	// Use this for initialization
	void Start () {
	
	}

	void Awake (){
		waktu = GetComponent<TextMesh>();
	}
	
	// Update is called once per frame
	void Update () {
		waktu.text = "Time : " + timer.ToString ();//
		timer -= Time.deltaTime;//
		if (timer <= 0){  //
			timer=0;  //
		} //
		if (ScoreManage.score <= 10000 && timer <= 0) {
			StartCoroutine(info());

		}
	}

	public IEnumerator info() {
		lose.text = "You are a Loser! Go Home!";
		yield return new WaitForSeconds(3f); // waits 3 seconds
		lose.text = ""; // will make the update method pick up 
	}

}
