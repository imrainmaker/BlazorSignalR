using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;

namespace BlazorDemo.Client.Pages.Demo.Demo7
{
    public partial class Demo7
    {
        public List<Message> MessageList{ get; set; } = new List<Message>();


        public HubConnection MyHub { get; set; }

        protected override async Task OnInitializedAsync()
        {
            MyHub = new HubConnectionBuilder()
                .WithUrl(new Uri("https://localhost:7275/chathub")).Build();

            MyHub.On<string, string>("newMessage", (user, message) =>
            {
                MessageList.Add(new Message
                {
                    user = user,
                    message = message
                });

                StateHasChanged();
            });

            await MyHub.StartAsync();
        }

        public string User { get; set; }
        public string Message { get; set; }
        public async Task Send()
        {
            await MyHub.SendAsync("SendMessage", User, Message);
        }
    }

    public class Message
    {
        public string user { get; set; }
        public string message { get; set; }
    }
}
