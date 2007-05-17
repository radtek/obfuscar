#region Copyright (c) 2007 Ryan Williams <drcforbin@gmail.com>
/// <copyright>
/// Copyright (c) 2007 Ryan Williams <drcforbin@gmail.com>
/// 
/// Permission is hereby granted, free of charge, to any person obtaining a copy
/// of this software and associated documentation files (the "Software"), to deal
/// in the Software without restriction, including without limitation the rights
/// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
/// copies of the Software, and to permit persons to whom the Software is
/// furnished to do so, subject to the following conditions:
/// 
/// The above copyright notice and this permission notice shall be included in
/// all copies or substantial portions of the Software.
/// 
/// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
/// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
/// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
/// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
/// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
/// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
/// THE SOFTWARE.
/// </copyright>
#endregion

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

using Mono.Cecil;

namespace Obfuscar
{
	static class Helper
	{
		public static void Noop( ) { }

		/// <summary>
		/// Returns the simplified name for the assembly where a type can be found,
		/// for example, a type whose module is "Assembly.exe", "Assembly" would be 
		/// returned.
		/// </summary>
		public static string GetScopeName( TypeReference type )
		{
			ModuleDefinition module = type.Scope as ModuleDefinition;
			if ( module != null )
				return module.Assembly.Name.Name;
			else
				return type.Scope.Name;
		}

		/// <summary>
		/// Builds a name for a parameter type that can be used for comparing parameters.  See 
		/// <see cref="GetTypeName"/> for details.
		/// </summary>
		public static string GetParameterTypeName( ParameterReference param )
		{
			return TypeNameCache.GetTypeName( param.ParameterType );
		}

		public static string GetAttribute( XmlReader reader, string name )
		{
			string val = reader.GetAttribute( name );
			if ( val == null )
				val = String.Empty;
			else
				val = val.Trim( );

			return val;
		}

		public static string GetAttribute( XmlReader reader, string name, Variables vars )
		{
			return vars.Replace( GetAttribute( reader, name ) );
		}
	}
}
