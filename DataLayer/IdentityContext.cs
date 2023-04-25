using BusinessLayer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class IdentityContext
    {
        UserManager<Worker> userManager;
        SignInManager<Worker> signInManager;
        ProjectDBContext context;

        public IdentityContext(ProjectDBContext context,
            UserManager<Worker> userManager,
            SignInManager<Worker> signInManager)
        {
            this.context = context;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        #region Seeding Data with this Project

        public async Task SeedDataAsync(string adminPass, string adminEmail)
        {
            //await context.Database.MigrateAsync();

            int roles = await context.Roles.CountAsync();

            if (roles == 0)
            {
                await ConfigureRolesAsync();
            }

            int userRoles = await context.UserRoles.CountAsync();

            if (userRoles == 0)
            {
                await ConfigureAdminAccountAsync(adminPass, adminEmail);
            }
        }

        private async Task ConfigureRolesAsync()
        {
            // NormalizedName is not set by Identity :[ but when you want to find role by its name
            // remember that you are checking Normalized column's value! That is why I am adding NormalizedName value!
            IdentityRole admin = new IdentityRole(Role.Administrator.ToString()) { NormalizedName = Role.Administrator.ToString().ToUpper() };
            IdentityRole user = new IdentityRole(Role.User.ToString()) { NormalizedName = Role.User.ToString().ToUpper() };
            IdentityRole unspecified = new IdentityRole(Role.Unspecified.ToString()) { NormalizedName = Role.Unspecified.ToString().ToUpper() };

            context.Roles.Add(admin);
            context.Roles.Add(user);
            context.Roles.Add(unspecified);
            await context.SaveChangesAsync();
        }

        private async Task ConfigureAdminAccountAsync(string password, string email)
        {
            Worker adminIdentityUser = await context.Workers.FirstOrDefaultAsync();

            if (adminIdentityUser == null)
            {
                adminIdentityUser = new Worker("admin", "Admin", "Adminov");
                context.Users.Add(adminIdentityUser);
                await context.SaveChangesAsync();
            }

            await userManager.AddToRoleAsync(adminIdentityUser, Role.Administrator.ToString());
            await userManager.AddPasswordAsync(adminIdentityUser, password);
            await userManager.SetEmailAsync(adminIdentityUser, email);

        }

        #endregion

        #region CRUD

        public async Task CreateUserAsync(string username, string password, string email, string name, int age, Role role)
        {
            try
            {
                Worker user = new Worker(username, email, name);
                IdentityResult result = await userManager.CreateAsync(user, password);

                if (!result.Succeeded)
                {
                    throw new ArgumentException(result.Errors.First().Description);
                }

                if (role == Role.Administrator)
                {
                    await userManager.AddToRoleAsync(user, Role.Administrator.ToString());
                }
                else
                {
                    await userManager.AddToRoleAsync(user, Role.User.ToString());
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ClaimsPrincipal> LogInUserAsync(string username, string password)
        {
            try
            {
                Worker user = await userManager.FindByNameAsync(username);

                if (user == null)
                {
                    return null;
                }

                IdentityResult result = await userManager.PasswordValidators[0].ValidateAsync(userManager, user, password);

                if (result.Succeeded)
                {
                    Worker loggedUser = await context.Workers
                        .FirstOrDefaultAsync(u => u.Id == user.Id);

                    return await signInManager.CreateUserPrincipalAsync(loggedUser);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ClaimsPrincipal> LogOutUserAsync(ClaimsPrincipal claimsPrincipal)
        {
            if (claimsPrincipal.Identity is not null && claimsPrincipal.Identity.IsAuthenticated)
            {
                return new ClaimsPrincipal();
            }

            // If should always be true when you call this method!
            return claimsPrincipal;
        }

        public async Task<Worker> ReadUserAsync(string key, bool useNavigationalProperties = false)
        {
            try
            {
                if (useNavigationalProperties)
                {
                    return await userManager.Users
                        .FirstOrDefaultAsync(u => u.Id == key);
                }

                return await userManager.FindByIdAsync(key);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Worker>> ReadAllUsersAsync(bool useNavigationalProperties = false)
        {
            try
            {
                IQueryable<Worker> query = userManager.Users;

                return await query.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateUserAsync(Worker item, bool useNavigationalProperties = false)
        {
            try
            {
                Worker user = await ReadUserAsync(item.Id, useNavigationalProperties);

                if (user != null)
                {
                    user.UserName = item.UserName;
                    user.NormalizedUserName = item.UserName.ToUpperInvariant();
                    user.Name = item.Name;

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteUserAsync(string id)
        {
            try
            {
                Worker user = await ReadUserAsync(id);

                if (user == null)
                {
                    throw new ArgumentException("There is no user in the database with that id!");
                }

                context.Users.Remove(user);
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteUserByNameAsync(string name)
        {
            try
            {
                Worker user = await FindUserByNameAsync(name);

                if (user == null)
                {
                    throw new InvalidOperationException("User not found for deletion!");
                }

                await userManager.DeleteAsync(user);
            }
            catch (Exception)
            {
                throw;
            }
        }


        #endregion

        #region Find Methods

        public async Task<Worker> FindUserByNameAsync(string name, bool useNavigationalProperties = false)
        {
            try
            {
               // Identity return Null if there is no user!
                return await userManager.FindByNameAsync(name);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Exists(string key)
        {
            Worker user = context.Workers.Find(key);

            if (user == null)
            {
                return false;
            }

            return true;
        }

        #endregion
    }
}
