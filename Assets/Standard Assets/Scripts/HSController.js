//var secretKey="sdfjjw23kk4"; // Edit this value and make sure it's the same as the one stored on the server
//var addScoreUrl="http://127.0.0.1/unity/addscore.php?";
//var highscoreUrl="http://127.0.0.1/unity/display.php";    

//function Start() {
//    postScore("test", 19.0);
//    getScores();
//}

//function postScore(name, score) {
//    //This connects to a server side php script that will add the name and score to a MySQL DB.
//    // Supply it with a string representing the players name and the players score.
//    var hash=md5functions.Md5Sum(name + score + secretKey); 
//    var highscore_url = addScoreUrl + "name=" + WWW.EscapeURL(name) + "&score=" + score + "&hash=" + hash;
//	
//    // Post the URL to the site and create a download object to get the result.
//    hs_post = WWW(highscore_url);
//    yield hs_post; // Wait until the download is done
//    if(hs_post.error) {
//        print("There was an error posting the high score: " + hs_post.error);
//    }
//}
// 
//// Get the scores from the MySQL DB to display in a GUIText.
//function getScores() {
//    gameObject.guiText.text = "Loading Scores..";
//    hs_get = WWW(highscoreUrl);
//    yield hs_get;
//    
//    if(hs_get.error) {
//	    gameObject.guiText.text = "There was an error getting the high score: " + hs_get.error; 
//        print("There was an error getting the high score: " + hs_get.error);
//    } else {
//        gameObject.guiText.text = hs_get.text; // this is a GUIText that will display the scores in game.
//    }


//}