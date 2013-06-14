using UnityEngine;
using System.Collections;

public class DontGoThroughThings : MonoBehaviour 
{
	
	public LayerMask layerMask;
	public float skinWidth = 0.1f;
    private float minimumExtent; 
    private float partialExtent; 
    private float sqrMinimumExtent ; 
    private Vector3  previousPosition ; 
    private Rigidbody myRigidbody; 
	

   void  Awake() { 
   myRigidbody = rigidbody; 
   previousPosition = myRigidbody.position; 
   minimumExtent = Mathf.Min(Mathf.Min(collider.bounds.extents.x, collider.bounds.extents.y), collider.bounds.extents.z); 
   partialExtent = minimumExtent*(1.0f - skinWidth); 
   sqrMinimumExtent = minimumExtent*minimumExtent; 
} 

 void FixedUpdate() { 
   
   if ((previousPosition - myRigidbody.position).sqrMagnitude > sqrMinimumExtent) { 
      Vector3 movementThisStep  = myRigidbody.position - previousPosition; 
      float movementMagnitude = movementThisStep.magnitude; 
      RaycastHit hitInfo = new RaycastHit();  
	   
      
      if (Physics.Raycast(previousPosition, movementThisStep, out  hitInfo, movementMagnitude, layerMask.value)) 
         myRigidbody.position = hitInfo.point - (movementThisStep/movementMagnitude)*partialExtent; 
   } 
   previousPosition = myRigidbody.position; 


}
	
	
}