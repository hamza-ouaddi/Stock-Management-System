using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gestion.classes;

namespace Gestion.IDao
{
    interface IDao<T>
    {
        void add(T p);
        void delete(int id);
        T getById(int id);
        List<T> getAll();
        void update(T objet);
    }
}
