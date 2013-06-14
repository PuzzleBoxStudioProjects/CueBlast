var aTexture : Texture;

function OnGUI() {
if(!aTexture){
Debug.LogError("Assign a Texture in the inspector.");
return;
}
GUI.DrawTexture(Rect(10,10,60,60), aTexture, ScaleMode.ScaleToFit, true, 10.0f);
}