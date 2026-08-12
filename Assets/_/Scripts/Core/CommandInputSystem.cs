using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.UI;
public class CommandInputSystem : MonoBehaviour
{
    [SerializeField] private TMP_InputField commandInputField;
    [SerializeField] private Button commandSubmitButton;
    
    public UnityEvent<string> OnCommandSubmitted;
    
    private void OnEnable()
    {
        commandSubmitButton.onClick.AddListener(SubmitCommand);
    }
    
    private void OnDisable()
    {
        commandSubmitButton.onClick.RemoveListener(SubmitCommand);
    }
    
    private void SubmitCommand()
    {
        var command = commandInputField.text;
        
        OnCommandSubmitted?.Invoke(command);
    }
}
