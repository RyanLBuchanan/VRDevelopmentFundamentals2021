using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandControllerScript : MonoBehaviour
{

    [SerializeField] InputActionReference gripInputAction;
    [SerializeField] InputActionReference triggerInputAction;

    Animator handAnimator;


    private void Awake()
    {
        handAnimator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        gripInputAction.action.performed += GripPressed;
        gripInputAction.action.canceled += GripReleased;
        triggerInputAction.action.performed += TriggerPressed; // MY OWN CODE!!!  I WROTE CODE!!!
        triggerInputAction.action.canceled += TriggerReleased; // MY OWN CODE!!!  I WROTE CODE!!!
    }

    private void TriggerReleased(InputAction.CallbackContext obj)
    {
        Debug.Log(obj.ReadValue<float>());
        handAnimator.SetFloat("Trigger", obj.ReadValue<float>());
    }

    private void TriggerPressed(InputAction.CallbackContext obj)
    {
        Debug.Log(obj.ReadValue<float>());
        handAnimator.SetFloat("Trigger", obj.ReadValue<float>());
    }

    private void GripPressed(InputAction.CallbackContext obj)
    {
        Debug.Log(obj.ReadValue<float>());
        handAnimator.SetFloat("Grip", obj.ReadValue<float>());
    }

    private void GripReleased(InputAction.CallbackContext obj)
    {
        Debug.Log(obj.ReadValue<float>());
        handAnimator.SetFloat("Grip", obj.ReadValue<float>());
    }


    private void OnDisable()
    {
        //gripInputAction.action.performed -= GripPressed;
        gripInputAction.action.canceled += GripReleased; // MY OWN CODE!!!  I WROTE CODE!!!
        triggerInputAction.action.performed += TriggerReleased; // MY OWN CODE!!!  I WROTE CODE!!!
    }


}
