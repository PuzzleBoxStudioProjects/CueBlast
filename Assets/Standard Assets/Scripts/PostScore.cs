using UnityEngine; 
using System; 
using System.Collections; 


static public class PostScore { 

static string scores;
	
static private string secretKey="mySecretKey"; // Edit this value and make sure it's the same as the one stored on the server 

static string addScoreUrl; 
static string highscoreUrl;    

public static IEnumerator  postScore(string name, float score) 
   { 
       
      //This connects to a server side php script that will add the name and score to a MySQL DB. 
      // Supply it with a string representing the players name and the players score. 
      string hash = Utility.Md5Sum(name + score + secretKey); 
      string highscore_url = addScoreUrl + "?" + "name=" + WWW.EscapeURL(name) + "&score=" + score + "&hash=" + hash; 
      Debug.Log(addScoreUrl + "name=" + WWW.EscapeURL(name) + "&score=" + score + "&hash=" + hash); 
      // Post the URL to the site and create a download object to get the result. 
      WWW hs_post = new WWW(highscore_url); 
	  yield return hs_post;
	
	   
      while(!hs_post.isDone){;} // Wait untill download is done, insert custom loop here for dynamic wait screen       
      
		  if(hs_post.error != null) 
      { 
         Debug.Log("There was an error posting the high score: " + hs_post.error); 
      } 
   } 

   public static IEnumerator  postScore(string name, string score) 
   { 
       
      //This connects to a server side php script that will add the name and score to a MySQL DB. 
      // Supply it with a string representing the players name and the players score. 
      string hash = Utility.Md5Sum(name + score + secretKey); 
      string highscore_url = addScoreUrl + "?" + "name=" + WWW.EscapeURL(name) + "&score=" + score + "&hash=" + hash; 
      Debug.Log(addScoreUrl + "name=" + WWW.EscapeURL(name) + "&score=" + score + "&hash=" + hash); 
      // Post the URL to the site and create a download object to get the result. 
      WWW hs_post = new WWW(highscore_url); 
	  yield return hs_post;
	
	   
      while(!hs_post.isDone){;} // Wait untill download is done, insert custom loop here for dynamic wait screen       
      
		  if(hs_post.error != null) 
      { 
         Debug.Log("There was an error posting the high score: " + hs_post.error); 
      } 
   } 

  
   
   
// Get the scores from the MySQL DB to display in a GUIText. 
public static IEnumerator getScores() 
   { 
      //gameObject.guiText.text = "Loading Scores"; 
      WWW hs_get = new WWW(highscoreUrl); 
      // while(!hs_get.isDone){;}//Wait untill download is done, insert custom loop here for dynamic wait screen 
	  yield return hs_get;
    
      if(hs_get.error != null) 
      { 
         Debug.Log("There was an error getting the high score: " + hs_get.error); 
		 scores = hs_get.error;
      } 
      else 
      { 
         scores = hs_get.text as string; // this is a GUIText that will display the scores in game. 
		 Debug.Log(scores);
      } 
     
   } 
   
   public static string getScoreResults()
   {
	   return scores;
   }

       
public static void Init(string postURL, string displayURL, string key) 
   { 
      addScoreUrl = postURL; 
      highscoreUrl = displayURL; 
      if(key != null) 
      { 
         secretKey = key; 
      } 
       
   } 
} 


