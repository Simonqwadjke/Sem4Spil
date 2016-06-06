using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using ModelLayer;
using System;
using System.Globalization;
using System.Net.Mail;

public class SignUp : MonoBehaviour {

    public InputField FirstName;
    public InputField Email;

    public Dropdown Day;
    public Dropdown Month;
    public Dropdown Year;

    public InputField Username;
    public InputField Password;
    public InputField RePass;

    public Text OutPut;

    // Use this for initialization
    void Start() {

    }

    public bool ValidEmail(string emailaddress) {
        try {
            MailAddress m = new MailAddress(emailaddress);
            return true;
        }
        catch (FormatException) {
            return false;
        }
    }

    public void SignUpClick() {
        bool valid = true;
        if (FirstName.text == "") {
            valid = false;
            OutPut.text = "Please enter a first name.";
        }
        else if (Email.text == "") {
            valid = false;
            OutPut.text = "Please enter an email";
        }
        else if (ValidEmail(Email.text)) {
            valid = false;
            OutPut.text = "Please enter a valid email.";
        }
        else if (Username.text == "") {
            valid = false;
            OutPut.text = "Please enter a username.";
        }
        else if (Password.text == "") {
            valid = false;
            OutPut.text = "Please enter a password.";
        }
        else if (RePass.text == "") {
            valid = false;
            OutPut.text = "Please re-enter the password.";
        }
        else if (!Password.text.Equals(RePass.text)) {
            valid = false;
            OutPut.text = "Pasword does not match";
        }

        if (valid) {
            User user = new User() {
                Name = FirstName.text,
                Email = Email.text,
                BirthDate = new DateTime(Convert.ToInt32(Year.captionText.text),
                                         DateTime.ParseExact(Month.captionText.text, "MMMM", CultureInfo.CurrentCulture).Month,
                                         Convert.ToInt32(Day.captionText.text)),
                Username = Username.text,
            };
        }
    }
}
