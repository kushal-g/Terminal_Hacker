﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    enum Screen {MainMenu,Password,Win};
    //Game State
    int level = 0;
    string password;
    Screen currentScreen = Screen.MainMenu;

    // Start is called before the first frame update
    void Start()
    {
        ShowStartMenu();
    }

    void ShowStartMenu()
    {
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
            case "1": password = "book";
                StartGame(int.Parse(input));
                break;
            case "2": password = "prison";
                StartGame(int.Parse(input));
                break;
            case "3": password = "astronaut";
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
        Terminal.WriteLine("\nYou've selected level " + level);
        Terminal.WriteLine("Please enter the password: ");
    }

    void CheckPassword(string input){
        if(input == password){
            ShowWinScreen();
        }else{
            Terminal.WriteLine("Incorrect Password");
        }
    }

    void ShowWinScreen(){
        level = 0;
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        Terminal.WriteLine("You have succesfully hacked into your destination");
        Terminal.WriteLine("Type 'menu' to hack into somewhere else");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
