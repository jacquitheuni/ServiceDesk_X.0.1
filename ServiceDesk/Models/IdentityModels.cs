using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using ServiceDesk.Migrations;

namespace ServiceDesk.Models
{
    
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    //public class ApplicationUser : IdentityUser
    //{
    //    public ApplicationUser()
    //        : base()
    //    {
    //        this.Groups = new HashSet<ApplicationUserGroup>();
    //    }
    //    [Required]
    //    public string FirstName { get; set; }

    //    [Required]
    //    public string LastName { get; set; }
    //    [Required]
    //    public string Email { get; set; }

    //    public bool isActive { get; set; }

    //    public virtual ICollection<ApplicationUserGroup> Groups { get; set; }
    //    public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
    //    {

    //        // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
    //        var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
    //        // Add custom user claims here
    //        return userIdentity;
    //    }
    //    public ICollection<ApplicationUserRole> UserRoles { get; set; }
    //}

    //public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    //{
    //    new public virtual IDbSet<ApplicationRole> Roles { get; set; }

    //    public virtual IDbSet<Group> Groups { get; set; }
    //    public ApplicationDbContext()
    //        : base("ServiceDeskContext")
    //    {
    //    }
    //    public DbSet<Request> Request { get; set; }
    //    public DbSet<RequestLink> RequestLink { get; set; }


    //    public static ApplicationDbContext Create()
    //    {
    //        return new ApplicationDbContext();
    //    }

    //    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    //    {
    //        modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

    //        if (modelBuilder == null)
    //        {
    //            throw new ArgumentNullException("modelBuilder");
    //        }

    //        modelBuilder.Entity<ApplicationUser>().ToTable("AspNetUsers");
    //        modelBuilder.Entity<ApplicationRole>().HasKey<string>(r => r.Id).ToTable("AspNetRoles");
    //        modelBuilder.Entity<ApplicationUser>().HasMany<ApplicationUserRole>((ApplicationUser u) => u.UserRoles);
    //        modelBuilder.Entity<ApplicationUserRole>().HasKey(r => new { UserId = r.UserId, RoleId = r.RoleId }).ToTable("AspNetUserRoles");
    //        modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.UserId, r.RoleId }).ToTable("AspNetUserRoles");
    //        modelBuilder.Entity<IdentityUserLogin>().HasKey(l => new { l.LoginProvider, l.ProviderKey, l.UserId }).ToTable("AspNetUserLogins");
    //    }



        //public class IdentityManager
        //{
        //    ApplicationDbContext _db = new ApplicationDbContext();

        //    private ApplicationSignInManager _signInManager;
        //    private ApplicationUserManager _userManager;
        //    public bool RoleExists(string name)
        //    {
        //        var rm = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
        //        return rm.RoleExists(name);
        //    }


        //    public bool CreateRole(string name)
        //    {
        //        var rm = new RoleManager<IdentityRole>(
        //            new RoleStore<IdentityRole>(new ApplicationDbContext()));
        //        var idResult = rm.Create(new IdentityRole(name));
        //        return idResult.Succeeded;
        //    }


        //    public bool CreateUser(ApplicationUser user, string password)
        //    {
        //        var um = new UserManager<ApplicationUser>(
        //            new UserStore<ApplicationUser>(new ApplicationDbContext()));
        //        var idResult = um.Create(user, password);
        //        return idResult.Succeeded;
        //    }


        //    public bool AddUserToRole(string userId, string roleName)
        //    {
        //        var um = new UserManager<ApplicationUser>(
        //            new UserStore<ApplicationUser>(new ApplicationDbContext()));
        //        var idResult = um.AddToRole(userId, roleName);
        //        return idResult.Succeeded;
        //    }


        //    public void ClearUserRoles(string userId)
        //    {
        //        var um = new UserManager<ApplicationUser>(
        //            new UserStore<ApplicationUser>(new ApplicationDbContext()));
        //        var user = um.FindById(userId);
        //        var currentRoles = new List<IdentityUserRole>();
        //        currentRoles.AddRange(user.Roles);
        //        foreach (var role in currentRoles)
        //        {
        //            um.RemoveFromRole(userId, role.ToString());
        //        }
        //    }

        //    public void CreateGroup(string groupName)
        //    {
        //        if (this.GroupNameExists(groupName))
        //        {
        //            throw new System.Exception("A group by that name already exists in the database. Please choose another name.");
        //        }

        //        var newGroup = new Group(groupName);
        //        _db.Groups.Add(newGroup);
        //        _db.SaveChanges();
        //    }


