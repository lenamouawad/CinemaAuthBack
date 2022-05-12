using cinemas.Models;

namespace cinemas.Repositories
{
    public interface IRoomRepository
    {
        System.Collections.Generic.List<Room> CreateRoom(Room room);
        Room FindById(string id);
        System.Collections.Generic.List<Room> GetAllRooms();
        Room UpdateRoom(string id, Room roomUpdated);
    }
}