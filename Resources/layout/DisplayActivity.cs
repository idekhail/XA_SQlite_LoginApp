using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Newtonsoft.Json;

using System;
using System.Collections.Generic;

namespace XA_SQlite_LoginApp
{
    [Activity(Label = "ScreenActivity")]
    public class DisplayActivity : Activity
    {
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_display);
            TextView show = FindViewById<TextView>(Resource.Id.show);
            Button back = FindViewById<Button>(Resource.Id.back);
            Button allUsers = FindViewById<Button>(Resource.Id.allUsers);
            Button call = FindViewById<Button>(Resource.Id.call);

            MySqliteDB sq = new MySqliteDB();
            MySqliteDB.Users user = new MySqliteDB.Users();
            user = JsonConvert.DeserializeObject<MySqliteDB.Users>(Intent.GetStringExtra("user"));
            var address = sq.GetAddress(user.Username);

            try {
                show.Text = user.UId + "\t\t\t" + user.Username + "\t\t\t" + user.Password + "\t\t\t" + user.Mobile
                     + "\t\t\t" + address.City + "\t\t\t" + address.HomeNu;
            }catch(Exception e) {
                show.Text = e.Message;
            }                
            allUsers.Click += delegate {
                try {
                    show.Text = sq.GetAllUser();
                } catch (Exception e) {
                    show.Text = e.Message;
                }
            }; 
            call.Click += delegate {
                var url = Android.Net.Uri.Parse("tel:" + user.Mobile);
                var intent = new Intent(Intent.ActionDial, url);
                StartActivity(intent);
            };      
            back.Click += delegate {
                Intent i = new Intent(this, typeof(LoginActivity));
                StartActivity(i);
            };

        }
    }
}