﻿namespace briefCore.Data.Repositories
{
    using System;
    using System.Threading.Tasks;
    using brief.Library.Repositories;
    using Library.Entities;
    using Library.Repositories;

    class EditionFileRepository : IEditionFileRepository
    {
        public EditionFileRepository()
        {
            
        }

        public Task<EditionFile> GetEditionFile(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> CreateEditionFile(EditionFile editionFile)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> UpdateEditionFile(EditionFile editionFile)
        {
            throw new NotImplementedException();
        }

        public Task RemoveEditionFile(EditionFile editionFile)
        {
            throw new NotImplementedException();
        }
    }
}
