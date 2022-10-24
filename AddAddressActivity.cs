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
    [Activity(Label = "AddAddressActivity")]
    public class AddAddressActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_addAddress);
            EditText username = FindViewById<EditText>(Resource.Id.username);
            EditText city = FindViewById<EditText>(Resource.Id.city);
            EditText homeNu = FindViewById<EditText>(Resource.Id.homeNu);

            Button add = FindViewById<Button>(Resource.Id.add);
            Button cancel = FindViewById<Button>(Resource.Id.cancel);

            MySqliteDB sq = new MySqliteDB();
            add.Click += delegate
            {
                if (!string.IsNullOrEmpty(username.Text))
                {
                    var user = sq.GetUser(username.Text);
                    if (user != null)
                    {
                        MySqliteDB.Address newAddress = new MySqliteDB.Address() {
                            Username = username.Text,
                            City     = city.Text,
                            HomeNu   = homeNu.Text
                        };
                        sq.InsertAddress(newAddress);
                        Intent i = new Intent(this, typeof(LoginActivity));
                        StartActivity(i);
                    }
                    else
                    {
                        Toast.MakeText(this, " UserName is not found", ToastLength.Short).Show();
                    }
                }
                else
                {
                    Toast.MakeText(this, " UserName is empty", ToastLength.Short).Show();
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