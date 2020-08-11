using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    private GameObject gameObject;
    private static GameManager m_Instance;

    public static GameManager Instance
    {
        get
        {
            if (m_Instance == null)
            {
                m_Instance = new GameManager();
                m_Instance.gameObject = new GameObject("_gameManager");
                m_Instance.gameObject.AddComponent<InputManager>();
            }
            return m_Instance;
        }
    }

    private InputManager m_InputManager;
    public InputManager InputManager
    {
        get
        {
            if (m_InputManager == null)
            {
                m_InputManager = gameObject.GetComponent<InputManager>();
            }
            return m_InputManager;
        }
       
    }
}
