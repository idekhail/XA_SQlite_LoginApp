using System;
using System.IO;
using Android.Support.V7.App;
using SQLite;
namespace XA_SQlite_LoginApp {
    // هذه الكلاس خاصة لربط قاعدة البيانات بالتطبيق 
    class MySqliteDB
    {
        //database path مسار قاعدة البيانات
        private readonly string dbPath = Path.Combine(
                Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "MyDB.db3");
        public MySqliteDB()
        {
            //Creating database, if it doesn't already exist 
            // اذا قاعدة البيانات غبر موجودة يتم إنشائها
            if (!File.Exists(dbPath))
            {  // يتم إنشاء اتصال الى قاعدة البيانات 
                var db = new SQLiteConnection(dbPath);
                // يتم إنشاء جدول في قاعدة البيانات
                db.CreateTable<Users>();
            }
        }
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
        //  Insert the object to Users table
        //  ادخال مستخدم
        public void InsertUser(Users newUser)
        {
            var db = new SQLiteConnection(dbPath);
            db.Insert(newUser);
        }
        // Object ارجاع بيانات مستخدم واحد على شكل   
        public Users RetrieveUser(string username, string password)
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
        public string RetrieveAllUser()
        {
            string data = "";
            var db = new SQLiteConnection(dbPath);
            Console.WriteLine("Reading data From Table");
            var table = db.Table<Users>();
            try
            {
                foreach (var s in table)
                    data += s.UId+ "\t" + s.Username + "\t" + s.Password + "\t" + s.Mobile + "\t" + s.Email + "\n";
                return data;
            }
            catch
            {
                return "Empty";
            }
        }
        //=================================
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
        [Table("Users")]
        public class Users
        {
            [PrimaryKey, AutoIncrement, Column("_uid")]
            public int UId { get; set; }
            [MaxLength(10)]
            public string Username { get; set; }
            [MaxLength(12)]
            public string Password { get; set; }
            public string Mobile { get; set; }
            public string Email { get; set; }
        }
    }
}