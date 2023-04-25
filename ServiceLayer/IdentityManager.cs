using BusinessLayer;
using DataLayer;
using ServiceLayer.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class IdentityManager
    {
        IdentityContext context;

        public IdentityManager(IdentityContext context)
        {
            this.context = context;
        }

        #region Seeding Data with this Project

        public async Task SeedDataAsync(string adminPass, string adminEmail)
        {
            await context.SeedDataAsync(adminPass, adminEmail);
        }

        #endregion

        #region CRUD

        public async Task CreateUserAsync(CreateUserViewModel viewModel)
        {
            Role role = Transformer.GetRole(viewModel.Role);
            await context.CreateUserAsync(viewModel.Username, viewModel.Password, viewModel.Email, viewModel.Name, viewModel.Age, role);
        }

        public async Task<ClaimsPrincipal> LogInUserAsync(string username, string password)
        {
            return await context.LogInUserAsync(username, password);
        }

        public async Task<ClaimsPrincipal> LogOutUserAsync(ClaimsPrincipal claimsPrincipal)
        {
            return await context.LogOutUserAsync(claimsPrincipal);
        }

        public async Task<Worker> ReadUserAsync(string key, bool useNavigationalProperties = false)
        {
            return await context.ReadUserAsync(key, useNavigationalProperties);
        }

        public async Task<IEnumerable<ReadUserViewModel>> ReadAllUsersAsync(bool useNavigationalProperties = false)
        {
            IEnumerable<Worker> users = await context.ReadAllUsersAsync();

            return Transformer.GetUserViewModelOnReadAll(users);
        }

        public async Task UpdateUserAsync(UpdateUserViewModel viewModel, bool useNavigationalProperties = false)
        {
            Worker user = Transformer.GetUserOnUpdate(viewModel, useNavigationalProperties);
            await context.UpdateUserAsync(user, useNavigationalProperties);
        }

        public async Task DeleteUserAsync(string id)
        {
            await context.DeleteUserAsync(id);
        }

        public async Task DeleteUserByNameAsync(string name)
        {
            await context.DeleteUserByNameAsync(name);
        }

        #endregion

        #region Find Methods

        public async Task<ReadUserViewModel> FindUserByNameAsync(string name, bool useNavigationalProperties = false)
        {
            Worker user = await context.FindUserByNameAsync(name, useNavigationalProperties);

            return Transformer.GetUserViewModelOnRead(user, useNavigationalProperties);
        }

        public UpdateUserViewModel GetUpdateUserViewModel(ReadUserViewModel readUserViewModel, bool useNavigationalProperties = false)
        {
            return Transformer.GetUpdateUserViewModel(readUserViewModel, useNavigationalProperties);
        }

        public bool Exists(string key)
        {
            return context.Exists(key);
        }

        #endregion

    }
}
