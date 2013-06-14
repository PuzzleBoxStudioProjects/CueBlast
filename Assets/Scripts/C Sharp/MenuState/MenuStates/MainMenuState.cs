using UnityEngine;
using System.Collections;

public class MainMenuState : GameState 
{
	public override void onGui()
	{
		float offsetX = MenuConstants.OFFSET_X;
		float offsetY = MenuConstants.OFFSET_Y;
		base.onGui();
		
		GUI.Box (GUIHelper.screenRect (offsetX,offsetY,.3f,.5f), "Main Menu");
		
		if(GUI.Button (GUIHelper.screenRect (offsetX+.05f,offsetY+.1f,.2f,.05f), "Start"))
		{
			m_gameStateManager.setActiveState( (int)MenuConstants.MenuState.MapSelect );
		}
		
		if(GUI.Button (GUIHelper.screenRect (offsetX+.05f,offsetY+.2f,.2f,.05f), "Options"))
		{
			m_gameStateManager.setActiveState( (int)MenuConstants.MenuState.Options );
		}		
		if(GUI.Button (GUIHelper.screenRect (offsetX+.05f,offsetY+.3f,.2f,.05f), "Credits"))
		{
			m_gameStateManager.setActiveState( (int)MenuConstants.MenuState.Credits );
		}
		

	}
}
