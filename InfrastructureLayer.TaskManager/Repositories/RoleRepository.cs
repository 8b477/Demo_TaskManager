using DomainLayer.TaskManager.Entities;
using DomainLayer.TaskManager.Interfaces;
using InfrastructureLayer.TaskManager.Context;

using Microsoft.EntityFrameworkCore;


namespace InfrastructureLayer.TaskManager.Repositories
{
    public class RoleRepository : IRolesRepository
    {

        // <--------------------------------> TODO <-------------------------------->
        // 
        // <--------------------------------> **** <-------------------------------->


        #region <-------------> DEPENDENCY <------------->
        private readonly TaskManagerDbContext _context;
        public RoleRepository(TaskManagerDbContext context) => _context = context;
        #endregion



        #region <-------------> VARIABLE <------------->

        #endregion



        #region <-------------> CREATE <------------->
        public async Task AddRoleAsync(Roles role)
        {
            await _context.Roles.AddAsync(role);
            await _context.SaveChangesAsync();
        }
        #endregion



        #region <-------------> GET <------------->
        public async Task<IEnumerable<Roles>> GetAllRolesAsync()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<Roles?> GetRoleByIdAsync(Guid id)
        {
            return await _context.Roles.FindAsync(id);
        }

        public async Task<Roles?> GetDefaultUserRole()
        {
            string defaultRoleValue = "User";

            var result = await _context.Roles
                                       .FirstOrDefaultAsync(x => x.RoleName.ToUpper() == defaultRoleValue.ToUpper());

            if (result is null)
                return null;

            return result;
        }
        #endregion



        #region <-------------> UPDATE <------------->
        public async Task UpdateRoleAsync(Roles role)
        {
            _context.Roles.Update(role);
            await _context.SaveChangesAsync();
        }
        #endregion



        #region <-------------> DELETE <------------->
        public async Task DeleteRoleAsync(Guid id)
        {
            var role = await GetRoleByIdAsync(id);
            if (role != null)
            {
                _context.Roles.Remove(role);
                await _context.SaveChangesAsync();
            }
        }
        #endregion



        #region <-------------> TOOLS <------------->

        #endregion

    }
}
