using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using top_library_models.Models;

namespace top_library_dblayer
{
    public partial class EntityGateway
    {
        public Client[] GetClients(Func<Client, bool> predicate) =>
            Context.Clients.Where(predicate).ToArray();
        public Client[] GetClients() =>
            Context.Clients.ToArray();

        public Book[] GetBooks(Func<Book, bool> predicate) =>
            Context.Books.Where(predicate).ToArray();
        public Book[] GetBooks() =>
            Context.Books.ToArray();

        public Room[] GetRooms(Func<Room, bool> predicate) =>
            Context.Rooms.Where(predicate).ToArray();
        public Room[] GetRooms() =>
            Context.Rooms.ToArray();
    }
}
