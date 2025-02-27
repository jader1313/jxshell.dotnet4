using System;
using System.Runtime.InteropServices;

namespace jxshell.dotnet4
{
	[ComVisible(true)]
    [Guid("13ED0900-57B3-4949-BCCC-0C1E84B8E565")]
    public class delegateWrapper : wrapper
	{
		public object __internalTarget;
        public bool disposed;
		public string __internalMethod = "";

		public delegateWrapper()
		{
		}


        public object target
        {
            get
            {
                return __internalTarget;
            }
        }



        public override void dispose()
        {

            disposed = true;
            // try call destroy 
            try
            {
                invoker inv = new invoker();
                inv.invokeMethod(__internalTarget, "destroy", new object[0]);
            }
            catch (Exception)
            {
            }

            this.__internalTarget = null;
            wrappedObject = null;
        }
		public delegateWrapper(object o) : base(o)
		{
            
		}

		public delegateWrapper(object o, typeDescriptor td) : base(o, td)
		{
		}
	}
}