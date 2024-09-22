using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationMove : MonoBehaviour
{
    [SerializeField] GameObject bgPanel, playerTile;

    void Start()
    {
        LeanTween.rotateAround(bgPanel, Vector3.forward, -360, 10f).setLoopClamp();
    }

}
