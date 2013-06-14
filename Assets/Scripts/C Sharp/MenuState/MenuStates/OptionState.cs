using UnityEngine;
using System.Collections;

public class OptionState : GameState 
{
	private float m_musicVolume;
	
	public override void onGui()
	{
		float offsetX = MenuConstants.OFFSET_X;
		float offsetY = MenuConstants.OFFSET_Y;
		base.onGui();
		GUI.Box (GUIHelper.screenRect (offsetX,offsetY,.3f,.5f), "Options");
		GUI.Label  (GUIHelper.screenRect (offsetX+.05f,offsetY+.1f,.2f,.05f), "Audio Volume: " +  m_musicVolume  +"%!");
		m_musicVolume = GUI.HorizontalSlider (GUIHelper.screenRect (offsetX+.05f,offsetY+.15f,.2f,.05f),m_musicVolume,0.0f,100.0f);

		if( GUI.Button (GUIHelper.screenRect (offsetX+.05f,offsetY+.4f,.2f,.05f) ,"Back to Main Menu"))
		{
			m_gameStateManager.setActiveState( (int)MenuConstants.MenuState.Main );
		}

	}
}
