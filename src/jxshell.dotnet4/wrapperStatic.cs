using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace jxshell.dotnet4
{
	[ComVisible(true)]
	[Guid("FF241366-6C0D-4DB7-B703-CFF0D05E2A2D")]
	public class wrapperStatic : wrapperBase
	{
		internal static Dictionary<Type, wrapperStatic> wrappersStatic;

		static wrapperStatic()
		{
			wrapperStatic.wrappersStatic = new Dictionary<Type, wrapperStatic>();
		}

		public wrapperStatic(Type t, typeDescriptor td)
		{
			this.wrappedObject = t;
			this.wrappedType = t;
			this.typeD = td;
		}

		public override object __getProperty(string property, params object[] args)
		{
			object staticProperty = this.typeD.getStaticProperty(null, property, args);
			return wrapper.getFromObject(staticProperty);
		}

		public override object __invokeMethod(string method, params object[] args)
		{
			object o = this.typeD.invokeStaticMethod(null, method, args);
			return wrapper.getFromObject(o);
		}

		public object __process(object o)
		{
			return wrapper.getFromObject(o);
		}

		public override void __setProperty(string property, string value, params object[] args)
		{
			this.typeD.setStaticProperty(null, property, value, args);
		}

		public virtual wrapper getWrapper(object o)
		{
			return new wrapper(o, this.typeD);
		}

        public static metaObject loadMetavalueFromType(Type t)
        {
            var m = new metaObject();
            string name = typeDescriptor.getNameForType(t);
            m.value = t;
            m.isstatic = true; 
            m.typeDescriptor= typeDescriptor.loadFromType(t, name, false);
            m.name = name;
            return m; 
        }


		public static wrapperStatic loadFromType(Type t)
		{
			wrapperStatic value;
			if (!wrapperStatic.wrappersStatic.TryGetValue(t, out value))
			{
                var typed = typeDescriptor.loadFromType(t);
                
                value = typed.compile();
                
				wrapperStatic.wrappersStatic[t] = value;
			}
			return value;
		}
	}
}