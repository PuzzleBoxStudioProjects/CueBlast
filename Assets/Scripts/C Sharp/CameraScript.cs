using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {
	private Vector3 m_offset;
	private Camera m_camera;
	private Quaternion m_orientation;
	
	private Vector3 cameraPos;
	private Vector3 targetPos;
	
	public Transform target;
	
	public Shader oldShader;
	public GameObject lastBlockingWall;
	public bool useRotation = false;
	
	private Shader[] m_shaders;
	private Color[] 	m_colors;
	private Renderer[] m_renderers;
	private int nMat = 0;
	private bool cMaterial = false;
	
	void Start () 
	{
		GameObject cameraObject = GameObject.FindWithTag("MainCamera");
		if(cameraObject!=null)
		{
			m_camera = cameraObject.camera;
			targetPos = target.position;
		}
			
	}
	
	public void setOffset(Vector3 offset)
	{
		m_offset = offset;
	}
	public void setOrientation(Quaternion orientation)
	{
		m_orientation = orientation;
	}
	
	void handleRaycast()
	{
		Vector3 CameraPos = m_camera.transform.position;
		targetPos = target.position;
		
		
		Vector3 dir = (CameraPos-targetPos);
		float dirLen =  dir.magnitude; 
		dir.Normalize();
		RaycastHit[] hitInfo;
		
		hitInfo = Physics.RaycastAll (targetPos, dir,dirLen);
		
		   if(cMaterial == true)
		   {
			if(m_renderers!=null) 
			{
				for (int i=0;i<m_renderers.Length;i++)
				{
					if(m_renderers!=null) 
					{
					for (int j=0;j<m_renderers[i].materials.Length;j++)
			        {	
						m_renderers[i].materials[j].shader = m_shaders[i];
					    m_renderers[i].materials[j].color = m_colors[i];
						
					}
				   }
				}
			}
			cMaterial = false;
		   }
			
			if(hitInfo.Length > 1)
			{
			m_shaders = new Shader[hitInfo.Length];
			m_colors = new Color[hitInfo.Length];
			m_renderers = new Renderer[hitInfo.Length];

			for (int i=0;i<hitInfo.Length;i++)
			{
			  Renderer r = null;
				
			  if(hitInfo!=null)
			  {
				r = hitInfo[i].collider.renderer;
				 if(r!=null)
                nMat = 	r.materials.Length;	
			   }	
			   
				if(r!=null)
				{
					m_shaders[i] = r.material.shader;
					m_colors[i] = r.material.color;
					m_renderers[i] = r;
					
					if(hitInfo[i].collider.name != "Marble")
					{
					
					if(hitInfo[i].collider.name != "DeathTrigger")
					{
					for (int j=0;j<nMat;j++)
			        {	
					r.materials[j].shader = Shader.Find("Transparent/Diffuse");
					r.materials[j].color = new Color(1,1,1,.3f);
					}
				   }
					}
				}
			}
			
			cMaterial = true;
		}
		
		
	}
		
		

	public void updateCamera () 
	{
		
	}
	
		void FixedUpdate () 
	{
			handleRaycast();
	}

}
