private var orientation : Vector3; 
private var offset : Vector3;

function Awake () { 
   orientation = transform.rotation.eulerAngles; 
   offset = transform.position - transform.parent.position; 
} 

function Update () { 
   //orientation.y = marble.rotation.eulerAngles.y; 
   transform.rotation.eulerAngles = orientation; 
   transform.position = transform.parent.position + offset; 
}