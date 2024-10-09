using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Button : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Animator _animator;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Click");
        
        _animator = GetComponent<Animator>();
        _animator.SetBool("anim", true);
        GameObject.Find("Panel").GetComponent<LoadSprites>().load();
    }
}