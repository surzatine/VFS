using System;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class CommandInputSystem : MonoBehaviour
{
    [SerializeField] private TMP_InputField commandInputField;
    [SerializeField] private Button commandSubmitButton;

    public UnityEvent<string> OnCommandSubmitted;

    private bool _isSubmitting = false;

    private void OnEnable()
    {
        commandSubmitButton.onClick.AddListener(SubmitCommand);
    }

    private void OnDisable()
    {
        commandSubmitButton.onClick.RemoveListener(SubmitCommand);
    }

    private void Update()
    {
        if (Keyboard.current == null)
            return;

        bool pressed =
            Keyboard.current.enterKey.wasPressedThisFrame ||
            Keyboard.current.numpadEnterKey.wasPressedThisFrame;

        bool released =
            Keyboard.current.enterKey.wasReleasedThisFrame ||
            Keyboard.current.numpadEnterKey.wasReleasedThisFrame;

        if (pressed && !_isSubmitting)
        {
            _isSubmitting = true;
            SubmitCommand();
        }

        if (released)
        {
            _isSubmitting = false;
        }
    }

    private void SubmitCommand()
    {
        var command = commandInputField.text;

        OnCommandSubmitted?.Invoke(command);
        commandInputField.text = string.Empty;
    }
}