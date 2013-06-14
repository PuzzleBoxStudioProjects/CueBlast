var bounceForce : float = 10;

function OnCollisionEnter(hit : Collision)
{
	hit.rigidbody.AddForce(bounceForce * transform.forward, ForceMode.VelocityChange);
}