using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour 
{
	#region Variables
	public MenuConstants.MenuState defaultState;
	private GameStateManager m_gameStateManager = new GameStateManager();
	#endregion
	
	#region void Start()
	public void Start()
	{
		GameState[] states = GetComponents<GameState>();
		foreach (GameState state in states)
		{
			m_gameStateManager.addState( (int )state.id,state );
		}
		m_gameStateManager.finish();
		m_gameStateManager.setActiveState( (int)defaultState);
	}
	#endregion
	
	#region void onGui()
	public void OnGUI()
	{
		m_gameStateManager.onGui();
	}
	#endregion
}
