var sparks : GameObject;
var impactSound : AudioClip;
var impactSoundPlayer : AudioClip;


private var win : boolean = false;

function OnCollisionEnter(collision : Collision)
{
	//contact with the value collision dot contacts in an array.
	var contact = collision.contacts[0];
	//rot representing rotation.  Quaternion dot FromToRotation needs a from direction
	//and a to direction.  Vector3.up short hand for 1 on the Y and contact dot normal
	//the normal of the contact point.
	var rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
	//pos representing position contact dot point where exactly the object was hit.
	var pos = contact.point;
	
	if(collision.gameObject.tag == "Player")
	{
		if (collision.relativeVelocity.magnitude > 20)
		{
			//Then we just create a spark at those points.
			//and play a sound.
			Instantiate(sparks, pos, rot);
			audio.PlayOneShot(impactSoundPlayer);
		}
	}
	
	if (collision.gameObject.tag == "OtherBalls")
	{
		if (collision.relativeVelocity.magnitude > 10)
		{
			audio.PlayOneShot(impactSound);
		}
	}
}

function OnTriggerEnter(other : Collider)
{
	if (other.gameObject.tag == "Pocket")
	{
		Destroy(this.gameObject);
	}
}