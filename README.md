+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+
|  |        |                 |  |     |        |
+  +  +  +  +  +--+--+--+--+--+  +  +  +  +  +--+
|  |  |  |  |  |           |        |     |     |
+  +  +  +--+  +  +--+  +--+  +--+--+--+--+--+  +
|  |  |  |     |  |  |  |     |     |        |  |
+  +  +  +  +--+  +  +  +  +--+  +  +  +--+  +  +
|     |     |     |     |  |     |  |     |  |  |
+  +--+--+--+  +--+--+--+  +--+--+  +--+  +  +  +
|          AMAZE                    |     |     |
+  +--+--+--+--+--+--+--+--+  +--+--+  +--+--+  +
|                       |     |        |         \
+--+--+--+--+--+--+--+  +--+--+  +--+--+--+--+--+
|  o                             |        |     |
+ /|\ +--+--+  +  +--+--+--+--+--+  +--+--+--+  +
| /\  |        |                                |
+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+
        
                                                                                                                      
Academic Project - Unity based game that make use of AES encryption

This repository contains a game which I wrote on third year of my IT studies on Uniwersytet of Kazimierz Wielki in Bygdoszcz.
The subject of the "Security Of The Information System" class was to implement an application that will use one of encryption types.
I figured out that the presentation would be more interesting, if I would implement a game instead of another desktop program to present in front of my class. At this time I was really keen to understand the game creation process so I started learning Unity, which I eventually used to create this game.

The Game implements a maze generation algorythm, that creates different maze every time the game is launched. By default maze covers a square field which length and width are equal to 31 sizes of a wall object. The only escape from maze is through the door which lock is encrypted. The corridors in the maze are wide for the size of a single wall object, it is impossible for this maze to have wider corridors. The border of the maze is build with the (30*4)-1 wall objects and a single door. The player need to find four crystals in the maze and write down the message displayed on these crystals. Concatenated message need to be typed into decryption keyboard located next to the exit door. If player provides correct combination of encrypted code, decrypted message will be displayed on the screen and the door will open. I choose the AES encryption method to generate the messages that were written on the crystals as it was one of the topics of the "Security of Information System" class. The game is just a technological demo I created to show the possibilities of Unity gaming engine to my classmates. The both gameplay and UI should be improved in order to upgrade the game. More technical and theoretical information can be found in the paper provided with code code.

The sctucture of the repository:
  Executable - Executable code for the game for Windows platform
  aMaze - code and all of the assets of the Actual Game
  Paper -  Technical and theoretical report I created for the class (written in Polish)
  
 
It was written in Unity 4.6.1fa using C#, Javascript and some free assets from Unity Marketplace.
