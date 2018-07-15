using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace UniCraft.Toolbox.Class.Utility
{
	/// <summary>
	/// Utility class used to perform various actions on reflection
	/// </summary>
	public static class ReflectionUtility
	{
	    /// <summary>
	    /// Return all the assemblies of the current domain
	    /// </summary>
        public static IEnumerable<Assembly> GetAssemblies()
        {
            return (AppDomain.CurrentDomain.GetAssemblies());
        }

	    /// <summary>
	    /// Returns all the types or those specified by the match
	    /// </summary>
	    /// <param name="match">(Optional) The Type predicate</param>
        public static IEnumerable<Type> GetTypes(Predicate<Type> match = null)
        {
            return (GetAssemblies().SelectMany(assembly => GetTypesFromAssembly(assembly, match)));
        }

	    /// <summary>
	    /// Returns all the types or those specified by the match from an assembly
	    /// </summary>
	    /// <param name="assembly">The assembly where the research will be done</param>
	    /// <param name="match">(Optional) The Type predicate</param>
        public static IEnumerable<Type> GetTypesFromAssembly(Assembly assembly, Predicate<Type> match = null)
        {
            return (match == null ? assembly.GetTypes() : Array.FindAll(assembly.GetTypes(), match));
        }

		/// <summary>
		/// Returns all the subtypes of a Type from an assembly or from the entire project
		/// </summary>
		/// <param name="rootType">The root Type</param>
		/// <param name="assembly">(Optional) The assembly where the research will be done</param>
        public static IEnumerable<Type> GetSubtypes(Type rootType, Assembly assembly = null)
        {
            Predicate<Type> match;

            if (rootType.IsInterface)
                match = t => rootType.IsAssignableFrom(t) && !string.Equals(rootType.Name, t.Name);
            else
                match = t => t.IsSubclassOf(rootType);
            return (assembly == null ? GetTypes(match) : GetTypesFromAssembly(assembly, match));
        }
	}
}
