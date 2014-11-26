using UnityEngine;
using System.Collections;

public class ScoreManage1 : MonoBehaviour {

	public static int scoree;
	public TextMesh text;

	// Use this for initialization
	void Start () {
	
	}

	void Awake (){
		text = GetComponent<TextMesh>();
		scoree = 0;
	}
	
	// Update is called once per frame
	void Update () {
		text.text = "Score : " + scoree.ToString();

	}

	/*public IEnumerator wait() {
		text2.text = "Congratulation, You Achieve New Place";
		yield return new WaitForSeconds(3f); // waits 3 seconds
		text2.text = ""; // will make the update method pick up 
	}*/
}
