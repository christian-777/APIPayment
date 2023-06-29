using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIPayment.Domain.Contracts;
using APIPayment.Infra.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace APIPayment.Infra.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly DbContext _context;

    public UnitOfWork(DbContext context)
    {
        _context = context;
    }

    public async Task<bool> Commit()
    {
        using(var transaction= await _context.Database.BeginTransactionAsync())
        {
            try
            {
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                return false;
            }
            return true;
        }
        
    }
}
