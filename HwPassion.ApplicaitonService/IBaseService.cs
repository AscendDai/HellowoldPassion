using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwPassion.ApplicaitonService
{
    public interface IBaseService<TEntity> : IService<TEntity, int> where TEntity : class
    {

    }
}
