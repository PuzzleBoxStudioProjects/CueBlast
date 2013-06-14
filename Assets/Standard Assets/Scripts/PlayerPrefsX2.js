
static function SetFloatArrayPrefs (key : String, floatArray : float[]) : boolean {
       
    try {
	
	 for (i = 0; i < floatArray.Length-1; i++) 
		{
		PlayerPrefs.SetFloat(key + "_" + i.ToString(), floatArray[i]);
		}
      
	 }
    catch (err) {
        return false;
    }
    return true;
}



static function SetStringArrayPrefs (key : String, stringArray : String[]) : boolean {
    try {
	
	for (i = 0; i < stringArray.Length-1; i++) 
		{
		PlayerPrefs.SetString(key + "_" + i.ToString(), stringArray[i]);
		}
		
    }
    catch (err) {
        return false;
    }
    return true;
}



static function GetFloatArrayPrefs (key : String, defaultSize : int) : float[] {
		
		var floatArray = new float[defaultSize];
        for (i = 0; i < defaultSize; i++) {
            floatArray[i] = PlayerPrefs.GetFloat(key + "_" + i.ToString());
        }
        return floatArray;
    }
	
	
static function GetStringArrayPrefs (key : String, defaultSize : int) : String[] {
   
        var stringArray = new String[defaultSize];
        for (i = 0; i < defaultSize; i++) {
            stringArray[i] = PlayerPrefs.GetString(key + "_" + i.ToString());
        }
        return stringArray;
    
}


