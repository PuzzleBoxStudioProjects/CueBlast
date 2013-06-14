using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameStateManager 
{
	private Dictionary<int,GameState> m_states = new Dictionary<int,GameState>();
	private GameState m_activeState;
	
	//add a gamestate
	public void addState( int id,
									GameState state)
	{
		m_states[ id ] = state;
	}
	public void finish()
	{
		foreach(KeyValuePair<int,GameState> entry in m_states)
		{
			entry.Value.setManager( this );
		}
	
	}
	//set the active state
	public void setActiveState(int id)
	{
		if(m_states.ContainsKey( id ))
		{
			if(m_activeState != m_states[ id ])
			{
				if(m_activeState!=null)
				{
					m_activeState.exitState();
				}
				if(m_states[ id ]!=null)
				{
					m_states[ id ].enterState();
				}
				
			}
			
			m_activeState  = m_states[ id ];
		}
	}
	
	public void onGui()
	{
		if(m_activeState!=null)
		{
			m_activeState.onGui();
		}
	}
}
