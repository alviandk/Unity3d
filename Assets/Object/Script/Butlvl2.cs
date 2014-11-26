using UnityEngine;
using System.Collections;

public class Butlvl2 : MonoBehaviour {

	RaycastHit hit;
	public GameObject Obj;
	public Texture textur2;
	public Texture textur1;
	private ScoreManage scorr;
	// Use this for initialization
	void Start () {
		scorr = gameObject.GetComponent<ScoreManage>();
		if(ScoreManage.score<=10000){
			Obj.renderer.material.mainTexture = textur1;
		}
		else{
			Obj.renderer.material.mainTexture = textur2;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(0))
		{
			Ray ray = Camera.mainCamera.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit))
			{
				if (hit.collider.gameObject == Obj) {
					if(Obj.renderer.material.mainTexture == textur2){
					Application.LoadLevel(4);
					}
				}
			}
		}
	}

	void OnMouseEnter(){

	}
	
	void OnMouseExit(){

	}
}
