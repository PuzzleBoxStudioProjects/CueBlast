var spawnPoint : Transform;
var cam : Camera;

function OnTriggerEnter (hit : Collider)
{
	if (hit.gameObject.tag == "Pocket")
	{
		Instantiate(cam, spawnPoint.position, spawnPoint.rotation);
		Destroy(this.gameObject);
	}
}