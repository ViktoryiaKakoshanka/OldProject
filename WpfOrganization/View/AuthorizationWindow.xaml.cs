using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Windows;
using WpfOrganization.DAL.EF;
using WpfOrganization.DAL.Entities;
using WpfOrganization.DAL.Repositories;

namespace WpfOrganization
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            using (var ctx = new DatabaseContext(@"Data Source=.\SQLEXPRESS;Initial Catalog=CableTV;Integrated Security=True"))
            {
                var stud = new User() { Login = "Bill", Password = "", AdminRole = true, LoggedIn = false};

                ctx.Users.Add(stud);
                ctx.SaveChanges();
            }
        }
    }
}
