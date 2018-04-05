using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoLotDAL.EF;
using System.Data.Entity;

namespace AutoLotDAL.Repos
{
    public abstract class BaseRepo<T> where T:class,new()
    {
        public AutoLotEntities Context { get; } = new AutoLotEntities();
        protected DbSet<T> Table;
    }
}
