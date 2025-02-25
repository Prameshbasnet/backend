﻿using API.Data.Contracts;
using API.Models.Feedbacks;
using API.Models.Feedbacks.Contracts;
using API.PromoCodes;
using API.PromoCodes.Contracts;
using Microsoft.EntityFrameworkCore.Storage;

namespace API.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly APIDbContext _db;
        private IDbContextTransaction _transaction;

        public UnitOfWork(APIDbContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
            PromoCodes = new PromoCodeRepository(_db);
            FeedBacks = new FeedBackRepository(_db);
        }
        public IPromoCodeRepository PromoCodes { get; private set; }
        public IFeedBackRepository FeedBacks { get; private set; }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task<string> SaveAsync()
        {
            try
            {
                var result = await _db.SaveChangesAsync();
                if (result > 0)
                {
                    return "Save successful";
                }
                else if (result == 0)
                {
                    return "No changes were saved";
                }
                else
                {
                    return "Save operation encountered an error";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
