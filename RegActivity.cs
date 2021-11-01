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

namespace XA_SQlite_LoginApp
{
    [Activity(Label = "RegActivity")]
    public class RegActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_reg);
            EditText username = FindViewById<EditText>(Resource.Id.username);
            EditText password = FindViewById<EditText>(Resource.Id.password);
            EditText mobile = FindViewById<EditText>(Resource.Id.mobile);
            EditText email = FindViewById<EditText>(Resource.Id.email);


            Button add = FindViewById<Button>(Resource.Id.add);
            Button cancel = FindViewById<Button>(Resource.Id.cancel);

            MySqliteDB sq = new MySqliteDB();
            add.Click += delegate
            {
                if (username.Text != "" && password.Text != "")
                {
                    if (!sq.CheckUsername(username.Text))
                    {
                        MySqliteDB.Users newUser = new MySqliteDB.Users();
                        newUser.Username = username.Text;
                        newUser.Password = password.Text;
                        newUser.Mobile = mobile.Text;
                        newUser.Email = email.Text;

                        sq.InsertUser(newUser);
                        Intent i = new Intent(this, typeof(LoginActivity));
                        StartActivity(i);
                    }
                    else
                    {
                        Toast.MakeText(this, " UserName is found", ToastLength.Short).Show();
                    }
                }
                else
                {
                    Toast.MakeText(this, " UserName or Password is empty", ToastLength.Short).Show();
                }
            };

            cancel.Click += delegate
            {
                Intent i = new Intent(this, typeof(LoginActivity));
                StartActivity(i);
            };



        }
    }
}