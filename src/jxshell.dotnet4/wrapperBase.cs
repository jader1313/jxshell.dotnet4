using System;
using System.Runtime.InteropServices;

namespace jxshell.dotnet4
{
	[ComVisible(true)]
	[Guid("777CFACD-E934-4B77-96FC-BDC33A056BF1")]
	public class wrapperBase
	{
		public Type wrappedType;

		public object wrappedObject;

		public typeDescriptor typeD;

		public wrapperBase()
		{
		}

		public virtual object __getProperty(string property, params object[] args)
		{
			return null;
		}

		public virtual object __invokeMethod(string method, params object[] args)
		{
			return null;
		}

		public virtual void __setProperty(string property, string value, params object[] args)
		{
		}
	}
}