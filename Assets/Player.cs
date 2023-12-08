using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Vector2 pointerInput;
    private InputActionReference pointerPosition;
    private WeaponParent weaponParent;

    private void Awake()
    {
        weaponParent = GetComponentInChildren<WeaponParent>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pointerInput = GetPointerInput();
        weaponParent.Pointerposition = pointerInput;
    }

    private Vector2 GetPointerInput()
    {
        Vector3 mousePos = pointerPosition.action.ReadValue<Vector2>();
        mousePos.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
}
