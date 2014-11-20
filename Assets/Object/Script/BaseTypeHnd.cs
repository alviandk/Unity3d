using UnityEngine;
using System.Collections;


[System.Serializable]
public class BaseTypeHnd : MonoBehaviour
{
	[HideInInspector]
	public UniHand unityHand;
	
	[HideInInspector]
	public FSM<BaseTypeHnd> stateController;
	
	[HideInInspector]
	public GameObj activeObj; // activeObj is acted on by states only 
	[HideInInspector]
	public bool canBeVisible = true;
	
	protected virtual void Awake() 
	{
		stateController = new FSM<BaseTypeHnd>();
	}
	
	protected virtual void OnTriggerEnter(Collider c)
	{
		if (unityHand.hand == null)
			return;
		
		stateController.OnTriggerEnter(c);
	}
	
	protected virtual void OnTriggerStay(Collider c)
	{
		if (unityHand.hand == null)
			return;
		stateController.OnTriggerStay(c);
	}
	
	protected virtual void OnTriggerExit(Collider c)
	{
		if (unityHand.hand == null)
			return;
		stateController.OnTriggerExit(c);
	}
	
	protected virtual void OnCollisionEnter(Collision c)
	{
		if (unityHand.hand == null)
			return;
		stateController.OnCollisionEnter(c);
	}
	
	protected virtual void OnCollisionStay(Collision c)
	{
		if (unityHand.hand == null)
			return;
		stateController.OnCollisionStay(c);
	}
	
	protected virtual void OnCollisionExit(Collision c)
	{
		if (unityHand.hand == null)
			return;
		stateController.OnCollisionExit(c);
	}
	
	protected virtual void NoFingers()
	{
		
	}
	
	public virtual void UpdateHandType()
	{
		transform.position = unityHand.transform.position;
		transform.rotation = unityHand.transform.rotation;
	}
	
	public virtual void ChangeState(State ls)
	{
		if(ls != null)
			stateController.ChangeState(ls);
	}
	
	/// <summary>
	/// Updates the hand state, this must be called explicitly for each Hand Type
	/// State may depend on model updating order
	/// </summary>
	protected virtual void UpdateState()
	{
		stateController.Update();
	}
	
	
	
	public virtual void SetOwner(UniHand h)
	{
		unityHand = h;
	}
	
	public virtual void HandFound()
	{
		if (activeObj)
		{
			activeObj.owner = null; // Clear reference
			stateController.ChangeState(activeObj.Activate(this));
		}
		else
			stateController.ChangeState(new GodHand());
	}
	
	public virtual void HandLost()
	{
		stateController.ChangeState(new NoHand(activeObj));
		//override in inherited classes
	}
	
	/// <summary>
	/// Will hide the hand, override to specify how hand is hidden
	/// </summary>
	public virtual void HideHand()
	{
		canBeVisible = false;
	}
	
	/// <summary>
	/// Will make hand visible, override to specify how hand is hidden
	/// </summary>
	public virtual void ShowHand()
	{
		canBeVisible = true;
	}
	
	public virtual void SetActiveObject(GameObj obj)
	{
		if (activeObj != null)
			return;
		
		activeObj = obj;
		activeObj.owner = this;
	}
	
	
	
}
