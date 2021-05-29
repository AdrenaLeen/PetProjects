using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System;
using System.Linq;

namespace ConventionsAndConstraints.Infrastructure
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class AdditionalActionsAttribute : Attribute, IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            var actions = controller.Actions.Select(a => new
            {
                Action = a,
                Names = a.Attributes.Select(attr => (attr as AddActionAttribute)?.AdditionalName)
            });
            foreach (var item in actions.ToList())
            {
                foreach (string name in item.Names)
                {
                    controller.Actions.Add(new ActionModel(item.Action)
                    {
                        ActionName = name
                    });
                }
            }
        }
    }
}
