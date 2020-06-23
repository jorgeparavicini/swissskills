﻿using Level.Path;
using UnityEngine;

namespace Level.Packages
{
    public class PathPackage : Package
    {
#pragma warning disable 649
        
        [SerializeField] private PathElement _pathElement;

#pragma warning restore
        
        public PathElement PathElement => _pathElement;
    }
}
