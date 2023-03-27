using System;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameManager gameManager;
    
    public GameObject[] levelObjects; // 0 , 1 , 2 , 3 , 4

    private GameObject _currentLevelObject;
    
    public void CreateLevel()
    {
        if (_currentLevelObject != null)
        {
            Destroy(_currentLevelObject);
        }
        
        if (gameManager.currentLevelNumber >= levelObjects.Length)
        {
            gameManager.currentLevelNumber = 0;
        }

        _currentLevelObject = Instantiate(levelObjects[gameManager.currentLevelNumber], Vector3.zero, Quaternion.identity);
    }
}