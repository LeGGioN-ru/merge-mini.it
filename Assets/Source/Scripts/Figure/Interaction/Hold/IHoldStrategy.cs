using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHoldStrategy 
{
    public void Hold(IHoldable holdable);
    public void Place();
}
