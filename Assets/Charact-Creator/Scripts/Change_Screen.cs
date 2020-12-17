using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Change_Screen : MonoBehaviour
{
    public void Go_To_Character_Creator_Menu()
    {
        SceneManager.LoadScene("Character-menu");
    }
    public void Go_Back_To_Main_Menu()
    {
        SceneManager.LoadScene("Main");
    }

}
