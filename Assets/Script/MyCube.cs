using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MyCube : MonoBehaviour
{
    public GameManager gameManager;
    public UiManager uiManager;
    
    public float speed;
    public float forwardSpeed;
    int point;
    
    private Vector3 _startPosition;

    private void Start()
    {
        _startPosition = transform.position;
        OnLevelReset();
    }

    private void Update()
    {
        switch (gameManager.gameStatus)
        {
            case GameStatus.Start:
                
                break;
            
            case GameStatus.GameOn:
                
                MoveObjectHorizontal();

                transform.position += Vector3.forward * Time.deltaTime * forwardSpeed;
            
                point++;
                SetPointText();
                break;
            
            case GameStatus.End:
                
                break;
            
            default:
                throw new ArgumentOutOfRangeException();
            
        }

        if (gameManager.isGameOn && transform.position.y < -10)
        {
            OnPlayerFail();
        }
    }

    private void MoveObjectHorizontal()
    {
        Vector3 position = new Vector3(1, 0, 0); // Vector.right

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += speed * Time.deltaTime * position;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += -speed * Time.deltaTime * position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Barrier"))
        {
            if (gameManager.isGameOn)
            {
                OnPlayerFail();
            }
        }
        if (other.gameObject.CompareTag("Finish"))
        {
            OnLevelCompleted();
        }
    }

    private void OnPlayerFail()
    {
        gameManager.OnLevelFail();
    }

    private void OnLevelCompleted()
    {
        gameManager.OnLevelCompleted();
    }
    

    private void SetPointText()
    {
        uiManager.SetPointText(point);
    }

    public void OnLevelReset()
    {
        point = 0;
        SetPointText();
        transform.position = _startPosition;
    }
}