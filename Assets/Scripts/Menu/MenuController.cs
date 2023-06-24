using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StartController : MonoBehaviour
{
    [SerializeField] RectTransform _mainMenu;
    [SerializeField] RectTransform _loadMenu;
    //public int Level;
    
    public void Play()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("Level1");
    }

    public void Load()
    {
        _mainMenu.gameObject.SetActive(false);
        _loadMenu.gameObject.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(EventSystem.current.currentSelectedGameObject.name);
    }

    public void BackToMenu()
    {
        _mainMenu.gameObject.SetActive(true);
        _loadMenu.gameObject.SetActive(false);
    }
}
