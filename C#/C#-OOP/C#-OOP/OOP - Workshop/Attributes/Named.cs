﻿using System;

namespace OOP___Workshop.Attributes
{
    [AttributeUsage(AttributeTargets.Parameter)]
    public class Named : Attribute
    {
        public Named(Type type)
        {
            this.TypeName = type;
        }
        public Type TypeName { get; set; }
    }
}
