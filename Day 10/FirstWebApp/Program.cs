namespace Employee_MVC_v1._0
{


    //Entry Point of our Web App
    //Whenever we run the Application, all the instructions are managed from here
    public class Program
    {
        public static void Main(string[] args)
        {

            
            /*This creates the builder to start the application
            *var can also be replaced with 
            *WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
            */
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            /*This is the Pipeline for all the incoming requests of the user
            // Configure the HTTP request pipeline.
            //All the instructions are given here, basically what to allow to the request is mentioned here
            */
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            //Allows to use HTML files in wwwroot
            app.UseStaticFiles();

            //Allows to access the Root Folder
            app.UseRouting();

            app.UseAuthorization();

            //Map Controller for all the Request Handling URI
            app.MapControllerRoute(
                name: "default",
                
                //First part - Controller
                //Second part - Action
                //Third part - ID or variables to be sent through link

                //Here for null requests, default values has been assigned as - Home/Index/id(Optional)
                pattern: "{controller=Home}/{action=Index}/{id?}");

                
            app.Run();
        }
    }
}
