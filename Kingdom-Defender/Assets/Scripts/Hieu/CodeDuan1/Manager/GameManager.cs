using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : HieuSingleton<GameManager>
{
    public event Action onPlayerWin;
    public event Action onPlayerLose;
    
    public virtual void PlayerWin()
    {
        onPlayerWin?.Invoke();
    }
    public virtual void PlayerLose()
    {
        onPlayerLose?.Invoke();
    }
}
