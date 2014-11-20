/******************************************************************************\
* Copyright (C) Leap Motion, Inc. 2011-2014.                                   *
* Leap Motion proprietary. Licensed under Apache 2.0                           *
* Available at http://www.apache.org/licenses/LICENSE-2.0.html                 *
\******************************************************************************/

using UnityEngine;
using System.Collections;
using Leap;

// The model for our rigid hand made out of various polyhedra.
public class RigidHand : SkeletalHand {

  public float filtering = 0.5f;

	[HideInInspector]
	public Vector3 maxVelocity;
	
	[HideInInspector]
	public BaseTypeHnd owner;
	
	private Vector3 prevPos;
	//private Transform prevTransform;
	private Vector3 highestVel;
	
	private float maxVelTime = 0.2f;
	private float velTime;

  void Start() {
    palm.rigidbody.maxAngularVelocity = Mathf.Infinity;
    Leap.Utils.IgnoreCollisions(gameObject, gameObject);
  }

  public override void InitHand() {
    base.InitHand();
  }

  public override void UpdateHand() {
  

    if (palm != null) {
      // Set palm velocity.
      Vector3 target_position = GetPalmCenter();
      palm.rigidbody.velocity = (target_position - palm.transform.position) *
                                (1 - filtering) / Time.deltaTime;

      // Set palm angular velocity.
      Quaternion target_rotation = GetPalmRotation();
      Quaternion delta_rotation = target_rotation *
                                  Quaternion.Inverse(palm.transform.rotation);
      float angle = 0.0f;
      Vector3 axis = Vector3.zero;
      delta_rotation.ToAngleAxis(out angle, out axis);

      if (angle >= 180) {
        angle = 360 - angle;
        axis = -axis;
      }
      if (angle != 0) {
        float delta_radians = (1 - filtering) * angle * Mathf.Deg2Rad;
        palm.rigidbody.angularVelocity = delta_radians * axis / Time.deltaTime;
      }
    }
  }
	private void UpdatePunchingVelocity()
	{
		//prevTransform = transform;
		maxVelocity = highestVel;
		
		Vector3 dir = owner.transform.position - prevPos;
		dir = dir.normalized;
		dir = dir * (Vector3.Distance(owner.transform.position, prevPos) * owner.unityHand.settings.throwingStrength);
		
		// Keep track of highestVelocity, reset if maxVel exists for too long
		VelocityCheck(dir);
		
		prevPos = owner.transform.position;
		velTime += Time.deltaTime;
	}

	private void VelocityCheck(Vector3 dir)
	{
		float maxVelocitySpeed = owner.unityHand.settings.maxThrowingVelocity;
		if (dir.magnitude > highestVel.magnitude)
		{
			if (dir.magnitude > maxVelocitySpeed)
			{
				// Vector limited to max velocity
				dir.Normalize();
				dir = dir * maxVelocitySpeed;
			}
			
			highestVel = dir;
			velTime = 0;
		}
		else if (velTime > maxVelTime)
		{
			highestVel = dir;
			velTime = 0;
		}
	}
}
