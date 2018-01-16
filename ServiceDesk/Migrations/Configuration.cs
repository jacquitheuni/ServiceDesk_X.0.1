namespace ServiceDesk.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ServiceDesk.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "ServiceDesk.Models.ApplicationDbContext";
        }
        private const string InitialUserName = "tester";
        private const string InitialUserFirstName = "TestFirstName";
        private const string InitialUserLastName = "TestLastName";
        private const string InitialUserEmail = "test@test.com";
        private const string InitialUserPassword = "Password1";

        private const string VaniallaUserName = "Jacqui";
        private const string VaniallaUserFirstName = "Jacqui";
        private const string VaniallaUserLastName = "Thuenissen";
        private const string VaniallaUserEmail = "jacqui.muller@kingprice.co.za";
        private const string VaniallaUserPassword = "Qwe12345_";


        private readonly ApplicationDbContext _db = new ApplicationDbContext();
        private readonly string[] _groupAdminRoleNames = { "AgentView", "CanEdit", "CanDelete" };
        private readonly IdentityManager _idManager = new IdentityManager();

        private readonly string[] _initialGroupNames = { "SuperAdmins", "Agents", "UserAdmins", "Users" };


        private readonly string[] _superAdminRoleNames = { "Admin", "AgentView", "CanEdit", "CanDelete", "ManagerView", "User" };
        private readonly string[] _userAdminRoleNames = { "ManagerView", "User" };
        private readonly string[] _userRoleNames = { "User" };

        protected override void Seed(ServiceDesk.Models.ApplicationDbContext context)
        {
            //AddGroups();
            //AddRoles();
            //AddUsers();
            //AddRolesToGroups();
            //AddUsersToGroups();
        }

        private void AddRoles()
        {
            // Some example initial roles. These COULD BE much more granular:
            _idManager.CreateRole("Admin", "Global Access");
            _idManager.CreateRole("AgentView", "View all requests");
            _idManager.CreateRole("CanEdit", "Add & modify requests");
            _idManager.CreateRole("CanDelete", "Add, modify, and delete requests");
            _idManager.CreateRole("ManagerView", "Expanded user access to view team requests");
            _idManager.CreateRole("User", "Restricted to business domain activity");
        }

        private void AddGroups()
        {
            foreach (string name in _initialGroupNames)
            {
                _idManager.CreateGroup(name);
            }
        }

        private void AddRolesToGroups()
        {
            // Add the Super-Admin Roles to the Super-Admin Group:
            IDbSet<Group> allGroups = _db.Group;
            Group superAdmins = allGroups.First(g => g.Name == "SuperAdmins");
            foreach (string name in _superAdminRoleNames)
            {
                _idManager.AddRoleToGroup(superAdmins.Id, name);
            }

            // Add the Group-Admin Roles to the Group-Admin Group:
            Group groupAdmins = _db.Group.First(g => g.Name == "GroupAdmins");
            foreach (string name in _groupAdminRoleNames)
            {
                _idManager.AddRoleToGroup(groupAdmins.Id, name);
            }

            // Add the User-Admin Roles to the User-Admin Group:
            Group userAdmins = _db.Group.First(g => g.Name == "UserAdmins");
            foreach (string name in _userAdminRoleNames)
            {
                _idManager.AddRoleToGroup(userAdmins.Id, name);
            }

            // Add the User Roles to the Users Group:
            Group users = _db.Group.First(g => g.Name == "Users");
            foreach (string name in _userRoleNames)
            {
                _idManager.AddRoleToGroup(users.Id, name);
            }
        }

        // Change these to your own:

        private void AddUsers()
        {
            //var newUser = new ApplicationUser
            //{
            //    UserName = InitialUserName,
            //    FirstName = InitialUserFirstName,
            //    LastName = InitialUserLastName,
            //    Email = InitialUserEmail,
            //    isActive = true
            //};

            //// Be careful here - you  will need to use a password which will 
            //// be valid under the password rules for the application, 
            //// or the process will abort:
            //var userCreationResult = _idManager.CreateUser(newUser, InitialUserPassword);
            //if (!userCreationResult.Succeeded)
            //{
            //    // warn the user that it's seeding went wrong
            //    throw new DbEntityValidationException("Could not create InitialUser because: " + String.Join(", ", userCreationResult.Errors));
            //}

            var newVaniallaUser = new ApplicationUser
            {
                UserName = VaniallaUserName,
                FirstName = VaniallaUserFirstName,
                LastName = VaniallaUserLastName,
                Email = VaniallaUserEmail,
                isActive = true
            };

            // Be careful here - you  will need to use a password which will 
            // be valid under the password rules for the application, 
            // or the process will abort:
            var userCreationResult = _idManager.CreateUser(newVaniallaUser, VaniallaUserPassword);
            if (!userCreationResult.Succeeded)
            {
                // warn the user that it's seeding went wrong
                throw new DbEntityValidationException("Could not create VaniallaUser because: " + String.Join(", ", userCreationResult.Errors));
            }
        }

        // Configure the initial Super-Admin user:
        private void AddUsersToGroups()
        {
    
            //Console.WriteLine(String.Join(", ", _db.Users.Select(u => u.Email)));
            ApplicationUser user = _db.Users.First(u => u.UserName == VaniallaUserName);
            IDbSet<Group> allGroups = _db.Group;
            foreach (Group group in allGroups)
            {
                _idManager.AddUserToGroup(user.Id, group.Id);
            }

            //user = _db.Users.FirstOrDefault(u => u.UserName == VaniallaUserName);
            //var plainUsers = allGroups.FirstOrDefault(g => g.Name == "Users");
            //_idManager.AddUserToGroup(user.Id, plainUsers.Id);
        }
    }
}
