using UnityEngine;
using System.Collections;

public class CreditState : GameState 
{
	public override void onGui()
	{
		float offsetX = MenuConstants.OFFSET_X;
		float offsetY = MenuConstants.OFFSET_Y;
		base.onGui();
		GUI.Box (GUIHelper.screenRect (offsetX,offsetY,.3f,.5f), "Credits");
		if( GUI.Button (GUIHelper.screenRect (offsetX+.05f,offsetY+.4f,.2f,.05f) ,"Back to Main Menu"))
		{
			m_gameStateManager.setActiveState( (int)MenuConstants.MenuState.Main );
		}
	}
}
