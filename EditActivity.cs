using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
namespace XA_SQlite_LoginApp
{
    [Activity(Label = "EditActivity")]
    public class EditActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_edit);

            TextView id = FindViewById<TextView>(Resource.Id.id);
            TextView username = FindViewById<TextView>(Resource.Id.username);

            EditText password = FindViewById<EditText>(Resource.Id.password);
            EditText mobile = FindViewById<EditText>(Resource.Id.mobile);
            EditText email = FindViewById<EditText>(Resource.Id.email);

            Button update = FindViewById<Button>(Resource.Id.update);
            Button delete = FindViewById<Button>(Resource.Id.delete);
            Button cancel = FindViewById<Button>(Resource.Id.cancel);


            MySqliteDB sq = new MySqliteDB();
            MySqliteDB.Users user = new MySqliteDB.Users();
            user = JsonConvert.DeserializeObject<MySqliteDB.Users>(Intent.GetStringExtra("user"));

            id.Text = user.UId.ToString();
            username.Text = user.Username;
            password.Text = user.Password;
            mobile.Text = user.Mobile;
            email.Text = user.Email;


            update.Click += delegate
            {
                if (username.Text != "" && password.Text != "")
                {
                    if (user != null)
                    {
                        user.Password = password.Text;
                        user.Mobile = mobile.Text;
                        user.Email = email.Text;

                        sq.UpdateUser(user);
                        Intent i = new Intent(this, typeof(LoginActivity));
                        StartActivity(i);
                    }
                    else
                        Toast.MakeText(this, " user is null", ToastLength.Short).Show();
                }
                else
                    Toast.MakeText(this, " Username or Password is Empty!!!!", ToastLength.Short).Show();
            };
                
            delete.Click += delegate
            {
                if (id.Text != "")
                {
                    if (user != null)
                    {
                        sq.DeleteteUser(user);
                        Intent i = new Intent(this, typeof(LoginActivity));
                        StartActivity(i);
                    }
                    else
                        Toast.MakeText(this, " user is null ", ToastLength.Short).Show();
                }
                else
                    Toast.MakeText(this, " Id is not found !!!", ToastLength.Short).Show();
            };

            cancel.Click += delegate
            {
                Intent i = new Intent(this, typeof(LoginActivity));
                StartActivity(i);
            };            
        }
    }
}