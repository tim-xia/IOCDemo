using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.Practices.Unity.Configuration;
using Unity;
using Unity.Attributes;

namespace IOCDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * 1.0普通版
             * 使用IOS手机打电话
             * 使用安卓手机打电话
             * 直观简单，
             * 但可拓展性差
             */
            CallSomebody1 callSomebody1 =new CallSomebody1(){Phone = new IOSPhone1()};
            callSomebody1.Call();

            /*2.0 接口版
             * 使用IOS手机打电话
             * 使用安卓手机打电话
             * 使用接口进行拓展，代码得到改善，
             * 但仍然需要修改控制台代码
             */
            CallSomebody2 callSomebody2 = new CallSomebody2() {Phone = new AndroidPhone2()};
            callSomebody2.Call();

            /*3.0 Unity版
             *Unity使用入门
             */
            IUnityContainer container = new UnityContainer();
            container.RegisterType<IPhone, AndroidPhone2>();
            IPhone phone = container.Resolve<IPhone>();
            var callSomebody3 = new CallSomebody2 {Phone = phone};
            callSomebody3.Call();

            /*4.0 Unity 配置文件版
             *
             */
            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap
            {
                ExeConfigFilename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"UnityXml\UnityConfig.xml")
            };
            Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            UnityConfigurationSection section = (UnityConfigurationSection)configuration.GetSection(UnityConfigurationSection.SectionName);
            IUnityContainer xmlContainer = new UnityContainer();
            section.Configure(xmlContainer, "unityContainer");
            IPhone xmlPhone = xmlContainer.Resolve<IPhone>();
            var callSomebody4 = new CallSomebody2() {Phone = xmlPhone};
            callSomebody4.Call();

            /*4.5 Unity 配置文件版 增加多配置
             * 配置文件修改，增加name标记
             */
            ExeConfigurationFileMap fileMap1 = new ExeConfigurationFileMap
            {
                ExeConfigFilename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"UnityXml\UnityConfig.xml")
            };
            Configuration configuration1 = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            UnityConfigurationSection section1 = (UnityConfigurationSection)configuration1.GetSection(UnityConfigurationSection.SectionName);
            IUnityContainer xmlContainer1 = new UnityContainer();
            section1.Configure(xmlContainer1, "unityContainer");
            IPhone xmlPhone2 = xmlContainer1.Resolve<IPhone>("Apple");
            IPhone xmlIOS2 = xmlContainer1.Resolve<IPhone>("Android");
            var callSomebody4_5 = new CallSomebody2() { Phone = xmlPhone2 };
            var callSomebody4_6 = new CallSomebody2() { Phone = xmlIOS2};
            callSomebody4_5.Call();
            callSomebody4_6.Call();

            /*5.0 Unity使用注入
             *自动生成
             */
            ExeConfigurationFileMap fileMap2 = new ExeConfigurationFileMap
            {
                ExeConfigFilename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"UnityXml\UnityConfig.xml")
            };
            Configuration configuration2 = ConfigurationManager.OpenMappedExeConfiguration(fileMap2, ConfigurationUserLevel.None);
            UnityConfigurationSection section2 = (UnityConfigurationSection)configuration2.GetSection(UnityConfigurationSection.SectionName);
            IUnityContainer xmlContainer2 = new UnityContainer();
            section2.Configure(xmlContainer2, "unityContainer");
            var callSomebody5 = xmlContainer2.Resolve<CallSomebody5>();
            callSomebody5?.Call();
            Console.ReadLine();

        }
    }
}
