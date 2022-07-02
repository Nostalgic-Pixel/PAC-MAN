using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Ghost[] ghosts;

    public Pacman pacman;

    public Transform pellets;

    public int score { get; private set; } // public getter, private setter.

    public int lives { get; private set; }

    // This will be the way to start the game.
    private void Start()
    {
        // This will call the NewGame function.
        NewGame();

    }

    // Starting a new game after a game over.
    private void Update()
    {
        // IF the user is in a game over state and types in any key on the keyboard.
        if (this.lives <= 0 && Input.anyKeyDown)
        {
            NewGame();
        }

        // Option for wanting to do it with the ENTER key.
        // if (Input.GetKeyDown(KeyCode.Return))
        // {
            
        // }
    }



    
    // When the game starts, we want to start a new game.
    private void NewGame()
    {
        SetScore(0);
        SetLives(3);
        NewRound();

    }

    // When all of the pellets are eaten and will start a new round.
    private void NewRound()
    {
        // This will allow us to loop through every object of the Child.  
        foreach (Transform pellet in this.pellets)
        {
            pellet.gameObject.SetActive(true);
        }

        // This will call the ResetState function to reset the states of 
        // PAC-MAN and the ghosts.
        ResetState();

    }

    // This will be used to loop through the ghosts and PAC-MAN objects when 
    // the game is reset. This can also be used if/when PAC-MAN dies, but 
    // does not want to reset the pellets (keep the ones eaten missing).
    private void ResetState()
    {
        // Loop through the ghosts.
        for (int  i = 0; i < this.ghosts.Length; i++)
        {
            this.ghosts[i].gameObject.SetActive(true);
        }

        // Loop for PAC-MAN.
        this.pacman.gameObject.SetActive(true);

    }

    private void GameOver()
    {
        // Loop through the ghosts.
        for (int  i = 0; i < this.ghosts.Length; i++)
        {
            this.ghosts[i].gameObject.SetActive(false);
        }

        // Loop for PAC-MAN.
        this.pacman.gameObject.SetActive(false);

    }

    private void SetScore(int score)
    {
        this.score = score;
    }

    private void SetLives(int lives)
    {
        this.lives = lives;
    }

    // When the ghost(s) are eaten.
    public void GhostEaten(Ghost ghost)
    {
        // Increase score when a ghost is eaten.
        SetScore(this.score = ghost.points);

    }

    // When PAC-MAN dies (eaten).
    public void PacmanEaten()
    {
        // Turn of PAC-MAN.
        this.pacman.gameObject.SetActive(false);

        // Decrease the amount of lives by 1.
        SetLives(this.lives - 1);

        // If PAC-MAN has 1 or more lives, reset the round.
        if (this.lives > 0)
        {
            // This will give the game a certain amount of seconds before dying.
            // (like give a dying animation before imediately ending the state).
            Invoke(nameof(ResetState), 3.0f); // 3 seconds of dying animation.
           
        }

        // Otherwise, it will be a game over.
        else
        {
            GameOver();

        }

    }





}
