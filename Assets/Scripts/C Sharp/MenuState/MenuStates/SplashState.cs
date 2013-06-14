using UnityEngine;
using System.Collections;

public class SplashState : GameState 
{
	public float ttl = 2.0f;
	public AudioSource sound;
	
	public override void enterState()
	{
		if(sound!=null)
		{
			sound.Play();
		}
	}
	public override void onGui()
	{
		float dt = Time.deltaTime;
		base.onGui();
		ttl -= dt;
		if(ttl < 0f)
		{
			m_gameStateManager.setActiveState( (int)MenuConstants.MenuState.Main );
		}
	}
}
