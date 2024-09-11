using DatabaseLibrary.DataStruct;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLibrary
{
    public class DatabaseClass
    {
        public static DatabaseClass Instance => new DatabaseClass();

        public ObservableCollection<UserStruct> users;
        public ObservableCollection<RoomStruct> rooms;
        

        public DatabaseClass() 
        {
            users = new ObservableCollection<UserStruct>();
            rooms = new ObservableCollection<RoomStruct>();

            UserStruct user1 = new UserStruct();
            user1.userName = "CuteCat";
            users.Add(user1);

            UserStruct user2 = new UserStruct();
            user2.userName = "SmilyPotato";
            users.Add(user2);

            UserStruct user3 = new UserStruct();
            user3.userName = "RosyBear23";
            users.Add(user3);

            rooms = new ObservableCollection<RoomStruct>();

            RoomStruct room1 = new RoomStruct();
            room1.RoomName = "Musician";
            //room1.AddUser(user1);
            rooms.Add(room1);

            RoomStruct room2 = new RoomStruct();
            room2.RoomName = "Assassins Only";
            //room2.AddUser(user2);
            //room2.AddUser(user3);
            MessageStruct message1 = new MessageStruct();
            message1.username = user1.userName;
            message1.mssg = $"{message1.username} [{DateTime.Now:HH:mm:ss}]: testing";
            room2.mssges.Add(message1);
            rooms.Add(room2);

        }

        public void AddUser(string username)
        {
            if (!UserExists(username))
            {
                UserStruct newUser = new UserStruct();
                newUser.userName = username;
                users.Add(newUser);
            }
        }


        public  string GetUsernameByIndex(int index)
        {
            return users[index].userName;
        }

        public int GetNumberOfUsers()
        {
            return users.Count;
        }

        public string GetRoomnameByIndex(int index)
        {
            return rooms[index].RoomName;
        }

        public List<UserStruct> GetUsersInRoom(string roomName)
        {
            var room = rooms.FirstOrDefault(u => u.RoomName == roomName);

            return room?.Users ?? new List<UserStruct>();
        }
        public bool UserExists(string userName)
        {
            return users.Any(u => u.userName == userName);
        }



    }
}
