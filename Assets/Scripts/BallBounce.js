var bounceSound : AudioClip;

function OnCollisionEnter(hit : Collision)
{
	if (hit.gameObject.tag == "Player")
	{
		audio.PlayOneShot(bounceSound);
	}
}