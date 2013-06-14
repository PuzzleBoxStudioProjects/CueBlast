
function OnTriggerEnter(other : Collider)
{
	if (other.gameObject.tag == "Floor")
	{
		rigidbody.isKinematic = true;
		yield WaitForSeconds(1.5);
		//Temporary position.
		transform.position = Vector3(143, -57, -210);
		rigidbody.isKinematic = false;
	}
}