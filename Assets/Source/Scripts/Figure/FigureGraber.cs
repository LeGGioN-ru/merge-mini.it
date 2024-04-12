using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class FigureGraber : ITickable
{
    private readonly ContactFilter2D _grabFilter;

    public FigureGraber(ContactFilter2D grabFilter)
    {
        _grabFilter = grabFilter;
    }

    public void Tick() //Сделать нормальным!
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            List<Collider2D> collider2Ds = new List<Collider2D>();
            Physics2D.OverlapPoint(mousePosition, _grabFilter, collider2Ds);

            mousePosition.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;

            if (collider2Ds[0] != null)
            {
                collider2Ds[0].transform.position = mousePosition;
            }

            foreach (Collider2D collider in collider2Ds)
            {
                Debug.Log(collider.gameObject.name);
            }
        }
    }
}
