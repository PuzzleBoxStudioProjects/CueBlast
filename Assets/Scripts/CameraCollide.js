var target : Transform;

function Start()
{
	var player = (target);
	
	Physics.IgnoreCollision(player.collider, collider);
}