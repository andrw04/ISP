﻿using _153504_SIVY.Domain.Abstractions;
using _153504_SIVY.Domain.Entities;
using _153504_SIVY.Persistense.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _153504_SIVY.Persistense.Repository
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly Lazy<IRepository<Song>> _songRepository;
        private readonly Lazy<IRepository<Performer>> _performerRepository;

        public EfUnitOfWork(AppDbContext context)
        {
            _context = context;
            _performerRepository = new Lazy<IRepository<Performer>>(() => new EfRepository<Performer>(context));
            _songRepository = new Lazy<IRepository<Song>>(() => new EfRepository<Song>(context));
        }

        public IRepository<Song> SongRepository => _songRepository.Value;

        public IRepository<Performer> PerformerRepository => _performerRepository.Value;

        public async Task CreateDatabaseAsync()
        {
            await _context.Database.EnsureCreatedAsync();
        }

        public async Task RemoveDatabaseAsync()
        {
            await _context.Database.EnsureDeletedAsync();
        }

        public async Task SaveAllAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
