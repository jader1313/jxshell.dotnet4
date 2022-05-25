using System;
using System.Runtime.InteropServices;
using System.Reflection;
using System.ComponentModel;

namespace jxshell.dotnet4
{

    [ComVisible(true)]
    [Guid("379e175f-f180-4d06-b5c2-18ed9b8a40f0")]
    public class C712783c425134c5b5fcc1deccde0e94e859b79a5_static : wrapperStatic
{
        public C712783c425134c5b5fcc1deccde0e94e859b79a5_static(Type t, typeDescriptor td) : base(t, td) { }
        static invoker __invoker = new invoker();
        public override wrapper getWrapper(object o) { return new C712783c425134c5b5fcc1deccde0e94e859b79a5(o, typeD); }
        /* FIELDS */
        /* MÉTODOS */
        public object generic_As([Optional] object type0)
        {
            System.Collections.Generic.List<System.Type> genericArguments = new System.Collections.Generic.List<System.Type>(1); if (type0 != null) { if (type0 is wrapper) { genericArguments.Add((System.Type)(((wrapper)type0).wrappedObject)); } else { genericArguments.Add(Manager.lastManager.getTypeOrGenericType(type0.ToString())); } }
            object[] args = { };
            var m = typeD.methods[19];
            var method = m.getGenericMethodForParameters(genericArguments.ToArray(), ref args);
            try
            {
                return __process(method.Invoke(null, args));
            }
            catch (Exception e) { if (e.InnerException != null) { throw e.InnerException; } throw e; }

        }
        public object FromAbi([Optional] object a0)
        {
            object[] args = { a0 };
            var m = typeD.methods[20];
            var method = m.getMethodForParameters(ref args);
            try
            {
                return __process(method.Invoke(null, args));
            }
            catch (Exception e) { if (e.InnerException != null) { throw e.InnerException; } throw e; }

        }
        public object op_Equality([Optional] object a0, [Optional] object a1)
        {
            object[] args = { a0, a1 };
            var m = typeD.methods[21];
            var method = m.getMethodForParameters(ref args);
            try
            {
                return __process(method.Invoke(null, args));
            }
            catch (Exception e) { if (e.InnerException != null) { throw e.InnerException; } throw e; }

        }
        public object op_Inequality([Optional] object a0, [Optional] object a1)
        {
            object[] args = { a0, a1 };
            var m = typeD.methods[22];
            var method = m.getMethodForParameters(ref args);
            try
            {
                return __process(method.Invoke(null, args));
            }
            catch (Exception e) { if (e.InnerException != null) { throw e.InnerException; } throw e; }

        }
        public object Equals([Optional] object a0, [Optional] object a1)
        {
            object[] args = { a0, a1 };
            var m = typeD.methods[23];
            var method = m.getMethodForParameters(ref args);
            try
            {
                return __process(method.Invoke(null, args));
            }
            catch (Exception e) { if (e.InnerException != null) { throw e.InnerException; } throw e; }

        }
        public object ReferenceEquals([Optional] object a0, [Optional] object a1)
        {
            object[] args = { a0, a1 };
            var m = typeD.methods[24];
            var method = m.getMethodForParameters(ref args);
            try
            {
                return __process(method.Invoke(null, args));
            }
            catch (Exception e) { if (e.InnerException != null) { throw e.InnerException; } throw e; }

        }
        /* PROPIEDADES  */
        public object Current
        {
            get
            {
                object[] args = { };
                var m = typeD.properties[9];
                var method = m.getPropertyForParameters(ref args);
                try
                {
                    return __process(method.GetValue(null, args));
                }
                catch (Exception e) { if (e.InnerException != null) { throw e.InnerException; } throw e; }

            }
            set
            {
                object[] args = { };
                var m = typeD.properties[9];
                var method = m.getPropertyForParameters(ref args);
                try
                {
                    if (value is wrapper) { value = ((wrapper)value).wrappedObject; }
                    method.SetValue(null, value, args);
                }
                catch (Exception e) { if (e.InnerException != null) { throw e.InnerException; } throw e; }

            }
        }
        public object construct()
        {
            object[] args = { };
            var m = typeD.methods[18];
            var method = m.getConstructorForParameters(ref args);
            try
            {
                return getWrapper(method.Invoke(args));
            }
            catch (Exception e) { if (e.InnerException != null) { throw e.InnerException; } throw e; }

        }
    }

