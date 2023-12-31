﻿using backend.Data;
using backend.Models;
using backend.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories.CategoryRepository;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    public CategoryRepository(DatabaseContext dbContext) : base(dbContext)
    {
    }

    public DateTime? GetDateFromId(Guid id)
    {
        return _table
            .AsNoTracking()
            .Where(src => src.Id == id)
            .Select(src => src.DateCreated)
            .FirstOrDefault();
    }

    public List<Category> GetAllCategoriesWithIncludes(string? include)
    {
        IQueryable<Category> query = _table;
        if (!string.IsNullOrEmpty(include))
        {
            var relationships = include.Split(',').ToList();
            foreach (var relationship in relationships)
            {
                switch (relationship.ToLower())
                {
                    case "user":
                        query = query.Include(c => c.Users);
                        break;
                }
            }
        }

        return query.ToList();
    }
}