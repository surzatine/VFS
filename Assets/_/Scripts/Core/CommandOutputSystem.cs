using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class CommandOutputSystem : MonoBehaviour
{
    [SerializeField] private CommandProcessor commandProcessor;
    
    [SerializeField] private TMP_Text commandOutputText;

    private void OnEnable()
    {
        commandProcessor.onCommandProcessed.AddListener(DisplayOutputCommand);
    }

    private void OnDisable()
    {
        commandProcessor.onCommandProcessed.RemoveListener(DisplayOutputCommand);
    }

    private void DisplayOutputCommand(string outputText) => commandOutputText.text = outputText;
}