    [ComVisible(true)]
    [Guid("bc392fe4-bc31-4d18-91bb-43c4f09e3844")]
    public class C712783c425134c5b5fcc1deccde0e94e859b79a5 : wrapper
{
        public C712783c425134c5b5fcc1deccde0e94e859b79a5(object o, typeDescriptor td) : base(o, td) { }
        public C712783c425134c5b5fcc1deccde0e94e859b79a5() : base() { }
        static jxshell.dotnet4.invoker __invoker = new invoker();
        /* FIELDS */
        /* MÉTODOS */
        public object InitializeComponent()
        {
            object[] args = { };
            var m = typeD.methods[0];
            try
            {
                var method = m.getMethodForParameters(ref args);
                if (typeDescriptor.isSpecialMethod(method))
                {
                    return __process(method.Invoke(wrappedObject, args));
                }
                else
                {
                    object ret = null;
                    System.Reflection.MethodInfo mi = (System.Reflection.MethodInfo)method;
                    if (mi.ReturnType == typeof(void))
                        __invoker.invokeMethodVoid(wrappedObject, mi.Name, args);
                    else
                        ret = __invoker.invokeMethod(wrappedObject, mi.Name, args);
                    return __process(ret);
                }
            }
            catch (Exception e) { if (e.InnerException != null) { throw e.InnerException; } throw e; }

        }
        public object Connect([Optional] object a0, [Optional] object a1)
        {
            object[] args = { a0, a1 };
            var m = typeD.methods[1];
            try
            {
                var method = m.getMethodForParameters(ref args);
                if (typeDescriptor.isSpecialMethod(method))
                {
                    return __process(method.Invoke(wrappedObject, args));
                }
                else
                {
                    object ret = null;
                    System.Reflection.MethodInfo mi = (System.Reflection.MethodInfo)method;
                    if (mi.ReturnType == typeof(void))
                        __invoker.invokeMethodVoid(wrappedObject, mi.Name, args);
                    else
                        ret = __invoker.invokeMethod(wrappedObject, mi.Name, args);
                    return __process(ret);
                }
            }
            catch (Exception e) { if (e.InnerException != null) { throw e.InnerException; } throw e; }

        }
        public object GetBindingConnector([Optional] object a0, [Optional] object a1)
        {
            object[] args = { a0, a1 };
            var m = typeD.methods[2];
            try
            {
                var method = m.getMethodForParameters(ref args);
                if (typeDescriptor.isSpecialMethod(method))
                {
                    return __process(method.Invoke(wrappedObject, args));
                }
                else
                {
                    object ret = null;
                    System.Reflection.MethodInfo mi = (System.Reflection.MethodInfo)method;
                    if (mi.ReturnType == typeof(void))
                        __invoker.invokeMethodVoid(wrappedObject, mi.Name, args);
                    else
                        ret = __invoker.invokeMethod(wrappedObject, mi.Name, args);
                    return __process(ret);
                }
            }
            catch (Exception e) { if (e.InnerException != null) { throw e.InnerException; } throw e; }

        }
        public object Equals([Optional] object a0)
        {
            object[] args = { a0 };
            var m = typeD.methods[3];
            try
            {
                var method = m.getMethodForParameters(ref args);
                if (typeDescriptor.isSpecialMethod(method))
                {
                    return __process(method.Invoke(wrappedObject, args));
                }
                else
                {
                    object ret = null;
                    System.Reflection.MethodInfo mi = (System.Reflection.MethodInfo)method;
                    if (mi.ReturnType == typeof(void))
                        __invoker.invokeMethodVoid(wrappedObject, mi.Name, args);
                    else
                        ret = __invoker.invokeMethod(wrappedObject, mi.Name, args);
                    return __process(ret);
                }
            }
            catch (Exception e) { if (e.InnerException != null) { throw e.InnerException; } throw e; }

        }
        public object GetHashCode()
        {
            object[] args = { };
            var m = typeD.methods[4];
            try
            {
                var method = m.getMethodForParameters(ref args);
                if (typeDescriptor.isSpecialMethod(method))
                {
                    return __process(method.Invoke(wrappedObject, args));
                }
                else
                {
                    object ret = null;
                    System.Reflection.MethodInfo mi = (System.Reflection.MethodInfo)method;
                    if (mi.ReturnType == typeof(void))
                        __invoker.invokeMethodVoid(wrappedObject, mi.Name, args);
                    else
                        ret = __invoker.invokeMethod(wrappedObject, mi.Name, args);
                    return __process(ret);
                }
            }
            catch (Exception e) { if (e.InnerException != null) { throw e.InnerException; } throw e; }

        }
        public object Activate()
        {
            object[] args = { };
            var m = typeD.methods[5];
            try
            {
                var method = m.getMethodForParameters(ref args);
                if (typeDescriptor.isSpecialMethod(method))
                {
                    return __process(method.Invoke(wrappedObject, args));
                }
                else
                {
                    object ret = null;
                    System.Reflection.MethodInfo mi = (System.Reflection.MethodInfo)method;
                    if (mi.ReturnType == typeof(void))
                        __invoker.invokeMethodVoid(wrappedObject, mi.Name, args);
                    else
                        ret = __invoker.invokeMethod(wrappedObject, mi.Name, args);
                    return __process(ret);
                }
            }
            catch (Exception e) { if (e.InnerException != null) { throw e.InnerException; } throw e; }

        }
        public object Close()
        {
            object[] args = { };
            var m = typeD.methods[6];
            try
            {
                var method = m.getMethodForParameters(ref args);
                if (typeDescriptor.isSpecialMethod(method))
                {
                    return __process(method.Invoke(wrappedObject, args));
                }
                else
                {
                    object ret = null;
                    System.Reflection.MethodInfo mi = (System.Reflection.MethodInfo)method;
                    if (mi.ReturnType == typeof(void))
                        __invoker.invokeMethodVoid(wrappedObject, mi.Name, args);
                    else
                        ret = __invoker.invokeMethod(wrappedObject, mi.Name, args);
                    return __process(ret);
                }
            }
            catch (Exception e) { if (e.InnerException != null) { throw e.InnerException; } throw e; }

        }
        public object SetTitleBar([Optional] object a0)
        {
            object[] args = { a0 };
            var m = typeD.methods[7];
            try
            {
                var method = m.getMethodForParameters(ref args);
                if (typeDescriptor.isSpecialMethod(method))
                {
                    return __process(method.Invoke(wrappedObject, args));
                }
                else
                {
                    object ret = null;
                    System.Reflection.MethodInfo mi = (System.Reflection.MethodInfo)method;
                    if (mi.ReturnType == typeof(void))
                        __invoker.invokeMethodVoid(wrappedObject, mi.Name, args);
                    else
                        ret = __invoker.invokeMethod(wrappedObject, mi.Name, args);
                    return __process(ret);
                }
            }
            catch (Exception e) { if (e.InnerException != null) { throw e.InnerException; } throw e; }

        }
        public object add_Activated([Optional] object a0)
        {
            object[] args = { a0 };
            var m = typeD.methods[8];
            try
            {
                var method = m.getMethodForParameters(ref args);
                if (typeDescriptor.isSpecialMethod(method))
                {
                    return __process(method.Invoke(wrappedObject, args));
                }
                else
                {
                    object ret = null;
                    System.Reflection.MethodInfo mi = (System.Reflection.MethodInfo)method;
                    if (mi.ReturnType == typeof(void))
                        __invoker.invokeMethodVoid(wrappedObject, mi.Name, args);
                    else
                        ret = __invoker.invokeMethod(wrappedObject, mi.Name, args);
                    return __process(ret);
                }
            }
            catch (Exception e) { if (e.InnerException != null) { throw e.InnerException; } throw e; }

        }
        public object remove_Activated([Optional] object a0)
        {
            object[] args = { a0 };
            var m = typeD.methods[9];
            try
            {
                var method = m.getMethodForParameters(ref args);
                if (typeDescriptor.isSpecialMethod(method))
                {
                    return __process(method.Invoke(wrappedObject, args));
                }
                else
                {
                    object ret = null;
                    System.Reflection.MethodInfo mi = (System.Reflection.MethodInfo)method;
                    if (mi.ReturnType == typeof(void))
                        __invoker.invokeMethodVoid(wrappedObject, mi.Name, args);
                    else
                        ret = __invoker.invokeMethod(wrappedObject, mi.Name, args);
                    return __process(ret);
                }
            }
            catch (Exception e) { if (e.InnerException != null) { throw e.InnerException; } throw e; }

        }
        public object add_Closed([Optional] object a0)
        {
            object[] args = { a0 };
            var m = typeD.methods[10];
            try
            {
                var method = m.getMethodForParameters(ref args);
                if (typeDescriptor.isSpecialMethod(method))
                {
                    return __process(method.Invoke(wrappedObject, args));
                }
                else
                {
                    object ret = null;
                    System.Reflection.MethodInfo mi = (System.Reflection.MethodInfo)method;
                    if (mi.ReturnType == typeof(void))
                        __invoker.invokeMethodVoid(wrappedObject, mi.Name, args);
                    else
                        ret = __invoker.invokeMethod(wrappedObject, mi.Name, args);
                    return __process(ret);
                }
            }
            catch (Exception e) { if (e.InnerException != null) { throw e.InnerException; } throw e; }

        }
        public object remove_Closed([Optional] object a0)
        {
            object[] args = { a0 };
            var m = typeD.methods[11];
            try
            {
                var method = m.getMethodForParameters(ref args);
                if (typeDescriptor.isSpecialMethod(method))
                {
                    return __process(method.Invoke(wrappedObject, args));
                }
                else
                {
                    object ret = null;
                    System.Reflection.MethodInfo mi = (System.Reflection.MethodInfo)method;
                    if (mi.ReturnType == typeof(void))
                        __invoker.invokeMethodVoid(wrappedObject, mi.Name, args);
                    else
                        ret = __invoker.invokeMethod(wrappedObject, mi.Name, args);
                    return __process(ret);
                }
            }
            catch (Exception e) { if (e.InnerException != null) { throw e.InnerException; } throw e; }

        }
        public object add_SizeChanged([Optional] object a0)
        {
            object[] args = { a0 };
            var m = typeD.methods[12];
            try
            {
                var method = m.getMethodForParameters(ref args);
                if (typeDescriptor.isSpecialMethod(method))
                {
                    return __process(method.Invoke(wrappedObject, args));
                }
                else
                {
                    object ret = null;
                    System.Reflection.MethodInfo mi = (System.Reflection.MethodInfo)method;
                    if (mi.ReturnType == typeof(void))
                        __invoker.invokeMethodVoid(wrappedObject, mi.Name, args);
                    else
                        ret = __invoker.invokeMethod(wrappedObject, mi.Name, args);
                    return __process(ret);
                }
            }
            catch (Exception e) { if (e.InnerException != null) { throw e.InnerException; } throw e; }

        }
        public object remove_SizeChanged([Optional] object a0)
        {
            object[] args = { a0 };
            var m = typeD.methods[13];
            try
            {
                var method = m.getMethodForParameters(ref args);
                if (typeDescriptor.isSpecialMethod(method))
                {
                    return __process(method.Invoke(wrappedObject, args));
                }
                else
                {
                    object ret = null;
                    System.Reflection.MethodInfo mi = (System.Reflection.MethodInfo)method;
                    if (mi.ReturnType == typeof(void))
                        __invoker.invokeMethodVoid(wrappedObject, mi.Name, args);
                    else
                        ret = __invoker.invokeMethod(wrappedObject, mi.Name, args);
                    return __process(ret);
                }
            }
            catch (Exception e) { if (e.InnerException != null) { throw e.InnerException; } throw e; }

        }
        public object add_VisibilityChanged([Optional] object a0)
        {
            object[] args = { a0 };
            var m = typeD.methods[14];
            try
            {
                var method = m.getMethodForParameters(ref args);
                if (typeDescriptor.isSpecialMethod(method))
                {
                    return __process(method.Invoke(wrappedObject, args));
                }
                else
                {
                    object ret = null;
                    System.Reflection.MethodInfo mi = (System.Reflection.MethodInfo)method;
                    if (mi.ReturnType == typeof(void))
                        __invoker.invokeMethodVoid(wrappedObject, mi.Name, args);
                    else
                        ret = __invoker.invokeMethod(wrappedObject, mi.Name, args);
                    return __process(ret);
                }
            }
            catch (Exception e) { if (e.InnerException != null) { throw e.InnerException; } throw e; }

        }
        public object remove_VisibilityChanged([Optional] object a0)
        {
            object[] args = { a0 };
            var m = typeD.methods[15];
            try
            {
                var method = m.getMethodForParameters(ref args);
                if (typeDescriptor.isSpecialMethod(method))
                {
                    return __process(method.Invoke(wrappedObject, args));
                }
                else
                {
                    object ret = null;
                    System.Reflection.MethodInfo mi = (System.Reflection.MethodInfo)method;
                    if (mi.ReturnType == typeof(void))
                        __invoker.invokeMethodVoid(wrappedObject, mi.Name, args);
                    else
                        ret = __invoker.invokeMethod(wrappedObject, mi.Name, args);
                    return __process(ret);
                }
            }
            catch (Exception e) { if (e.InnerException != null) { throw e.InnerException; } throw e; }

        }
        public object GetType()
        {
            object[] args = { };
            var m = typeD.methods[16];
            try
            {
                var method = m.getMethodForParameters(ref args);
                if (typeDescriptor.isSpecialMethod(method))
                {
                    return __process(method.Invoke(wrappedObject, args));
                }
                else
                {
                    object ret = null;
                    System.Reflection.MethodInfo mi = (System.Reflection.MethodInfo)method;
                    if (mi.ReturnType == typeof(void))
                        __invoker.invokeMethodVoid(wrappedObject, mi.Name, args);
                    else
                        ret = __invoker.invokeMethod(wrappedObject, mi.Name, args);
                    return __process(ret);
                }
            }
            catch (Exception e) { if (e.InnerException != null) { throw e.InnerException; } throw e; }

        }
        public object ToString()
        {
            object[] args = { };
            var m = typeD.methods[17];
            try
            {
                var method = m.getMethodForParameters(ref args);
                if (typeDescriptor.isSpecialMethod(method))
                {
                    return __process(method.Invoke(wrappedObject, args));
                }
                else
                {
                    object ret = null;
                    System.Reflection.MethodInfo mi = (System.Reflection.MethodInfo)method;
                    if (mi.ReturnType == typeof(void))
                        __invoker.invokeMethodVoid(wrappedObject, mi.Name, args);
                    else
                        ret = __invoker.invokeMethod(wrappedObject, mi.Name, args);
                    return __process(ret);
                }
            }
            catch (Exception e) { if (e.InnerException != null) { throw e.InnerException; } throw e; }

        }
        /* PROPIEDADES  */
        public object Bounds
        {
            get
            {
                object[] args = { };
                var m = typeD.properties[0];
                try
                {
                    var method = m.getPropertyForParameters(ref args);
                    object o = method.GetValue(wrappedObject, args); return __process(o);
                }
                catch (Exception e) { if (e.InnerException != null) { throw e.InnerException; } throw e; }

            }
            set
            {
                object[] args = { };
                var m = typeD.properties[0];
                var method = m.getPropertyForParameters(ref args);
                try
                {
                    if (value is wrapper) { value = ((wrapper)value).wrappedObject; }
                    method.SetValue(wrappedObject, value, args);
                }
                catch (Exception e) { if (e.InnerException != null) { throw e.InnerException; } throw e; }

            }
        }
        public object Compositor
        {
            get
            {
                object[] args = { };
                var m = typeD.properties[1];
                try
                {
                    var method = m.getPropertyForParameters(ref args);
                    object o = method.GetValue(wrappedObject, args); return __process(o);
                }
                catch (Exception e) { if (e.InnerException != null) { throw e.InnerException; } throw e; }

            }
            set
            {
                object[] args = { };
                var m = typeD.properties[1];
                var method = m.getPropertyForParameters(ref args);
                try
                {
                    if (value is wrapper) { value = ((wrapper)value).wrappedObject; }
                    method.SetValue(wrappedObject, value, args);
                }
                catch (Exception e) { if (e.InnerException != null) { throw e.InnerException; } throw e; }

            }
        }
        public object Content
        {
            get
            {
                object[] args = { };
                var m = typeD.properties[2];
                try
                {
                    var method = m.getPropertyForParameters(ref args);
                    object o = method.GetValue(wrappedObject, args); return __process(o);
                }
                catch (Exception e) { if (e.InnerException != null) { throw e.InnerException; } throw e; }

            }
            set
            {
                object[] args = { };
                var m = typeD.properties[2];
                var method = m.getPropertyForParameters(ref args);
                try
                {
                    if (value is wrapper) { value = ((wrapper)value).wrappedObject; }
                    method.SetValue(wrappedObject, value, args);
                }
                catch (Exception e) { if (e.InnerException != null) { throw e.InnerException; } throw e; }

            }
        }
        public object CoreWindow
        {
            get
            {
                object[] args = { };
                var m = typeD.properties[3];
                try
                {
                    var method = m.getPropertyForParameters(ref args);
                    object o = method.GetValue(wrappedObject, args); return __process(o);
                }
                catch (Exception e) { if (e.InnerException != null) { throw e.InnerException; } throw e; }

            }
            set
            {
                object[] args = { };
                var m = typeD.properties[3];
                var method = m.getPropertyForParameters(ref args);
                try
                {
                    if (value is wrapper) { value = ((wrapper)value).wrappedObject; }
                    method.SetValue(wrappedObject, value, args);
                }
                catch (Exception e) { if (e.InnerException != null) { throw e.InnerException; } throw e; }

            }
        }
        public object Dispatcher
        {
            get
            {
                object[] args = { };
                var m = typeD.properties[4];
                try
                {
                    var method = m.getPropertyForParameters(ref args);
                    object o = method.GetValue(wrappedObject, args); return __process(o);
                }
                catch (Exception e) { if (e.InnerException != null) { throw e.InnerException; } throw e; }

            }
            set
            {
                object[] args = { };
                var m = typeD.properties[4];
                var method = m.getPropertyForParameters(ref args);
                try
                {
                    if (value is wrapper) { value = ((wrapper)value).wrappedObject; }
                    method.SetValue(wrappedObject, value, args);
                }
                catch (Exception e) { if (e.InnerException != null) { throw e.InnerException; } throw e; }

            }
        }
        public object DispatcherQueue
        {
            get
            {
                object[] args = { };
                var m = typeD.properties[5];
                try
                {
                    var method = m.getPropertyForParameters(ref args);
                    object o = method.GetValue(wrappedObject, args); return __process(o);
                }
                catch (Exception e) { if (e.InnerException != null) { throw e.InnerException; } throw e; }

            }
            set
            {
                object[] args = { };
                var m = typeD.properties[5];
                var method = m.getPropertyForParameters(ref args);
                try
                {
                    if (value is wrapper) { value = ((wrapper)value).wrappedObject; }
                    method.SetValue(wrappedObject, value, args);
                }
                catch (Exception e) { if (e.InnerException != null) { throw e.InnerException; } throw e; }

            }
        }
        public object ExtendsContentIntoTitleBar
        {
            get
            {
                object[] args = { };
                var m = typeD.properties[6];
                try
                {
                    var method = m.getPropertyForParameters(ref args);
                    object o = method.GetValue(wrappedObject, args); return __process(o);
                }
                catch (Exception e) { if (e.InnerException != null) { throw e.InnerException; } throw e; }

            }
            set
            {
                object[] args = { };
                var m = typeD.properties[6];
                var method = m.getPropertyForParameters(ref args);
                try
                {
                    if (value is wrapper) { value = ((wrapper)value).wrappedObject; }
                    method.SetValue(wrappedObject, value, args);
                }
                catch (Exception e) { if (e.InnerException != null) { throw e.InnerException; } throw e; }

            }
        }
        public object Title
        {
            get
            {
                object[] args = { };
                var m = typeD.properties[7];
                try
                {
                    var method = m.getPropertyForParameters(ref args);
                    object o = method.GetValue(wrappedObject, args); return __process(o);
                }
                catch (Exception e) { if (e.InnerException != null) { throw e.InnerException; } throw e; }

            }
            set
            {
                object[] args = { };
                var m = typeD.properties[7];
                var method = m.getPropertyForParameters(ref args);
                try
                {
                    if (value is wrapper) { value = ((wrapper)value).wrappedObject; }
                    method.SetValue(wrappedObject, value, args);
                }
                catch (Exception e) { if (e.InnerException != null) { throw e.InnerException; } throw e; }

            }
        }
        public object Visible
        {
            get
            {
                object[] args = { };
                var m = typeD.properties[8];
                try
                {
                    var method = m.getPropertyForParameters(ref args);
                    object o = method.GetValue(wrappedObject, args); return __process(o);
                }
                catch (Exception e) { if (e.InnerException != null) { throw e.InnerException; } throw e; }

            }
            set
            {
                object[] args = { };
                var m = typeD.properties[8];
                var method = m.getPropertyForParameters(ref args);
                try
                {
                    if (value is wrapper) { value = ((wrapper)value).wrappedObject; }
                    method.SetValue(wrappedObject, value, args);
                }
                catch (Exception e) { if (e.InnerException != null) { throw e.InnerException; } throw e; }

            }
        }
    }
}
class program { public static void main() { } }
