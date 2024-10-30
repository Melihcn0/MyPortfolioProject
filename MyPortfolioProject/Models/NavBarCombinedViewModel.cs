using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using MyPortfolioProject.DataAccessLayer.Entities;
using Message = MyPortfolioProject.DataAccessLayer.Entities.Message;

namespace MyPortfolioProject.Models
{
    public class NavBarCombinedViewModel
    {
        public List<Message> Messages { get; set; } = new List<Message> ();
        public List<ToDoList> ToDoLists { get; set; } = new List<ToDoList>();
    }
}