        //    public bool GroupNameExists(string groupName)
        //    {
        //        var g = _db.Groups.Where(gr => gr.Name == groupName);
        //        if (g.Count() > 0)
        //        {
        //            return true;
        //        }
        //        return false;
        //    }


        //    public void ClearUserGroups(string userId)
        //    {
        //        this.ClearUserRoles(userId);
        //        var user = _db.Users.Find(userId);
        //        user.Groups.Clear();
        //        _db.SaveChanges();
        //    }


        //    public void AddUserToGroup(string userId, int GroupId)
        //    {
        //        var group = _db.Groups.Find(GroupId);
        //        var user = _db.Users.Find(userId);

        //        var userGroup = new ApplicationUserGroup()
        //        {
        //            Group = group,
        //            GroupId = group.Id,
        //            User = user,
        //            UserId = user.Id
        //        };

        //        foreach (var role in group.Roles)
        //        {
        //            _userManager.AddToRole(userId, role.Role.Name);
        //        }
        //        user.Groups.Add(userGroup);
        //        _db.SaveChanges();
        //    }


        //    public void ClearGroupRoles(int groupId)
        //    {
        //        var group = _db.Groups.Find(groupId);
        //        var groupUsers = _db.Users.Where(u => u.Groups.Any(g => g.GroupId == group.Id));

        //        foreach (var role in group.Roles)
        //        {
        //            var currentRoleId = role.RoleId;
        //            foreach (var user in groupUsers)
        //            {
        //                // Is the user a member of any other groups with this role?
        //                var groupsWithRole = user.Groups
        //                    .Where(g => g.Group.Roles
        //                        .Any(r => r.RoleId == currentRoleId)).Count();

        //                // This will be 1 if the current group is the only one:
        //                if (groupsWithRole == 1)
        //                {
        //                    this.RemoveFromRole(user.Id, role.Role.Name);
        //                }
        //            }
        //        }
        //        group.Roles.Clear();
        //        _db.SaveChanges();
        //    }

        //    public void RemoveFromRole(string userId, string roleName)
        //    {
        //        var userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(new IdentityDbContext("ServiceDeskContext")));
        //        userManager.RemoveFromRole(userId, roleName);
        //    }


        //    public void AddRoleToGroup(int groupId, string roleName)
        //    {
        //        var group = _db.Groups.Find(groupId);
        //        var role = _db.Roles.First(r => r.Name == roleName);
        //        var newgroupRole = new ApplicationRoleGroup()
        //        {
        //            GroupId = group.Id,
        //            Group = group,
        //            RoleId = role.Id,
        //            Role = (ApplicationRole)role
        //        };

        //        group.Roles.Add(newgroupRole);
        //        _db.SaveChanges();

        //        // Add all of the users in this group to the new role:
        //        var groupUsers = _db.Users.Where(u => u.Groups.Any(g => g.GroupId == group.Id));
        //        foreach (var user in groupUsers)
        //        {
        //            if (!(_userManager.IsInRole(user.Id, roleName)))
        //            {
        //                this.AddUserToRole(user.Id, role.Name);
        //            }
        //        }
        //    }


        //    public void DeleteGroup(int groupId)
        //    {
        //        var group = _db.Groups.Find(groupId);

        //        // Clear the roles from the group:
        //        this.ClearGroupRoles(groupId);
        //        _db.Groups.Remove(group);
        //        _db.SaveChanges();
        //    }
        //}

        //public bool RoleExists(ApplicationRoleManager roleManager, string name)
        //{
        //    return roleManager.RoleExists(name);
        //}

        //public bool CreateRole(ApplicationRoleManager _roleManager, string name, string description = "")
        //{
        //    var idResult = _roleManager.Create(new ApplicationRole(name, description));
        //    return idResult.Succeeded;
        //}

        //public bool AddUserToRole(ApplicationUserManager _userManager, string userId, string roleName)
        //{
        //    var idResult = _userManager.AddToRole(userId, roleName);
        //    return idResult.Succeeded;
        //}

        //public void ClearUserRoles(ApplicationUserManager userManager, string userId)
        //{
        //    var user = userManager.FindById(userId);
        //    var currentRoles = new List<IdentityUserRole>();

        //    currentRoles.AddRange(user.UserRoles);
        //    foreach (ApplicationUserRole role in currentRoles)
        //    {
        //        userManager.RemoveFromRole(userId, role.Role.Name);
        //    }
        //}

        //public void RemoveFromRole(ApplicationUserManager userManager, string userId, string roleName)
        //{
        //    userManager.RemoveFromRole(userId, roleName);
        //}

