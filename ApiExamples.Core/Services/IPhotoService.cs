using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;


namespace ApiExamples.Core.Services
{
    public interface IPhotoService
    {
        Task<bool> TakePhoto();
    }
}
