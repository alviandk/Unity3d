﻿using UnityEngine;


/// <summary>
/// NoHandState is called when a UnityHand loses a reference to a Leap hand 
/// e.g. when a hand is no longer present in the Leap's field of view
/// </summary>
public class NoHand : State
{
	
	public NoHand() { }
	public NoHand(GameObj obj)
	{
		if (!obj)
			return;
		
		if (obj.isStatePersistent)
		{
			if (obj.dropOnLost)
				obj.Release(handController);
			else
				obj.gameObject.SetActive(false);
		}
		else
		{
			obj.Release(handController);
		}
		
	}
	
	
	public override void Enter(BaseTypeHnd o)
	{
		handController = o;
		handController.HideHand();
	}
	
	public override void Execute()
	{
		
	}
	
	public override void Exit()
	{
		handController.ShowHand();
		if (handController.activeObj)
			handController.activeObj.gameObject.SetActive(true);
		
	}
}