using System;
using System.Data;

namespace SocialNetEngineFed
{
    class Program
    {
        class User
        {
            public string ID { get; private set; }
            public User(string id) { this.ID = id; } //конструктор создает юзера
        }

        class Friends
        {
            public User Key { get; private set; } //хранится пользователь
            public User[] Value { get; private set; } //хранятся друзья этого пользователя
            public Friends(User sr, User[] arr)
            {
                this.Key = sr;
                this.Value = arr;
            } //
        }

        class Users
        {
            private Friends[] frnds;
            public Users(uint size) { frnds = new Friends[size]; } //создали массив друзей
            public void Add(User sr, User[] arr) // добавляем друга в список друзей
            {
                Friends newFriend = new Friends(sr, arr);
                for (int i = 0; i < frnds.Length; ++i)
                {
                    if (frnds[i] == null)
                    {
                        frnds[i] = newFriend;
                        break;
                    }
                }
            }
            public User[] GetFriends(User sr) // возвращает список друзей
            {
                User[] localArr = null;
                for (int i = 0; i < frnds.Length; ++i)
                {
                    if (frnds[i].Key == sr)
                    {
                        localArr = frnds[i].Value;
                        break;
                    }
                }
                return localArr;
            }
        }

        class Message
        {
            private string message;
            public User User { get; private set; }
            public DateTime Date { get; private set; }
            public Message(User sr, DateTime date, string msg)
            {
                this.User = sr;
                this.Date = date;
                this.message = msg;
            } //6
            public override string ToString() //
            {
                return $"{Date:yyyy'-'MM'-'dd'T'HH':'mm':'ss} {User.ID}{message}";
            }
        }

        class Messages
        {
            private Message[] mssgs { get; set; }
            public Messages(uint size) { mssgs = new Message[size]; } //
            public void Add(Message msg) //добавляем сообщение в массив сообщений
            {
                for (int i = 0; i < mssgs.Length; ++i)
                {
                    if (mssgs[i] == null)
                    {
                        mssgs[i] = msg;
                        break;
                    }
                }
            }

            public Message[] ShowMessage(User sr)  //выбирает сообщения одного пользователя
            {
                Message[] messOfUser = new Message[] { };
                for (int i = 0, j = 0; i < mssgs.Length; ++i)
                {
                    if (mssgs[i].User == sr)
                    {
                        messOfUser[j] = mssgs[i];
                        ++j;
                    }
                }
                return messOfUser;
            }


        }

        class SocialNet
        {
            private Users users { get; set; }
            private Messages messages;
            public SocialNet(uint size)
            {
                this.users = new Users(size);
                this.messages = new Messages(size);
            }
            public void AddUsers(User sr, User[] arr) //4
            {
                users.Add(sr, arr);
            }

            public void AddMessage(Message msg)
            {
                messages.Add(msg);
            }
            //4
            public void ShowMessage(User sr)
            {

            }
            //50
            // private User[] NoDuplicates(User[] arr) { } //21
            // public uint Handshake(User first, User second) { }//18

        }

        static void Main(string[] args)
        {
            User vasya = new User("vasya");
            User kolya = new User("kolya");
            User petya = new User("petya");
            User sasha = new User("sasha");
            User cool1234 = new User("cool1234");

            Array f = new Array[5];

            SocialNet social = new SocialNet(10);
            social.AddUsers(vasya, new User[] { kolya, petya, sasha });
            social.AddUsers(sasha, new User[] { vasya, cool1234, petya });
            social.AddUsers(cool1234, new User[] { kolya });
            social.AddUsers(kolya, new User[] { cool1234 });

            social.AddMessage(new Message(vasya, new DateTime(2014, 10, 20, 8, 0, 0), "mes1"));
            social.AddMessage(new Message(cool1234, new DateTime(2014, 10, 20, 8, 5, 0), "mes2"));
            social.AddMessage(new Message(kolya, new DateTime(2014, 10, 20, 8, 39, 0), "mes3"));
            social.AddMessage(new Message(petya, new DateTime(2014, 10, 20, 8, 41, 0), "mes4"));
            social.AddMessage(new Message(sasha, new DateTime(2014, 10, 20, 8, 52, 0), "mes5"));
            social.AddMessage(new Message(petya, new DateTime(2014, 10, 20, 9, 3, 0), "mes6"));
            social.AddMessage(new Message(cool1234, new DateTime(2014, 10, 20, 11, 0, 0), "mes7"));
            social.AddMessage(new Message(kolya, new DateTime(2014, 10, 20, 9, 24, 0), "mes8"));
            social.AddMessage(new Message(sasha, new DateTime(2014, 10, 20, 9, 45, 0), "mes9"));
            social.AddMessage(new Message(kolya, new DateTime(2014, 10, 20, 9, 51, 0), "mes10"));

            social.ShowMessage(kolya);
            // Console.WriteLine("Рукопожатий - {0}", social.Handshake(vasya,cool1234));
            Console.ReadKey();

        }
    }
}
