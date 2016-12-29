using OpenPop.Mime;
using OpenPop.Pop3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utility
{
    public class MailHelper
    {
        private string _popAddress;
        private string _user;
        private string _password;

        public MailHelper(string popAddress, string user, string password)
        {
            _popAddress = popAddress;
            _user = user;
            _password = password;
        }

        public List<MailModel> GetMailList()
        {
            using (Pop3Client client = new Pop3Client())
            {
                if (client.Connected)
                {
                    client.Disconnect();
                }

                // Connect to the server, false means don't use ssl
                client.Connect(_popAddress, 110, false);

                // Authenticate ourselves towards the server by email account and password
                client.Authenticate(_user, _password);

                //email count
                int messageCount = client.GetMessageCount();

                List<MailModel> result = new List<MailModel>();
                //i = 1 is the first email; 1 is the oldest email
                for (int i = 1; i <= messageCount; i++)
                {
                    OpenPop.Mime.Message message = client.GetMessage(i);

                    MailModel t = new MailModel();
                    t.Sender = message.Headers.From.DisplayName;
                    t.FromMail = message.Headers.From.Address;
                    t.Subject = message.Headers.Subject;
                    t.SendTime = message.Headers.DateSent;

                    MessagePart messagePart = message.MessagePart;

                    if (messagePart.IsText)
                    {
                        t.Body = messagePart.GetBodyAsText();
                    }
                    else if (messagePart.IsMultiPart)
                    {
                        MessagePart plainTextPart = message.FindFirstPlainTextVersion();
                        if (plainTextPart != null)
                        {
                            // The message had a text/plain version - show that one
                            t.Body = plainTextPart.GetBodyAsText();
                        }
                        else
                        {
                            // Try to find a body to show in some of the other text versions
                            List<MessagePart> textVersions = message.FindAllTextVersions();
                            if (textVersions.Count >= 1)
                                t.Body = textVersions[0].GetBodyAsText();
                            else
                                t.Body = "<<OpenPop>> Cannot find a text version body in this message.";
                        }
                    }

                    result.Add(t);
                }

                return result;
            }
        }
    }
}
