using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenuController : MonoBehaviour
{
    public void PlayGame()
    {
       int selectedCharecter = int.Parse(EventSystem.current.currentSelectedGameObject.name);
        GameManager.instance.charIndex = selectedCharecter;
        SceneManager.LoadScene("Gameplay");
    }
}