        //public void DeleteRole(ApplicationDbContext context, ApplicationUserManager userManager, string roleId)
        //{
        //    var roleUsers = context.Users.Where(u => u.UserRoles.Any(r => r.RoleId == roleId));
        //    var role = context.Roles.Find(roleId);

        //    foreach (var user in roleUsers)
        //    {
        //        this.RemoveFromRole(userManager, user.Id, role.Name);
        //    }
        //    context.Roles.Remove(role);
        //    context.SaveChanges();
        //}
        //IdentityManager _idManager = new IdentityManager();
        //ApplicationDbContext _db = new ApplicationDbContext();
    //    internal void Seed(ApplicationDbContext context)
    //    {
    //        AddGroups();
    //        AddRoles();
    //        AddUsers();
    //        AddRolesToGroups();
    //        AddUsersToGroups();
    //    }

    //    string[] _initialGroupNames =
    //    new string[] { "Admins", "Agents", "Managers", "Users" };

    //    public void AddGroups()
    //    {
    //        foreach (var groupName in _initialGroupNames)
    //        {
    //            _idManager.CreateGroup(groupName);
    //        }
    //    }

    //    void AddRoles()
    //    {
    //        foreach (var groupName in _initialGroupNames)
    //        {
    //            _idManager.CreateRole(groupName);
    //        }
    //        //// Some example initial roles. These COULD BE much more granular:
    //        //_idManager.CreateRole("Admin");
    //        //_idManager.CreateRole("Agent");
    //        ////_idManager.CreateRole("CanEditGroup");
    //        //_idManager.CreateRole("Manager");
    //        //_idManager.CreateRole("User");
    //    }

    //    string[] _superAdminRoleNames = new string[] { "Admin", "Agent", "Manager", "User" };
    //    string[] _groupAdminRoleNames = new string[] { "Agent", "Manager", "User" };
    //    string[] _userAdminRoleNames = new string[] { "Manager", "User" };
    //    string[] _userRoleNames = new string[] { "User" };

    //    void AddRolesToGroups()
    //    {
    //        // Add the Super-Admin Roles to the Super-Admin Group:
    //        var allGroups = _db.Groups;
    //        var superAdmins = allGroups.First(g => g.Name == "Admins");
    //        foreach (string name in _superAdminRoleNames)
    //        {
    //            _idManager.AddRoleToGroup(superAdmins.Id, name);
    //        }

    //        // Add the Group-Admin Roles to the Group-Admin Group:
    //        var groupAdmins = _db.Groups.First(g => g.Name == "Agents");
    //        foreach (string name in _groupAdminRoleNames)
    //        {
    //            _idManager.AddRoleToGroup(groupAdmins.Id, name);
    //        }

    //        // Add the User-Admin Roles to the User-Admin Group:
    //        var userAdmins = _db.Groups.First(g => g.Name == "Managers");
    //        foreach (string name in _userAdminRoleNames)
    //        {
    //            _idManager.AddRoleToGroup(userAdmins.Id, name);
    //        }

    //        // Add the User Roles to the Users Group:
    //        var users = _db.Groups.First(g => g.Name == "Users");
    //        foreach (string name in _userRoleNames)
    //        {
    //            _idManager.AddRoleToGroup(users.Id, name);
    //        }
    //    }

    //    string _initialUserName = "jacqui";
    //    string _InitialUserFirstName = "Jacqui";
    //    string _initialUserLastName = "Theunissen";
    //    string _initialUserEmail = "jacqui.muller@kingprice.co.za";
    //    void AddUsers()
    //    {
    //        var newUser = new ApplicationUser()
    //        {
    //            UserName = _initialUserName,
    //            FirstName = _InitialUserFirstName,
    //            LastName = _initialUserLastName,
    //            Email = _initialUserEmail
    //        };

    //        // Be careful here - you  will need to use a password which will 
    //        // be valid under the password rules for the application, 
    //        // or the process will abort:
    //        _idManager.CreateUser(newUser, "Pass@1");
    //    }

    //    void AddUsersToGroups()
    //    {
    //        var user = _db.Users.First(u => u.UserName == _initialUserName);
    //        var allGroups = _db.Groups;
    //        foreach (var group in allGroups)
    //        {
    //            _idManager.AddUserToGroup(user.Id, group.Id);
    //        }
    //    }
    //}

    //public class DropCreateAlwaysInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    //{
    //    protected override void Seed(ApplicationDbContext context)
    //    {
    //        context.Seed(context);

    //        base.Seed(context);
    //    }
    //}

}
