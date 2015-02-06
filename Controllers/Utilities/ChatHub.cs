using System.Net.Http;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FrontendCore
{
    [HubName("chathub")]
    public class ChatHub : Hub
    {
        /// <summary>
        /// <string,string> name ,connectionId
        /// </summary>
        static Dictionary<string, string> UserList { get; set; }

        public ChatHub()
        {

            if (UserList == null)
            {
                UserList = new Dictionary<string, string>();
            }
        }

        public void UserConnected(string name)   
        {
            name = HttpUtility.HtmlEncode(name);

            if (!UserList.ContainsKey(Context.ConnectionId))
            {
                UserList.Add(Context.ConnectionId, name);

                Clients.Others.addList(Context.ConnectionId, name);

                Clients.Caller.getList(UserList.Select(p => new { id = p.Key, name = p.Value }).ToList());

            }

        }


        public override Task OnDisconnected(bool stopCalled)
        {
            Clients.All.removeList(Context.ConnectionId);

            UserList.Remove(Context.ConnectionId);

            return base.OnDisconnected(stopCalled);
        }

        public Dictionary<string, string> GetUserList()
        {
            return UserList;
        }


        public void SendAll(string message)
        {
            var sender = UserList[Context.ConnectionId];
            //所有连接的客户端
            Clients.All.broadcastMessage(sender, message);

        }

        public void SendUser(string[] connectionIds, string message)
        {
            var sender = UserList[Context.ConnectionId];
            Clients.Clients(connectionIds.ToList()).broadcastUserMessage(sender,message);
        }

        public void SendGroup(string[] groupName, string message)
        {
            var sender = UserList[Context.ConnectionId];
            Clients.Groups(groupName.ToList()).broadcastGroupMessage(sender, message);
        }

        public Task JoinGroup(string groupName)
        {
            return Groups.Add(Context.ConnectionId, groupName);
        }

        public Task LeaveGroup(string groupName)
        {
            return Groups.Remove(Context.ConnectionId, groupName);
        }

    }
}
