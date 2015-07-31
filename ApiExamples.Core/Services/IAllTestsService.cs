using System;
using System.Collections.Generic;

namespace ApiExamples.Core.Services
{
    public interface IAllTestsService
    {
        Type NextViewModelType(ViewModels.TestViewModel currentViewModel);
        IList<Type> All { get; }
    }
}