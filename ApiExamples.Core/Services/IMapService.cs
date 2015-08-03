using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiExamples.Core.Services
{
    public interface IMapService
    {
        bool LoadNutiteqMap(Nutiteq.Ui.MapView mapViewer);
    }
}
