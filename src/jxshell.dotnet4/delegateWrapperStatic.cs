using System;
using System.Runtime.InteropServices;

namespace jxshell.dotnet4
{
	[ComVisible(true)]
	[Guid("9A292F30-5C8A-4B57-B353-94CD20B5B46D")]
	public class delegateWrapperStatic : wrapperStatic
	{
		public delegateWrapperStatic(Type t, typeDescriptor td) : base(t, td)
		{
		}

		public object construct(object target, string method)
		{
			delegateWrapper thisWrapper = this.getThisWrapper();
			Delegate @delegate = Delegate.CreateDelegate(this.wrappedType, thisWrapper, "__internalInvoke");
			object obj = @delegate;
			thisWrapper.wrappedObject = @delegate;
			//Delegate delegate = (Delegate)obj;
			thisWrapper.wrappedType = this.wrappedType;
			thisWrapper.typeD = this.typeD;
			thisWrapper.__internalMethod = method;
			thisWrapper.__internalTarget = target;
			return thisWrapper;
		}

		public virtual delegateWrapper getThisWrapper()
		{
			return null;
		}
	}
}