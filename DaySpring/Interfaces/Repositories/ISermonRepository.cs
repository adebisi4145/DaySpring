﻿using DaySpring.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.Interfaces.Repositories
{
    public interface ISermonRepository : IRepository<Sermon>
    {
        Task<List<Sermon>> GetSermonsByTitle(string title);
        Task<List<Sermon>> GetSermonsByPreacher(int id);
        Task<List<Sermon>> GetSermons();
        Task<Sermon> GetSermon(int id);
    }
}
