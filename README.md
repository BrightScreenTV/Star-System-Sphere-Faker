# Star-System-Sphere-Faker
 _Using spheres to mimic star system._



This project is a new version of my simple star system code that I initially used to create the illusion of an infinite backdrop of stars passes 'beneath' a player's ship in Unity. You can see a screen recording of the effect I achieved on YouTube, [here](https://youtu.be/3NLiXPS8ke8).

And that project is [here](https://github.com/BrightScreenTV/Simple-Star-System-In-Unity).

There were some irritating bugs with this method - not least of all, the stars flickered when the player's ship was forcibly repositioned (e.g. when jumping into Hyperspace) by a long distance. Physics also had some issues when moving the ship.

So I wanted to create something that would do the same thing but be a lot simpler and cleaner. My thinking is to use (in this case) 3 spheres which sat the other side of the player sprite from the main camera and would be a child of the player's transform so meaning that wherever the player went, the spheres automatically followed.

The spheres are of different sizes and sit inside each other like Russian Dolls:

![spheres](https://brightscreentv.net/images/soheres%20models.png)

In the above image, the player's sprite is the small, white dot in front of the spheres.

The textures for the spheres are just large png's that are all clear but with white dots. Each sphere has a different material and hence, texture.

As the player moves, an equal (if that's the right way of explaining it) and opposite force in the form of torque is applied to the game object that holds all three spheres (and which itself, is a child of the player). The camera is positioned and has a FOV that just captures all three spheres behind the player. As the parent object rotates due to the torque, the spheres rotate at what appears to be different speeds (because of their relative size differnces) and so there is the appearance of stars zooming behind the player and at different speeds due to their distance from the camera.

It's not perfect, but I really like the effect it produces and it does mean there's very few extra objects in the game to create this illusion.



Use the arrow keys to rotate the ship and the forward and backwards keys to accelerate the ship in the direction it's pointing. 'H' will make the ship jump to a random position within the boundary (see below) and has a little effect with the backdrop to indicate the change.

Adjust the Player Ones Master Object's drag to affect the speed of the ship and use it's boundary settings to make the player 'wrap' around a set area of the universe - i.e. when the player's position goes past -ve x or y boundary values then it will appear over at the +ve boundary.