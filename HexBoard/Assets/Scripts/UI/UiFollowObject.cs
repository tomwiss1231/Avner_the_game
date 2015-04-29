﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.UI
{
	public class UiFollowObject : MonoBehaviour
	{
	    public Vector2 Offset;
	    public Transform Following;

	    void Update()
	    {
	        transform.position = Following.transform.position + (Vector3) Offset;
	    }
	}
}