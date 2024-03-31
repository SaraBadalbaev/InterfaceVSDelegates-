namespace Ex04.Menus.Test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MenusInterfaces menuesInterfaces = new MenusInterfaces();
            MenusDelegates menuesDelegates = new MenusDelegates();

            menuesInterfaces.Show();
            menuesDelegates.Show();
        }
    }
}
