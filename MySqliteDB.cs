using System;
using System.IO;
using Android.Support.V7.App;
using SQLite;

namespace XA_SQlite_LoginApp
{
    class MySqliteDB : AppCompatActivity
    {
        //database path
        private readonly string dbPath = Path.Combine(
                Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "MyDB.db3");

        public MySqliteDB()
        {
            //Creating database, if it doesn't already exist 
            if (!File.Exists(dbPath))
            {
                var db = new SQLiteConnection(dbPath);
                db.CreateTable<Users>();
                db.CreateTable<Address>();
        }
    }


        //  Insert the object to Users table
        //  ادخال مستخدم
        public void InsertUser(Users newUser)
        {
            var db = new SQLiteConnection(dbPath);
            db.Insert(newUser);
        }
        // تحديث مستخدم
        public void UpdateUser(Users user)
        {
            var db = new SQLiteConnection(dbPath);
            db.Update(user);
        }
        //=================================

        //   حذف مستخدم
        public void DeleteteUser(Users user)
        {
            var db = new SQLiteConnection(dbPath);
            db.Delete(user);
        }
        //=================================



        // CheckUsername method return true : if Username is not taken
        // true اذا كان اسم المستخدم غير مستخدم سابقا ارجع  
        public bool CheckUsername(string username)
        {
            var db = new SQLiteConnection(dbPath);
            Console.WriteLine("Reading data From Table");
            var table = db.Table<Users>();
            try
            {
                foreach (var s in table)
                {
                    if (string.Equals(s.Username, username))
                        return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        // Object ارجاع بيانات مستخدم واحد على شكل   
        public Users GetUser(string username, string password)
        {
            var db = new SQLiteConnection(dbPath);
            Console.WriteLine("Reading data From Table");
            var table = db.Table<Users>();
            try
            {
                foreach (var s in table)
                {
                    if (string.Equals(s.Username, username))
                        if (string.Equals(s.Password, password))
                            return s;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
        //=================================

        // ارجاع كل بيانات المستخدمين على شكل بيانات نصية 
        public string GetAllUser()
        {
            string data = "";
            var db = new SQLiteConnection(dbPath);
            Console.WriteLine("Reading data From Table");
            var table = db.Table<Users>();
            try
            {
                foreach (var s in table)
                    data += s.UId + "\t" + s.Username + "\t" + s.Password + "\t" + s.Mobile + "\n";
                return data;
            }
            catch
            {
                return "Empty";
            }
        }
        //=================================

        //  Insert the object to Users table
        //  ادخال مستخدم
        public void InsertAddress(Address newAddress)
        {
            var db = new SQLiteConnection(dbPath);
            db.Insert(newAddress);
        }
        // Object ارجاع بيانات مستخدم واحد على شكل   
        public Users GetUser(string username)
        {
            var db = new SQLiteConnection(dbPath);
            var table = db.Table<Users>();
            try
            {
                foreach (var s in table)
                {
                    if (string.Equals(s.Username, username))
                            return s;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
        //=================================     

        [Table("Users")]
        public class Users
        {
            [PrimaryKey, AutoIncrement, Column("_uid")]
            public int UId { get; set; }
            [MaxLength(10)]
            public string Username { get; set; }
            public string Password { get; set; }
            [MaxLength(12)]
            public string Mobile { get; set; }
        }

        [Table("Address")]
        public class Address
        {
            [PrimaryKey, AutoIncrement, Column("_aid")]
            public int AId { get; set; } 
            public string Username { get; set; }
            public string City { get; set; }
            public string HomeNu { get; set; }
        }
    }
}