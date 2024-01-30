using System;
using System.Threading.Tasks;
using Flurl.Http;

namespace MedicalPlusFront.Utils;

public class TaskHelper
{

    public event Action<IFlurlResponse> TaskCompleted;

    private Task<IFlurlResponse> _task;
    public TaskHelper(Task<IFlurlResponse> task)
    {
        _task = task;
        _task.GetAwaiter().OnCompleted(InvokeEvent);
    }

    private void InvokeEvent()
    {
        TaskCompleted?.Invoke(_task.Result);
    }
    
}