/*var spark : ParticleEmitter;

function OnControllerColliderHit(other : ControllerColliderHit)
{
	var dir = transform.TransformDirection(Vector3.forward);
	
	if (Physics.Raycast(transform.position, dir, 0))
	{
		if (other.collider.gameObject.tag == "Player")
		{
			Instantiate(spark, other.point, Quaternion.FromToRotation(Vector3.up, other.normal));
			Debug.Log("Spark", this);
		}
	}
}*/