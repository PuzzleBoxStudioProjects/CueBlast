using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour 
{
	protected GameStateManager m_gameStateManager;
	public MenuConstants.MenuState id;
	public Texture2D backgroundTex;
	
	public void setManager(GameStateManager manager)
	{
		m_gameStateManager = manager;
	}
	public virtual void exitState()
	{
	}
	public virtual void enterState()
	{
	}
	
	#region virtual void render
	public virtual void onGui()
	{
		if(backgroundTex!=null)
		{
			GUI.DrawTexture  (GUIHelper.screenRect(0,0,1.0f,1), backgroundTex);		
		}
	}
	#endregion
}
