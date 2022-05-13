using NUnit.Framework;
using NoMoreYoyo.Helpers;

namespace NoMoreYoyoUnitTests
{
    public class EncryptionTests
    {
        [Test]
        public void TestWhenPasswordsAndSaltAreEqual()
        {
            string password = "alma";
            string salt = Encryption.SaltPassword(password);
            string hashedPassword = Encryption.GenerateHashWithSalt(password, salt);
            Assert.AreEqual(Encryption.GenerateHashWithSalt(password,salt), hashedPassword);
        }

        [Test]
        public void TestWhenPasswordsAreEqualAndSaltIsDifferent()
        {
            string password1 = "alma";
            string password2 = "alma";
            string salt1 = Encryption.SaltPassword(password1);
            string salt2 = Encryption.SaltPassword(password2);
            string hashedPassword1 = Encryption.GenerateHashWithSalt(password1, salt1);
            string hashedPassword2 = Encryption.GenerateHashWithSalt(password2, salt2);
            Assert.AreNotEqual(hashedPassword1,hashedPassword2);
        }

        [Test]
        public void TestWhenPasswordsAreNotEqual()
        {
            string password1 = "alma";
            string password2 = "";
            string salt1 = Encryption.SaltPassword(password1);
            string salt2 = Encryption.SaltPassword(password2);
            string hashedPassword1 = Encryption.GenerateHashWithSalt(password1, salt1);
            string hashedPassword2 = Encryption.GenerateHashWithSalt(password2, salt2);
            Assert.AreNotEqual(hashedPassword1, hashedPassword2);
        }
    }
}
