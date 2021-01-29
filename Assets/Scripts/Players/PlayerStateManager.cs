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
    private List<PlayerState> stateApplied = new List<PlayerState>();


    public PlayerState GetState()
    {
        if (stateApplied.Contains(PlayerState.INVINCIBLE)) return PlayerState.INVINCIBLE;
        if (stateApplied.Contains(PlayerState.PUSHED)) return PlayerState.PUSHED;
        return PlayerState.NORMAL;
    }

    public void ChangeStateTemporaly(PlayerState newState, float duration)
    {
        var beforeState = GetState();
        if (newState != PlayerState.INVINCIBLE && beforeState == PlayerState.INVINCIBLE) return;
        stateApplied.Add(newState);
        StartCoroutine(WaitRemoveState(duration, newState));
    }

    private IEnumerator WaitRemoveState(float duration, PlayerState state)
    {
        yield return new WaitForSeconds(duration);
        stateApplied.Remove(state);
    }
}
