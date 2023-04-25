using BusinessLayer;
using ServiceLayer.ViewModels;
using ServiceLayer.ViewModels.Hobbies;
using ServiceLayer.ViewModels.Messages;
using ServiceLayer.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public static class Transformer
    {

        #region Hobby and its ViewModels

        public static Hobby GetHobbyOnCreate(CreateHobbyViewModel viewModel)
        {
            return new Hobby(viewModel.Name);
        }

        public static ReadHobbyViewModel GetHobbyViewModelOnRead(Hobby hobby, bool useNavigationalProperties = false)
        {
            if (useNavigationalProperties)
            {
                List<ReadUserViewModel> usersViewModels = new List<ReadUserViewModel>();

                foreach (User user in hobby.Users)
                {
                    usersViewModels.Add(GetUserViewModelOnRead(user, false));
                }

                return new ReadHobbyViewModel(hobby.Id, hobby.Name, usersViewModels);
            }
            else
            {
                return new ReadHobbyViewModel(hobby.Id, hobby.Name);
            }
        }

        public static ReadAllHobbyViewModel GetHobbyViewModelOnReadAll(Hobby hobby, bool useNavigationalProperties = false)
        {
            if (useNavigationalProperties)
            {
                List<ReadUserViewModel> usersViewModel = new List<ReadUserViewModel>();

                foreach (User user in hobby.Users)
                {
                    usersViewModel.Add(GetUserViewModelOnRead(user));
                }

                return new ReadAllHobbyViewModel(hobby.Id, hobby.Name, usersViewModel);
            }
            else
            {
                return new ReadAllHobbyViewModel(hobby.Id, hobby.Name);
            }
        }

        public static Hobby GetHobbyOnUpdate(UpdateHobbyViewModel viewModel)
        {
            return new Hobby(viewModel.Id, viewModel.Name);
        }

        public static IEnumerable<ReadAllHobbyViewModel> GetHobbiesViewModelOnFind(IEnumerable<Hobby> hobbies)
        {
            List<ReadAllHobbyViewModel> hobbiesViewModel = new List<ReadAllHobbyViewModel>();

            foreach (Hobby item in hobbies)
            {
                hobbiesViewModel.Add(GetHobbyViewModelOnReadAll(item));
            }

            return hobbiesViewModel;
        }

        #endregion

        #region Message and its ViewModels

        public static ReadMessageViewModel GetMessageViewModelOnRead(Message message, bool useNavigationalProperties = false)
        {
            if (useNavigationalProperties)
            {
                ReadUserViewModel senderViewModel = GetUserViewModelOnRead(message.Sender, false);
                ReadUserViewModel receiverViewModel = GetUserViewModelOnRead(message.Receiver, false);
                return new ReadMessageViewModel(message.Id, message.Title, message.Text, senderViewModel, receiverViewModel);
            }
            else
            {
                return new ReadMessageViewModel(message.Id, message.Title, message.Text);
            }
        }

        public static Message GetMessageOnUpdate(UpdateMessageViewModel viewModel, bool useNavigationalProperties = false)
        {
            if (useNavigationalProperties)
            {
                return new Message(viewModel.Id, viewModel.Title, viewModel.Text, GetUserOnUpdate(viewModel.Sender), GetUserOnUpdate(viewModel.Receiver));
            }
            else
            {
                return new Message(viewModel.Id, viewModel.Title, viewModel.Text, GetUserOnUpdate(viewModel.Sender));
            }
        }

        #endregion

        #region Users and its ViewModels

        public static ReadUserViewModel GetUserViewModelOnRead(User user, bool useNavigationalProperties = false)
        {
            if (useNavigationalProperties)
            {
                List<ReadMessageViewModel> readMessagesViewModels = new List<ReadMessageViewModel>();
                List<ReadHobbyViewModel> readHobbiesViewModels = new List<ReadHobbyViewModel>();

                foreach (Message message in user.Messages)
                {
                    readMessagesViewModels.Add(GetMessageViewModelOnRead(message, false));
                }

                foreach (Hobby hobby in user.Hobbies)
                {
                    readHobbiesViewModels.Add(GetHobbyViewModelOnRead(hobby, false));
                }

                return new ReadUserViewModel(user.Id, user.UserName, user.Name, user.Age, user.Email, readMessagesViewModels, readHobbiesViewModels);
            }
            else
            {
                return new ReadUserViewModel(user.Id, user.UserName, user.Name, user.Age, user.Email);
            }
        }

        public static ICollection<ReadUserViewModel> GetUserViewModelOnReadAll(IEnumerable<User> users, bool useNavigationalProperties = false)
        {
            List<ReadUserViewModel> usersViewModels = new List<ReadUserViewModel>();

            foreach (User user in users)
            {
                usersViewModels.Add(GetUserViewModelOnRead(user, useNavigationalProperties));
            }

            return usersViewModels;
        }

        public static UpdateUserViewModel GetUserViewModelOnUpdate(User user, bool useNavigationalProperties)
        {
            if (useNavigationalProperties)
            {
                ICollection<UpdateMessageViewModel> messagesViewModels = new List<UpdateMessageViewModel>();
                ICollection<UpdateHobbyViewModel> hobbiesViewModels = new List<UpdateHobbyViewModel>();

                foreach (Message message in user.Messages)
                {
                    messagesViewModels.Add(GetMessageViewModelOnUpdate());
                }

                foreach (Hobby hobby in user.Hobbies)
                {
                    hobbiesViewModels.Add(GetHobbyViewModelOnUpdate());
                }

                return new UpdateUserViewModel(user.Id, user.UserName, user.Email, user.Name, user.Age, messagesViewModels, hobbiesViewModels);
            }
            else
            {
                return new UpdateUserViewModel(user.Id, user.UserName, user.Email, user.Name, user.Age);
            }
        }

        public static UpdateHobbyViewModel GetHobbyViewModelOnUpdate()
        {
            throw new NotImplementedException();
        }

        public static UpdateMessageViewModel GetMessageViewModelOnUpdate()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region ViewModels to ViewModels

        public static User GetUserOnUpdate(UpdateUserViewModel viewModel, bool useNavigationalProperties = false)
        {
            if (useNavigationalProperties)
            {
                ICollection<Hobby> hobbies = new List<Hobby>(viewModel.Hobbies.Count);
                ICollection<Message> messages = new List<Message>(viewModel.Messages.Count);

                foreach (UpdateHobbyViewModel item in viewModel.Hobbies)
                {
                    hobbies.Add(GetHobbyOnUpdate(item));
                }

                foreach (UpdateMessageViewModel item in viewModel.Messages)
                {
                    messages.Add(GetMessageOnUpdate(item));
                }

                return new User(viewModel.Id, viewModel.Username, viewModel.Email, viewModel.Age, viewModel.Name, hobbies, messages);
            }
            else
            {
                return new User(viewModel.Id, viewModel.Username, viewModel.Email, viewModel.Age, viewModel.Name);
            }
        }

        public static UpdateHobbyViewModel GetUpdateHobbyViewModel(ReadAllHobbyViewModel readAllHobbyViewModel)
        {
            return new UpdateHobbyViewModel(readAllHobbyViewModel.Id, readAllHobbyViewModel.Name);
        }

        public static ICollection<UpdateHobbyViewModel> GetUpdateHobbiesViewModel(IEnumerable<ReadAllHobbyViewModel> readAllHobbyViewModels)
        {
            List<UpdateHobbyViewModel> updateHobbyViewModels = new();

            foreach (ReadAllHobbyViewModel item in readAllHobbyViewModels)
            {
                updateHobbyViewModels.Add(GetUpdateHobbyViewModel(item));
            }

            return updateHobbyViewModels;
        }

        public static UpdateHobbyViewModel GetUpdateHobbyViewModel(ReadHobbyViewModel readHobbyViewModel)
        {
            return new UpdateHobbyViewModel(readHobbyViewModel.Id, readHobbyViewModel.Name);
        }

        public static ICollection<UpdateHobbyViewModel> GetUpdateHobbiesViewModel(IEnumerable<ReadHobbyViewModel> readHobbyViewModels)
        {
            List<UpdateHobbyViewModel> updateHobbyViewModels = new();

            foreach (ReadHobbyViewModel item in readHobbyViewModels)
            {
                updateHobbyViewModels.Add(GetUpdateHobbyViewModel(item));
            }

            return updateHobbyViewModels;
        }

        public static UpdateMessageViewModel GetUpdateMessageViewModel(ReadMessageViewModel readMessageViewModel, bool useNavigationalProperties = false)
        {
            if (useNavigationalProperties)
            {
                return new UpdateMessageViewModel(readMessageViewModel.Id, readMessageViewModel.Title, readMessageViewModel.Text, GetUpdateUserViewModel(readMessageViewModel.Sender), GetUpdateUserViewModel(readMessageViewModel.Receiver));
            }
            else
            {
                return new UpdateMessageViewModel(readMessageViewModel.Id, readMessageViewModel.Title, readMessageViewModel.Text);
            }
            
        }

        public static ICollection<UpdateMessageViewModel> GetUpdateMessagesViewModel(IEnumerable<ReadMessageViewModel> readMessageViewModels, bool useNavigationalProperties = false)
        {
            List<UpdateMessageViewModel> updateMessagesViewModels = new();

            foreach (ReadMessageViewModel item in readMessageViewModels)
            {
                updateMessagesViewModels.Add(GetUpdateMessageViewModel(item, useNavigationalProperties));
            }

            return updateMessagesViewModels;
        }


        public static UpdateUserViewModel GetUpdateUserViewModel(ReadUserViewModel readUserViewModel, bool useNavigationalProperties = false)
        {
            if (useNavigationalProperties)
            {
                return new UpdateUserViewModel(readUserViewModel.Id, readUserViewModel.Username, readUserViewModel.Email, readUserViewModel.Name, readUserViewModel.Age, GetUpdateMessagesViewModel(readUserViewModel.Messages, useNavigationalProperties), GetUpdateHobbiesViewModel(readUserViewModel.Hobbies));
            }
            else
            {
                return new UpdateUserViewModel(readUserViewModel.Id, readUserViewModel.Username, readUserViewModel.Email, readUserViewModel.Name, readUserViewModel.Age);
            }
        }

        #endregion

        #region Roles and its ViewModels

        public static Role GetRole(RoleViewModel viewModel)
        {
            switch (viewModel)
            {
                case RoleViewModel.Administrator:
                    return Role.Administrator;
                case RoleViewModel.User:
                    return Role.User;
                case RoleViewModel.Unspecified:
                    return Role.Unspecified;
                default:
                    throw new ArgumentException("There is no such role!");
            }
        }

        public static RoleViewModel GetRoleViewModel(Role role)
        {
            switch (role)
            {
                case Role.Administrator:
                    return RoleViewModel.Administrator;
                case Role.User:
                    return RoleViewModel.User;
                case Role.Unspecified:
                    return RoleViewModel.Unspecified;
                default:
                    throw new ArgumentException("There is no such role!");
            }
        }

        public static ICollection<Role> GetRoles()
        {
            return new List<Role>() { Role.Administrator, Role.User, Role.Unspecified };
        }

        public static ICollection<RoleViewModel> GetRolesViewModel()
        {
            return new List<RoleViewModel>() { RoleViewModel.Administrator, RoleViewModel.User, RoleViewModel.Unspecified };
        }

        internal static IEnumerable<ReadUserViewModel> GetUserViewModelOnReadAll(IEnumerable<Worker> users)
        {
            throw new NotImplementedException();
        }

        internal static ReadUserViewModel GetUserViewModelOnRead(Worker user, bool useNavigationalProperties)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
