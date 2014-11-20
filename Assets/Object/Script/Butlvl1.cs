using UnityEngine;
using System.Collections;

public class Butlvl1 : MonoBehaviour {

	RaycastHit hit;
	public GameObject Obj;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(0))
		{
			Ray ray = Camera.mainCamera.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit))
			{
				if (hit.collider.gameObject == Obj) {
					Application.LoadLevel(2);
				}
			}
		}
	}

	void OnMouseEnter(){

	}
	
	void OnMouseExit(){

	}
}
