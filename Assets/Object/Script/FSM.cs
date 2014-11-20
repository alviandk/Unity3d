using UnityEngine;

public class FSM <T>  
{
	private T Owner;
	public FSMStat<T> CurrentState;
	private FSMStat<T> PreviousState;
	
	
	public void Awake()
	{
		CurrentState = null;
		PreviousState = null;
	}
	
	public void Initialize(T owner, FSMStat<T> InitialState) 
	{
		Owner = owner;
		ChangeState(InitialState);
	}
	
	public void  Update() 
	{
		if (CurrentState != null) CurrentState.Execute();
	}
	
	public void OnTriggerEnter(Collider o)
	{
		if (CurrentState != null) CurrentState.OnTriggerEnter(o);
	}
	
	public void OnTriggerStay(Collider o)
	{
		if (CurrentState != null) CurrentState.OnTriggerStay(o);
	}
	
	public void OnTriggerExit(Collider o)
	{
		if (CurrentState != null) CurrentState.OnTriggerExit(o);
	}
	
	public void ChangeState(FSMStat<T> NewState) 
	{
		PreviousState = CurrentState;
		if (PreviousState != null)
		{
			//Debug.Log(Owner + "EXITED STATE: " + PreviousState);
			PreviousState.Exit();
		}
		//Debug.Log(Owner + "ENTERED STATE: " + NewState);
		CurrentState = NewState;
		CurrentState.Enter(Owner);
	}
	
	public void  RevertToPreviousState() 
	{
		if (PreviousState != null)
			ChangeState(PreviousState);
	}
	
	public void OnCollisionEnter(Collision c)
	{
		if (CurrentState != null) CurrentState.OnCollisionEnter(c);
	}
	
	public void OnCollisionStay(Collision c)
	{
		if (CurrentState != null) CurrentState.OnCollisionStay(c);
	}
	
	public void OnCollisionExit(Collision c)
	{
		if (CurrentState != null) CurrentState.OnCollisionExit(c);
	}
}