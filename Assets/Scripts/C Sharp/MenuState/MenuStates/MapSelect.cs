using UnityEngine;
using System.Collections;

public class MapSelect : GameState 
{
	public int nomOfRows = 2;
	public int nomOfCols  = 5;
	float offsetX = 0.125f;
	float offsetY =  0.3f;
	private int m_levelIndex = -1;

	
	
	public override void onGui()
	{
		base.onGui();
		
		
		GUI.Box (GUIHelper.screenRect (0,0,1,1), "Map Select");
		drawLevelIcons();
		
		if( GUI.Button (GUIHelper.screenRect (offsetX,offsetY+.4f,.2f,.05f), "Back"))
		{
			m_gameStateManager.setActiveState( (int)MenuConstants.MenuState.Main );
		}
		if(GUI.Button (GUIHelper.screenRect (offsetX+.6f,offsetY+.4f,.2f,.05f), "Start"))
		{
			if(m_levelIndex!=-1)
			{
				Application.LoadLevel( m_levelIndex + 1);
			}
		}
	}
	public void drawLevelIcons()
	{
		//offsetY = 0.125f;
		int n = 0;
		for(int j=0; j<nomOfRows; j++)
		{
			for(int i=0; i<nomOfCols; i++)
			{
				int index = n + 1;
				string str = "LVL" + index;
				if(n==m_levelIndex)
				{
					str += "\n+";
				}
				if(GUI.Button (GUIHelper.screenRect (offsetX+ .05f + 0.15f*i,offsetY +.145f *j,.1f,.125f), str))
				{
					m_levelIndex = n;
				}
				n++;
			}
		}		
	}

}
