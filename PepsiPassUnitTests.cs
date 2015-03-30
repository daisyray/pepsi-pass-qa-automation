using NUnit.Framework;
using System;
using Xamarin.UITest;
using Xamarin.UITest.Android;
using Xamarin.UITest.Queries;

namespace myFirstTest
{
	[TestFixture]
	public class Test
	{
		private string path = "/Users/daisyray/Downloads/app-debug.apk";
		private AndroidApp app;
		private TimeSpan time_out = TimeSpan.FromSeconds(10);

		[SetUp]
		public void Setup()
		{
			app = ConfigureApp.Android.ApkFile (path).StartApp ();
		}
			
		[TearDown]
		public void tearDown()
		{
			app.Invoke ("Finish");	
		}
	
		[Test]
		public void more_music_textview_is_present() {
			var more_music_textview = app.Query(e =>e.Id("more_music_textview"));
			Assert.IsNotNull (more_music_textview);
		}

		//[Test]
		public void sign_in_with_facebook_button_is_present() {
			var authButton = app.Query (e => e.Id ("authButton"));
			Assert.IsNotNull (authButton);
		}
		 
		//[Test]
		public void sign_in_with_email_text_is_present() {
			var signInText = app.Query (e => e.Id ("email_signin_textview"));
			Assert.IsNotNull (signInText);
		}
	
		//[Test]
		public void verifying_create_new_account_button() {
			var facebook_sign_is_present = app.Query (e => e.Id ("authButton"));
			Assert.IsNotNull (facebook_sign_is_present);
			app.Tap (e => e.Marked ("authButton"));
			app.WaitForElement (x => x.Css ("button[name=login]"), timeout: time_out);
			app.Tap (e => e.Css ("button[name=login]"));
			app.WaitForElement (e => e.Css ("a"), timeout: time_out);
			app.Tap(e => e.XPath("(//SPAN)[6]")); 
			//Tree doesn't show any element.
		} 
		//[Test]
		public void tos_text_is_not_null ()
		{ 
			var tosElement = app.Query (e => e.Id ("tos_textview"));
			Assert.IsNotNull (tosElement);
		}
		//[Test]
		public void and_text_is_present() {
			var authButton = app.Query (e => e.Id ("and_textview"));
			Assert.IsNotNull (authButton);
		}
		//[Test]
		public void privacy_policy_text_is_present() {
			var privacyElement = app.Query (e => e.Id ("privacy_textview"));
			Assert.IsNotNull (privacyElement);
		}
		
		//[Test]
		public void login_with_facebook_with_wrong_email_shows_forgot_password() {
			app.Tap (e => e.Id ("authButton"));
			app.WaitForElement (e => e.Css ("input[name=email]"), timeout: time_out);

			app.EnterText(e => e.Css("input[name=email]"), "divyadonna@yahoo.com");
			app.EnterText(e => e.Css("input[name=pass]"), "apple1234");
			app.Tap (e => e.Css ("button[name=login]"));
			app.WaitForElement (e => e.Css ("a"), timeout: time_out);

			var name = app.Query(e=>e.Css("a"))[1].TextContent;
			Assert.AreEqual (name, "Forgot password?");
		
		}

		//[Test]
		public void login_with_facebook_valid_email_password() {
			app.Tap (e => e.Id ("authButton"));
			app.WaitForElement (e => e.Css ("input[name=email]"), timeout: time_out);

			app.EnterText (e => e.Css ("input[name=email]"), "divyadonna@yahoo.com");
			app.EnterText (e => e.Css ("input[name=pass]"), "apple123");
			app.Tap (e => e.Css ("button[name=login]"));
			app.WaitForElement (e => e.Css ("a"), timeout: time_out);

			app.Tap (e => e.Css ("button[value=OK]"));
			app.WaitForElement (e => e.Id ("zip_code"), timeout: time_out);
			Assert.IsNotNull (app.Query(e => e.Id ("zip_code")));
		}

		//[Test]
		public void enter_zip_code_after_login_works() {
			
			login_with_facebook_valid_email_password ();
			var zip_code_tab = app.Query (e => e.Id ("zip_code"));
			Assert.IsNotNull (zip_code_tab);
			app.Tap (e => e.Id ("zip_code"));
			app.EnterText(e => e.Id("zip_code"),"11234"); 

			app.Tap(e=>e.Id("agree_checkbox")); 
			Assert.IsNotNull(app.Query(e => e.Marked("send_newsletter")));
			app.Tap (e => e.Id ("next_button"));
			app.WaitForElement (e => e.Id ("next_button"));
		}

		//[Test]
		public void who_referred_you_page_verification() {
			app.Query (e => e.Marked ("next_button"));
			Assert.IsNotNull (app.Query (e => e.Marked ("next_button")));
			app.Tap (e => e.Marked ("next_button"));
			app.WaitForElement (e => e.Marked ("next_button"), timeout: time_out);
		}

		//[Test]
		public void hang_with_pepsi_pass_friends_get_points_page_verifiction() {
			app.Query (e => e.Marked ("next_button"));
			Assert.IsNotNull (app.Query (e => e.Marked ("next_button")));
			app.Tap (e => e.Marked ("next_button"));
			app.WaitForElement (e => e.Marked ("next_button"), timeout: time_out);
				}

		//[Test]
		public void use_your_camera_to_capture_pepsi_codes_rack_up_points_page_verifiction() {
			app.Query (e => e.Marked ("next_button"));
			Assert.IsNotNull (app.Query (e => e.Marked ("next_button")));
			app.Tap (e => e.Marked ("next_button"));
			app.WaitForElement (e=>e.Marked("next_button"), timeout: time_out);
		}
		//[Test]
		public void use_points_toward_ultimate_experience_awesome_reward_page_verifiction() {
			app.Query (e => e.Marked ("next_button"));
			Assert.IsNotNull (app.Query (e => e.Marked ("next_button")));
			app.Tap (e => e.Marked ("next_button"));
			app.WaitForElement (e => e.Marked ("next_button"), timeout: time_out);		
		}
	 
		//[Test]
		public void capture_code_page_verification() {
			Assert.IsNotNull(app.Query(e=>e.Marked("action_indicator")));
			Assert.IsNotNull (app.Query(e => e.Marked ("points_container")));
			Assert.IsNotNull(app.Query(e => e.Marked ("camera_button")));
			Assert.IsNotNull (app.Query(e => e.Marked ("trophy_button")));
			Assert.IsNotNull (app.Query(e => e.Marked ("close_button")));					
			app.Tap (e => e.Marked ("close_button"));
			app.WaitForElement(e=>e.Marked("points_container"), timeout:time_out);
		}
		
		//[Test]
		public void points_icon_verification() {
			enter_zip_code_after_login_works ();
			who_referred_you_page_verification ();
			hang_with_pepsi_pass_friends_get_points_page_verifiction ();
			use_your_camera_to_capture_pepsi_codes_rack_up_points_page_verifiction ();
			use_points_toward_ultimate_experience_awesome_reward_page_verifiction ();
			capture_code_page_verification ();

			Func <AppQuery,AppQuery> func = e => e.Marked ("points_container");
			Assert.IsNotNull(app.Query(func));

			app.Tap (func);
			app.WaitForElement (e => e.Marked("record_title"), timeout:time_out);
			app.Tap (e => e.Marked ("feed_back"));
			app.WaitForElement (e => e.Marked("record_title"), timeout:time_out);
			Assert.IsNotNull(app.Query(func));

		}
	   //[Test]
		public void opens_repl() {
			app.Repl ();	
		}
	}
}
	




