using Microsoft.EntityFrameworkCore;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using WebAppFooter.Data;
using WebAppFooter.Entities;

namespace WebAppFooter.Repositories
{
    public interface IFooterRepository
    {
        public Task Create(Footer footer);
        public Task<Footer> GetFooterById(int id);

        public Task<IEnumerable<Footer>> GetAll();

    }

    public class FooterRepository : IFooterRepository
    {
        private readonly DataContext dataContext;

        public FooterRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task Create(Footer footer)
        {
            dataContext.Footers.Add(footer);
            await dataContext.SaveChangesAsync();
        }

        public async Task<Footer> GetFooterById(int id)
        => await dataContext.Footers.FirstOrDefaultAsync(f => f.Id == id);
        

        public async Task<IEnumerable<Footer>> GetAll()
         => await dataContext.Footers.ToListAsync();
    }
}
