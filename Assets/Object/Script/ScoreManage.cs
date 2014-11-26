using UnityEngine;
using System.Collections;

public class ScoreManage : MonoBehaviour {

	public static int score;
	public TextMesh text2;
	public TextMesh text3;
	public TextMesh text;
	

	// Use this for initialization
	void Start () {
	
	}

	void Awake (){
		text = GetComponent<TextMesh>();
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		text.text = "Score : " + score.ToString();
		if (score >= 10000) {
			StartCoroutine(wait());
		}

	}

	public IEnumerator wait() {
		text2.text = "Congratulation, You Achieve New Place";
		yield return new WaitForSeconds(3f); // waits 3 seconds
		text2.text = ""; // will make the update method pick up 
	}

}
