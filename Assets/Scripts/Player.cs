using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    InputManager inputManager;
    void Start()
    {
        inputManager = GameManager.Instance.InputManager;
    }

    // Update is called once per frame
    void Update()
    {
        print("Horizontal : " + inputManager.Horizontal);
        print("Mouse X : " + inputManager.MouseInput.x);
    }
}
