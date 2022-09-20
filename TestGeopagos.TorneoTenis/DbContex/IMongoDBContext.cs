﻿using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestGeopagos.TorneoTenis.Repositories
{
    public interface IMongoDBContext
    {
        IMongoCollection<TorneoDTO> GetCollection<TorneoDTO>(string name);
    }
}
