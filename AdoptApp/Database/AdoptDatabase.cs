﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdoptApp.Models;

namespace AdoptApp.Database
{
    public class AdoptDatabase
    {
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });

        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;

        public AdoptDatabase()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(CaseWorker).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(CaseWorker)).ConfigureAwait(false);
                }
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(Case).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(Case)).ConfigureAwait(false);
                }
                if(!Database.TableMappings.Any(m => m.MappedType.Name == typeof(Family).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(Family)).ConfigureAwait(false);
                }
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(Home).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(Home)).ConfigureAwait(false);
                }
                initialized = true;
            }
        }

        public Task<int> SaveHome(Home home)
        {
            if (home.Id == 0)
                return Database.InsertAsync(home);
            else
                return Database.UpdateAsync(home);
        }

        public Task<int> SaveFamily(Family family)
        {
            if (family.Id == 0)
                return Database.InsertAsync(family);
            else
                return Database.UpdateAsync(family);
        }

        public Task<int> SaveCaseWorker(CaseWorker worker)
        {
            if(worker.Id == 0)
                return Database.InsertAsync(worker);
            else
                return Database.UpdateAsync(worker);
        }

        public Task<int> SaveCase(Case child)
        {
            if (child.Id == 0)
                return Database.InsertAsync(child);
            else
                return Database.UpdateAsync(child);
        }

        public Task<List<Case>> GetCases()
        {
            return Database.Table<Case>().ToListAsync();
        }

        public Task<int> DeleteCase(Case child)
        {
            return Database.DeleteAsync(child);
        }
    }
}