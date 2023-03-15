using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invoker : MonoBehaviour
{
    private bool isRecording;
    private bool isReplaying;

    private List<Command> recordedCommands = new List<Command>();

    public void ExecuteCommand(Command aCommand)
    {
        aCommand.Execute();

        if(isRecording == true)
        {
            recordedCommands.Add(aCommand);
        }

        Debug.Log("Recorded Command: " + aCommand);
    }

    public void Record()
    {
        isRecording = true;
    }

    public void Replay()
    {
        isReplaying = true;

        if(recordedCommands.Count <= 0)
        {
            Debug.Log("There is nothing to replay");
        }
        else
        {
            foreach(var c in recordedCommands)
            {
                Debug.Log("Executing Command: " + c);
                c.Execute();
            }

            isReplaying = false;
        }
    }
}
