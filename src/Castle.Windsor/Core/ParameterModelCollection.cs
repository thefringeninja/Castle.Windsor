// Copyright 2004-2010 Castle Project - http://www.castleproject.org/
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

namespace Castle.Core
{
	using System;
	using System.Collections;
	using System.Collections.ObjectModel;
	using System.Diagnostics;

	using Castle.Core.Configuration;

	using System.Collections.Generic;

	/// <summary>
	///   Collection of <see cref = "ParameterModel" />
	/// </summary>
	[Serializable]
	[DebuggerDisplay("Count = {dictionary.Count}")]
	public class ParameterModelCollection : Collection<ParameterModel>
	{
		private readonly IDictionary<string, ParameterModel> dictionary =
			new Dictionary<string, ParameterModel>(StringComparer.OrdinalIgnoreCase);

		/// <summary>
		///   Gets the count.
		/// </summary>
		/// <value>The count.</value>
		public new int Count
		{
			get { return dictionary.Count; }
		}

		/// <summary>
		///   Gets the <see cref = "ParameterModel" /> with the specified key.
		/// </summary>
		/// <value></value>
		public ParameterModel this[object key]
		{
			get
			{
				ParameterModel result;
				dictionary.TryGetValue((string)key, out result);
				return result;
			}
		}

		/// <summary>
		///   Adds the specified name.
		/// </summary>
		/// <param name = "name">The name.</param>
		/// <param name = "value">The value.</param>
		public void Add(string name, string value)
		{
			Add(name, new ParameterModel(name, value) );
		}

		/// <summary>
		///   Adds the specified name.
		/// </summary>
		/// <param name = "name">The name.</param>
		/// <param name = "configNode">The config node.</param>
		public void Add(string name, IConfiguration configNode)
		{
			Add(name, new ParameterModel(name, configNode));
		}

		/// <summary>
		///   Adds the specified key.
		/// </summary>
		/// <remarks>
		///   Not implemented
		/// </remarks>
		/// <param name = "key">The key.</param>
		/// <param name = "value">The value.</param>
		private void Add(string key, ParameterModel value)
		{
			try
			{
				dictionary.Add(key, value);
			}
			catch (ArgumentException e)
			{
				throw new ArgumentException(string.Format("Parameter '{0}' already exists.", key), e);
			}
		}

		/// <summary>
		///   Clears this instance.
		/// </summary>
		/// <remarks>
		///   Not implemented
		/// </remarks>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
		public new void Clear()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		///   Determines whether this collection contains the specified key.
		/// </summary>
		/// <param name = "key">The key.</param>
		/// <returns>
		///   <c>true</c> if yes; otherwise, <c>false</c>.
		/// </returns>
		public bool Contains(object key)
		{
			return dictionary.ContainsKey((string)key);
		}

		/// <summary>
		///   Copy the content to the specified array
		/// </summary>
		/// <param name = "array">target array</param>
		/// <param name = "index">target index</param>
		/// <remarks>
		///   Not implemented
		/// </remarks>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "index")]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "array")]
		public void CopyTo(Array array, int index)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		///   Returns an enumerator that can iterate through a collection.
		/// </summary>
		/// <returns>
		///   An <see cref = "T:System.Collections.IEnumerator" />
		///   that can be used to iterate through the collection.
		/// </returns>
		public new IEnumerator GetEnumerator()
		{
			return dictionary.Values.GetEnumerator();
		}

		/// <summary>
		///   Removes the specified key.
		/// </summary>
		/// <param name = "key">The key.</param>
		/// <remarks>
		///   Not implemented
		/// </remarks>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "key")]
		public void Remove(object key)
		{
			throw new NotImplementedException();
		}
	}
}