using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum PlayerState
{
    NORMAL,
    PUSHED,
    INVINCIBLE
}

public class PlayerStateManager : MonoBehaviour
{
    public PlayerState state = PlayerState.NORMAL;
    public UnityEvent<PlayerState> onStateChanged;

    public void ChangeState(PlayerState newState)
    {
        state = newState;
        onStateChanged?.Invoke(state);
    }

    public void ChangeStateTemporaly(PlayerState newState, float duration)
    {
        ChangeState(newState);
        StartCoroutine(WaitResetState(duration));
    }

    private IEnumerator WaitResetState(float duration)
    {
        yield return new WaitForSeconds(duration);
        ChangeState(PlayerState.NORMAL);
    }
}
