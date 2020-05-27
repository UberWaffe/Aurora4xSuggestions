using Aurora.AddInsInterfacing.ExtraGameManipulation.Interface;
using Aurora.AddInsInterfacing.ExtraGameManipulation.Models;
using Aurora.AddInsPersist.SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aurora.AddInsPersist.ExtraGameManipulation
{
    public class GameManipPersistentStorage : IGameManipPersistentStorage
    {
        private SQLiteDatabase databaseHandler;

        public GameManipPersistentStorage()
        {
            this.databaseHandler = new SQLiteDatabase();
        }

        public List<TechType> GetAllTechTypesFromStorage()
        {
            var result = databaseHandler.GetQueryResult<TechType>("SELECT * FROM DIM_TechType");
            return result;
        }
    }
}
