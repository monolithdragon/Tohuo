using System;
using UnityEngine.EventSystems;

public class HandleAttack : Singleton<HandleAttack>, IPointerDownHandler, IPointerUpHandler
{
    public event Action<bool> OnAttack;

    public void OnPointerDown(PointerEventData eventData)
    {
        OnAttack?.Invoke(true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        OnAttack?.Invoke(false);
    }
}
