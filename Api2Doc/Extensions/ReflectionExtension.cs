using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Api2Doc.Extensions
{
    public static class ReflectionExtension
    {
        /// <summary>
        /// 访问私有字段
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static T GetPrivateField<T>(this object instance, string name)
        {
            BindingFlags flag = BindingFlags.Instance | BindingFlags.NonPublic;
            Type type = instance.GetType();

            FieldInfo field = type.GetField(name, flag);
            return (T)field?.GetValue(instance);
        }

        /// <summary>
        /// 设置私有字段
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public static void SetPrivateField(this object instance, string name, object value)
        {
            BindingFlags flag = BindingFlags.Instance | BindingFlags.NonPublic;
            Type type = instance.GetType();

            FieldInfo field = type.GetField(name, flag);
            field?.SetValue(instance, value);
        }

        /// <summary>
        /// 访问私有属性
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static T GetPrivateProperty<T>(this object instance, string name)
        {
            BindingFlags flag = BindingFlags.Instance | BindingFlags.NonPublic;
            Type type = instance.GetType();

            PropertyInfo property = type.GetProperty(name, flag);
            return (T)property?.GetValue(instance, null);
        }

        /// <summary>
        /// 设置私有属性
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public static void SetPrivateProperty(this object instance, string name, object value)
        {
            BindingFlags flag = BindingFlags.Instance | BindingFlags.NonPublic;
            Type type = instance.GetType();

            PropertyInfo property = type.GetProperty(name, flag);
            property?.SetValue(instance, value, null);
        }

        /// <summary>
        /// 访问私有方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance"></param>
        /// <param name="name"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static T CallPrivateMethod<T>(this object instance, string name, params object[] param)
        {
            BindingFlags flag = BindingFlags.Instance | BindingFlags.NonPublic;
            Type type = instance.GetType();

            MethodInfo method = type.GetMethod(name, flag);
            return (T)method?.Invoke(instance, param);
        }
    }
}
