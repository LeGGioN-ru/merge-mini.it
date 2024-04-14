using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHoldable
{
    public Transform GetTransform();
    public void Hold();
    public void Place();
}
