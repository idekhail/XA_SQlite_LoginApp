using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content;
using Newtonsoft.Json;

namespace XA_SQlite_LoginApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class LoginActivity : AppCompatActivity
    {
        MySqliteDB sq;
        MySqliteDB.Users user;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            SetContentView(Resource.Layout.activity_login);

            EditText username = FindViewById<EditText>(Resource.Id.username);
            EditText password = FindViewById<EditText>(Resource.Id.password);

            Button login = FindViewById<Button>(Resource.Id.login);
            Button create = FindViewById<Button>(Resource.Id.create);
            Button close = FindViewById<Button>(Resource.Id.close);
            Button edit = FindViewById<Button>(Resource.Id.edit);

            sq = new MySqliteDB();

            login.Click += delegate
            {
                // Make sure your username and password are entered
                if (username.Text != "" && password.Text != "")
                {
                    user = sq.RetrieveUser(username.Text, password.Text);
                    if (user != null)
                    {
                        Intent i = new Intent(this, typeof(DisplayActivity));
                        i.PutExtra("user", JsonConvert.SerializeObject(user));
                        StartActivity(i);
                    }
                    else
                    {
                        Toast.MakeText(this, " UserName or Password is wrong", ToastLength.Short).Show();
                    }
                }
                else
                {
                    Toast.MakeText(this, " Enter your UserName ...... ", ToastLength.Short).Show();
                }
            };

            edit.Click += delegate
            {
                // Make sure your username and password are entered
                if (username.Text != "" && password.Text != "")
                {
                    user = sq.RetrieveUser(username.Text, password.Text);
                    if (user != null)
                    {
                        Intent i = new Intent(this, typeof(EditActivity));
                        i.PutExtra("user", JsonConvert.SerializeObject(user));
                        StartActivity(i);
                    }
                    else
                    {
                        Toast.MakeText(this, " UserName or Password is wrong", ToastLength.Short).Show();
                    }
                }
                else
                {
                    Toast.MakeText(this, " Enter your UserName ...... ", ToastLength.Short).Show();
                }

            };

            create.Click += delegate
            {
                Intent i = new Intent(this, typeof(RegActivity));
                StartActivity(i);

            };

            close.Click += delegate
            {
                System.Environment.Exit(0);
            };

        }
    }
}