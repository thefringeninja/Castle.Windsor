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

namespace Castle.Windsor.Tests.MicroKernel
{
	using Castle.MicroKernel;
	using Castle.MicroKernel.Context;

	using NUnit.Framework;

	[TestFixture]
	public class ArgumentsTestCase
	{
		[Test]
		public void Handles_Type_as_key()
		{
			var arguments = new Arguments();
			var key = typeof(object);
			var value = new object();

			arguments.Add(key, value);

			Assert.AreEqual(1, arguments.Count);
			Assert.IsTrue(arguments.Contains(key));
			Assert.AreSame(value, arguments[key]);
		}

		[Test]
		public void Handles_string_as_key()
		{
			var arguments = new Arguments();
			var key = "Foo";
			var value = new object();

			arguments.Add(key, value);

			Assert.AreEqual(1, arguments.Count);
			Assert.IsTrue(arguments.Contains(key));
			Assert.AreSame(value, arguments[key]);
		}

		[Test]
		public void Handles_string_as_key_case_insensitive()
		{
			var arguments = new Arguments();
			var key = "foo";
			var value = new object();

			arguments.Add(key, value);

			Assert.IsTrue(arguments.Contains(key.ToLower()));
			Assert.IsTrue(arguments.Contains(key.ToUpper()));
		}

		[Test]
		public void Custom_stores_get_picked_over_default_ones()
		{
			var arguments = new Arguments(new CustomStringComparer());
			var key = "foo";
			var value = new object();

			arguments.Add(key, value);

			Assert.AreEqual(value, arguments["boo!"]);
		}

		[Test]
		public void By_default_any_type_as_key_is_supported()
		{
			var arguments = new Arguments(new CustomStringComparer());
			var key = new object();
			var value = "foo";

			arguments.Add(key, value);

			Assert.AreEqual("foo", arguments[key]);
		}
	}

	public class CustomStringComparer : IArgumentsComparer
	{
		public bool RunEqualityComparison(object x, object y, out bool areEqual)
		{
			if (x is string)
			{
				areEqual = true;
				return true;
			}
			areEqual = false;
			return false;
		}

		public bool RunHasCodeCalculation(object o, out int hashCode)
		{
			if(o is string )
			{
				hashCode = "boo!".GetHashCode();
				return true;
			}
			hashCode = 0;
			return false;

		}
	}
}