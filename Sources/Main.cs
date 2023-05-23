using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using PusherClient;
using PusherClient.Tests.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iReverse_Pusher_Realtime
{
    public partial class Main : Form
    {
        public static Main DelegateFunction;

        public static Pusher _pusher;
        public static Channel _publicChannel;
        public static Channel _privateChannel;
        public static Channel _privateEncryptedChannel;
        private static GenericPresenceChannel<ChatMember> _presenceChannel;

        WebClient wc = new WebClient();
        NameValueCollection dataToSend = new NameValueCollection();


        public Main()
        {
            DelegateFunction = this;
            InitializeComponent();

            var connectResult = Task.Run(() => InitPusher());
            Task.WaitAll(connectResult);

            // Read input in loop to keep the program running
            string line;
            do
            {
                line = Console.ReadLine();

                if (line == "quit")
                {
                    break;
                }
            } while (line != null);

            //var disconnectResult = Task.Run(() => _pusher.DisconnectAsync());
            //Task.WaitAll(disconnectResult);

        }

        private static async Task InitPusher()
        {
            _pusher = new Pusher(Config.AppKey, new PusherOptions
            {
                ChannelAuthorizer = new HttpChannelAuthorizer("http://localhost/pusher/auth.php"),
                Cluster = Config.Cluster,
                Encrypted = Config.Encrypted,
                TraceLogger = new TraceLogger(),
            });
            _pusher.ConnectionStateChanged += PusherConnectionStateChanged;
            _pusher.Error += PusherError;
            _pusher.Subscribed += Subscribed;
            _pusher.CountHandler += CountHandler;
            _pusher.Connected += Connected;
            _pusher.BindAll(GeneralListener);

            //_pusher.User.Signin();
            //_pusher.User.Bind(OnUserEvent);
            //_pusher.User.Bind("test_event", OnBlahUserEvent);
            //_pusher.User.Watchlist.Bind("online", OnWatchlistOnlineEvent);
            //_pusher.User.Watchlist.Bind("offline", OnWatchlistOfflineEvent);
            //_pusher.User.Watchlist.Bind(OnWatchlistEvent);

            try
            {
                _publicChannel = await _pusher.SubscribeAsync("my-channel");
                _publicChannel.BindAll(ChannelEvent);

                _privateChannel = await _pusher.SubscribeAsync("private-channel");
                _privateChannel.BindAll(ChannelEvent);

                //_presenceChannel = await _pusher.SubscribePresenceAsync<ChatMember>("presence-channel");
                //_presenceChannel.BindAll(ChannelEvent);
                //_presenceChannel.MemberAdded += PresenceChannel_MemberAdded;
                //_presenceChannel.MemberRemoved += PresenceChannel_MemberRemoved;

                //_privateEncryptedChannel = await _pusher.SubscribeAsync("private-encrypted-channel");
                //_privateEncryptedChannel.BindAll(ChannelEvent);

            }
            catch (ChannelUnauthorizedException unauthorizedException)
            {
                Console.WriteLine($"Authorization failed for {unauthorizedException.ChannelName}. {unauthorizedException.Message}");
            }

            Console.WriteLine("All SubscribeAsync already called");

            await _pusher.ConnectAsync().ConfigureAwait(false);

            //await _pusher.User.SigninDoneAsync();


            //await Task.Delay(10000).ConfigureAwait(false);
            //Console.WriteLine($"Test Disconnect & Connect");
            //await _pusher.DisconnectAsync().ConfigureAwait(false);
            //await Task.Delay(2000).ConfigureAwait(false);
            //await _pusher.ConnectAsync().ConfigureAwait(false);
            //await _pusher.User.SigninDoneAsync();
        }

        static void ListMembers()
        {
            if (_presenceChannel != null)
            {
                StringBuilder builder = new StringBuilder($"{Environment.NewLine}[MEMBERS]{Environment.NewLine}");
                int count = 1;
                var sorted = _presenceChannel.GetMembers().Select(m => m).OrderBy(m => m.Value.Name);
                foreach (var member in sorted)
                {
                    builder.AppendLine($"{count}: {member.Value.Name}");
                    count++;
                }

                Console.WriteLine(builder.ToString());
            }
        }

        // Pusher Initiation / Connection

        // Setup private encrypted channel
        static void GeneralListener(string eventName, PusherEvent eventData)
        {
            Console.WriteLine($"{Environment.NewLine} GeneralListner {eventName} {eventData.Data}");

            if (eventName == DelegateFunction.textBox_eventme.Text)
            {
                dynamic data = JObject.Parse(eventData.Data);
                DelegateFunction.RtbMsg("Received : [Time : " + data.datetime + "]\nFrom Channel : " + data.From_channel + " Event : " + data.From_event + "\n\n" + data.Message, Color.Black, false, true, false);
            }
        }

        static void Connected(object sender)
        {
            Console.WriteLine($"Connected");
        }

        static void Subscribed(object sender, Channel channel)
        {
            Console.WriteLine($"Subscribed To Channel {channel.Name}");
        }

        static void CountHandler(object sender, string data)
        {
            Console.WriteLine($"CountHandler {data}");
        }

        static void OnBlahUserEvent(UserEvent userEvent)
        {
            Console.WriteLine($"{Environment.NewLine} OnBlahUserEvent {userEvent}");
        }

        static void OnUserEvent(string eventName, UserEvent userEvent)
        {
            Console.WriteLine($"{Environment.NewLine} UserEvent {eventName} {userEvent}");
        }

        static void OnWatchlistEvent(string eventName, WatchlistEvent watchlistEvent)
        {
            Console.WriteLine($"{Environment.NewLine} OnWatchlistEvent {eventName} {watchlistEvent.Name}");
            foreach (var id in watchlistEvent.UserIDs)
            {
                Console.WriteLine($"{Environment.NewLine} OnWatchlistEvent {eventName} {watchlistEvent.Name} {id}");
            }
        }
        static void OnWatchlistOnlineEvent(WatchlistEvent watchlistEvent)
        {
            Console.WriteLine($"{Environment.NewLine} OnWatchlistOnlineEvent {watchlistEvent}");
        }
        static void OnWatchlistOfflineEvent(WatchlistEvent watchlistEvent)
        {
            Console.WriteLine($"{Environment.NewLine} OnWatchlistOfflineEvent {watchlistEvent}");
        }


        static void ChannelEvent(string eventName, PusherEvent eventData)
        {
            Console.WriteLine($"{Environment.NewLine}{eventName} {eventData.Data}");
        }

        static void PusherError(object sender, PusherException error)
        {
            TraceMessage(sender, $"{Environment.NewLine}Pusher Error: {error.Message}{Environment.NewLine}{error}");
        }

        static void PusherConnectionStateChanged(object sender, ConnectionState state)
        {
            TraceMessage(sender, $"Connection state: {state}");
        }

        static void PresenceChannel_MemberRemoved(object sender, KeyValuePair<string, ChatMember> member)
        {
            Console.WriteLine($"Member {member.Value.Name} has left");
            ListMembers();
        }

        static void PresenceChannel_MemberAdded(object sender, KeyValuePair<string, ChatMember> member)
        {
            Console.WriteLine($"Member {member.Value.Name} has joined");
            ListMembers();
        }

        static void TraceMessage(object sender, string message)
        {
            Pusher client = sender as Pusher;
            Console.WriteLine($"{DateTime.Now:o} - {client.SocketID} - {message}");
        }

        public void RtbMsg_Clear()
        {
            richTextBox_messages.Invoke(new Action(() => { richTextBox_messages.Clear(); }));
        }
        
        public void RtbWriteMgs_Clear()
        {
            richTextBox_write_messages.Invoke(new Action(() => { richTextBox_write_messages.Clear(); }));
        }

        public void RtbMsg(string msg, Color colour, bool isBold, bool NextLine = false, bool Right = false)
        {
            richTextBox_messages.Invoke(new Action(() =>
            {
                richTextBox_messages.SelectionStart = richTextBox_messages.Text.Length;
                var selectionColor = richTextBox_messages.SelectionColor;
                richTextBox_messages.SelectionColor = colour;
                if (isBold)
                {
                    richTextBox_messages.SelectionFont = new Font(richTextBox_messages.Font, FontStyle.Bold);
                }
                else
                {
                    richTextBox_messages.SelectionFont = new Font(richTextBox_messages.Font, FontStyle.Regular);
                }
                if (Right)
                {
                    richTextBox_messages.SelectionAlignment = HorizontalAlignment.Right;
                }
                else
                {
                    richTextBox_messages.SelectionAlignment = HorizontalAlignment.Left;
                }
                richTextBox_messages.AppendText(msg);
                richTextBox_messages.SelectionColor = selectionColor;
                if (NextLine)
                {
                    if (richTextBox_messages.TextLength > 0)
                    {
                        richTextBox_messages.AppendText(Environment.NewLine);
                    }
                }
            }));
        }

        private void button_send_Click(object sender, EventArgs e)
        {
            // Trigger event
            Channel channel = _pusher.GetChannel("private-channel");
            string client = "";
            if (!textBox_evento.Text.Contains("client-"))
            {
                client = textBox_evento.Text;

                MessageBox.Show("Event To harus diawali dengan client-", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                textBox_evento.Text = "client-" + client;
            }

            // Get all data

            DateTime currentDateTime = DateTime.Now;
            string formattedDateTime = currentDateTime.ToString("dd-MMMM-yyyy HH:mm:ss");

            var myData = new
            {
                datetime = formattedDateTime,
                From_channel = "private-channel",
                From_event = DelegateFunction.textBox_eventme.Text,
                Message = DelegateFunction.richTextBox_write_messages.Text
            };

            // Tranform it to Json object
            string jsonData = JsonConvert.SerializeObject(myData);
            channel.Trigger(textBox_evento.Text, jsonData);
            dynamic data = JObject.Parse(jsonData);
            DelegateFunction.RtbMsg("Received : [Time : " + data.datetime + "]\nFrom Channel : " + data.From_channel + " Event : " + data.From_event + "\n\n" + data.Message, Color.Black, false, true, true);
            RtbWriteMgs_Clear();
        }
    }
}
