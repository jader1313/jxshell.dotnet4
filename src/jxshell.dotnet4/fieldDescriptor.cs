using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace jxshell.dotnet4
{
	[ComVisible(true)]
	[Guid("9F05B4A5-DA5B-44CA-82E6-8DF938A28257")]
	public class fieldDescriptor : memberDescriptor
	{
		public FieldInfo fieldInfo;

		public string name;

		public int fieldOrder;

		public fieldDescriptor()
		{
		}

        public object getValue(object o = null)
        {
            return wrapper.getFromObject(this.fieldInfo.GetValue(o));
        }

        public object getMetavalue(object o=null)
        {
            return metaObject.getFromObject(this.fieldInfo.GetValue(o));
        }


        

        public void setValue(object value, object o = null)
		{
			if (value is wrapper)
			{
				value = ((wrapper)value).wrappedObject;
			}
			this.fieldInfo.SetValue(o, value);
		}
	}
}