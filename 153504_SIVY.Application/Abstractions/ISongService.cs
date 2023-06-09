﻿using _153504_SIVY.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _153504_SIVY.MyApplication.Abstractions
{
    public interface ISongService : IBaseService<Song>
    {
        Task<IEnumerable<Song>> GetPerformerSongs(long id);
    }
}
