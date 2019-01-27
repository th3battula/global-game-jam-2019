using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquippedToolScript : MonoBehaviour
{
	public static EquippedToolScript instance;

    void Start()
    {
        instance = this;
    }
}
