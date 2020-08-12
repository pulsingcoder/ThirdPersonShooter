using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(MoveController))]
public class Player : MonoBehaviour
{
    [System.Serializable]
    public class MouseInput
    {
        public Vector2 Damping;
        public Vector2 Sensitivity;

    }

    [SerializeField] float speed;
    [SerializeField] MouseInput mouseControl;

    private MoveController m_MoveController;
    public MoveController MoveController
    {
        get
        {
            if (m_MoveController == null)
            {
                m_MoveController = GetComponent<MoveController>();
            }
            return m_MoveController;
        }
    }

    // Start is called before the first frame update
    InputManager playerInput;
    Vector2 mouseInput;
    void Awake()
    {
        playerInput = GameManager.Instance.InputManager;
        GameManager.Instance.LocalPlayer = this;
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = new Vector2(playerInput.Vertical * speed, playerInput.Horizontal * speed);
        MoveController.Move(direction);
        mouseInput.x = Mathf.Lerp(mouseInput.x, playerInput.MouseInput.x, 1f / mouseControl.Damping.x);
        transform.Rotate(Vector3.up * mouseInput.x * mouseControl.Sensitivity.x);

    }
}
