using UnityEngine;

public abstract class CharacterController : MonoBehaviour
{
    [SerializeField] protected SpriteRenderer spriteRenderer;
    protected bool canMove = false;


    #region Virtual Methods
    public virtual void Display(bool state)
    {
        spriteRenderer.enabled = state;
    }

    public virtual void SetMovement(bool state)
    {
        canMove = state;
    }

    public virtual void DisplayAndMove(bool state)
    {
        SetMovement(state);
        Display(state);
    }
    #endregion

    #region Abstract Methods
    public abstract void Reset();
    #endregion
}
