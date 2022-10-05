using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Main
{
    public static Dictionary<string, string> levels = new Dictionary<string, string> { { "NextBtn1_1", "Webview" },
        { "NextBtn1_2", "Menu" }, { "PlayBtn", "Game" }, { "BackBtn1", "StartScene" }, { "BackBtn2", "Menu" } };

    public static bool PolicyWasAccepted = false;

    public static bool internetAccess = false, internetChecked = false;

    public static int score = 717;
}
