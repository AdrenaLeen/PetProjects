﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace Views.Infrastructure
{
    public class DebugDataViewEngine : IViewEngine
    {
        public ViewEngineResult FindView(ActionContext context, string viewName, bool isMainPage)
        {
            if (viewName == "DebugData") return ViewEngineResult.Found(viewName, new DebugDataView());
            else return ViewEngineResult.NotFound(viewName, new string[] { "(Debug View Engine - FindView)" });
        }

        public ViewEngineResult GetView(string executingFilePath, string viewPath, bool isMainPage) => ViewEngineResult.NotFound(viewPath, new string[] { "(Debug View Engine - GetView)" });
    }
}
