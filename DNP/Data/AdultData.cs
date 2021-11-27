using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using FileData;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DNP.Data
{
    public class AdultData : IAdultData
    {
        private AdultContext adultContext;

        public AdultData(AdultContext adultContext)
        {
            this.adultContext = adultContext;
        }

       

        public async Task<List<Adult>> GetAdults()
        {
           
            return await adultContext.Adults.Include(j => j.JobTitle).ToListAsync();
            
        }

        public async Task<Adult> AddAdults(Adult adult)
        {
            await adultContext.Adults.AddAsync(adult);
            await adultContext.Jobs.AddAsync(adult.JobTitle);
            await adultContext.SaveChangesAsync();

            return adult;
            
        }

        public async Task RemoveAdults(int adultId)
        {
            
            Adult toRemove = await adultContext.Adults.FirstOrDefaultAsync(a => a.Id == adultId);
            adultContext.Adults.Remove(toRemove);
            adultContext.SaveChanges();
        }

        public async Task<Adult> Update(Adult adult)
        {
            adultContext.Update(adult);

            await adultContext.SaveChangesAsync();

            return adult;
        }

        public async Task<Adult> Get(int id)
        {
            return adultContext.Adults.FirstOrDefault(a => a.Id == id);
        }
    }
}