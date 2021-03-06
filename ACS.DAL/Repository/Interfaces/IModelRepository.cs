using ASC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.DAL.Repository.Interfaces
{
    public interface IModelRepository
    {
        IEnumerable<Model> GetModels();
        Model GetModel(int id);
        string CreateModel(Model model);
        string EditModel(Model model);
        string DeleteModel(int id);
    }
}
