﻿using System;
using Autofac.Annotation;

namespace Autofac.Configuration
{
    /// <summary>
    /// 会扫描有该注解的类 自动装配到autofac容器内
    /// 只能打在class上面 打在abstract不支持会被忽略
    /// 允许打多个 如果打多个有重复的话会覆盖
    /// 打在父类上子类没打的话子类就获取不到
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class Component : System.Attribute
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public Component()
        {
            
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_service"></param>
        public Component(Type _service)
        {
            Service = _service;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_service"></param>
        /// <param name="key"></param>
        public Component(Type _service,string key):this(_service)
        {
            this.Key = key;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="key"></param>
        public Component(string key)
        {
            this.Key = key;
        }
        #region Services
        /// <summary>
        /// 注册的类型
        /// 如果为null则注册为本身类型
        /// </summary>
        public Type[] Services { get; set; }

        /// <summary>
        /// 注册单个的类型
        /// </summary>
        public Type Service { get; }

        /// <summary>
        /// 注册单个的key
        /// </summary>
        public string Key { get;}

        /// <summary>
        ///  注册key 在同一个类型注册多个的时候就需要用到key来做区分
        /// </summary>
        public string[] Keys { get; set; }


        #endregion

        /// <summary>
        /// A Boolean indicating if the component should auto-activate.
        /// </summary>
        public bool AutoActivate { get; set; }

        /// <summary>
        /// A Boolean indicating whether property (setter) injection for the component should be enabled.
        /// </summary>
        public bool InjectProperties { get; set; }

        /// <summary>
        /// 属性自动装配的类型
        /// </summary>
        public InjectPropertyType InjectPropertyType { get; set; } = InjectPropertyType.ALL;

        /// <summary>
        /// 作用域
        /// </summary>
        public AutofacScope AutofacScope { get; set; } = AutofacScope.InstancePerLifetimeScope;

        /// <summary>
        /// 如果设置值为external代表需要自己管理dispose
        /// </summary>
        public string Ownership { get; set; }

    }

    /// <summary>
    /// 自动注册属性类型
    /// </summary>
    public enum InjectPropertyType
    {
        /// <summary>
        /// 代表全部自动装配
        /// </summary>
        ALL,
        /// <summary>
        /// 代表打了Autowired标签的才会装配
        /// </summary>
        Autowired
    }
}
