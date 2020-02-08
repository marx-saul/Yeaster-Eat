using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this class is extended by YeasterAutoControl1,2,...
public class YeasterAutoController : MonoBehaviour
{
    // these are set by the colliders. Hence this script must be executed after the colliders.
    public Dictionary<YeasterDirection, bool> TouchedDirection = new Dictionary<YeasterDirection, bool>() {
        {YeasterDirection.Left,  false},
        {YeasterDirection.Right, false},
        {YeasterDirection.Up,    false},
        {YeasterDirection.Down,  false}
    };
}
