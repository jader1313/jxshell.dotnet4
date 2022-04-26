using System;
using System.Runtime.InteropServices;
using System.Reflection;
using jxshell.dotnet4;
namespace jxshell.dotnet4
{

    [ComVisible(true)]
    [Guid("c12d197b-a878-44f9-952d-6ef9cf87152d")]
    public class C1fa0fedcc79791dfe282331eaa2b3332cbb8db92_static : wrapperStatic
    {
        public C1fa0fedcc79791dfe282331eaa2b3332cbb8db92_static(Type t, typeDescriptor td) : base(t, td) { }
        static invoker __invoker = new invoker();
        public override wrapper getWrapper(object o) { return new C1fa0fedcc79791dfe282331eaa2b3332cbb8db92(o, typeD); }
        /* FIELDS */
        /* MÉTODOS */
        public object Equals([Optional] object a0, [Optional] object a1)
        {
            object[] args = { a0, a1 };
            var m = typeD.methods[5];
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
            var m = typeD.methods[6];
            var method = m.getMethodForParameters(ref args);
            try
            {
                return __process(method.Invoke(null, args));
            }
            catch (Exception e) { if (e.InnerException != null) { throw e.InnerException; } throw e; }

        }
        /* PROPIEDADES  */
        public object construct([Optional] object a0)
        {
            object[] args = { a0 };
            var m = typeD.methods[4];
            var method = m.getConstructorForParameters(ref args);
            try
            {
                return getWrapper(method.Invoke(args));
            }
            catch (Exception e) { if (e.InnerException != null) { throw e.InnerException; } throw e; }

        }
    }

    [ComVisible(true)]
    [Guid("5f6bc315-a69e-4874-95b8-1f335a01883b")]
    public class C1fa0fedcc79791dfe282331eaa2b3332cbb8db92 : wrapper
    {
        public C1fa0fedcc79791dfe282331eaa2b3332cbb8db92(object o, typeDescriptor td) : base(o, td) { }
        public C1fa0fedcc79791dfe282331eaa2b3332cbb8db92() : base() { }
        static jxshell.dotnet4.invoker __invoker = new invoker();
        /* FIELDS */
        /* MÉTODOS */
        public object GetType()
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
        public object ToString()
        {
            object[] args = { };
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
        public object Equals([Optional] object a0)
        {
            object[] args = { a0 };
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
        public object GetHashCode()
        {
            object[] args = { };
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
        /* PROPIEDADES  */
        public object CaminhoArquivo
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
    }
}
class program { public static void main() { } }
