using System;
using System.Runtime.InteropServices;

namespace jxshell.dotnet4
{
	[ComVisible(true)]
	[Guid("74D4A060-D765-4435-8E76-1B41E6C91F6C")]
	public class enumWrapper : wrapper
	{
		public enumWrapper()
		{
		}

		public enumWrapper(object o) : base(o)
		{
		}

		public enumWrapper(object o, typeDescriptor td) : base(o, td)
		{
		}

		public object bitAnd(enumWrapper other)
		{
			Enum enum1 = (Enum)this.wrappedObject;
			Enum value = (Enum)other.wrappedObject;
			object value2 = Convert.ChangeType(enum1, enum1.GetTypeCode());
			object value3 = Convert.ChangeType(value, enum1.GetTypeCode());
			long num = (long)Convert.ChangeType(value2, TypeCode.Int64) & (long)Convert.ChangeType(value3, TypeCode.Int64);
			object value4 = Convert.ChangeType(num, enum1.GetTypeCode());
			object o = Enum.ToObject(this.wrappedType, value4);
			return wrapper.createWrapper(o, this.typeD);
		}

		public object bitOr(enumWrapper other)
		{
			Enum enum1 = (Enum)this.wrappedObject;
			Enum value = (Enum)other.wrappedObject;
			object value2 = Convert.ChangeType(enum1, enum1.GetTypeCode());
			object value3 = Convert.ChangeType(value, enum1.GetTypeCode());
			long num = (long)Convert.ChangeType(value2, TypeCode.Int64) | (long)Convert.ChangeType(value3, TypeCode.Int64);
			object value4 = Convert.ChangeType(num, enum1.GetTypeCode());
			object o = Enum.ToObject(this.wrappedType, value4);
			return wrapper.createWrapper(o, this.typeD);
		}
	}
}