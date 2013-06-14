var pocketScore : ParticleEmitter;
var points : int = 10;
var scoreSound : AudioClip;

static var startPoints : int = 0;

function OnTriggerEnter (hit : Collider)
{
	if (hit.gameObject.tag == "OtherBalls")
	{
		Instantiate(pocketScore, transform.position, transform.rotation);
		startPoints += points;
		audio.PlayOneShot(scoreSound);
		GameMaster.canCount = true;
	}
}