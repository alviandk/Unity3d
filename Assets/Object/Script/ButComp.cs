using UnityEngine;
using System.Collections;

public class ButComp : MonoBehaviour {

	RaycastHit hit;
	public GameObject text3D;
	public Light theLight;
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
				if (hit.collider.gameObject == text3D) {
					Application.LoadLevel(3);
				}
			}
		}
	}

	void OnMouseEnter(){
		/*GUIText text = text3D.GetComponent<TextMesh>;
		text.color =*/ 
		theLight.intensity = 8.0f;
	}

	void OnMouseExit(){
		theLight.intensity = 0.0f;
	}
}
