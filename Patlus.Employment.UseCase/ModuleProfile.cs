﻿using System.Reflection;

namespace Patlus.Employment.UseCase
{
    public class ModuleProfile
    {
        public static Assembly[] GetBundles() => new Assembly[] {
            typeof(ModuleProfile).GetTypeInfo().Assembly
        };
    }
}
