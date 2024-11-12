using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Xacadmey.Models;
using Xacadmey.ViewModel;

namespace Xacadmey.Models
{
    public class Academy:IdentityDbContext<ApplicationUser>
    {
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
      /*  public DbSet<Account> Accounts { get; set; }*/
        public DbSet<Trainee> Traineess { get; set; }

        public DbSet<CourseResult> CourseResults { get; set; }

        public Academy(DbContextOptions<Academy> options) : base(options)
        {
        }
        public Academy()
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data source=DESKTOP-PR1MKJD\\SQLEXPRESS;Initial Catalog=Xacadmey2;Integrated Security=True");
            //.UseLazyLoadingProxies();
        }
        public DbSet<Xacadmey.Models.RegisterUserModel> RegisterUserModel { get; set; }
        public DbSet<Xacadmey.ViewModel.loginviewmodel> loginviewmodel { get; set; }
        public DbSet<Xacadmey.ViewModel.RoleViewModel> RoleViewModel { get; set; }

    }
}
