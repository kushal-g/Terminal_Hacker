using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    //Game configuration
    readonly string[] level1Password = { "book" ,"aisle","shelf"};
    readonly string[] level2Password = { "prison", "jail", "crime" };
    readonly string[] level3Password = { "astronaut", "interstellar", "rocketship" };

    //Game State
    int level = 0;
    string password;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen = Screen.MainMenu;

    // Start is called before the first frame update
    void Start()
    {
        ShowStartMenu();
    }

    void ShowStartMenu()
    {
        level = 0;
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("What would you like to hack into?\n");
        Terminal.WriteLine("Press 1 to hack into the library");
        Terminal.WriteLine("Press 2 to hack into Police Station");
        Terminal.WriteLine("Press 3 to hack into NASA\n");
        Terminal.WriteLine("Enter your selection:");
    }

    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowStartMenu();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            PickLevel(input);
        }
        else if(currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }

    }

    void PickLevel(string input)
    {
        switch (input)
        {
            case "1": password = level1Password[ UnityEngine.Random.Range(0, level1Password.Length)  ];
                StartGame(int.Parse(input));
                break;
            case "2": password = level2Password[ UnityEngine.Random.Range(0, level2Password.Length) ];
                StartGame(int.Parse(input));
                break;
            case "3": password = level3Password[ UnityEngine.Random.Range(0, level3Password.Length)];
                StartGame(int.Parse(input));
                break;
            default:
                Terminal.WriteLine("Please give a valid input");
                break;
        }
        
    }

    void StartGame(int lvl)
    {
        level = lvl;
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        Terminal.WriteLine("\nYou've selected level " + level);
        Terminal.WriteLine("\nClue:" + Scramble(password));
        Terminal.WriteLine("\nPlease enter the password: ");
    }

    StringBuilder Scramble(string password)
    {
        var jumble = new StringBuilder(password);
        int length = jumble.Length;
        var random = new System.Random();
        for (int i = length - 1; i > 0; i--)
        {
            int j = random.Next(i);
            char temp = jumble[j];
            jumble[j] = jumble[i];
            jumble[i] = temp;
        }
        return jumble;
    }
    void CheckPassword(string input){
        if(input == password){
            ShowWinScreen();
        }else{
            Terminal.WriteLine("Incorrect Password");
        }
    }

    void ShowWinScreen(){
        
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        if (level == 1)
        {
            
            Terminal.WriteLine(@"
        (\ 
        \'\ 
         \'\     __________  
         / '|   ()_________)
         \ '/    \ ~~~~~~~~ \
           \       \ ~~~~~~   \
           ==).      \__________\
          (__)       ()__________)

"); 
            Terminal.WriteLine("You've succesfully hacked into the local library");
        }
        else if(level == 2)
        {
            
            Terminal.WriteLine(@"
 _    .----.       .----.
( )  //--\  \.---./  /--\\
 T  ((    ) @)   (@ (    ))
 |   \\__/  /'---'\  \__//
 |E   '----'       '----'
");

            Terminal.WriteLine("You've succesfully hacked into the police station");
        }
        else if(level == 3)
        {
            
            Terminal.WriteLine(@"
      /\
     (  )
     (  )
    /|/\|\
   /_||||_\

");
            Terminal.WriteLine("You've succesfully hacked into NASA");
        }

        Terminal.WriteLine("Type 'menu' to hack someone else");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
