using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Newtonsoft.Json;

using System;
using System.Collections.Generic;

using Xamarin.Essentials;

namespace XA_SQlite_LoginApp
{
    [Activity(Label = "DisplayActivity")]
    public class DisplayActivity : Activity
    {        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_display);
            TextView show = FindViewById<TextView>(Resource.Id.show);

            Button logout = FindViewById<Button>(Resource.Id.logout);
            Button allUsers = FindViewById<Button>(Resource.Id.allUsers);
            Button call = FindViewById<Button>(Resource.Id.call);
            Button sendemail = FindViewById<Button>(Resource.Id.sendemail);

            MySqliteDB sq = new MySqliteDB();
            MySqliteDB.Users user = new MySqliteDB.Users();
            user = JsonConvert.DeserializeObject<MySqliteDB.Users>(Intent.GetStringExtra("user"));

            try {
                show.Text = user.UId + "\t\t\t" + user.Username + "\t\t\t" + user.Password + "\t\t\t" + user.Mobile + "\t\t\t" + user.Email;
            }catch(Exception e) {
                show.Text = e.Message;
            }      
            
            allUsers.Click += delegate {
                try {
                    show.Text = sq.RetrieveAllUser();
                } catch (Exception e) {
                    show.Text = e.Message;
                }
            }; 

            call.Click += delegate {
                var url = Android.Net.Uri.Parse("tel:" + user.Mobile);
                var intent = new Intent(Intent.ActionDial, url);
                StartActivity(intent);
            };      

            logout.Click += delegate {
                Intent i = new Intent(this, typeof(LoginActivity));
                StartActivity(i);
            };

            sendemail.Click += delegate
            {
                var email = new Intent(Android.Content.Intent.ActionSend);
                email.PutExtra(Android.Content.Intent.ExtraEmail, new string[] {
                    user.Email,
                    "idekhail@tvtc.gov.sa"
                });
                //email.PutExtra(Android.Content.Intent.ExtraCc, new string[] {
                //    "Your Email from db"
                //});
                email.PutExtra(Android.Content.Intent.ExtraSubject, "Midterm2");
                email.PutExtra(Android.Content.Intent.ExtraText, "Final Lab Exam for Email Xamarin!");
                email.SetType("message/rfc822");
                StartActivity(email);
            };
        }
    }
}