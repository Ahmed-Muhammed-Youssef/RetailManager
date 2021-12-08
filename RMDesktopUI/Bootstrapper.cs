using Caliburn.Micro;
using RMDesktopUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RMDesktopUI
{
    public class CustomBootstrapper : BootstrapperBase
    {
        private SimpleContainer _simpleContainer = new SimpleContainer();
        public CustomBootstrapper()
        {
            Initialize();
        }
        protected override void Configure()
        {
            _simpleContainer.Instance(_simpleContainer);
            
            _simpleContainer
                .Singleton<IWindowManager, WindowManager>()
                .Singleton<IEventAggregator, EventAggregator>();
            GetType().Assembly.GetTypes()
                              .Where(type => type.IsClass)
                              .Where(type => type.Name.EndsWith("ViewModel"))
                              .ToList()
                              .ForEach(viewModelType => _simpleContainer.RegisterPerRequest
                                (
                                    viewModelType, viewModelType.ToString(), viewModelType)
                                );
        }
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }
        protected override object GetInstance(Type service, string key)
        {
            return _simpleContainer.GetInstance(service, key);
        }
        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _simpleContainer.GetAllInstances(service);
        }
        protected override void BuildUp(object instance)
        {
            _simpleContainer.BuildUp(instance);
        }
    }
}
