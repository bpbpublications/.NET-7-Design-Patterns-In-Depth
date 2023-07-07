
UserController controller = new();
IView loginView = controller.LoginIndex();
loginView = ((LoginView)loginView).Login();
loginView = ((DashboardView)loginView).Logout();

Console.ReadLine();