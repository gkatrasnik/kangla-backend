﻿using Domain.Entities;
using Domain.Model;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

public class WateringEventRepository : IWateringEventRepository
{
    private readonly WateringContext _context;

    public WateringEventRepository(WateringContext context)
    {
        _context = context;
    }

    public async Task<PagedResponse<WateringEvent>> GetWateringEventsByPlantIdAsync(int plantId, string userId, int pageNumber, int pageSize)
    {
        var totalRecords = await _context.WateringEvents.AsNoTracking()
            .Where(e => e.PlantId == plantId && e.Plant.UserId == userId)
            .CountAsync();

        var wateringEvents = await _context.WateringEvents.AsNoTracking()
                             .Where(e => e.PlantId == plantId && e.Plant.UserId == userId)
                             .OrderBy(x => x.CreatedAt)
                             .Skip((pageNumber - 1) * pageSize)
                             .Take(pageSize)
                             .ToListAsync();

        return new PagedResponse<WateringEvent>(wateringEvents, pageNumber, pageSize, totalRecords);
    }

    public async Task AddWateringEventAsync(WateringEvent wateringEvent)
    {
        _context.WateringEvents.Add(wateringEvent);
        await _context.SaveChangesAsync();
    }
}
