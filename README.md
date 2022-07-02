# Overview

## *PAC-MAN (DEMO)*
## By: Joseph Wilson

![Image](Pictures\PAC-MAN.gif)

### Description:
> This game is a recreation of the beloved BANDAI NAMCO game, PAC-MAN. This program will go over some of the basic functionalities of the PAC-MAN game and give an idea on how it works all together."
```
using UnityEngine;

[RequireComponent(typeof(Movement))]
public class Pacman : MonoBehaviour
{
    public Movement movement { get; private set; }

    private void Awake()
    {
        this.movement = GetComponent<Movement>();
    }

    private void Update()
    {
        // If the user presses the "W" key or the Up Arrow key, go up.
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            this.movement.SetDirection(Vector2.up);
        }

        // If the user presses the "S" key or the Down Arrow key, go down.
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            this.movement.SetDirection(Vector2.down);
        }

        // If the user presses the "A" key or the Left Arrow key, go left.
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            this.movement.SetDirection(Vector2.left);
        }

        // If the user presses the "D" key or the Right Arrow key, go right.
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            this.movement.SetDirection(Vector2.right);
        }

    }
   
}

```

### Purpose:
> The purpose of this software is to help the users understand the basic concepts of using Unity and apply learnings of the C# programming language. By this, the user can understand how the physics work and develop simple understandings on how to make future games in similar formats.

# Development Environment

### Platform(s) used:
> 1. Visual Studio Code
> 2. Unity
> 3. Github

### Programming Language(s):
> 1. C#
> 2. Unity (program functions)

### Youtube Video Link:
> [PAC-MAN Demo Video](https://www.youtube.com/watch?v=IpW-4-OLhKI)

# Useful Websites

{Make a list of websites that you found helpful in this project}
* [Youtube](http://youtube.com)
* [Github](http://github.com)
